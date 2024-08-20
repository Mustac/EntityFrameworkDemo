using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Data.Models;
using EntityFrameworkDemo.Services;

class Program
{
    static void Main()
    {
        var context = new AppDbContext();

        var student = new Student()
        {
            Name = "Jarek",
            LastName = "Jarekovski",
            Remarks = "He was a great man!"
        };

        context.Students.Add(student);

        context.SaveChanges();

        context.Dispose();
    }
}