# AspNetCoreAlertRP

I had used this before in numerous .Net 4.6 Framework apps using a BaseController class

Asp.Net Core 2.1 Web App Razor Pages that is an attempt to use James Chambers's alert services he created in a ASP.Net Monsters Video.
It was his solution to make Bootstrap Alerts that had been working in MVC working in Core.

I couldn't get the services solution that James created to work but I could get it to work using the BaseController class and code written byt Joshua C Garrison
Also I wanted an example of this written in **Razor Pages** (not MVC).

## Resources
- Joshua C Garrison [@JoshuaGarrison7](https://twitter.com/JoshuaGarrison7) wrote a blog [Complex Objects and TempData using .NET Core 2](https://dotnetevolved.com/2017/08/complex-objects-and-tempdata-using-net-core-2/)
- ASP.NET Monsters # 115: Creating Bootstrap Alerts with the ASP.NET Core MVC Framework, [YouTube](https://www.youtube.com/watch?v=Z8RstrIaeFA)

## Other Stuff
I'm new to using GitHub and so these are notes to help me do this in the future

### Tools 
- Cmder (console emulator) [install](http://cmder.net/) and references
- VS Code Integrated Terminal integration [docs](https://code.visualstudio.com/docs/editor/integrated-terminal#_can-i-use-cmders-shell-with-the-terminal-on-windows)

### dotnet CLI
- [ref](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet?tabs=netcore21)

### Managing a Repository Structure [blog](https://odetocode.com/blogs/scott/archive/2018/09/06/net-core-opinion-2-ndash-managing-a-repository-structure.aspx)
```
dotnet new sln # to create a sln file
dotnet new [template_name] -o [output path] # to create a project
dotnet sln [sln_name] add [csproj_name] # to add a project to a solutition.
```
