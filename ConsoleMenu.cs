using System;
using System.ComponentModel.DataAnnotations;

namespace WestCoastEducation;

public class ConsoleMenu
{
    private readonly CourseManager _courseManager;
    private readonly StudentManager _studentManager;
    private readonly TeacherManager _teacherManager;

    public ConsoleMenu(CourseManager courseManager, StudentManager studentManager, TeacherManager teacherManager)
    {
        _courseManager = courseManager;
        _studentManager = studentManager;
        _teacherManager = teacherManager;
    }

    public void Run()
    {
        bool running = true;
        try
        {
            while (running)
            {
                Console.WriteLine(" ");
                Console.WriteLine("=== WestCoast Education ===");
                Console.WriteLine("1. List courses");
                Console.WriteLine("2. List students");
                Console.WriteLine("3. List teachers");
                Console.WriteLine("4. List everything");
                Console.WriteLine("5. Add course");
                Console.WriteLine("6. Add student");
                Console.WriteLine("7. Add teacher");
                Console.WriteLine("8. Enroll student in course");
                Console.WriteLine("9. Enlist teacher in course");
                Console.WriteLine("10. Save courses to JSON");
                Console.WriteLine("11. Load courses from JSON");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                Console.Write(" ");

                switch (Console.ReadLine())
                {
                    case "1": PrintSection("COURSES", _courseManager.GetAllCourses()); break;
                    case "2": PrintSection("STUDENTS", _studentManager.GetAll()); break;
                    case "3": PrintSection("TEACHERS", _teacherManager.GetAll()); break;
                    case "4": ListEverything(); break;
                    case "5": AddCourse(); break;
                    case "6": AddStudent(); break;
                    case "7": AddTeacher(); break;
                    case "8": EnrollStudent(); break;
                    case "9": EnlistTeacher(); break;
                    case "10": _courseManager.SaveCourseToJson(); Console.WriteLine("--- Saved ---"); break;
                    case "11":
                        int count = _courseManager.LoadCoursesFromJson();
                        RelinkAfterLoad();
                        Console.WriteLine($"--- Loaded {count} courses ---");
                        break;
                    case "0": running = false; break;
                    default: Console.WriteLine("--- Invalid choice ---"); break;
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("--- Invalid input format (check numbers and dates), back to menu ---");
        }
        catch (OverflowException)
        {
            Console.WriteLine("--- Number is too large, back to menu ---");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--- Something went wrong: {ex.Message} ---");
        }
    }

    private static string Ask(string label)
    {
        Console.Write($"{label}: ");
        return Console.ReadLine() ?? "";
    }

    private void AddCourse()
    {
        int number = int.Parse(Ask("Course number"));
        string title = Ask("Title");
        string subject = Ask("Subject");
        int weeks = int.Parse(Ask("Length in weeks"));
        DateOnly start = DateOnly.Parse(Ask("Start date (yyyy-MM-dd)"));
        CourseType type = Ask("Type (1 = InClass, 2 = AtHome)") == "1"
        ? CourseType.InClass
        : CourseType.AtHome;

        _courseManager.AddCourse(new Course(number, title, subject, weeks, start, type));
        Console.WriteLine(" ");
        Console.WriteLine("--- Course added ---");
    }

    private void AddStudent()
    {
        var student = new Student(
            Ask("Id"), Ask("Social security number"), Ask("First name"), Ask("Last name"),
            Ask("Phone"), Ask("Email"), Ask("Address"), Ask("Zip"), Ask("Locality"));

        _studentManager.Add(student);
        Console.WriteLine(" ");
        Console.WriteLine("--- Student added ---");
    }

    private void AddTeacher()
    {
        var teacher = new Teacher(
            Ask("Id"), Ask("Social security number"), Ask("First name"), Ask("Last name"),
            Ask("Phone"), Ask("Email"), Ask("Address"), Ask("Zip"), Ask("Locality"));

        _teacherManager.Add(teacher);
        Console.WriteLine(" ");
        Console.WriteLine("--- Teacher added ---");
    }

    private void EnrollStudent()
    {
        string studentId = Ask("Student id");
        int courseNumber = int.Parse(Ask("Course number"));

        var student = _studentManager.GetById(studentId);
        if (student == null)
        {
            Console.WriteLine(" ");
            Console.WriteLine("--- Student not found ---");
            return;
        }
        _courseManager.EnrollStudentToCourse(student, courseNumber);
    }

    private void EnlistTeacher()
    {
        string teacherId = Ask("Teacher id");
        int courseNumber = int.Parse(Ask("Course number"));

        var teacher = _teacherManager.GetById(teacherId);
        if (teacher == null)
        {
            Console.WriteLine(" ");
            Console.WriteLine("--- Teacher not found ---");
            return;
        }

        var course = _courseManager.GetCoursesByNumbers(courseNumber).FirstOrDefault();
        if (course == null)
        {
            Console.WriteLine(" ");
            Console.WriteLine("--- Course not found ---");
            return;
        }

        _teacherManager.RegisterCourseToTeacher(course, teacherId);
        Console.WriteLine(" ");
        Console.WriteLine("--- Teacher enlisted ---");
    }

    private void RelinkAfterLoad()
    {
        foreach (var student in _studentManager.GetAll())
            student.EnrolledCourses.Clear();
        foreach (var teacher in _teacherManager.GetAll())
            teacher.TeachingCourses.Clear();

        foreach (var course in _courseManager.GetAllCourses())
        {
            foreach (var id in course.StudentIds)
            {
                var student = _studentManager.GetById(id);
                if (student != null)
                {
                    course.EnrolledStudents.Add(student);
                    student.EnrolledCourses.Add(course);
                }
            }

            foreach (var id in course.TeacherIds)
            {
                var teacher = _teacherManager.GetById(id);
                if (teacher != null)
                {
                    course.DeployedTeachers.Add(teacher);
                    teacher.TeachingCourses.Add(course);
                }
            }
        }
    }

    private void ListEverything()
    {
        PrintSection("COURSES", _courseManager.GetAllCourses());
        PrintSection("STUDENTS", _studentManager.GetAll());
        PrintSection("TEACHERS", _teacherManager.GetAll());
    }

    private static void PrintSection(string title, IEnumerable<IPrintable> items)
    {
        Console.WriteLine();
        Console.WriteLine($"===== {title} =====");
        Printer.PrintAll(items);
    }

}
