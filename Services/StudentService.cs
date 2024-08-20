using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Services;

/// <summary>
/// Dont use this yet
/// </summary>
public class StudentService
{
    private readonly AppDbContext _appDbContext;
    public StudentService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public bool CreateStudent(Student student)
    {
     
            _appDbContext.Students.Add(student);

            bool success = _appDbContext.SaveChanges() > 0;

            return success;
    }

    // Using ? means that Student can be null and I wanna return null if in case student is not found without being afrait of NullReferenceException
    public Student? GetStudent(int id)
    {
      Student? student = _appDbContext.Students.FirstOrDefault(x => x.Id == id);
      return student;
    }

    public List<Student> GetStudentsByExactName(string name)
    {
        List<Student>? student = _appDbContext.Students.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
        return student;
    }

    public List<Student> GetStudents()
    {
        return _appDbContext.Students.ToList();
    }

    public bool DeleteStudent(int id)
    {
        var student = GetStudent(id);
        
        if (student == null) 
        {
            return false;
        }

        _appDbContext.Students.Remove(student);

        bool success = _appDbContext.SaveChanges() > 0;

        return success;
    }

    public bool UpdateStudent(Student student)
    {
        var tempStudent = GetStudent(student.Id);

        if (tempStudent == null)
        {
            return false;
        }

        tempStudent.Name = student.Name;
        tempStudent.LastName = student.LastName;
        tempStudent.Remarks = student.Remarks;

        _appDbContext.Students.Remove(student);

        bool success = _appDbContext.SaveChanges() > 0;

        return success;
    }
}