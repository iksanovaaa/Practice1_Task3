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
                double x = CheckDouble("Введите х:");
                double y = CheckDouble("Введите y:");
                bool belongs = InRectangle(x, y) && !InTriangle(x, y);
                if (belongs) PrintTrue(x, y);
                else PrintFalse(x, y);
                end = CheckKey();
            } while (!end);
        }

        //проверка ввода действительного числа
        public static double CheckDouble(string s)
        {
            Console.WriteLine(s);
            double number;
            bool okay = false;
            do
            {
                okay = Double.TryParse(Console.ReadLine(), out number);
                if (!okay) Console.WriteLine("Некорретный формат входной строки. Повторите ввод вещественного числа.");
            } while (!okay);
            return number;
        }

        //проверка точки на принадлежность прямоугольной области
        public static bool InRectangle(double x, double y)
        {
            bool belongsRect = (y >= -2 && y <= 1) && (x >= -1 && x <= 1);
            return belongsRect;
        }

        //проверка точки на принадлежность треугольной области
        public static bool InTriangle(double x, double y)
        {
            bool belongsTr = (y > x) && (y > -x);
            return belongsTr;
        }

        //вывод сообщения в случае, если точка принадлежит заданной области
        public static void PrintTrue(double x, double y)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Точка ({0};{1}) принадлежит заданной области", x, y);
            Console.ResetColor();
        }

        //вывод сообщения в случае, если точка не принадлежит заданной области
        public static void PrintFalse(double x, double y)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Точка ({0};{1}) не принадлежит заданной области", x, y);
            Console.ResetColor();
        }

        //проверка на выход из программы
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

