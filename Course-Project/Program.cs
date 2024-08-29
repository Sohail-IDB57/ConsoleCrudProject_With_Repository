using System;
using System.Collections.Generic;
using Repository_Domain;
using Repository_Pattern;

namespace Course_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICourseRepository source = RepositoryFactory.Create<ICourseRepository>(ContextTypes.XMLSource);

            bool isRun = true;
            while (isRun)
            {
                Console.Clear();
                Console.WriteLine("================= Select Your Process =================");
                Console.WriteLine("Press 1: To Get Course Information");
                Console.WriteLine("Press 2: To Create a New Course");
                Console.WriteLine("Press 3: To Update a Course");
                Console.WriteLine("Press 4: To Remove a Course");
                Console.WriteLine("Press 5: To Exit The Application");

                string inputKey = Console.ReadLine();
                Console.Clear();

                if (inputKey == "1")
                {
                    Console.WriteLine("Select option:");
                    Console.WriteLine("1. Get course information by ID");
                    Console.WriteLine("2. Get course information by name");
                    Console.WriteLine("3. Get course information by type");
                    Console.WriteLine("4. Get all course information");

                    string option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.Write("Enter Course ID: ");
                        if (int.TryParse(Console.ReadLine(), out int courseId))
                        {
                            var course = source.GetCourseById(courseId);
                            if (course != null)
                            {
                                DisplayCourseInformation(course);
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Course ID.");
                        }
                    }
                    else if (option == "2")
                    {
                        Console.Write("Enter Course Name: ");
                        string courseName = Console.ReadLine();
                        var course = source.GetCourseByName(courseName);
                        if (course != null)
                        {
                            DisplayCourseInformation(course);
                        }
                        else
                        {
                            Console.WriteLine("Course not found.");
                        }
                    }
                    else if (option == "3")
                    {
                        Console.Write("Enter Course Type: ");
                        string courseType = Console.ReadLine();
                        var allcourses = source.GetCoursesByType(courseType);
                        if (allcourses.Count > 0)
                        {
                            foreach (var course in allcourses)
                            {
                                DisplayCourseInformation(course);
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No courses found for the specified type.");
                        }
                    }
                    else if (option == "4")
                    {
                        var courses = source.GetAll();
                        foreach (var course in courses)
                        {
                            DisplayCourseInformation(course);
                            Console.WriteLine();
                        }
                    }

                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (inputKey == "2")
                {
                    bool createAnotherCourse = true;
                    while (createAnotherCourse)
                    {
                        Course course = new Course();
                        Console.Write("Enter Course ID: ");
                        course.CourseID = int.Parse(Console.ReadLine());

                        Console.Write("Enter Course Name: ");
                        course.CourseName = Console.ReadLine();

                        Console.Write("Enter Course Type: ");
                        course.CourseType = Console.ReadLine();

                        Console.Write("Enter Duration: ");
                        course.Duration = int.Parse(Console.ReadLine());

                        Console.Write("Enter Fee: ");
                        course.Fee = decimal.Parse(Console.ReadLine());

                        try
                        {
                            source.Insert(course);
                            Console.WriteLine($"Course {course.CourseID} created successfully!");

                            Console.Write("Do you want to create another course? (yes/no): ");
                            string response = Console.ReadLine().ToLower();
                            createAnotherCourse = response == "yes";
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex);
                            Console.ReadKey();
                        }
                    }
                }
                else if (inputKey == "3")
                {
                    Console.Write("Enter Course ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int courseIdToUpdate))
                    {
                        var courseToUpdate = new Course();
                        Console.Write("Enter New ID: ");
                        courseToUpdate.CourseID = int.Parse(Console.ReadLine());
                        Console.Write("Updated Course Name : ");
                        courseToUpdate.CourseName = Console.ReadLine();
                        Console.Write("Updated Course Type : ");
                        courseToUpdate.CourseType = Console.ReadLine();
                        Console.Write("Updated Duration. : ");
                        courseToUpdate.Duration = int.Parse(Console.ReadLine());
                        Console.Write("Updated Fee : ");
                        courseToUpdate.Fee = int.Parse(Console.ReadLine());

                        // Use the existing 'source' variable declared outside the block
                        if (source.Update(courseIdToUpdate, courseToUpdate))
                        {
                            Console.WriteLine("Course updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update course. Course not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Course ID.");
                    }
                }
                else if (inputKey == "4")
                {
                    Console.WriteLine("Select option:");
                    Console.WriteLine("1. Remove course by ID");
                    Console.WriteLine("2. Remove courses by type");
                    Console.WriteLine("3. Remove all courses");
                    string removeOption = Console.ReadLine();

                    if (removeOption == "1")
                    {
                        Console.Write("Enter Course ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int courseIdToDelete))
                        {
                            if (source.Remove(courseIdToDelete))
                            {
                                Console.WriteLine("Course deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Course ID.");
                        }
                    }
                    else if (removeOption == "2")
                    {
                        Console.Write("Enter Course Type to delete: ");
                        string courseTypeToDelete = Console.ReadLine();
                        if (source.RemoveByType(courseTypeToDelete))
                        {
                            Console.WriteLine($"Courses of type '{courseTypeToDelete}' deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"No courses found with type '{courseTypeToDelete}'.");
                        }
                    }
                    else if (removeOption == "3")
                    {
                        if (source.RemoveAll())
                        {
                            Console.WriteLine("All courses deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to delete all courses.");
                        }
                    }
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }

                else if (inputKey == "5")
                {
                    isRun = false;
                }
            }
        }
        public static void DisplayCourseInformation(Course course)
        {
            Console.WriteLine("============= Course Information ===========");
            Console.WriteLine($"Course ID: {course.CourseID}");
            Console.WriteLine($"Course Name: {course.CourseName}");
            Console.WriteLine($"Course Type: {course.CourseType}");
            Console.WriteLine($"Duration: {course.Duration} Hours");
            Console.WriteLine($"Fee: {course.Fee} TK");
        }
    }
}
  


