namespace SimpleCommands;

internal class CommandInputParser
{
  public string commandPrefix { get; private set; }

  public CommandInputParser(string commandPrefix = "/")
  {
    this.commandPrefix = commandPrefix;
  }

  public void SetPrefix(string commandPrefix)
  {
    this.commandPrefix = commandPrefix;
  }

  public bool TryParseUserInput(string userInput, out string commandName, out string[] commandArgs)
  {
    commandName = string.Empty;
    commandArgs = Array.Empty<string>();

    if (string.IsNullOrWhiteSpace(userInput) || !userInput.StartsWith(commandPrefix))
      return false;

    string[] parts = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    commandName = parts[0].Substring(commandPrefix.Length).ToLowerInvariant();
    commandArgs = parts.Skip(1).ToArray();
    return true;
  }
}
