
namespace Copify.SpotifyModels;

public class Track
{
    public Item album{ get; set; }
    public Artist1[] artists { get; set; }
    public string[] available_markets { get; set; }
    public int disc_number { get; set; }
    public int duration_ms { get; set; }
    public bool _explicit { get; set; }
    public External_Ids external_ids { get; set; }
    public External_Urls2 external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public bool is_playable { get; set; }
    public Linked_From linked_from { get; set; }
    public Restrictions1 restrictions { get; set; }
    public string name { get; set; }
    public int popularity { get; set; }
    public string preview_url { get; set; }
    public int track_number { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public bool is_local { get; set; }
}

public class External_Urls
{
    public string spotify { get; set; }
}
public class External_Urls1
{
    public string spotify { get; set; }
}
public class External_Ids
{
    public string isrc { get; set; }
    public string ean { get; set; }
    public string upc { get; set; }
}

public class External_Urls2
{
    public string spotify { get; set; }
}

public class Linked_From
{
}
public class Restrictions1
{
    public string reason { get; set; }
}

public class Artist1
{
    public External_Urls3 external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class External_Urls3
{
    public string spotify { get; set; }
}
