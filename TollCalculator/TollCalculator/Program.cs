using TollCalculatorLib;
using TollCalculatorLib.Model;

namespace TollCalculatorConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TollCalculator tollCalculator = new TollCalculator();


            var tollFee = tollCalculator.GetTollFee(new Car(), new DateTime[] { new DateTime(2021, 1, 1, 6, 0, 0), new DateTime(2021, 1, 1, 6, 30, 0), new DateTime(2021, 1, 1, 7, 0, 0) });

            Console.WriteLine($"Total fee for the day: {tollFee}");

            Console.ReadKey();
        }
    }
}
