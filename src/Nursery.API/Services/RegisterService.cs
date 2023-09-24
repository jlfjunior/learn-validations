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

        //if true - Parent has been registered already.
        if (_personRepository.Exists(parent.CPF)) return false;

        _personRepository.Add(parent);

        return true;
    }

    public bool AddChild(ChildRequest request)
    {
        //If child has been registered already. return false
        if (_personRepository.Exists(request.CPF)) return false;

        //If father not found. return false
        if (!_personRepository.Exists(request.FatherId)) return false;

        //If mother not found. return false
        if (!_personRepository.Exists(request.MotherId)) return false;

        var child = new Child(request.CPF, request.Name, request.Address, request.FatherId, request.MotherId);
        
        _personRepository.Add(child);

        return true;
    }
}