namespace SimpleCommands
{
  [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
  public class CommandNameAttribute : Attribute
  {
    public string[] Names { get; }

    public CommandNameAttribute(string[] names)
    {
      Names = names;
    }
  }
}
