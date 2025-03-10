namespace QuesGenie.Domain.Entities;

public class McqQuestions:Questions
{
    public McqQuestions()
    {
        McqOptions = new HashSet<McqOptions>();
    }
    public ICollection<McqOptions> McqOptions { get; set; }
}