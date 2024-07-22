using ASPRestAPI.Models;

namespace ASPRestAPI.Services;

public static class PersonService
{
    static List<Person> Persons { get; }
    static int nextId = 3;

    static PersonService()
    {
        Persons =
        [
            new Person { Id = 1, Name = "Eric Rojas", IsActive = true },
            new Person { Id = 2, Name = "Valeria Gómez", IsActive = false }
        ];
    }

    public static List<Person> GetAll() => Persons;

    public static Person? Get(int id) => Persons.FirstOrDefault(p => p.Id == id);

    public static void Add(Person person)
    {
        person.Id = nextId++;
        Persons.Add(person);
    }

    public static void Delete(int id)
    {
        var person = Get(id);
        if(person is null)
            return;

        Persons.Remove(person);
    }

    public static void Update(Person person){
        var index = Persons.FindIndex(p => p.Id == person.Id);
        if(index == -1)
            return;
        
        Persons[index] = person;
    }
}