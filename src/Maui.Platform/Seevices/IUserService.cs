using Maui.Platform.Model;

namespace Maui.Platform.Seevices;

public interface IUserService
{
    Task AddUserAsync(string name, int age);
    Task<User[]> GetListUserAsync();

}

public class UserService : IUserService
{

    private readonly IDatabaseStorage _databaseStorage;

    public UserService(IDatabaseStorage databaseStorage)
    {
        _databaseStorage = databaseStorage;
    }

    public async Task AddUserAsync(string name, int age)
    {

        await _databaseStorage.Database.InsertAsync(new User(name, age));
    }

    public async Task<User[]> GetListUserAsync()
    {

        return await _databaseStorage.Database.Table<User>().ToArrayAsync();

    }

}
