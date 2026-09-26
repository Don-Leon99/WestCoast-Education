namespace WestCoastEducation;

public class Student
{
    public string StudentID { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string SocialSecurityNumber { get; set; } = "";
    public string Address { get; set; } = "";
    public string ZipCode { get; set; } = "";
    public string Locality { get; set; } = "";
    public List<Course> EnrolledCourses { get; set; } = new();

    // Konstruktor för snabb initiering
    public Student(string id, string firstName, string lastName, string phone, string email, string ssn, string address, string zip, string locality)
    {
        StudentID = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phone;
        Email = email;
        SocialSecurityNumber = ssn;
        Address = address;
        ZipCode = zip;
        Locality = locality;
    }
}
