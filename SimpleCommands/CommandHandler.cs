namespace SimpleCommands
{
  /// <summary>
  /// Provides a simple command management system that allows you to 
  /// register, execute, and unregister commands at runtime.
  /// </summary>
  /// <remarks>
  /// Commands can be registered either by specifying a unique name and a 
  /// delegate (<see cref="Action{T}"/>), or by providing a class that 
  /// inherits from <see cref="Command"/> and is decorated with a 
  /// <see cref="CommandNameAttribute"/>.
  /// <para>
  /// This enables flexible command handling where commands can be 
  /// dynamically added, removed, or executed based on their names.
  /// </para>
  /// </remarks>
  public class CommandHandler
  {
    private static Dictionary<string, Action<string, string[]>> commandList = new Dictionary<string, Action<string, string[]>>();

    /// <summary>
    /// Registers a new command with the <see cref="CommandHandler"/>.
    /// </summary>
    /// <param name="name">
    /// The unique name of the command. This is the identifier used to 
    /// execute or unregister the command later.
    /// </param>
    /// <param name="action">
    /// The delegate (callback) that will be executed when the command 
    /// is invoked. The string array contains the arguments passed at runtime.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if a command with the same name has already been registered.
    /// </exception>
    public void Register(string name, Action<string, string[]> action)
    {
      name = name.ToLower();
      if (!commandList.ContainsKey(name))
      {
        commandList.Add(name, action);
      }
      else
      {
        throw new InvalidOperationException($"Command '{name}' already exists.");
      }
    }

    /// <summary>
    /// Registers a new command instance with the <see cref="CommandHandler"/>.
    /// </summary>
    /// <param name="command">
    /// The <see cref="Command"/> instance to register. The command must have a 
    /// <see cref="CommandNameAttribute"/> applied to its class in order to determine 
    /// the unique name under which it will be registered.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the command does not have a <see cref="CommandNameAttribute"/> 
    /// or if a command with the same name has already been registered.
    /// </exception>
    public void Register(Command command)
    {
      string name = command.Name.ToLower();
      if (!commandList.ContainsKey(name))
      {
        commandList.Add(name, command.Execute);
      }
      else
      {
        throw new InvalidOperationException($"Command '{command.Name}' already exists.");
      }
    }

    /// <summary>
    /// Unregisters a previously registered command from the <see cref="CommandHandler"/>.
    /// </summary>
    /// <param name="name">
    /// The unique name of the command to unregister
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the specified command does not exist in the handler.
    /// </exception>
    public void Unregister(string name) {
      name = name.ToLower();
      if (commandList.ContainsKey(name)) {
        commandList.Remove(name);
      }
      else
      {
        throw new InvalidOperationException($"The command '{name}' does not exist.");
      }
    }

/// <summary>
/// Executes a registered command by its name.
/// </summary>
/// <param name="name">
/// The unique name of the command to execute. Must match the name used when the command was registered.
/// </param>
/// <param name="args">
/// The arguments to pass to the command’s execution logic. Can be an empty array if the command does not require arguments.
/// </param>
/// <exception cref="InvalidOperationException">
/// Thrown if the specified command does not exist in the <see cref="CommandHandler"/>
/// </exception>
    public void Execute(string name, string[] args)
    {
      if (commandList.TryGetValue(name, out Action<string, string[]>? action))
      {
        action.Invoke(name, args);
      }
      else
      {
        throw new InvalidOperationException($"The command '{name}' does not exist.");
      }
    }
  }
}