using UniversitySystem.DTOs;
using UniversitySystem.Models;

namespace UniversitySystem.Interfaces;

public interface IStudentHelper
{
    public IEnumerable<Student> GetAllStudents(List<Student> students);
    public Student GetStudentById(List<Student> students, int id);
    public IEnumerable<Student> AddStudent(List<Student> students,Student student);
    public IEnumerable<Student> DeleteStudent(List<Student> students,int id);
    public IEnumerable<Student> UpdateStudent(List<Student> students,int id,UpdateStudentDto usDto);
    public List<Student> GetStudentByString(List<Student> students, string s);
}