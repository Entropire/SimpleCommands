using System.Reflection;

namespace SimpleCommands
{
  public abstract class Command
  {
    public string[] Names { get; }

    protected Command()
    {
      var attribute = GetType().GetCustomAttribute<CommandNameAttribute>();

      if (attribute == null)
      {
        throw new InvalidOperationException(
            $"Class '{GetType().FullName}' must have a [CommandName] attribute.");
      }

      Names = attribute.Names;
    }

    public abstract void Execute(string CommandName, string[] args);
  }
}
