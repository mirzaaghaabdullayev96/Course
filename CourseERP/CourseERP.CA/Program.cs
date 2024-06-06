using CourseERP.Business.implementations;
using CourseERP.Business.interfaces;
using CourseERP.Core.Models;
using CourseERP.Database.DAL;

namespace CourseERP.CA
{
    internal class Program
    {
        static void Main(string[] args)
        {   //creating services
            IGroupService groupService = new GroupService();
            IStudentService studentService = new StudentService();

            //creating groups
            Group group1 = new Group("Back-end");
            Group group2 = new Group("Front-end");

            //creating students
            Student student1 = new Student() { Fullname = "Zaur Babayev", Grade = 57, Group = group1 };
            Student student2 = new Student() { Fullname = "Ali Babayev", Grade = 50, Group = group1 };
            Student student3 = new Student() { Fullname = "Metin Babayev", Grade = 87, Group = group1 };

            //adding to the student list
            studentService.Create(student1);
            studentService.Create(student2);
            studentService.Create(student3);

            //adding groups to the group list
            groupService.Create(group1);
            groupService.Create(group2);

            //adding students to the list of group2 students
            group2.Students.Add(student1);
            group2.Students.Add(student2);
            group2.Students.Add(student3);

            //adding students to the list of group1 students
            group1.Students = studentService.GetAll();

            var allStudent = studentService.GetAll();
            var allGroups = groupService.GetAll();

            foreach (Student student in allStudent)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('-', 20));

            foreach (Group group in allGroups)
            {
                Console.WriteLine(group);
            }

            Console.WriteLine("after deleting");
            Console.WriteLine(new string('-', 20));

            groupService.Remove(1);

            foreach (Student student in allStudent)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('-', 20));

            foreach(Student student in group2.Students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("after removing student");

            studentService.Remove(2);

            foreach (Student student in group1.Students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("========");

            foreach (Student student in group2.Students)
            {
                Console.WriteLine(student);
            }










        }
    }
}
