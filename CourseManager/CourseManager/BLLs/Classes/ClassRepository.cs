using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.BLLs.Classes
{
    public class ClassRepository:IClassRepository
    {
        protected CourseManagerEntities db = new CourseManagerEntities();

        public List<CourseDetail> GetClassCourse(int id)
        {
            var query =
                from cm in db.CourseManagements
                join c in db.Classes
                     on cm.ClassId equals c.id
                join cr in db.Courses
                     on cm.CourseId equals cr.id
                join t in db.Teachers
                     on cm.TeacherId equals t.id
                where cm.ClassId == id
                select new CourseDetail
                {
                    ClassName = c.Name,
                    CourseName = cr.Name,
                    TeacherName = t.Name
                };

            return query.ToList();
        }
    }
}