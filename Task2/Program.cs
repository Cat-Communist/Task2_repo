using System.Diagnostics;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;

namespace Task2
{
    public class Logic
    {
        private static DateOnly start_date = new DateOnly(2026, 3, 1);

        public static double ReadMoney()
        {
            var result = 0d;
            do
            {
                try
                {
                    // берём только 2 цифры после запятой
                    var input = double.Parse(Console.ReadLine());
                    result = Math.Truncate(input * 100) / 100;
                    if (result <= 0)
                    {
                        result = 0;
                        throw new ArgumentOutOfRangeException(nameof(result));
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (result == 0);
            return result;
        }

        public static string CalcIncrement(double dep, double fin_incr)
        {
            for (var i = 0; ; i++)
            {
                var curr_incr = Math.Round(dep * 0.02, 2);
                dep += curr_incr;
                if (curr_incr > fin_incr)
                    return start_date.AddMonths(i).ToString("MMMM");
            }
        }

        public static int CalcDeposit(double startDeposit, double finalDeposit)
        {
            if (startDeposit > finalDeposit)
                return 0;

            var currDeposit = startDeposit;
            for (var i = 1; ; i++)
            {
                currDeposit = Math.Round(currDeposit * 1.02, 2);
                if (currDeposit > finalDeposit)
                    return i;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /* Задание 15 
             * Гражданин 1 марта открыл счет в банке, вложив A (start_deposit) руб. Через каждый месяц размер вклада 
             * увеличивается на 2% от имеющейся суммы. Определить: а) за какой месяц (month) величина ежемесячного 
             * увеличения вклада превысит B (increment) руб.; б) через сколько месяцев размер вклада превысит C (final_deposit) руб.
             */
            // НАЧАЛО взаимодействия с пользователем
            Console.WriteLine("Гражданин 1 марта открыл счет в банке, вложив A руб. " +
                "Через каждый месяц размер вклада увеличивается на 2% от имеющейся суммы. Определить: \n" +
                "а) за какой месяц величина ежемесячного увеличения вклада превысит B руб.; \n" +
                "б) через сколько месяцев размер вклада превысит C руб");
            Console.WriteLine("Введите сумму вклада. Пример: 12000,34");

            Console.Write("Вклад: ");
            var start_deposit = Logic.ReadMoney();

            Console.Write("Ежемесячное увеличение вклада, для которого считаем месяц: ");
            var final_increment = Logic.ReadMoney();

            Console.Write("Конечное значение вклада, для которого вычисляем месяц: ");
            var final_deposit = Logic.ReadMoney();
            // КОНЕЦ взаимодействия с пользователем

            // НАЧАЛО логики
            var OutMsgforA = Logic.CalcIncrement(start_deposit, final_increment);
            var OutMsgforB = Logic.CalcDeposit(start_deposit, final_deposit).ToString();
            // КОНЕЦ логики

            // НАЧАЛО взаимодействия с пользователем
            Console.WriteLine("а) " + OutMsgforA);
            Console.WriteLine("б) " + OutMsgforB);
            // КОНЕЦ взаимодействия с пользователем
        }
    }
}