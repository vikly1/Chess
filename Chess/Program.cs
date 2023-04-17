using System;
public class Chess
{
    // проверка хода для Короля
    public  bool King(int x1, int y1, int x2, int y2)
    {
        return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2)) == 1;
    }

    // проверка хода для Королевы
    public  bool Queen(int x1, int y1, int x2, int y2)
    {
        return Rook(x1, y1, x2, y2) || Bishop(x1, y1, x2, y2);
    }

    // проверка хода для Ладьи
    public bool Rook(int x1, int y1, int x2, int y2)
    {
        return x1 == x2 || y1 == y2;
    }

    // проверка хода для Слона
    public bool Bishop(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
    }

    // проверка хода для Коня
    public bool Knight(int x1, int y1, int x2, int y2)
    {
        return ((y2 == y1 + 2 && x2 == x1 + 1) || (y2 == y1 + 2 && x2 == x1 - 1) || (y2 == y1 - 2 && x2 == x1 + 1) || (y2 == y1 - 2 && x2 == x1 - 1) || (y2 == y1 + 1 && x2 == x1 + 2) || (y2 == y1 - 1 && x2 == x1 + 2) || (y2 == y1 + 1 && x2 == x1 - 2) || (y2 == y1 - 1 && x2 == x1 - 2));
    }

    // проверка хода для Пешки
    public bool Pawn(int x1, int y1, int x2, int y2)
    {
        return ((y2 == y1 + 1));
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Chess ch = new();
        Coordinats();
        void Coordinats()
        {
            Console.WriteLine("Введите начальные координаты x1y1, затем x2y2, куда будет перемещена выбранная фигура.");
            bool valid1 = int.TryParse(Console.ReadLine(), out int x1);
            bool valid2 = int.TryParse(Console.ReadLine(), out int y1);
            bool valid3 = int.TryParse(Console.ReadLine(), out int x2);
            bool valid4 = int.TryParse(Console.ReadLine(), out int y2);
            if (valid1 && valid2 && valid3 && valid4 && (x1 >= 1 && x1 <= 8) && (y1 >= 1 && y1 <= 8) && (x2 >= 1 && x2 <= 8) && (y2 >= 1 && y2 <= 8))
            {
                Console.WriteLine("Выберите одну из фигур для проверки хода");
                Console.WriteLine("1 - король");
                Console.WriteLine("2 - королева");
                Console.WriteLine("3 - ладья");
                Console.WriteLine("4 - слон");
                Console.WriteLine("5 - конь");
                Console.WriteLine("6 - пешка");
                FigureSelect(x1, y1, x2, y2);
            }
            else
            {
                Console.WriteLine("Некорректный ввод, координаты могут пнинимать значение только от 1 до 8");
                Coordinats();
            }
        }
        void FigureSelect(int x1, int y1, int x2, int y2)
        {
            var figure = Console.ReadKey().Key;
            Console.WriteLine();
            switch (figure)
            {
                case ConsoleKey.D1:
                    Console.WriteLine($"Сможет ли фигура переместиться в данные координаты? {ch.King(x1, y1, x2, y2)}");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine($"Сможет ли фигура переместиться в данные координаты? {ch.Queen(x1, y1, x2, y2)}");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine($"Сможет ли фигура переместиться в данные координаты? {ch.Rook(x1, y1, x2, y2)}");
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine($"Сможет ли фигура переместиться в данные координаты? {ch.Bishop(x1, y1, x2, y2)}");
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine($"Сможет ли фигура переместиться в данные координаты? {ch.Knight(x1, y1, x2, y2)}");
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine($"Сможет ли фигура переместиться в данные координаты? {ch.Pawn(x1, y1, x2, y2)}");
                    break;
                default:
                    Console.WriteLine("Введите число от 1 до 6.");
                    FigureSelect(x1, y1, x2, y2);
                    break;
            }
        }
    }
}