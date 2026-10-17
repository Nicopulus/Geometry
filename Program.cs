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
            Console.WriteLine($"Area: {rectangle1.Area()}");
            rectangle1.Height = -4; // This will trigger the validation in the setter
            Console.WriteLine(rectangle1.Description);

            var rectangle2 = new Rectangle(5, 2);
            Console.WriteLine($"Width: {rectangle2.Width}");
            Console.WriteLine($"Height: {rectangle2.Height}");
            Console.WriteLine($"Perimeter: {rectangle2.Perimeter()}");
            Console.WriteLine($"Area: {rectangle2.Area()}");
            Console.WriteLine(rectangle2.Description);

            var Person1 = new Person("Nicolás", 1988);
            //Console.WriteLine($"Person: {Person1.Name}, Age: {Person1.Age}");

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
            this._width = ValidateValue(width, nameof(width));
            this._height = ValidateValue(height, nameof(height));
        }
        public int Width
        {
            get => this._width;
            set
            {
                if (value > 0)
                {
                    this._width = value;
                }
                else
                {
                    Console.WriteLine($"Invalid value for {nameof(Width)}: {value}. Please enter a positive integer.");
                }
            }
        }
        public int Height
        {
            get => this._height;
            set
            {
                if (value > 0)
                {
                    this._height = value;
                }
                else
                {
                    Console.WriteLine($"Invalid value for {nameof(Height)}: {value}. Please enter a positive integer.");
                }
            }
        }
        public int Perimeter() => 2 * (this._width + this._height);
        public int Area() => this._width * this._height;
        public string Description => $"Rectangle with width {this._width} and height {this._height}.";
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

    class Person
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public int Age { get; set; }
        private Person(string name, int yearOfBirth, string lastName) : this(name, yearOfBirth)
        {
            this.LastName = lastName;
        }
        public Person(string name, int yearOfBirth)
        {
            this.Name = name;
            this.LastName = "";
            this.YearOfBirth = yearOfBirth;
            this.Age = DateTime.Now.Year - this.YearOfBirth;
            this.Introduce();
        }
        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {this.Name} {this.LastName} and I am {this.Age} years old.");
        }
    }
}
