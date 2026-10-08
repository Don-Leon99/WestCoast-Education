namespace WestCoastEducation;

public class Course
{
    public int CourseNumber { get; set; }
    public string Title { get; set; } = "";
    public string Subject { get; set; } = "";
    public int LengthInWeeks { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate => StartDate.AddDays(LengthInWeeks * 7);
    public CourseType Presence { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new();
    public List<Teacher> DeployedTeachers { get; set; } = new();

    public Course(int id, string title, string subject, int length, DateOnly startDate, CourseType presence)
    {
        CourseNumber = id;
        Title = title;
        Subject = subject;
        LengthInWeeks = length;
        StartDate = startDate;
        Presence = presence;
    }

    public string GetInfo()
    {
        string teacherText;
        if (DeployedTeachers.Count == 0)
        {
            teacherText = "No teachers assigned.";
        }
        else
        {
            teacherText = "";
            foreach (Teacher teacher in DeployedTeachers)
            {
                teacherText += $"{teacher.FirstName} {teacher.LastName}, ";
            }
            teacherText = teacherText.TrimEnd(',', ' ');
        }
        return $"[{CourseNumber}] {Title} ({Subject}) - {Presence} - " +
       $"{LengthInWeeks} weeks, {StartDate} to {EndDate} - {GetStatus()} - " +
       $"Students: {EnrolledStudents.Count} - Teachers: {teacherText}";
    }

    public string GetStatus()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        if (today < StartDate) return "Upcoming";
        else if (today > EndDate) return "Finished";
        else return "Ongoing";
    }
}
