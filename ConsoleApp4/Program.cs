using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    public abstract class Shapes
    {
        public abstract double Perimeter();
        public abstract double Square();
        public abstract void Info();
    }
    class Triangle : Shapes
    {
        public int SideA;
        public int SideB;
        public int SideC;
        public Triangle(int sideA, int sideB, int sideC)
        {
            if ((sideA + sideB) > sideC && (sideA + sideC) > sideB && (sideB + sideC) > sideA)
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }
            else
            {
                throw new Exception($"Треугольника со сторонами {sideA}, {sideB}, {sideC} не существует");
            }
        }
        public override double Perimeter()
        {
            return SideA + SideB + SideC;
        }
        public override double Square()
        {
            double p = Perimeter() / 2;
            double h = (2 * Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC))) / SideC;
            return (SideC * h) / 2;
        }
        public override void Info()
        {
            Console.Write($"Треугольник {SideA,10}, {SideB}, {SideC} {Perimeter(),10:0.00} {Square(),12:0.00} ");
            if (SideA == SideB && SideB == SideC)
            {
                Console.Write(" равностороний");
            }
            else if (SideA == SideB || SideA == SideC || SideC == SideB)
            {
                Console.Write(" равнобедренный");
            }
            Console.WriteLine();
        }
    }
    class Rectangle : Shapes
    {
        public int SideA;
        public int SideB;
        public Rectangle(int sideA, int sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }
        public override double Perimeter()
        {
            return 2 * (SideA + SideB);
        }
        public override double Square()
        {
            return SideA * SideB;
        }
        public override void Info()
        {
            if (SideA == SideB)
            {
                Console.Write("Квадрат      ");
            }
            else
            {
                Console.Write("Прямоугольник");
            }
            Console.WriteLine($"{SideA,10}, {SideB} {Perimeter(),12:0.00} {Square(),12:0.00} ");
        }
    }
    class Elipse : Shapes
    {
        public int Radius1;
        public int Radius2;
        public Elipse(int radius1, int radius2)
        {
            Radius1 = radius1;
            Radius2 = radius2;
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Radius1 * Radius1 + Radius2 * Radius2) / 2);
        }
        public override double Square()
        {
            return Math.PI * Radius1 * Radius2;
        }
        public override void Info()
        {
            if (Radius1 == Radius2)
            {
                Console.Write($"Окружность  ");
            }
            else
            {
                Console.Write($"Эллипс      ");
            }
            Console.WriteLine($"{Radius1,10}, {Radius2} {Perimeter(),13:0.00} {Square(),13:0.00}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();
            List<Shapes> shapesList = new();
            try
            {
                for (int i = 0; i <= 4; i++)
                {
                    switch (rnd.Next(3))
                    {
                        case 0:
                            shapesList.Add(new Triangle(rnd.Next(5, 10), rnd.Next(5, 10), rnd.Next(5, 10)));
                            break;
                        case 1:
                            shapesList.Add(new Rectangle(rnd.Next(5, 10), rnd.Next(5, 10)));
                            break;
                        case 2:
                            shapesList.Add(new Elipse(rnd.Next(5, 10), rnd.Next(5, 10)));
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Наименование         Стороны     Периметр     Площадь");
            foreach (var i in shapesList)
            {
                i.Info();
            }
            Console.Write("\nЗапустить программу еще раз? (1-да, 0-нет) ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                Main(args);
            }
        }
    }
}