using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models;

public class Student
{
    
    public Student(int id, string name, string email)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
    }
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(3,ErrorMessage = "please enter a valid name")]

    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

}