namespace HW_CSharp_3._5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var calc = new Calc();
            calc.MyEventHandler += Calc_MyEventHandler;
            calc.View();
        }

        private static void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)
                Console.WriteLine(((Calc)sender).Result);
        }
    }
}