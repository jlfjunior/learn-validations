using Nursey.API.Entities;

namespace Nursey.API.Data;

public class PersonRepository
{
    private readonly Context _context;

    public PersonRepository(Context context)
    {
        _context = context;
    }

    public void Add(Person person)
    {
        _context.People.Add(person);
        _context.SaveChanges();
    }

    public IEnumerable<Person> GetAll() => _context.People.ToList();

    public bool Exists(string cpf) => _context.People.Any(x => x.CPF == cpf);
}