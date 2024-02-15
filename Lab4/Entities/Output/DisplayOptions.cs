namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;

public class DisplayOptions
{
    public DisplayOptions()
    {
        DirectoryIcon = "|--";
        FileIcon = "|--";
    }

    public string DirectoryIcon { get; private set; }
    public string FileIcon { get; private set; }

    public void SetOutputOptions(string fileIcon, string dirIcon)
    {
        FileIcon = fileIcon;
        DirectoryIcon = dirIcon;
    }
}