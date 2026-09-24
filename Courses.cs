namespace WestCoastEducation;

public class Course
{
    public int CourseNumber { get; set; }
    public string Title { get; set; } = "";
    public string Subject { get; set; } = "";
    public int Length { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new();
}
