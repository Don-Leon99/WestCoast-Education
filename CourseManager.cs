namespace WestCoastEducation;

public class CourseManager
{
    private readonly List<Course> _courses = new()
    {
    new(101, "Rise Of The Roman Empire", "History", 40),
    new(102, "Algebra And Other Weird Numbers", "Math", 35),
    new(103, "How To Build Bombs And Other Fun Toys", "Chemistry", 60),
    new(104, "How To Best Serve Our AI Overlord", "Social Science", 45),
    new(105, "Putting Ketchup On Everything And Tasting It", "Cooking", 50),
    new(106, "Why George R.R Martin Still Hasn't Released Winds of Winter", "Literature", 20)
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
            Console.WriteLine($"[{course.CourseNumber}] {course.Title} - {course.Subject} - {course.LengthInWeeks} weeks - Enrolled students: {course.EnrolledStudents}");
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
        // Hitta alla kurser vars CourseNumber finns i arrayen courseNumbers
        return _courses.Where(c => courseNumbers.Contains(c.CourseNumber)).ToList();
    }
}
