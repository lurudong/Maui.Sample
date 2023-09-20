using Maui.Platform.Model;
using System.Linq.Expressions;

namespace Maui.Platform.Seevices;

public interface IUserService
{
    Task AddUserAsync(string name, int age);
    Task<User[]> GetListUserAsync();

    Task<bool> ExistAsync(Expression<Func<User, bool>> expression);

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

    public async Task<bool> ExistAsync(Expression<Func<User, bool>> expression)
    {
        var count = await _databaseStorage.Database.Table<User>().Where(expression).CountAsync();
        return count == 0 ? false : true;
    }

    public async Task<User[]> GetListUserAsync()
    {

        return await _databaseStorage.Database.Table<User>().ToArrayAsync();

    }

}
