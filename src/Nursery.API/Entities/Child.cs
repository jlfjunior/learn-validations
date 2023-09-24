namespace Nursey.API.Entities;

public class Child : Person
{
    protected Child() { }

    public Child(string cpf, string name, string fatherId, string motherId, string address)
        : base(cpf, name, address)
    {
        if (string.IsNullOrEmpty(fatherId) || string.IsNullOrEmpty(motherId))
            throw new ArgumentException("Parents should be informed.");

        FatherId = fatherId;
        MotherId = motherId;
        Type = PersonType.Child;
    }

    public string FatherId { get; private set; }
    public string MotherId { get; private set; }
}