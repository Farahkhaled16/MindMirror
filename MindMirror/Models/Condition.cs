namespace MindMirror.Models;

public class Condition
{
    public string Slug { get; set; } = "";
    public string Name { get; set; } = "";
    public string Icon { get; set; } = "💜";
    public string Summary { get; set; } = "";
    public string Overview { get; set; } = "";
    public string[] Signs { get; set; } = Array.Empty<string>();
    public string[] Causes { get; set; } = Array.Empty<string>();
    public string[] Treatment { get; set; } = Array.Empty<string>();
    public string[] SelfHelp { get; set; } = Array.Empty<string>();
    public string[] Support { get; set; } = Array.Empty<string>();
    public string SeekHelp { get; set; } = "";
    public bool Urgent { get; set; }
}