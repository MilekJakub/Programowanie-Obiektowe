<<<<<<< HEAD
﻿using System;

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
=======
﻿class App
{
    public static void Main(string[] args)
    {
        #region Ćwiczenie 1
        Console.WriteLine("Ćwiczenie 1");
        (int, int) point1 = (5, 5);
        Direction4 dir = Direction4.LEFT;

        Console.WriteLine(point1);

        for (int i = 0; i <= 5; i++)
        {
            point1 = Exercise1.NextPoint(dir, point1, (10, 10));
            Console.Write(" -> " + point1);
        }

        Console.WriteLine();
        dir = Direction4.UP;

        for (int i = 0; i <= 5; i++)
        {
            point1 = Exercise1.NextPoint(dir, point1, (10, 10));
            Console.Write(" -> " + point1);
        }
        Console.WriteLine();
        #endregion

        #region Ćwiczenie 2
        Console.WriteLine("\nĆwiczenie 2");
        int[,] screen =
        {{0, 0, 0},
         {0, 1, 0},
         {0, 0, 0}};

        Console.WriteLine(Exercise2.DirectionTo(screen, (0, 0), 1));
        Console.WriteLine(Exercise2.DirectionTo(screen, (1, 0), 1));
        Console.WriteLine(Exercise2.DirectionTo(screen, (2, 0), 1));
        Console.WriteLine(Exercise2.DirectionTo(screen, (2, 1), 1));
        Console.WriteLine(Exercise2.DirectionTo(screen, (2, 2), 1));
        Console.WriteLine(Exercise2.DirectionTo(screen, (1, 2), 1));
        Console.WriteLine(Exercise2.DirectionTo(screen, (0, 2), 1));
        Console.WriteLine(Exercise2.DirectionTo(screen, (0, 1), 1));
        #endregion

        #region Ćwiczenie 3
        Console.WriteLine("\nĆwiczenie 3");
        Car[] _cars = new Car[]
        {
            new Car(),
            new Car(Model: "Fiat", true),
            new Car(),
            new Car(Power: 100),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Model: "Fiat", true),
            new Car(Power: 125),
            new Car()
        };

        Console.WriteLine(Exercise3.CarCounter(_cars));
        #endregion

        #region Ćwiczenie 4
        Console.WriteLine("\nĆwiczenie 4");
        Student[] students =
        {
            new Student("Kowal","Adam", 'A'),
            new Student("Nowak","Ewa", 'A'),
            new Student("Borowa","Ela", 'B'),
            new Student("Kasztan","Ola", 'B'),
            new Student("Maj","Franciszek", 'B'),
            new Student("Antolski","Jan", 'C'),
            new Student("Peroń","Henryk", 'C'),
            new Student("Regucki","Mateusz", 'C'),
            new Student("Doniec","Patryk", 'C'),
        };
        Exercise4.AssignStudentId(students);
        #endregion
    }
}

enum Direction8
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    UP_LEFT,
    DOWN_LEFT,
    UP_RIGHT,
    DOWN_RIGHT
}

enum Direction4
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

//Cwiczenie 1
class Exercise1
{
    public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
    {
        (int, int) newPoint = direction switch
        {
            Direction4.UP => (point.Item1, point.Item2 - 1),
            Direction4.DOWN => (point.Item1, point.Item2 + 1),
            Direction4.LEFT => (point.Item1 - 1, point.Item2),
            Direction4.RIGHT => (point.Item1 + 1, point.Item2),
            _ => point
        };

        if (newPoint.Item1 < 0 || newPoint.Item2 < 0)
            return (point.Item1, point.Item2);

        if (newPoint.Item1 > screenSize.Item1 || newPoint.Item2 > screenSize.Item2)
            return (point.Item1, point.Item2);

        return newPoint;
    }
}

//Cwiczenie 2
class Exercise2
{
    public static Direction8 DirectionTo(int[,] screen, (int, int) point, int value)
    {
        (int, int) coordinates = (-1, -1);
        for (int x = 0; x < screen.GetLength(0); x++)
        {
            for (int y = 0; y < screen.GetLength(1); y++)
            {
                if (screen[x, y].Equals(value))
                {
                    coordinates = (x, y);
                    break;
                }
            }
        }

        if (coordinates == (-1, -1))
            throw new ArgumentException($"Nie znaleziono punktu o wartości: {value}");

        if (point.Item1 > coordinates.Item1)
            coordinates.Item1 = -1;

        else if (point.Item1 < coordinates.Item1)
            coordinates.Item1 = 1;

        else
            coordinates = (0, coordinates.Item2);


        if (point.Item2 > coordinates.Item2)
            coordinates.Item2 = -1;

        else if (point.Item2 < coordinates.Item2)
            coordinates.Item2 = 1;

        else
            coordinates.Item2 = 0;

        Direction8 direction = coordinates switch
        {
            (-1, 0) => Direction8.LEFT,
            (1, 0) => Direction8.RIGHT,
            (0, -1) => Direction8.UP,
            (0, 1) => Direction8.DOWN,

            (-1, -1) => Direction8.UP_LEFT,
            (-1, 1) => Direction8.DOWN_LEFT,
            (1, -1) => Direction8.UP_RIGHT,
            (1, 1) => Direction8.DOWN_RIGHT,

            _ => throw new ArgumentException($"Szukana wartość leży na podanym punkcie.")
        };

        return direction;
    }
}

//Cwiczenie 3
record Car(string Model = "", bool HasPlateNumber = false, int Power = 0);
class Exercise3
{
    public static int CarCounter(Car[] cars)
    {
        int counter = 0;
        int max = 0;

        foreach (var car in cars)
        {
            counter = 0;
            foreach (var otherCar in cars)
            {
                if (car == otherCar)
                    counter++;
            }
            if(max < counter)
                max = counter;
        }

        return max;
    }
}

//Cwiczenie 4
record Student(string LastName, string FirstName, char Group, string StudentId = "");
class Exercise4
{
    public static void AssignStudentId(Student[] students)
    {
        int[] groups = new int[] {1, 1, 1};
        int A = 0, B = 1, C = 2;

        for (int i = 0; i < students.Length; i++)   
        {
            char group = students[i].Group;
            int groupNumber;
            switch (group)
            {
                case 'A':
                    groupNumber = groups[A];
                    groups[A]++;
                    break;
                case 'B':
                    groupNumber = groups[B];
                    groups[B]++;
                    break;
                case 'C':
                    groupNumber = groups[C];
                    groups[C]++;
                    break;
                default:
                    throw new ArgumentException();
            }
            string groupID = string.Format("{0:D3}", groupNumber);
            var newStudent = students[i] with { StudentId = group.ToString() + groupID };
            students[i] = newStudent;
        }

        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.Group} {student.StudentId}");
>>>>>>> 75f70dab518507fdac78178d087b5beb2ab162f0
        }
    }
}
