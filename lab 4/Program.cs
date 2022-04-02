class App
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
        Car[] _cars = new Car[]
        {
            new Car(),
            new Car(Model: "Fiat", true),
            new Car(),
            new Car(Power: 100),
            new Car(Model: "Fiat", true),
            new Car(Power: 125),
            new Car()
        };

        Console.WriteLine(Exercise3.CarCounter(_cars));
        //wywołanie CarCounter(Car[] cars) powinno zwrócić 3
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
//Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
//Przykład
//dla danych wejściowych
// Car[] _cars = new Car[]
// {
//     new Car(),
//     new Car(Model: "Fiat", true),
//     new Car(),
//     new Car(Power: 100),
//     new Car(Model: "Fiat", true),
//     new Car(Power: 125),
//     new Car()
// };
//wywołanie CarCounter(Car[] cars) powinno zwrócić 3
record Car(string Model = "", bool HasPlateNumber = false, int Power = 0);

class Exercise3
{
    public static int CarCounter(Car[] cars)
    {
        int counter = 0;
        foreach (var car in cars)
        {
            counter = 0;
            foreach (var otherCar in cars)
            {
                if (car == otherCar)
                {
                    counter++;
                    Console.WriteLine($"{car}:{counter}");
                }
            }
        }

        return counter;
    }
}

record Student(string LastName, string FirstName, char Group, string StudentId = "");
//Cwiczenie 4
//Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
//Przykład
//dla danych wejściowych
//Student[] students = {
//  new Student("Kowal","Adam", 'A'),
//  new Student("Nowak","Ewa", 'A')
//};
//po wywołaniu metody AssignStudentId(students);
//w tablicy students otrzymamy:
// Kowal Adam 'A' - 'A001'
// Nowal Ewa 'A'  - 'A002'
//Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
class Exercise4
{
    public static void AssignStudentId(Student[] students)
    {

    }
}

