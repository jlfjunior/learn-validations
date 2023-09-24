namespace Nursey.API.Requests;

public class ChildRequest : PersonRequest
{
    public string FatherId { get; set; }
    public string MotherId { get; set; }
}