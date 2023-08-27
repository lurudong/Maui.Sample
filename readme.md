跟上现在思想。
## AppShell是什么
.NET 多平台应用 UI (.NET MAUI) Shell 通过提供大多数应用所需的基本功能来降低应用开发的复杂性，包括：

用于描述应用的视觉层次结构的单个位置。
常见的导航用户体验。
一种基于 URI 的导航方案，允许导航到应用中的任何页面。
集成的搜索处理程序。

## 官网MVVM工具包
它是一个现代、快速且模块化的 MVVM 库

### 添加MVVM包
``` sh
dotnet add package CommunityToolkit.Mvvm --version 8.2.1
```
### Maui社区工具包
https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/maui/

官网文档:
```
https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/introduction

https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/mvvm/
```
``` C#
public partial class MainPageViewModel:ObservableObject
{
    [ObservableProperty]
    private string _result = string.Empty;

     [RelayCommand]
    public void ClickMe()
    {
        Result = "Hello World";
    }
}
ViewModel 必须继承 
 [ObservableProperty] 生成属性
 [RelayCommand] 生成命令事件
使用特性让代码更简洁
```

### ORM
https://github.com/praeclarum/sqlite-net
``` sh
Install sqlite-net-pcl from NuGet.
```
``` C#
public class Stock
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Symbol { get; set; }
}

    private const string DbFileName = "poetrydb.sqlite3";
    //当前程序安全读取
    private static readonly string BbPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.
            LocalApplicationData), DbFileName);

var db = new SQLiteConnection(BbPath);
db.CreateTable<Stock>();

这个在ios上和android上会报错
```


假如要在ios上和android上都要创建数据库
还需要添加 `dotnet add package SQLitePCLRaw.bundle_green --version 2.1.6`
具体代码请看官网文档 https://learn.microsoft.com/zh-cn/dotnet/maui/data-cloud/database-sqlite

