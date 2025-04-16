using System.Text;
using System.Text.Json;
using AutoMapper;
using QuesGenie.Application.GenerateQuestions.Dtos;
using QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.Services.SyncCommunication;

public class QuestionHttpClient(HttpClient httpClient,IUnitOfWork unitOfWork,
    IMapper mapper):IQuestionHttpClient
{
    public async Task GenerateQuestion(QuestionRequestDto dto)
    {
        var questionSets = await FetchGeneratedQuestionsAsync(dto);
        var questionSetEntities = MapToEntities(dto.submissionId, questionSets);
        await PersistQuestionSets(questionSetEntities);
    }
    
    private async Task<GenerateQuestionsDto> FetchGeneratedQuestionsAsync(QuestionRequestDto dto)
    {
        var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("http://20.151.232.233/question-generation", content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to fetch questions: {response.StatusCode} - {error}");
        }

        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GenerateQuestionsDto>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (result == null)
            throw new Exception("Empty result from question generator.");

        return result;
    }
    
    private IEnumerable<QuestionsSets> MapToEntities(string submissionId,GenerateQuestionsDto gq)
    {
        List<QuestionsSets> questionSets = new List<QuestionsSets>();
        foreach (var dto in gq.questionSets)
        {
            var questionSet = new QuestionsSets
            {
                QuestionSetId = Guid.NewGuid().ToString(),
                SubmissionId = submissionId,
                DocumentId = dto.documentId,
                GeneratedAt = DateTime.UtcNow,
                Status = QuestionsStatus.COMPLETED,
                Questions = new List<Questions>()
            };

            if (dto.mcqQuestions?.Any() == true)
                questionSet.Questions.AddRange(mapper.Map<IEnumerable<McqQuestions>>(dto.mcqQuestions));

            if (dto.trueFalseQuestions?.Any() == true)
                questionSet.Questions.AddRange(mapper.Map<IEnumerable<TrueFalseQuestions>>(dto.trueFalseQuestions));

            if (dto.matchingQuestions?.Any() == true)
                questionSet.Questions.AddRange(mapper.Map<IEnumerable<MatchingQuestions>>(dto.matchingQuestions));

            if (dto.fillTheBlanks?.Any() == true)
                questionSet.Questions.AddRange(mapper.Map<IEnumerable<FillTheBlankQuestions>>(dto.fillTheBlanks));
            
            foreach (var question in questionSet.Questions)
            {
                question.DocumentId = dto.documentId;
            }
            
            yield return questionSet;
        }
    }
    
    private async Task PersistQuestionSets(IEnumerable<QuestionsSets> sets)
    {
        foreach (var set in sets)
            await unitOfWork.QuestionSet.AddAsync(set);

        await unitOfWork.SaveAsync();
    }

}