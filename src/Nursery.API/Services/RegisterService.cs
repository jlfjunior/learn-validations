using Nursey.API.Entities;
using Nursey.API.Repositories;

namespace Nursey.API.Services;

public class RegisterService 
{
    private readonly PersonRepository _personRepository;

    public RegisterService(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    public bool AddParent(PersonRequest person)
    {
        var parent = new Parent(person.CPF, person.Name, person.Address);

        if (_personRepository.Exists(parent.CPF)) return false;

        _personRepository.Add(parent);

        return true;
    }

    public bool AddChild(ChildRequest person)
    {
        //TODO: Repositoty
        // if (person exist) return false;

        var parent = new Parent(person.CPF, person.Name, person.Address);

        return true;
    }
}