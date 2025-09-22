<div id="toc" align="center"> 
  <ul style="list-style: none"> 
    <summary> 
      <h1>Simple Commands</h1> 
    </summary> 
  </ul> 
</div> 

--- 
## Description 
`SimpleCommands` provides a lightweight framework to create, register, and execute commands dynamically in C#. Commands can be registered either as **lambda functions** or as **dedicated classes** inheriting from `Command` with a unique `[CommandName]` attribute.

## Usage
### 1. Create a CommandHandler
```csharp
CommandHandler handler = new CommandHandler();
```

### 2.1. Registering a Command with a Lambda

```csharp
handler.Register("greet", args =>
{
    Console.WriteLine($"Hello, {args[0]}!");
});
```

### 2.2. Registering a Command with a Command Class
```csharp
[CommandName("greet")]
class GoodbyeCommand : Command
{
    public override void Execute(string[] args)
    {
        Console.WriteLine($"Hello, {args[0]}!");
    }
}
```

### 3. Unregistering a Command
```csharp
handler.Unregister("greet");
```

### 3. Execute a Command
```csharp
handler.Execute("greet");
```

## Getting Started

Follow these steps to use `SimpleCommands` in your project.

1. Download the `SimpleCommands.dll` from the releases tab.  
2. Create a folder in your project called `Libs` (or any name you prefer) and place the `SimpleCommands.dll` there: `YourProjectFolder/Libs/SimpleCommands.dll`
3. Open your project in Visual Studio.  
4. Right-click on the project in **Solution Explorer** → **Add** → **Reference…**  
5. Click **Browse**, navigate to the DLL location, select `SimpleCommands.dll`, and click **OK**.  
