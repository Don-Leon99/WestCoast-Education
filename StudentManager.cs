namespace WestCoastEducation;

public class StudentManager : PersonManager<Student>
{
    /* private readonly List<Student> _students; */
    public StudentManager(CourseManager courseManager)
    {
        _people.AddRange(new List<Student>
        {
            new("abc123", "Liam", "Diesel", "070 777 56 65", "student1@gmail.com", "20000118-3579", "Stora Nygatan 14B", "211 37", "Malmö")
            {
                EnrolledCourses = courseManager.GetCoursesByNumbers(101, 102)
            },
            new("asd123", "Lex", "Kex", "070 777 45 76", "student2@gmail.com", "20010525-7412", "Kopparbergsgatan 8", "214 44", "Malmö")
            {
                EnrolledCourses = courseManager.GetCoursesByNumbers(102)
            },
            new("qwe123", "Lovisa", "Måste Fisa", "070 777 84 23", "student3@gmail.com", "19961012-5689", "Södergatan 22", "252 25", "Helsingborg")
                        {
                EnrolledCourses = courseManager.GetCoursesByNumbers(102, 104)
            },
            new("tyu123", "Lena", "Bena", "070 777 67 25", "student4@gmail.com", "19900704-4237", "Bredgatan 3", "222 21", "Lund")
            {
                EnrolledCourses = courseManager.GetCoursesByNumbers(103, 104, 105)
            },
            new("uio123", "Maja", "Gräddnos", "070 777 91 12", "student5@gmail.com", "19980315-1234", "Stortorget 1", "291 31", "Kristianstad")
            {
                EnrolledCourses = courseManager.GetCoursesByNumbers(101, 103, 105)
            },
            new("pas123", "Pelle", "Svanslös", "070 777 33 44", "student6@gmail.com", "19951130-8899", "Eriksgatan 45", "261 32", "Landskrona")
            {
            EnrolledCourses = courseManager.GetCoursesByNumbers(101, 105)
            }
        });
    }

        public void RegisterCourseToStudent(Course course, string studentId)
    {
        var student = GetById(studentId);
        if (student != null && !student.EnrolledCourses.Contains(course))
        {
            student.EnrolledCourses.Add(course);
        }
    }

/*     public Student? GetStudentById(string studentId)
    {
        return _students.FirstOrDefault(s => s.Id == studentId);
    }

    public void ListStudents()
    {
        foreach (var student in _students)
        {
            Console.WriteLine(student.GetInfo());
        }
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public bool RemoveStudent(string studentId)
    {
        var student = _students.FirstOrDefault(s => s.Id == studentId);
        if (student != null)
        {
            _students.Remove(student);
            return true;
        }
        return false;
    } */
}
