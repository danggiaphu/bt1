using System;

namespace GiaiPT
{
    public class giaiptb1
    {
        protected double a, b;

        public giaiptb1(double hsA, double hsB)
        {
            this.a = hsA;
            this.b = hsB;
        }

        public giaiptb1() { }

        public virtual string Solve()
        {
            if (a == 0)
            {
                if (b == 0)
                    return "Phuong trinh vo so nghiem";
                else
                    return "Phuong trinh vo nghiem";
            }
            else
            {
                double x = -b / a;
                return $"Phuong trinh co 1 nghiem: x = {x}";
            }
        }
    }

    // dau : inherit
    public class giaiptb2 : giaiptb1
    {
        private double c;

        public giaiptb2(double hsA, double hsB, double hsC)
        {
            this.a = hsA;
            this.b = hsB;
            this.c = hsC;
        }

        public override string Solve()
        {
            if (a == 0)
            {
                //a = 0 pt vo nghiem
                return base.Solve();
            }
            else
            {
                double delta = (b * b) - (4 * a * c);
                if (delta < 0)
                {
                    return "Phuong trinh vo nghiem (Delta < 0)";
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    return $"Phuong trinh co nghiem kep: x1 = x2 = {x}";
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    return $"Phuong trinh co 2 nghiem phan biet:\n x1 = {x1=x1:F2}\n x2 = {x2=x2:F2}";
                }
            }
        }
    }

    //chay ct
    public class chayct
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            giaiptb2 pt = new giaiptb2(a, b, c);

            Console.WriteLine("\nKet qua:");
            Console.WriteLine(pt.Solve());

            Console.WriteLine("\nNhan phim bat ky de thoat...");
            Console.ReadKey();
        }
    }
}
