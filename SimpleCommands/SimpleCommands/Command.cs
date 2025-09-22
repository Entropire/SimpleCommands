using System.Reflection;

namespace SimpleCommands
{
  public abstract class Command
  {
    protected Command()
    {
      var attribute = GetType().GetCustomAttribute<CommandNameAttribute>();
      if (attribute == null)
      {
        throw new InvalidOperationException($"Class '{GetType().FullName}' must have a [CommandName] attribute.");
      }
    }

    public abstract void Execute(string[] args);
  }
}
