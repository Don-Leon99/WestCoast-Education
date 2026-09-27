namespace WestCoastEducation;

public abstract class PersonManager<T> where T : Person
{
    protected readonly List<T> _people = new();

    public T? GetById (string id)
    {
        return _people.FirstOrDefault(p => p.Id == id);
    }

    public void ListAll()
    {
        foreach (var person in _people)
        {
            Console.WriteLine(person.GetInfo());
        }
    }

    public void Add(T person)
    {
        _people.Add(person);
    }

    public bool Remove(string id)
    {
        var person = GetById(id);
        if (person != null)
        {
            _people.Remove(person);
            return true;
        }
        else
        {
            Console.WriteLine("Couldn't find ID.");
        }
        return false;
    }
}
