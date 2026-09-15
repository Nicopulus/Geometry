using System.ComponentModel.Design;

namespace Geometry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rectangle1 = new Rectangle(-1, 3);
            Console.WriteLine($"Width: {rectangle1.Width}");
            Console.WriteLine($"Height: {rectangle1.Height}");
            Console.WriteLine($"Perimeter: {rectangle1.Perimeter()}");
            Console.WriteLine($"Area: {rectangle1.Area()}\n");
            rectangle1.Height = -4; // This will trigger the validation in the setter

            var rectangle2 = new Rectangle(5, 2);
            Console.WriteLine($"Width: {rectangle2.Width}");
            Console.WriteLine($"Height: {rectangle2.Height}");
            Console.WriteLine($"Perimeter: {rectangle2.Perimeter()}");
            Console.WriteLine($"Area: {rectangle2.Area()}\n");


            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
    public class Rectangle
    {
        const int NumberOfSides = 4;
        readonly int NumberOfSidesReadOnly;
        private int _width;
        private int _height;

        public Rectangle(int width = 1, int height = 1)
        {
            NumberOfSidesReadOnly = 4;
            _width = ValidateValue(width, nameof(width));
            _height = ValidateValue(height, nameof(height));
        }
        public int Width
        {
            get => _width;
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    Console.WriteLine($"Invalid value for {nameof(Width)}: {value}. Please enter a positive integer.");
                }
            }
        }
        public int Height
        {
            get => _height;
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    Console.WriteLine($"Invalid value for {nameof(Height)}: {value}. Please enter a positive integer.");
                }
            }
        }
        public int Perimeter() => 2 * (_width + _height);
        public int Area() => _width * _height;
        
        private int ValidateValue(int value, string paramName)
        {
            const int defaultValueIfNonPositive = 1;
            if (value <= 0)
            {
                //throw new ArgumentException("Value must be greater than zero.");
                Console.WriteLine($"Invalid value for {paramName}: {value}. Using default value: {defaultValueIfNonPositive}.");
                return defaultValueIfNonPositive;
            }
            return value;
        }
    }
}
