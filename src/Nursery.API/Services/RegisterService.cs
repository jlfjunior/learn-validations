using Nursey.API.Entities;

namespace Nursey.API.Services;

public class RegisterService 
{
    
    public bool AddParent(PersonRequest person)
    {
        //TODO: Repositoty
        // if (person exist) return false;

        var parent = new Parent(person.CPF, person.Name, person.Address);

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