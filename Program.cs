namespace WestCoastEducation;

class Program
{
    static void Main(string[] args)
    {
        var courseManager = new CourseManager();
        var studentManager = new StudentManager(courseManager);
        var teacherManager = new TeacherManager(courseManager);

        var menu = new ConsoleMenu(courseManager, studentManager, teacherManager);
        menu.Run();
    }
}
