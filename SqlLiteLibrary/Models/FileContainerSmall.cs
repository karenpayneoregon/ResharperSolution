namespace SqlLiteLibrary.Models;

public class FileContainerSmall
{
    public int Id { get; }
    public string FirstPath { get; }

    public FileContainerSmall(int id, string firstPath)
    {
        Id = id;
        FirstPath = firstPath;
    }
}