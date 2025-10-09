using SimpleCommands;

namespace Test
{
  [CommandName("hi", "h")]
  internal class HiCommand : Command
  {
    public override void Execute(string CommandName, string[] args)
    {
      Console.WriteLine("hi");
    }
  }
}
