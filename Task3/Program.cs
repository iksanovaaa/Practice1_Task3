using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 59(з). Даны действительные числа х, у. Определить, принадлежит ли точка с координатами (х, у) заштрихованной части плоскости
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            do
            {
                Console.WriteLine("Введите х:");
                double x = CheckDouble();
                Console.WriteLine("Введите y:");
                double y = CheckDouble();
                bool belongs = InRectangle(x, y) && !InTriangle(x, y);
                if (belongs) PrintTrue(x, y);
                else PrintFalse(x, y);
                end = CheckKey();
            } while (!end);
        }

        public static double CheckDouble()
        {
            double number;
            bool okay = false;
            do
            {
                okay = Double.TryParse(Console.ReadLine(), out number);
                if (!okay) Console.WriteLine("Некорретный формат входной строки. Повторите ввод вещественного числа.");
            } while (!okay);
            return number;
        }
        public static bool InRectangle(double x, double y)
        {
            bool belongsRect = (y >= -2 && y <= 1) && (x >= -1 && x <= 1);
            return belongsRect;
        }
        public static bool InTriangle(double x, double y)
        {
            bool belongsTr = (y > x) && (y > -x);
            return belongsTr;
        }
        public static void PrintTrue(double x, double y)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Точка ({0};{1}) принадлежит заданной области", x, y);
            Console.ResetColor();
        }
        public static void PrintFalse(double x, double y)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Точка ({0};{1}) не принадлежит заданной области", x, y);
            Console.ResetColor();
        }
        public static bool CheckKey()
        {
            bool next, end = false;
            int keyNum;
            Console.WriteLine("Для выхода из программы нажмите Esc, для проверки другой точки нажмите Enter.");
            do
            {
                keyNum = Console.ReadKey().KeyChar;
                next = (keyNum == 27) || (keyNum == 13);
            } while (!next);
            if (keyNum == 27) end = true;
            else Console.Clear();
            return end;
        }
    }
}

