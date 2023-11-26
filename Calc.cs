using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_CSharp_3._5
{
    public interface ICalc
    {
        double Result { get; set; }
        void Sum(int x);
        void Sub(int x);
        void Multy(int x);
        void Divide(int x);
        void CancelLast();
        event EventHandler<EventArgs> MyEventHandler;
    }
    internal class Calc : ICalc
    {
        public double Result { get; set; } = 0D;
        private Stack<double> LastResult { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }


        public void Divide(int x)
        {
            Result /= x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Multy(int x)
        {
            Result *= x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Sub(int x)
        {
            Result -= x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Sum(int x)
        {
            Result += x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void CancelLast()
        {
            if (LastResult.TryPop(out double res))
            {
                Result = res;
                Console.WriteLine("Последнее действие отменено. Результат равен:");
                PrintResult();
            }
            else
            {
                Console.WriteLine("Невозможно отменить послдеднее действие!");
            }
        }

        public void View()
        {
            bool done = true;
            while (done)
            {
                Console.Write("Введите команду (+,-,*,/, undo, cancel):");
                var cmd = Console.ReadLine().ToLower();
                switch (cmd)
                {
                    case "+":
                        Console.Write("Введите слагаемое:");
                        Sum(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "-":
                        Console.Write("Введите вычитаемое:");
                        Sub(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "*":
                        Console.Write("Введите множитель:");
                        Multy(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "/":
                        Console.Write("Введите делитель:");
                        Divide(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "undo":
                        CancelLast();
                        break;
                    case "":
                    case "cancel":
                        done = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда!");
                        break;
                }
            }
        }
    }
}
