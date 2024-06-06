using CourseERP.Business.interfaces;
using CourseERP.Core.Models;
using CourseERP.Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseERP.Business.implementations
{
    public class StudentService : IStudentService
    {
        public void Create(Student student)
        {
            Data<Student>.Course.Add(student);
        }

        public Student Get(int id)
        {
            var wantedStudent = Data<Student>.Course.Find(x => x.Id == id);

            if (wantedStudent is null)
            {
                throw new NullReferenceException("Student not found");
            }

            return wantedStudent;
        }

        public List<Student> GetAll()
        {
            return Data<Student>.Course;
        }

        public void Remove(int id)
        {
            var wantedStudent = Data<Student>.Course.Find(x => x.Id == id);
            if (wantedStudent is not null)
            {
                Data<Student>.Course.Remove(wantedStudent);
            }
            else
            {
                throw new NullReferenceException("Teacher not found");
            }
        }
    }
}
