using System.Numerics;

namespace Calculate
{
    public class Calculator
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;
        public static int Divide(int x, int y) => x / y;

        public readonly IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations = new Dictionary<char, Func<int, int, int>>
        {
            ['+'] = Add, 
            ['-']= Subtract,
            ['*'] = Multiply,
            ['/']= Divide,
        };

        public bool TryCalculate(string input, out int output)
        {
            output = 0;
            if (string.IsNullOrEmpty(input))
                return false;

            string[] calc = input.Split(' ');
            if(calc.Length != 3 || !int.TryParse(calc[0], out int x) || !int.TryParse(calc[2], out int y)){
                return false;
            }

            if (MathematicalOperations.TryGetValue(calc[1][0],out var op))
            {
                output = op(x,y);
                return true;
            }

            return false;
        }
    }
}
