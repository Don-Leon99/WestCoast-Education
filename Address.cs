using System;

namespace WestCoastEducation;

public class Address
{
    public string Street { get; }
    public string ZipCode { get; }
    public string Locality { get; }

    public Address(string street, string zipCode, string locality)
    {
        Street = street;
        ZipCode = zipCode;
        Locality = locality;
    }
    public override string ToString() => $"{Street}, {ZipCode} {Locality}";
}
    