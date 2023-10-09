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
``` sh
CommunityToolkit.Maui
```
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

### 命令与事件关系
``` c#
1. 事件（Event）：

定义和用途： 事件是一种机制，用于处理用户界面元素（如按钮、文本框、滑块等）的交互操作。例如，你可以处理按钮的Click事件以在用户单击按钮时执行特定的操作。

触发方式： 事件通常是在用户执行特定交互操作时触发的。例如，Click事件在用户点击按钮时触发。

事件处理器： 你可以在代码中为事件注册事件处理器（event handler），这些事件处理器定义了事件触发时要执行的操作。

适用场景： 事件适用于处理用户界面元素的直接交互操作，例如按钮点击、文本框输入等。它们通常用于触发用户界面的响应性操作。
```
``` c#
2.命令（Command）：
定义和用途： 命令是一种更通用的机制，用于将用户界面元素的交互操作与执行的操作解耦。它们允许你将操作抽象为命令，然后将命令绑定到用户界面元素，以便触发操作。

触发方式： 命令可以通过各种方式触发，不仅限于用户界面元素的交互操作。它们可以通过按钮点击、菜单项选择、手势识别等方式触发。

命令处理器： 你可以为命令定义一个命令处理器（Command Handler），该处理器定义了命令被执行时要执行的操作。

适用场景： 命令适用于需要将交互操作与执行的操作分离的情况。它们通常用于实现MVVM（Model-View-ViewModel）架构中的命令绑定。

```
``` 总结：
事件用于处理用户界面元素的交互操作，
而命令用于将交互操作与执行的操作解耦。
选择使用事件还是命令取决于你的应用程序的需求和架构。
命令通常更适用于大型应用程序，
特别是使用MVVM模式的应用程序，
以实现更好的分离和可维护性。
但对于简单的用户界面操作，
事件可能更为直观和方便。

总之，命令通常用于需要分离交互和操作、支持多种触发方式、
具有复杂业务逻辑的情况下。
事件通常用于简单的用户界面交互和快速原型开发。
在实际应用中，你可能会同时使用命令和事件，
根据具体的场景和需求来选择最适合的方式。
最重要的是，根据应用程序的架构和可维护性需求来做出明智的选择。

```

基础
使用 TAP 时，应遵循以下一般准则：

- 了解由 `TaskStatus` 枚举表示的任务生命周期。 有关详细信息，请参阅 [TaskStatus 的含义](https://devblogs.microsoft.com/pfxteam/the-meaning-of-taskstatus/)和[任务状态](https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap#task-status)。
- 使用 `Task.WhenAll` 方法异步地等待多个异步操作完成，而不是使用 `await` 单独等待一系列异步操作。 有关详细信息，请参阅 [Task.WhenAll](https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern#taskwhenall)。
- 使用 `Task.WhenAny` 方法异步地等待多个异步操作中的一个操作完成。 有关详细信息，请参阅 [Task.WhenAny](https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern#taskwhenall)。
- 使用 `Task.Delay` 方法生成在指定时间后完成的 `Task` 对象。 对于轮询数据和将用户输入的处理延迟预定时间之类的场景，这非常有用。 有关详细信息，请参阅 [Task.Delay](https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern#taskdelay)。
- 使用 `Task.Run` 方法对线程池执行密集型同步 CPU 操作。 此方法是 `TaskFactory.StartNew` 方法的快捷方式，其中设置的参数最佳。 有关详细信息，请参阅 [Task.Run](https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern#taskrun)。
- 避免尝试创建异步构造函数。 请改用生命周期事件或单独的初始化逻辑，以使用 `await` 正确处理任何初始化。 有关详细信息，请参阅 blog.stephencleary.com 上的 [Async 构造函数](https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html)。
- 使用延迟任务模式，以避免在应用启动期间等待异步操作完成。 有关详细信息，请参阅 [AsyncLazy](https://devblogs.microsoft.com/pfxteam/asynclazyt/)。
- 通过创建 `TaskCompletionSource<T>` 对象，为不使用 TAP 的现有异步操作创建任务包装器。 这些对象获得 `Task` 可编程性的优点，并使你能够控制关联 `Task` 的生存期和完成。 有关详细信息，请参阅 [TaskCompletionSource 的性质](https://devblogs.microsoft.com/pfxteam/the-nature-of-taskcompletionsourcetresult/)。
- 当无需处理异步操作的结果时，返回 `Task` 对象，而不是返回等待的 `Task` 对象。 由于执行的上下文切换较少，因此性能更高。
- 在数据可用时处理数据，或在你有多个必须以异步方式彼此通信的操作等场景下，使用任务并行库 (TPL) 数据流库。 有关详细信息，请参阅[数据流（任务并行库）](https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/dataflow-task-parallel-library)。