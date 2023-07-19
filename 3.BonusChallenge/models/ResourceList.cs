using System.Collections.Generic;

public class ResourceList
{
    public IEnumerable<string> SimpleList { get; set; }
    public IEnumerable<IEnumerable<string>> SimpleListAnagramSorted { get; set; }
    public IEnumerable<string> HarderList { get; set; }
    public IEnumerable<IEnumerable<string>> HarderListAnagramSorted { get; set; }
}