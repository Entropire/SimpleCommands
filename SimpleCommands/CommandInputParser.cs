namespace SimpleCommands;

internal class CommandInputParser
{
  public string CommandPrefix { get; private set; }

  public CommandInputParser(string commandPrefix = "/")
  {
    CommandPrefix = commandPrefix;
  }

  public void SetPrefix(string commandPrefix)
  {
    CommandPrefix = commandPrefix;
  }

  public bool TryParseUserInput(string userInput, out string commandName, out string[] commandArgs)
  {
    commandName = string.Empty;
    commandArgs = Array.Empty<string>();

    if (string.IsNullOrWhiteSpace(userInput) || !userInput.StartsWith(CommandPrefix))
      return false;

    string[] parts = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    commandName = parts[0].Substring(CommandPrefix.Length).ToLowerInvariant();
    commandArgs = parts.Skip(1).ToArray();
    return true;
  }
}
