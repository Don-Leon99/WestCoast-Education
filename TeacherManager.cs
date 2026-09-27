namespace WestCoastEducation;

public class TeacherManager
{
    private readonly List<Teacher> _teachers;
    public TeacherManager(CourseManager courseManager)
    {
        _teachers = new()
        {
            new Teacher("tch101", "Marcus", "Aurelius", "070 111 22 33", "marcus@westcoast.se", "19820412-1122", "Storgatan 5", "211 20", "Malmö")
            {
                EmploymentDate = new DateTime(2020, 08, 15),
                ExpertiseAreas = new List<string> { "History", "Math", "Programming" },
                TeachingCourses = courseManager.GetCoursesByNumbers(101, 102)
            },
            new Teacher("tch102", "Anna", "Lindgren", "070 444 55 66", "anna@westcoast.se", "19880920-3344", "Hamngatan 12", "252 20", "Helsingborg")
            {
                EmploymentDate = new DateTime(2023, 01, 10),
                ExpertiseAreas = new List<string> { "Chemistry", "Social Science", "Cooking" },
                TeachingCourses = courseManager.GetCoursesByNumbers(103, 104, 105)
            }
        };
    }

    public Teacher? GetTeacherById(string teacherId)
    {
        return _teachers.FirstOrDefault(t => t.Id == teacherId);
    }

    public void ListTeacher()
    {
        foreach (var teacher in _teachers)
        {
            Console.WriteLine(teacher.GetInfo());
        }
    }

    public void AddTeacher(Teacher teacher)
    {
        _teachers.Add(teacher);
    }

    public void RemoveTeacher(Teacher teacher)
    {
        _teachers.Remove(teacher);
    }

    public void RegisterCourseToTeacher(Course course, string teacherId)
    {
        var teacher = GetTeacherById(teacherId);
        if (teacher != null && !teacher.TeachingCourses.Contains(course))
        {
            teacher.TeachingCourses.Add(course);
        }
    }

}
