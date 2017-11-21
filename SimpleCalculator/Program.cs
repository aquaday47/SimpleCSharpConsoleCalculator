using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Runner runner = new Runner();
            //runner.Run();
            Calculator calc = new Calculator();
            while (true)
            {

                calc.Values = calc.ReceiveValue();
                
                Console.WriteLine(" type 'add' for sum, 'sub' for subtract, " +
                    "'mult' for product, and 'div' for division; " +
                    "to quit, type 'quit'");
                string opToDoS = Console.ReadLine();
                if (opToDoS == "quit") { break; }
                OperationToPerform? tempOpToP = ConvertToEnum(opToDoS);
                if (tempOpToP != null)
                {
                    calc.OpToPerform = (OperationToPerform)tempOpToP;
                    calc.RunCalculation(calc.Values, calc.OpToPerform);
                }
                else
                {
                    Console.WriteLine("sorry error, try again");
                }
                //ok, so can I write an  extension method for enum ToDo, 
                //that parses the string here into a ToDo...
                
            }


        }

        private static OperationToPerform? ConvertToEnum(string opToDoS)
        {
            OperationToPerform? opHere;
            if (opToDoS == "add")
            {
                opHere = OperationToPerform.add;
            }
            else if (opToDoS == "sub")
            {
                opHere = OperationToPerform.sub;
            }
            else if (opToDoS == "mult")
            {
                opHere = OperationToPerform.mult;
            }
            else if (opToDoS == "div")
            {
                opHere = OperationToPerform.div;
            }
            else { opHere = null; }

            return opHere;
        }

        public enum OperationToPerform
        {
            add,
            sub,
            mult,
            div
        };

        public class Calculator
        {


            //could make calc a singelton, right?
            public Calculator()
            {

            }

            public OperationToPerform OpToPerform;
            public int[] Values;
            public double AddNum(double first, double sec)
            {
                double sum = first + sec;
                return sum;
            }

            public int[] ReceiveValue()
            {
                Console.WriteLine("enter 2 values separated by a space");
                Values = new int[2];
                string[] input = Console.ReadLine().Split(' ');
                for (int i = 0; i < input.Length; i++)
                {
                    Values[i] = int.Parse(input[i]);
                }
                return Values;
            }

            public void RunCalculation(int[] input, OperationToPerform operation)
            {


                switch (operation)
                {
                    case OperationToPerform.add:
                        Console.WriteLine(AddVals(input));
                        break;
                    case OperationToPerform.sub:
                        Console.WriteLine(SubVals(input));
                        break;
                    case OperationToPerform.mult:
                        Console.WriteLine(MultVals(input));
                        break;
                    case OperationToPerform.div:
                        Console.WriteLine(DivVals(input));
                        break;
                    default:
                        Console.WriteLine("I'm sorry, the option you typed " +
                            "is an invalid operation. Please use all lowercase, " +
                            "and omit the single quotes ");
                        break;
                }


            }

            private int DivVals(int[] input)
            {
                int div = input[0] / input[1];
                return div;
            }

            private int MultVals(int[] input)
            {
                int product = input[0] * input[1];
                return product;
            }

            private int AddVals(int[] inputs)
            {
                int sum = 0;
                foreach (int val in inputs)
                {

                    sum += val;
                }
                return sum;
            }
            private int SubVals(int[] input)
            {
                int diff = 0;
                int first = 0;
                first = input[0];
                diff = first - input[1];
                return diff;
            }
        }



    }
}

