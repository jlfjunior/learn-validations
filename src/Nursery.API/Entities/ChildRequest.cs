namespace Nursey.API.Entities;

public class ChildRequest : PersonRequest
{
    public string FatherId { get; set; }
    public string MotherId { get; set; }
}

public class UpdateParentsRequest
{
    public string FatherId { get; set; }
    public string MotherId { get; set; }
}  