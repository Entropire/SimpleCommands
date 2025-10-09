using System.Reflection;

namespace SimpleCommands
{
  public abstract class Command
  {
    public string[] CommandNames { get; private set; }

    protected Command()
    {
      var commandNameAttribute = GetType().GetCustomAttribute<CommandNameAttribute>();

      if (commandNameAttribute == null)
      {
        throw new InvalidOperationException(
            $"Class '{GetType().FullName}' must have a [CommandName] attribute.");
      }

      CommandNames = commandNameAttribute.CommandNames;
    }

    public abstract void Execute(string commandName, string[] commandArgs);
  }
}
