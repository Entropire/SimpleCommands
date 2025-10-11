using SimpleCommands;

namespace Test
{
  internal class Program
  {
    static CommandHandler cmdh = new CommandHandler("/");
    static CommandHandler cmdh2 = new CommandHandler("!");
    static void Main(string[] args)
    {
      cmdh.RegisterCommand(new TestCommand());
      cmdh2.RegisterCommand(new HiCommand());

      string input;
      while (true)
      {
        input = Console.ReadLine() ?? "";
        cmdh.Execute(input);
        cmdh2.Execute(input);
      }
    }
  }
}
