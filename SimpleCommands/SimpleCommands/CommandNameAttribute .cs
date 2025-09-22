namespace SimpleCommands
{
  [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
  public class CommandNameAttribute : Attribute
  {
    public string[] Names { get; }

    public CommandNameAttribute(params string[] names)
    {
      Names = names;
    }
  }
}
