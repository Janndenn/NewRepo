public class apicountryinfo
{
    public Name Name { get; set; }
    public string Cca2 { get; set; }
    public List<string> Capital { get; set; }
    public Idd Idd { get; set; }
    public Flags Flags { get; set; }
    public string Region { get; set; }
    public List<string> Timezones { get; set; }
}

public class Name
{
    public string Common { get; set; }
}

public class Idd
{
    public string Root { get; set; }
    public List<string> Suffixes { get; set; }
}

public class Flags
{
    public string Png { get; set; }
}
