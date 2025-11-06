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

    public bool TryExecute(string name, string[] args)
    {
        if (!_commandRegistry.TryGetCommand(name, out Action<string, string[]>? commandAction))
        {
            return false;
        }

        commandAction?.Invoke(name, args);
        return true;
    }

    public bool TryExecute(string userInput)
    {
        if (!_commandInputParser.TryParseUserInput(userInput, out string commandName, out string[] commandArgs))
        {
            return false;
        }

        TryExecute(commandName, commandArgs);
        return true;
    }
}