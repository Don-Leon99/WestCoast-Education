namespace WestCoastEducation;

public class Student
{
    public string StudentID {get; set;} = "";
    public string FirstName {get; set;} = "";
    public string LastName {get; set;} = "";
    public string PhoneNumber {get; set;} = "";
    public string Email {get; set;} = "";
    public int SocialSecurityNumber {get; set;}
    public string Address {get; set;} = "";
    public int ZipCode {get; set;}
    public string Locality {get; set;} = "";
    public List<Course> EnrolledCourses {get; set;} = new();
}
