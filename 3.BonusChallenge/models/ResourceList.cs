using System.Collections.Generic;

public class ResourceList
{
    public IEnumerable<IEnumerable<string>> SimpleList { get; set; }
    public IEnumerable<IEnumerable<string>> HarderList { get; set; }
}