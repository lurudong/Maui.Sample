using SQLite;

namespace Maui.Platform.Model;

public sealed class User
{
    public User()
    {

    }
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    [PrimaryKey, AutoIncrement]
    public int Id { get; private set; }

    public string Name { get; init; }

    public int Age { get; init; }

}
