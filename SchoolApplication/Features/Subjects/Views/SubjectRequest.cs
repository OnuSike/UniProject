using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Features.Subjects.Views;

public class SubjectRequest
{
    [Required]public string Name { get; set; }
    
    [Required]public string ProfessorMail { get; set; }
    
    [Required]public List<double> Grades { get; set; }
}