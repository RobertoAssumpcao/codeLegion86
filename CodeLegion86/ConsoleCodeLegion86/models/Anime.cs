namespace ConsoleCodeLegion86;

public class Anime
{
    public IEnumerable<AnimeLists>? Lists { get; set; }
}

public class AnimeLists
{
    public string? Name { get; set; }
    public string? Status { get; set; }
    public IEnumerable<Entries>? Entries { get; set; }
}

public class Entries
{
    public string? Status { get; set; }
    public float Score { get; set; }
    public int Progress { get; set; }
    public int Repeat { get; set; }
    public string? Notes { get; set; }
    public Data? StartedAt { get; set; }
    public Data? CompletedAt { get; set; }
    public double UpdatedAt { get; set; }
    public double CreatedAt { get; set; }
    public Media? Media { get; set; }
}

public class Data
{
    public int? Day { get; set; }
    public int? Month { get; set; }
    public int? Year { get; set; }
}

public class Media
{
    public int Id { get; set; }
    public Title? Title { get; set; }
    public int? Episodes { get; set; }
}

public class Title
{
    public string? Romaji { get; set; }
    public string? English { get; set; }
    public string? Native { get; set; }
    public string? UserPreferred { get; set; }
}