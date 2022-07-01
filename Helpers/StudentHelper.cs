using UniversitySystem.DTOs;
using UniversitySystem.Exceptions;
using UniversitySystem.Interfaces;
using UniversitySystem.Models;

namespace UniversitySystem.Helpers;

public class StudentHelpers : IStudentHelper
{
    public IEnumerable<Student> GetAllStudents(List<Student> students)
    {
        return students.ToArray();
    }

    public Student GetStudentById(List<Student> students, int id)
    {
        try
        {
            Student student = students.Where(obj => obj.Id == id).Select(x => x).First();
            if (student != null)
            {
                return student;
            }
            else
            {
                throw new StudentNotFoundException();
            }
        }
        catch (StudentNotFoundException e)
        {
            Console.WriteLine("student not found");
        }
        catch (Exception d)
        {
            Console.WriteLine(d.Message);
        }
        return null;
    }

    public IEnumerable<Student> AddStudent(List<Student> students,Student student)
    { 
        students.Add(student);
        return students;
    }
    public IEnumerable<Student> DeleteStudent(List<Student> students, int id)
    {
        try
        {
            students.Remove(students.Where(obj => obj.Id == id).First());
            return students;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    public IEnumerable<Student> UpdateStudent(List<Student> students, int id, UpdateStudentDto usDto)
    {
        try
        {
            Student student = students.Where(obj => obj.Id == id).First();
            int index = students.IndexOf(student);
            students[index].Email = usDto.Email;
            students[index].Name = usDto.Name;
            return students.ToArray();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public List<Student> GetStudentByString(List<Student> students, string s)
    {
        try
        {
            return students.Where(obj => obj.Name.Contains(s)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}