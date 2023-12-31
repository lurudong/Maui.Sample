﻿using HelloWorld.Models;
using SQLite;

namespace HelloWorld.Services;

public interface IPoetryStorage
{
    Task InitializeAsync();

    Task AddAsync(Poetry poetry);


    Task<IEnumerable<Poetry>> GetAllAsync();

    Task RemoveAsync(Poetry poetry);
}

public class PoetryStorage : IPoetryStorage
{
    //private const string DbFileName = "poetrydb.sqlite3";
    ////当前程序安全读取
    //private static readonly string BbPath = Path.Combine(
    //    Environment.GetFolderPath(Environment.SpecialFolder.
    //        LocalApplicationData), DbFileName);
    //private SQLiteAsyncConnection _connection;
    //public SQLiteAsyncConnection Connection => _connection ??= new SQLiteAsyncConnection(BbPath);

    //https://learn.microsoft.com/zh-cn/dotnet/maui/data-cloud/database-sqlite

    public const string DatabaseFilename = "poetrydb.db3";
    public static string DatabasePath =>
    Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;
    private SQLiteAsyncConnection _connection;

    public SQLiteAsyncConnection Connection => _connection ??= new SQLiteAsyncConnection(DatabasePath, Flags);


    public Task InitializeAsync()
    {

        //创建数据库
        return Connection.CreateTableAsync<Poetry>();
    }

    public Task AddAsync(Poetry poetry)
    {
        return Connection.InsertAsync(poetry);
    }

    public async Task<IEnumerable<Poetry>> GetAllAsync()
    {
        return await Connection.Table<Poetry>().ToListAsync();
    }



    public Task RemoveAsync(Poetry poetry)
    {

        return Connection.DeleteAsync(poetry);
    }
}

