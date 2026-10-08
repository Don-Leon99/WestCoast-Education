namespace WestCoastEducation;

public class TeacherManager : PersonManager<Teacher>
{
    public TeacherManager(CourseManager courseManager)
    {
        _people.AddRange(new List<Teacher>
        {
            new Teacher("tch101", "Marcus", "Aurelius", "070 111 22 33", "marcus@westcoast.se", "19820412-1122", "Storgatan 5", "211 20", "Malmö")
            {
                EmploymentDate = new DateTime(2020, 08, 15),
                ExpertiseAreas = new List<string> { "History", "Math", "Programming" },
            },
            new Teacher("tch102", "Anna", "Lindgren", "070 444 55 66", "anna@westcoast.se", "19880920-3344", "Hamngatan 12", "252 20", "Helsingborg")
            {
                EmploymentDate = new DateTime(2023, 01, 10),
                ExpertiseAreas = new List<string> { "Chemistry", "Social Science", "Cooking" },
            }
        });

        foreach (var course in courseManager.GetCoursesByNumbers(101, 102))
            RegisterCourseToTeacher(course, "tch101");

        foreach (var course in courseManager.GetCoursesByNumbers(103, 104, 105))
            RegisterCourseToTeacher(course, "tch102");
    }

    public void RegisterCourseToTeacher(Course course, string teacherId)
    {
        var teacher = GetById(teacherId);
        if (teacher != null && !teacher.TeachingCourses.Contains(course))
        {
            teacher.TeachingCourses.Add(course);
            course.DeployedTeachers.Add(teacher);

        }
    }
}
