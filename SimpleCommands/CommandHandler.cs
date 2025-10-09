namespace SimpleCommands
{
  public class CommandHandler
  {
    private static Dictionary<string, Action<string, string[]>> commandList = new Dictionary<string, Action<string, string[]>>();
    private string commandPrefix = "/";

    public void Register(string name, Action<string, string[]> action)
    {
      name = name.ToLower();
      if (!commandList.ContainsKey(name))
      {
        commandList.Add(name, action);
      }
      else
      {
        throw new InvalidOperationException($"Command '{name}' already exists.");
      }
    }

    public void Register(Command command)
    {
      foreach (string name in command.Names)
      {
        if (!commandList.ContainsKey(name))
        {
          commandList.Add(name, command.Execute);
        }
        else
        {
          throw new InvalidOperationException($"Command '{name}' already exists.");
        }
      }
    }

    public void Unregister(string name) {
      name = name.ToLower();
      if (commandList.ContainsKey(name)) {
        commandList.Remove(name);
      }
      else
      {
        throw new InvalidOperationException($"The command '{name}' does not exist.");
      }
    }

    public void Execute(string name, string[] args)
    {
      if (commandList.TryGetValue(name, out Action<string, string[]>? action))
      {
        action.Invoke(name, args);
      }
      else
      {
        throw new InvalidOperationException($"The command '{name}' does not exist.");
      }
    }

    public void Execute(string userInput)
    {
      if (!userInput.StartsWith(commandPrefix)) return;
    
      string[] args = userInput.Split(" ");
      string commandName = args[0].Substring(commandPrefix.Length);
      args = args.Skip(1).ToArray();

      if (commandList.TryGetValue(commandName, out Action<string, string[]>? action))
      {
        action.Invoke(commandName, args);
      }
      else
      {
        throw new InvalidOperationException($"The command '{commandName}' does not exist.");
      }
    }

    public void SetCommandPrefix(string commandPrefix)
    {
      this.commandPrefix = commandPrefix;
    }
  }
}