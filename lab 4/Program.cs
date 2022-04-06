using System;

public record Student(string Name, int Points, char Egzam);

namespace lab_4
{
    enum Degree
    {
        BardzoDobry = 50,
        DobryPlus = 45,
        Dobry = 40,
        DostatecznyPlus = 35,
        Dostateczny = 30,
        Niedostateczny = 20
    }
    class Program
    {
        static void Main(string[] args)
        {
            App.AppMain();

            Degree? ocena = null;
            string[] vs = Enum.GetNames<Degree>();
            Console.WriteLine(string.Join(", ", vs));

            try
            {
                ocena = Enum.Parse<Degree>(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("OK");
            }

            string usDegree = null;
            switch (ocena)
            {
                case Degree.BardzoDobry:
                    usDegree = "A";
                    break;

                case Degree.DobryPlus:
                    usDegree = "B+";
                    break;

                case Degree.Dobry:
                    usDegree = "B";
                    break;

                case Degree.DostatecznyPlus:
                    usDegree = "C+";
                    break;

                case Degree.Dostateczny:
                    usDegree = "C";
                    break;

                case Degree.Niedostateczny:
                    usDegree = "D";
                    break;
            }

            usDegree = ocena switch
            {
                Degree.BardzoDobry => "A",
                Degree.DobryPlus => "B+",
                Degree.Dobry => "B",
                Degree.DostatecznyPlus => "C+",
                Degree.Dostateczny => "C",
                Degree.Niedostateczny => "D",
                _ => "D"
            };

            Console.WriteLine(usDegree);

            int points;

            if(int.TryParse(Console.ReadLine(), out points))
            {
                Console.WriteLine(points);
            }
            Degree result;
            
            if(points >= 50 && points < 60)
            {
                result = Degree.Dostateczny;
            }

            result = points switch
            {
                >= 50 and < 60 => Degree.Dostateczny,
                >= 60 and < 70 => Degree.DostatecznyPlus,
                >= 70 and < 80 => Degree.Dobry,
                >= 80 and < 90 => Degree.DobryPlus,
                >= 90 and < 100 => Degree.BardzoDobry,
                _ => Degree.Niedostateczny
            };

            Console.WriteLine(result);
        }
    }
}
