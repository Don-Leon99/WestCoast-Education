namespace WestCoastEducation;

public class StudentManager
{
    private readonly List<Student> _students = new();
    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
    public bool RemoveStudent(string studentId)
    {
        var student = _students.FirstOrDefault(s => s.StudentID == studentId);
        if (student != null)
        {
            _students.Remove(student);
            return true;
        }
        return false;
    }
    public void ListStudents()
    {
        foreach (var student in _students)
        {
            Console.WriteLine($"[{student.StudentID}] {student.FirstName} {student.LastName} - {student.PhoneNumber} - {student.Email} - {student.SocialSecurityNumber} - {student.Address} - {student.ZipCode} {student.Locality}");
        }
    }
    public Student? GetStudentById(string studentId)
    {
        return _students.FirstOrDefault(s => s.StudentID == studentId);
    }

        public void RegisterCourseToStudent(Course course, int studentId)
    {
        
    }
}
