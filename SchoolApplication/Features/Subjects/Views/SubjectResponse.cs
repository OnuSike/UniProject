namespace SchoolApplication.Features.Subjects.Views;

public class SubjectResponse
{
    public string ID { get; set; }
    
    public string Name { get; set; }
    
    public string ProfessorMail { get; set; }
    
    public List<double> Grades { get; set; }
}