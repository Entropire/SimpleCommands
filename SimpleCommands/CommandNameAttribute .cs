namespace SimpleCommands
{
  [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
  public class CommandNameAttribute : Attribute
  {
    public string[] CommandNames { get; private set; }

    public CommandNameAttribute(params string[] commandNames)
    {
      CommandNames = commandNames;
    }
  }
}
