using System.Reflection.Metadata;

namespace Task2
{
    public class Logic
    {
        public Logic() { }
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

            Console.WriteLine("Введите сумму вклада. Пример: 12000,43");
            float start_deposit = 0;
            do
            {
                Console.Write("Вклад: ");
                try
                {
                    string test_string = Console.ReadLine();
                    if (start_deposit <= 0)
                    {
                        start_deposit = 0;
                        throw new ArgumentOutOfRangeException(nameof(start_deposit), "Начальный вклад должен быть положительным вещественным числом");
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
            // TODO: Нужно проверять чтобы было 2 знака после запятой (либо ограничить ввод, либо обрезать просто)
            Console.WriteLine(start_deposit);
        }
    }
}
