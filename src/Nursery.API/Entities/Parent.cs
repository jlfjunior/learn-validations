namespace Nursey.API.Entities;

public class Parent : Person
{
    protected Parent() { }

    public Parent(string cpf, string name, string address)
        : base(cpf, name, address)
    {
        Type = PersonType.Parent;
    }
}