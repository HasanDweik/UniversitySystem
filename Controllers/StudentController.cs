using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.DTOs;
using UniversitySystem.Interfaces;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    private List<Student> students = new List<Student>{
        new Student(1,"Hasan","hasan7@live.com"),
        new Student(2,"George","george3@live.com"),
        new Student(3,"Maroun","maroun5@live.com"),
        
    };
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentHelper _studentHelper;

    public StudentController(ILogger<StudentController> logger, IStudentHelper studentHelper)
    {
        _logger = logger;
        _studentHelper = studentHelper;
    }

    [HttpGet("GetStudents")]
    public IEnumerable<Student> GetAllStudents()
    {
        return _studentHelper.GetAllStudents(students);
    }
    [HttpGet("GetStudent")]
    public Student GetStudentById([Required]int id)
    {
        return _studentHelper.GetStudentById(students, id);
    }
    [HttpPost("PostStudent")]
    public IActionResult AddStudent([Required]Student student)
    {
        _studentHelper.AddStudent(students, student);
       return Ok() ;
    }
    [HttpDelete("DeleteStudent")]
    public IEnumerable<Student> DeleteStudent([Required]int id)
    {
        return _studentHelper.DeleteStudent(students,id);
    }
    [HttpPost("UpdateStudent")]
    public IEnumerable<Student> UpdateStudent([Required]int id,UpdateStudentDto usDto)
    {
        return _studentHelper.UpdateStudent(students, id, usDto);
    }
    [HttpGet("GetStudentByString")]
    public List<Student> GetStudentByString(string s)
    {
        return _studentHelper.GetStudentByString(students,s);
    }

}