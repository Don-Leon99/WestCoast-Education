namespace WestCoastEducation;

public class StudentManager : PersonManager<Student>
{
    public StudentManager(CourseManager courseManager)
    {
        _people.AddRange(new List<Student>
        {
            new("abc123", "Liam", "Diesel", "070 777 56 65", "student1@gmail.com", "20000118-3579", "Stora Nygatan 14B", "211 37", "Malmö"),
            new("asd123", "Lex", "Kex", "070 777 45 76", "student2@gmail.com", "20010525-7412", "Kopparbergsgatan 8", "214 44", "Malmö"),
            new("qwe123", "Lovisa", "Måste Fisa", "070 777 84 23", "student3@gmail.com", "19961012-5689", "Södergatan 22", "252 25", "Helsingborg"),
            new("tyu123", "Lena", "Bena", "070 777 67 25", "student4@gmail.com", "19900704-4237", "Bredgatan 3", "222 21", "Lund"),
            new("uio123", "Maja", "Gräddnos", "070 777 91 12", "student5@gmail.com", "19980315-1234", "Stortorget 1", "291 31", "Kristianstad"),
            new("pas123", "Pelle", "Svanslös", "070 777 33 44", "student6@gmail.com", "19951130-8899", "Eriksgatan 45", "261 32", "Landskrona")
        });
        var enrollments = new Dictionary<string, int[]>
        {
            ["abc123"] = new[] { 101, 102 },
            ["asd123"] = new[] { 102 },
            ["qwe123"] = new[] { 102, 104 },
            ["tyu123"] = new[] { 103, 104, 105 },
            ["uio123"] = new[] { 101, 103, 105 },
            ["pas123"] = new[] { 101, 105 }
        };

        foreach (var (studentId, courseNumbers) in enrollments)
            foreach (var course in courseManager.GetCoursesByNumbers(courseNumbers))
                RegisterCourseToStudent(course, studentId);
    }

    public void RegisterCourseToStudent(Course course, string studentId)
    {
        var student = GetById(studentId);
        if (student != null && !student.EnrolledCourses.Contains(course))
        {
            student.EnrolledCourses.Add(course);
            course.EnrolledStudents.Add(student);
        }
    }
}
