using System;

namespace WestCoastEducation;

public class EducationLeader : Teacher
{
    public EducationLeader(
        string id, 
        string ssn, 
        string firstName, 
        string lastName,
        string phone, 
        string email, 
        string address, 
        string zip, 
        string locality,
        DateTime employmentDate)
        : base(id, ssn, firstName, lastName, phone, email, address, zip, locality)
    {
        EmploymentDate = employmentDate;
    }
}