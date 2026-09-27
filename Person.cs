namespace WestCoastEducation;

public abstract class Person
{
    public string Id { get; private set; } = "";
    public string SocialSecurityNumber { get; private set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public string ZipCode { get; set; } = "";
    public string Locality { get; set; } = "";

protected Person(
    string id,
    string firstName,
    string lastName,
    string phone,
    string email,
    string ssn,
    string address,
    string zip,
    string locality
)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phone;
        Email = email;
        SocialSecurityNumber = ssn;
        Address = address;
        ZipCode = zip;
        Locality = locality;
    }
    public virtual string GetInfo()
    {
        return $"[{Id}] {FirstName} {LastName} - {PhoneNumber} - {Email} - {Address}, {ZipCode} {Locality}";
    }
}