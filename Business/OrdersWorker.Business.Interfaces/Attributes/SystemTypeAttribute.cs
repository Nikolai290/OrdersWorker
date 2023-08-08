namespace OrderWorker.Business.Interfaces.Attributes;

public class SystemTypeAttribute : Attribute
{
    public string SystemType { get; set; }

    public SystemTypeAttribute(string systemType)
    {
        SystemType = systemType;
    }

    public override string ToString()
    {
        return SystemType.ToLower();
    }
}