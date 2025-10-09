namespace SimpleCommands;

public class CommandHandler
{
  private CommandRegistry commandRegistry;
  private CommandInputParser commandInputParser;

  public CommandHandler(string commandPrefix)
  {
    commandRegistry = new CommandRegistry();
    commandInputParser = new CommandInputParser(commandPrefix);
  }

  public void RegisterCommand(string commandName, Action<string, string[]> commandAction) 
    => commandRegistry.RegisterCommand(commandName, commandAction);

  public void RegisterCommand(Command command) => commandRegistry.RegisterCommand(command);

  public void UnregisterCommand(string commanName) => commandRegistry.UnregisterCommand(commanName);

  public void Execute(string name, string[] args)
  {
    if (!commandRegistry.TryGetCommand(name, out Action<string, string[]> commandAction))
    {
      throw new InvalidOperationException($"The command '{name}' does not exist.");
    }

    commandAction.Invoke(name, args);
  }

  public void Execute(string userInput)
  {
    if (!commandInputParser.TryParseUserInput(userInput, out string commandName, out string[] commandArgs))
    {
      throw new InvalidOperationException($"The command '{commandName}' does not exist.");
    }

    Execute(commandName, commandArgs);
  }
}