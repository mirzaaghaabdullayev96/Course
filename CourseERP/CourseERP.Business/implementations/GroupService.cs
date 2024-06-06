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
    public class GroupService : IGroupService
    {
        public void Create(Group Group)
        {
            Data<Group>.Course.Add(Group);
        }

        public Group Get(int id)
        {
            var wantedGroup = Data<Group>.Course.Find(x => x.Id == id);

            if (wantedGroup is null)
            {
                throw new NullReferenceException("Group not found");
            }

            return wantedGroup;
        }

        public List<Group> GetAll()
        {
            return Data<Group>.Course;
        }

        public void Remove(int id)
        {
            var wantedGroup = Data<Group>.Course.Find(x => x.Id == id);
            foreach (var student in Data<Student>.Course)
            {
                if (student.Group == wantedGroup)
                    student.Group = null;
            }
            Data<Group>.Course.Remove(wantedGroup);
        }
    }
}
