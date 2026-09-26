namespace WestCoastEducation;

public class Course
{
    public int CourseNumber { get; set; }
    public string Title { get; set; } = "";
    public string Subject { get; set; } = "";
    public int LengthInWeeks { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new();

    public Course(int id, string title, string subject, int length)
    {
        CourseNumber = id;
        Title = title;
        Subject = subject;
        LengthInWeeks = length;
    }
}
