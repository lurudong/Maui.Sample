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
官网文档:
```
https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/introduction

https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/mvvm/
```
``` C#
public class MainPageViewModel:ObservableObject
{

}
ViewModel 必须继承 ObservableObject
```
