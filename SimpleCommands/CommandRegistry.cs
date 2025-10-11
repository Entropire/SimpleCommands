namespace SimpleCommands;

public class CommandRegistry
{
    private Dictionary<string, Action<string, string[]>> dictionaryOfCommands = new(StringComparer.OrdinalIgnoreCase);

  public void RegisterCommand(Action<string, string[]> commandAction, params string[] commandNames)
  {
        foreach (string commandName in commandNames)
        {
            if (!dictionaryOfCommands.ContainsKey(commandName))
            {
                dictionaryOfCommands.Add(commandName, commandAction);
            }
            else
            {
                throw new InvalidOperationException($"Command '{commandName}' already exists.");
            }
        }
  }

  public void RegisterCommand(Command command)
  {
    RegisterCommand(command.Execute, command.CommandNames);
  }

  public void UnregisterCommand(string commandName)
  {
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
      => dictionaryOfCommands.TryGetValue(commandName, out commandAction);
}
