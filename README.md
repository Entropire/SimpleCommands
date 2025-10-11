<div id="toc" align="center"> 
  <ul style="list-style: none"> 
    <summary> 
      <h1>Simple Commands</h1> 
    </summary> 
  </ul> 
</div> 

---
## Description 
`SimpleCommands` is a lightweight C# framework for creating, registering, and executing commands dynamically. It is ideal for quickly building CLI tools, prototypes, or any application that requires command-based input.

The framework supports defining commands either via class inheritance or lambda expressions, giving you flexibility in how you structure your commands. Additionally, it provides an easy way to switch between command handlers, allowing you to change the active set of commands dynamically.

## Features
- Safe registration and unregistration of commands
- Flexible command parsing with customizable prefixes
- Support for commands via class inheritance or lambda expressions 
- Case-insensitive command lookup
- Easy to use command execution system execute commands directly by name or parse user input automatically.

## Usage
### 1. Instantiate a new CommandHandler
```cs
CommandHandler handler = new CommandHandler("/"); 
```

### 2. Register Commands
Commands can be registered in two ways:

#### a) Use a inline action
```cs
handler.RegisterCommand((name, args) =>
{
    Console.WriteLine($"Executed command '{name}' with arguments: {string.Join(", ", args)}");
}, "echo", "say");
```

#### b) Use a command class
```cs
[CommandName("greet", "hello")]
public class GreetCommand : Command
{
    public override void Execute(string commandName, string[] commandArgs)
    {
        Console.WriteLine($"Hello, {string.Join(' ', commandArgs)}!");
    }
}

// Register it
handler.RegisterCommand(new GreetCommand());
```

### 3. Executing commands
You can execute commands manually by name and arguments:
```cs
handler.Execute("echo", new[] { "Hello", "World" });
```
Or automatically by parsing user input:
```cs
string userInput = console.readline() ?? "";
handler.Execute(userInput);
```

### Removing a command
```cs
handler.UnregisterCommand("echo");
```

## Getting Started

Follow these steps to use `SimpleCommands` in your project.

1. Download the `SimpleCommands.dll` from the releases tab.  
2. Create a folder in your project called `Libs` (or any name you prefer) and place the `SimpleCommands.dll` there: `YourProjectFolder/Libs/SimpleCommands.dll`
3. Open your project in Visual Studio.  
4. Right-click on the project in **Solution Explorer** → **Add** → **Reference…**  
5. Click **Browse**, navigate to the DLL location, select `SimpleCommands.dll`, and click **OK**.

## License
> MIT License
> 
> Copyright (c) 2025 Entropire
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy
> of this software and associated documentation files (the "Software"), to deal
> in the Software without restriction, including without limitation the rights
> to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
> copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all
> copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
> IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
> FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
> AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER

