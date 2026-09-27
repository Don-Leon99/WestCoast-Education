namespace WestCoastEducation;

public class Student : Person
{

    public List<Course> EnrolledCourses { get; set; } = new();

    public Student(
        string id,
        string ssn,
        string firstName,
        string lastName,
        string phone,
        string email,
        string address,
        string zip,
        string locality)
        : base (id, ssn, firstName, lastName, phone, email, address, zip, locality)
    {

    }

    public override string GetInfo()
    {
        string courseNames = "";
        if (EnrolledCourses.Count == 0)
        {
            courseNames = "No enrolled courses.";
        }
        else
        {
            foreach (Course course in EnrolledCourses)
            {
                courseNames += course.Title + ", ";
            }
            courseNames = courseNames.TrimEnd(',', ' ');
        }
        return $"{base.GetInfo()} | Kurser: {courseNames}";
    }
}
