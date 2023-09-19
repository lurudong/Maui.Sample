using SQLite;

namespace Maui.Platform.Seevices;

public sealed class DatabaseImp : IDatabaseStorage
{
    public SQLiteAsyncConnection Database { get; private set; }
    public DatabaseImp(SQLiteAsyncConnection database)
    {
        Database = database;
    }
}


public interface IDatabaseStorage
{
    /// <summary>
    /// 数据库
    /// </summary>
    SQLiteAsyncConnection Database { get; }


}