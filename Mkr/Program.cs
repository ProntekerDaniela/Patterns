using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr
{
    internal class Program
    {
        //Фабричний метод
        static void Main(string[] args)
        {
            Console.Write("A=");
            double A = Convert.ToDouble(Console.ReadLine());
            Console.Write("B=");
            double B = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Виберіть тип операції");
            Console.WriteLine("+");
            Console.WriteLine("*");
            Console.WriteLine("-");



            string operationType = Console.ReadLine();

            OperationFactory o = null;

            if (operationType == "+")
            {
                o = new AdditionFactory(A,B);
            }
            else if (operationType == "-")
            {
                o = new SubtractionFactory(A, B);
            }
            else if (operationType == "*")
            {
                o = new MultiplicationFactory(A, B);
            }


            IOperation op = o.GetOperation();
            double res = op.performOperation();
            Console.WriteLine($"{res}");
            Console.ReadLine();
        }
    }

    interface IOperation
    {
        double A {get; set; }
        double B { get; set; }
        double performOperation();
    }

    class Multiplication: IOperation
    {
        public double A { get; set; }
        public double B { get; set; }
        public Multiplication(double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public double performOperation()
        {
            return A * B;
        }
    }
    class Addition : IOperation
    {
        public double A { get; set; }
        public double B { get; set; }
        public Addition (double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public double performOperation()
        {
            return A + B;
        }
    }
    class Subtraction : IOperation
    {
        public double A { get; set; }
        public double B { get; set; }
        public Subtraction(double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public double performOperation()
        {
            return A - B;
        }
    }  
    internal abstract class OperationFactory
    {
        public abstract IOperation GetOperation();
    }
    class MultiplicationFactory : OperationFactory
    {
        public double A { get; set; }
        public double B { get; set; }
        public MultiplicationFactory(double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public override IOperation GetOperation()
        {
            Multiplication op = new Multiplication(A, B)
            {

            };
            return op;
        }
    }
    class AdditionFactory : OperationFactory
    {
        public double A { get; set; }
        public double B { get; set; }
        public AdditionFactory(double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public override IOperation GetOperation()
        {
            Addition op = new Addition(A, B)
            {

            };
            return op;
        }
    }
    class SubtractionFactory : OperationFactory
    {
        public double A { get; set; }
        public double B { get; set; }
        public SubtractionFactory(double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public override IOperation GetOperation()
        {
            Subtraction op = new Subtraction(A, B)
            {

            };
            return op;
        }
    }
    
}
