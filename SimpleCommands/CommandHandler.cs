namespace SimpleCommands;

public class CommandHandler
{
  private CommandRegistry _commandRegistry;
  private CommandInputParser _commandInputParser;

  public CommandHandler(string commandPrefix)
  {
    _commandRegistry = new CommandRegistry();
    _commandInputParser = new CommandInputParser(commandPrefix);
  }

  public void RegisterCommand(Action<string, string[]> commandAction, params string[] commandNames) 
    => _commandRegistry.RegisterCommand(commandAction, commandNames);

  public void RegisterCommand(Command command) => _commandRegistry.RegisterCommand(command);

  public void UnregisterCommand(string commanName) => _commandRegistry.UnregisterCommand(commanName);

  public void Execute(string name, string[] args)
  {
        if (!_commandRegistry.TryGetCommand(name, out Action<string, string[]> commandAction))
    {
      return;
    }

    commandAction.Invoke(name, args);
  }

  public void Execute(string userInput)
  {
    if (!_commandInputParser.TryParseUserInput(userInput, out string commandName, out string[] commandArgs))
    {
      return;
    }

    Execute(commandName, commandArgs);
  }
}