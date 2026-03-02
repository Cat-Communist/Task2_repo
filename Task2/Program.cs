using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;

namespace Task2
{
    public class Monetary
    {
        protected double dep_value;
        public void setValueFromLine()
        {
            try
            {
                // берём только 2 цифры после запятой
                double input = double.Parse(Console.ReadLine());
                this.dep_value = Math.Truncate(input * 100) / 100;
                if (this.dep_value <= 0)
                {
                    this.dep_value = 0;
                    throw new ArgumentOutOfRangeException();
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
        }
        public double getValue()
        {
            return this.dep_value;
        }
    }

    public class Deposit : Monetary
    {
        public Deposit() { }
        public Deposit(double value)
        {
            this.dep_value = value;
        }

        public void setValueFromLine(double value)
        {
            try
            {
                setValueFromLine();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Logic
    {
        private static DateOnly start_date = new DateOnly(2026, 3, 1);
        public static string incrGreater(double dep, double fin_incr)
        {
            for (int i = 0; ; i++)
            {
                double curr_incr = dep * 0.02;
                dep *= 1.02;
                if (curr_incr > fin_incr)
                    return start_date.AddMonths(i).ToString("MMMMMMMMMMM");
            }
        }
        public static int depGreater(double start_dep, double final_dep)
        {
            double dep = start_dep;
            for (int i = 0; ; i++)
            {
                dep *= 1.02;
                if (dep > final_dep)
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

            double start_deposit = 0; // Начальный вклад
            do
            {
                Console.Write("Вклад: ");
                try
                {
                    // берём только 2 цифры после запятой
                    double input = double.Parse(Console.ReadLine());
                    start_deposit = Math.Truncate(input * 100) / 100;
                    if (start_deposit <= 0)
                    {
                        start_deposit = 0;
                        throw new ArgumentOutOfRangeException();
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

            } while (start_deposit == 0);

            double final_increment = 0; // Увеличение суммы вклада
            do
            {
                Console.Write("Ежемесячное увеличение вклада, для которого ищем месяц: ");
                try
                {
                    // берём только 2 цифры после запятой
                    double input = double.Parse(Console.ReadLine());
                    final_increment = Math.Truncate(input * 100) / 100;
                    if (final_increment <= 0)
                    {
                        final_increment = 0;
                        throw new ArgumentOutOfRangeException();
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

            } while (final_increment == 0);

            double final_deposit = 0; // Конечная сумма вклада
            do
            {
                Console.Write("Конечная сумма вклада: ");
                try
                {
                    // берём только 2 цифры после запятой
                    double input = double.Parse(Console.ReadLine());
                    final_deposit = Math.Truncate(input * 100) / 100;
                    if (final_deposit <= 0)
                    {
                        final_deposit = 0;
                        throw new ArgumentOutOfRangeException();
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

            } while (final_deposit == 0);
            // КОНЕЦ взаимодействия с пользователем

            // НАЧАЛО логики
            string OutMsgforA = Logic.incrGreater(start_deposit, final_increment);
            string OutMsgforB = Logic.depGreater(start_deposit, final_deposit).ToString();
            // КОНЕЦ логики

            // НАЧАЛО взаимодействия с пользователем
            Console.WriteLine("а) " + OutMsgforA);
            Console.WriteLine("б) " + OutMsgforB);
        }
    }
}
