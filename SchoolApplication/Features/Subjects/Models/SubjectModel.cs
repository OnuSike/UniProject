using SchoolApplication.Base;

namespace SchoolApplication.Features.Subjects.Models;

public class SubjectModel : Model
{
    public string Name { get; set; }
    
    public string ProfessorMail { get; set; }
    
    public List<double> Grades { get; set; }
}