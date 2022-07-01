namespace UniversitySystem.DTOs;

public class UpdateStudentDto
{
    public string Name { get; set;}
    public string Email { get; set;}

    public UpdateStudentDto(string name, string email)
    {
        Name = name;
        Email = email;
    }
}