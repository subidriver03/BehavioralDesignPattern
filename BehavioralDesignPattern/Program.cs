// Design Pattern: Strategy Pattern
// Type: Behavioral
// Examples of why it might be needed:
// The Strategy Pattern allows you to define a family of algorithms, encapsulate each one, and make them interchangeable.
// It lets the algorithm vary independently from clients that use it. This is useful when you have multiple ways of
// performing an operation and want to choose the algorithm at runtime.
// Link to UML Diagram:
// https://refactoring.guru/images/patterns/diagrams/strategy/structure.png
// Why I found it interesting and where I might use it in the future:
// I found the Strategy Pattern interesting because it promotes flexibility and reusability by allowing the selection of algorithms at runtime without modifying the client code.
// I might use it in the future for applications that require different sorting methods, payment processing strategies,
// or any system where behavior can change dynamically.

using System;

namespace StrategyPatternExample
{
    interface IStrategy
    {
        double Execute(int a, int b);
    }

    class AdditionStrategy : IStrategy
    {
        public double Execute(int a, int b)
        {
            return a + b;
        }
    }

    class SubtractionStrategy : IStrategy
    {
        public double Execute(int a, int b)
        {
            return a - b;
        }
    }

    class MultiplicationStrategy : IStrategy
    {
        public double Execute(int a, int b)
        {
            return a * b;
        }
    }

    class DivisionStrategy : IStrategy
    {
        public double Execute(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Error: Division by zero");
                return double.NaN;
            }
            return (double)a / b;
        }
    }

    class CalculatorContext
    {
        private IStrategy _strategy;

        public CalculatorContext(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public double Calculate(int a, int b)
        {
            return _strategy.Execute(a, b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 10;

            CalculatorContext context = new CalculatorContext(new AdditionStrategy());
            Console.WriteLine("Addition Result: " + context.Calculate(a, b)); 

            context.SetStrategy(new SubtractionStrategy());
            Console.WriteLine("Subtraction Result: " + context.Calculate(a, b)); 

            context.SetStrategy(new MultiplicationStrategy());
            Console.WriteLine("Multiplication Result: " + context.Calculate(a, b));  

            context.SetStrategy(new DivisionStrategy());
            Console.WriteLine("Division Result: " + context.Calculate(a, b));  

            b = 0;
            Console.WriteLine("Division by zero test:");
            Console.WriteLine("Division Result: " + context.Calculate(a, b));  
        }
    }
}
