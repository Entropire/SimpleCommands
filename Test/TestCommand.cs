using SimpleCommands;

namespace Test
{
  [CommandName("test", "t")]
  internal class TestCommand : Command
  {
    public override void Execute(string CommandName, string[] args)
    {
      Console.WriteLine("test");
    }
  }
}
