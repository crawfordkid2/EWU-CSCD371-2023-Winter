namespace Calculate;
public class Program
{
    public Action<string> WriteLine { get; init; } = x => Console.WriteLine(x);
    public Func<string?> ReadLine { get; init; } = () => Console.ReadLine();

    public Program() { }

    public static void Main()
    {
        Program program = new ();
        Calculator calc = new ();

        while (true)
        {
            program.WriteLine("Type a Mathmatical Equation using whole numbers\n" +
                "(Ex: x + y, x - y, x * y, x / y)\n" +
                "make sure to put a space between characters and symbols");
            var input = program.ReadLine();
            if (string.IsNullOrEmpty(input))
                break;

            if (calc.TryCalculate(input, out var result))
            {
                program.WriteLine($"Result is: {result}");
            }
            else
            {
                program.WriteLine("Invalid input");
            }
        }
    }
}
