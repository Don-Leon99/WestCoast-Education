namespace WestCoastEducation;

public class CourseManager
{
    private readonly List<Course> _courses = new();

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
            Console.WriteLine($"[{course.CourseNumber}] {course.Title} - {course.Subject} ({course.Length})");
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
}
