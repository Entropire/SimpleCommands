namespace SimpleCommands
{
  public class CommandHandler
  {
    private static Dictionary<string, Action<string[]>> commandList = new Dictionary<string, Action<string[]>>();

    public void Register(string name, Action<string[]> action)
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

    public void Register(string name, Command command)
    {
      name = name.ToLower();
      if (!commandList.ContainsKey(name))
      {
        commandList.Add(name, command.Execute);
      }
      else
      {
        throw new InvalidOperationException($"Command '{name}' already exists.");
      }
    }

    public void Unregister(string name) {
      name = name.ToLower();
      if (!commandList.ContainsKey(name)) {
        commandList.Remove(name);
      }
      else
      {
        throw new InvalidOperationException($"The command '{name}' does not exist.");
      }
    }


    public void Execute(string name, string[] args)
    {
      if (commandList.TryGetValue(name, out Action<string[]>? action))
      {
        action.Invoke(args);
      }
      else
      {
        throw new InvalidOperationException($"The command '{name}' does not exist.");
      }
    }
  }
}