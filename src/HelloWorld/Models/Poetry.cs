using SQLite;

namespace HelloWorld.Models;

public class Poetry
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}