using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Domain;
namespace Repository_Pattern
{
    public interface ICourseRepository : IRepository<Course,int>
    {
        //ICollection<Course> GetAll();
        Course GetCourseById(int courseId);
        Course GetCourseByName(string courseName);
        List<Course> GetCoursesByType(string courseType);
        bool Update(int courseId, Course updatedCourse);
        bool RemoveByType(string courseType);
        bool RemoveAll();
    }
}