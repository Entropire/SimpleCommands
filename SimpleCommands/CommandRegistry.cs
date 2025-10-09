namespace SimpleCommands;

public class CommandRegistry
{
  private Dictionary<string, Action<string, string[]>> dictionaryOfCommands = new();

  public void RegisterCommand(string commandName, Action<string, string[]> commandAction)
  {
    commandName = commandName.ToLowerInvariant();
    if (!dictionaryOfCommands.ContainsKey(commandName))
    {
      dictionaryOfCommands.Add(commandName, commandAction);
    }
    else
    {
      throw new InvalidOperationException($"Command '{commandName}' already exists.");
    }
  }

  public void RegisterCommand(Command command)
  {
    foreach (string commandName in command.Names)
    {
      RegisterCommand(commandName, command.Execute);
    }
  }

  public void UnregisterCommand(string commandName)
  {
    commandName = commandName.ToLowerInvariant();
    if (dictionaryOfCommands.ContainsKey(commandName))
    {
      dictionaryOfCommands.Remove(commandName);
    }
    else
    {
      throw new InvalidOperationException($"The command '{commandName}' does not exist.");
    }
  }

  public bool TryGetCommand(string commandName, out Action<string, string[]>? commandAction)
  {
    return dictionaryOfCommands.TryGetValue(commandName.ToLowerInvariant(), out commandAction);
  }
}
