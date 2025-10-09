namespace SimpleCommands
{
  /// <summary>
  /// Specifies the unique name of a <see cref="Command"/> class for use with <see cref="CommandHandler"/>.
  /// </summary>
  /// <remarks>
  /// Apply this attribute to any class that inherits from <see cref="Command"/> to define 
  /// the name under which the command will be registered and executed.
  /// The name must be unique across all registered commands.
  /// </remarks>
  [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
  public class CommandNameAttribute : Attribute
  {
    /// <summary>
    /// Gets the name of the command.
    /// </summary>
    public string[] Name { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandNameAttribute"/> class with the specified command name.
    /// </summary>
    /// <param name="name">The unique name of the command.</param>
    public CommandNameAttribute(string[] name)
    {
      Name = name;
    }
  }
}
