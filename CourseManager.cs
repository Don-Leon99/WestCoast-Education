namespace WestCoastEducation;

public class CourseManager
{
    private readonly List<Course> _courses = new()
    {
    new(101, "Rise Of The Roman Empire", "History", 40, new DateOnly(2026, 5, 20), CourseType.InClass),
    new(102, "Algebra And Other Weird Numbers", "Math", 35, new DateOnly(2026, 5, 20), CourseType.AtHome),
    new(103, "How To Build Bombs And Other Fun Toys", "Chemistry", 60, new DateOnly(2026, 8, 10), CourseType.InClass),
    new(104, "How To Best Serve Our AI Overlord", "Social Science", 45, new DateOnly(2026, 8, 10), CourseType.AtHome),
    new(105, "Putting Ketchup On Everything And Tasting It", "Cooking", 50, new DateOnly(2026, 11, 2), CourseType.InClass),
    new(106, "Why George R.R Martin Still Hasn't Released Winds of Winter", "Literature", 20, new DateOnly(2026, 11, 2), CourseType.AtHome)
};

    public void AddCourse(Course course)
    {
        _courses.Add(course);
    }

    public bool RemoveCourse(int courseNumber)
    {
        var course = _courses.FirstOrDefault(c => c.CourseNumber == courseNumber);
        if (course != null)
        {
            _courses.Remove(course);
            return true;
        }
        return false;
    }

    public void ListCourses()
    {
        foreach (var course in _courses)
        {
            Printer.Print(course);
        }
    }

    public void EnrollStudentToCourse(Student student, int courseNumber)
    {
        var course = _courses.FirstOrDefault(c => c.CourseNumber == courseNumber);
        if (course != null)
        {
            course.EnrolledStudents.Add(student);
            student.EnrolledCourses.Add(course);
        }
        else
        {
            Console.WriteLine($"Course with number {courseNumber} could not be found.");
        }
    }

    public List<Course> GetCoursesByNumbers(params int[] courseNumbers)
    {
        return _courses.Where(c => courseNumbers.Contains(c.CourseNumber)).ToList();
    }

    public List<Course> GetAllCourses()
    {
        return _courses;
    }

    public void SaveCourseToJson()
    {
        foreach (var course in _courses)
        {
            course.StudentIds = course.EnrolledStudents.Select(s => s.Id).ToList();
            course.TeacherIds = course.DeployedTeachers.Select(t => t.Id).ToList();
        }
        Jsonify.SaveCourses(_courses);
    }

    public int LoadCoursesFromJson()
    {
        var loaded = Jsonify.LoadCourses();
        if (loaded.Count > 0)
        {
            _courses.Clear();
            _courses.AddRange(loaded);
        }
        return loaded.Count;
    }
}
