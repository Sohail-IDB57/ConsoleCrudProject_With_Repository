using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository_Domain;
using Repository_Source;

namespace Repository_Pattern
{
    public class CourseXMLRepository : XMLRepositoryBase<XMLSet<Course>, Course, int>, ICourseRepository
    {
        public CourseXMLRepository() : base("CourseInformation.xml")
        {

        }
        public Course GetCourseById(int courseId)
        {
            return GetAll().FirstOrDefault(c => c.CourseID == courseId);
        }

        public Course GetCourseByName(string courseName)
        {
            return GetAll().FirstOrDefault(c => c.CourseName == courseName);
        }
        public List<Course> GetCoursesByType(string courseType)
        {
            var allCourses = GetAll();
            return allCourses
                .Where(c => c.CourseType.Equals(courseType, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public bool RemoveByType(string courseType)
        {
            try
            {
                var coursesToRemove = m_context.Data.Where(c => c.CourseType == courseType).ToList();
                foreach (var course in coursesToRemove)
                {
                    m_context.Data.Remove(course);
                }
                m_context.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveAll()
        {
            try
            {
                m_context.Data.Clear();
                m_context.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Update(int courseId, Course updatedCourse)
        {
            try
            {
                var course = m_context.Data.FirstOrDefault(c => c.CourseID == courseId);
                if (course != null)
                {
                    // Update the course properties with the values from updatedCourse
                    course.CourseID = updatedCourse.CourseID;
                    course.CourseName = updatedCourse.CourseName;
                    course.CourseType = updatedCourse.CourseType;
                    course.Duration = updatedCourse.Duration;
                    course.Fee = updatedCourse.Fee;

                    // Save changes to the XML file
                    m_context.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(int courseId)
        {
            try
            {
                var courseToRemove = m_context.Data.FirstOrDefault(c => c.CourseID == courseId);
                if (courseToRemove != null)
                {
                    // Remove the course from the list
                    m_context.Data.Remove(courseToRemove);

                    // Save changes to the XML file
                    m_context.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

