namespace SchoolWebApp.Features.Assignments.Views;

public class AssignmentResponse
{
    public string ID { get; set; }
    
    public string Subject { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Deadline { get; set; }
}