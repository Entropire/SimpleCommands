using System.Reflection;

namespace SimpleCommands
{
  /// <summary>
  /// Represents a base class for all commands that can be registered 
  /// and executed via <see cref="CommandHandler"/>.
  /// </summary>
  /// <remarks>
  /// Each subclass must be decorated with a <see cref="CommandNameAttribute"/>,
  /// which defines the unique name under which the command will be registered.
  /// The <see cref="Name"/> property is automatically populated from the attribute.
  /// </remarks>
  public abstract class Command
  {
    /// <summary>
    /// Gets the unique name of the command, as specified by <see cref="CommandNameAttribute"/>.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class and
    /// ensures the derived class has a <see cref="CommandNameAttribute"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the derived class does not have a <see cref="CommandNameAttribute"/>.
    /// </exception>
    protected Command()
    {
      var attribute = GetType().GetCustomAttribute<CommandNameAttribute>();

      if (attribute == null)
      {
        throw new InvalidOperationException(
            $"Class '{GetType().FullName}' must have a [CommandName] attribute.");
      }

      Name = attribute.Name;
    }

    /// <summary>
    /// Executes the command logic.
    /// </summary>
    /// <param name="args">
    /// The arguments passed to the command during execution.
    /// </param>
    public abstract void Execute(string[] args);
  }
}
