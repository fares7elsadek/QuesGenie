namespace QuesGenie.Application.HumanFeedback.Queries.Dtos;

public record HumandFeedbackDto(string questionId, string questionText, string context, int rate);
