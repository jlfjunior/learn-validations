namespace Nursey.API.Entities;

public abstract class Person
{
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
}

public class Parent : Person
{
    public Parent(string cpf, string name, string address)
        : base(cpf, name, address)
    {
        
    }
}

public class Child : Person
{
    public Child(string cpf, string name, string fatherId, string motherId, string address)
        : base(cpf, name, address)
    {
        if (string.IsNullOrEmpty(fatherId) || string.IsNullOrEmpty(motherId))
            throw new ArgumentException("Parents should be informed.");

        FatherId = fatherId;
        MotherId = motherId;
    }

    public string FatherId { get; private set; }
    public string MotherId { get; private set; }
}