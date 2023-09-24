namespace Nursey.API.Entities;

public abstract class Person
{
    protected Person() { }

    public Person(string cpf, string name, string address)
    {
        if (string.IsNullOrEmpty(cpf)) throw new ArgumentException(nameof(cpf), "CPF cannot be null or empty.");
        if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name), "Name cannot be null or empty.");
        if (string.IsNullOrEmpty(address)) throw new ArgumentException(nameof(address), "Address cannot be null or empty.");
        
        CPF = cpf;
        Name = name;
        Address = address;
    }

    public string CPF { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public PersonType Type { get; protected set; }
}