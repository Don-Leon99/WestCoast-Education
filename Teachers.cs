namespace WestCoastEducation;

public class Teacher : Person
{
    public DateTime EmploymentDate { get; set; }
    public List<string> ExpertiseAreas { get; set; } = new();
    public List<Course> TeachingCourses { get; set; } = new();

    public Teacher(
        string id,
        string ssn,
        string firstName,
        string lastName,
        string phone,
        string email,
        string address,
        string zip,
        string locality)
        : base(id, ssn, firstName, lastName, phone, email, address, zip, locality)
    {

    }

    public override string GetInfo()
    {
        string expertiseText = "";
        if (ExpertiseAreas.Count == 0)
        {
            expertiseText = "No expertise given.";
        }
        else
        {
            foreach (string area in ExpertiseAreas)
            {
                expertiseText += area + ", ";
            }
            expertiseText = expertiseText.TrimEnd(',', ' ');
        }

        string coursesText = "";
        if (TeachingCourses.Count == 0)
        {
            coursesText = "No courses teaching.";
        }
        else
        {
            foreach (Course course in TeachingCourses)
            {
                coursesText += course.Title + ", ";
            }
            coursesText = coursesText.TrimEnd(',', ' ');
        }

        return $"{base.GetInfo()} Expertise: {expertiseText} Teaches: {coursesText}";
    }
}
