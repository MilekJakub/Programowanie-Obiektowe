class Program
{
    static void Main()
    {
        #region ĆWICZENIE 2
        //ĆWICZENIE 2
        IFlyable[] flyables =
        {
            new Duck(),
            new Wasp(),
            new Wasp(),
            new Wasp(),
            new Wasp(),
            new Wasp(),
            new Wasp(),
            new Duck()
        };
        int counter = 0;
        foreach (var animal in flyables)
        {
            if (animal is ISwimmingable)
                counter++;
        }
        //Console.WriteLine(counter);
        #endregion

        #region ĆWICZENIE 3
        //ĆWICZENIE 3
        var aggregate = new ArrayIntAggregate();
        for (var iterator = aggregate.CreateIterator(); iterator.HasNext();)
        {
            Console.WriteLine(iterator.GetNext());
        }
        #endregion

        #region ZADANIE 6
        //ZADANIE 6
        var student = new Student() { FirstName = "Jakub", LastName = "Milek", StudentID = 1 };
        var lecturer = new Lecturer() { FirstName = "Cezary", LastName = "Siwoń", AcademicDegree = "dr inż." };
        var group = new StudentLectureGroup();
        group.AddStudent(student);
        group.SetLecturer(lecturer);
        #endregion
    }
}

#region ĆWICZENIE 1
//ĆWICZENIE 1
public abstract class Vehicle
{
    public double Weight { get; init; }
    public int MaxSpeed { get; init; }
    protected int _mileage;
    public int Mealeage
    {
        get { return _mileage; }
    }
    public abstract decimal Drive(int distance);
    public override string ToString()
    {
        return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
    }
}
abstract class Scooter : Vehicle
{

}
class ElectricScooter : Scooter
{
    private double _batteriesLevel;
    public double BatteriesLevel
    {
        get { return _batteriesLevel; }
    }
    public int MaxRange { get; set; }

    public void ChargeBatteries()
    {
        _batteriesLevel = 1;
    }
    public override decimal Drive(int Distance)
    {
        double batteryDistance = Distance / 100;
        if (batteryDistance > 1)
            return -1;
        if (BatteriesLevel - batteryDistance < 0)
            return -1;

        _batteriesLevel =- batteryDistance;
        _mileage += Distance;
        return 0;
    }
}
class KickScooter
{

}
#endregion

#region ĆWICZENIE 2
//ĆWICZENIE 2
interface ISwimmingable
{
    void Swim();
}
interface IFlyable
{
    void Fly();
}
class Duck : ISwimmingable, IFlyable
{
    public void Swim()
    {
        Console.WriteLine("Duck is swimming");
    }
    public void Fly()
    {
        Console.WriteLine("Duck is flying");
    }
}
class Wasp : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Wasp is flying");
    }
}
#endregion

#region ĆWICZENIE 3
//ĆWICZENIE 3
public abstract class Aggregate
{
    public abstract Iterator CreateIterator();
}
public abstract class Iterator
{
    public abstract int GetNext();
    public abstract bool HasNext();
}
public class ArrayIntAggregate : Aggregate
{
    internal int[] array = { 1, 2, 3, 4, 5 };
    public override Iterator CreateIterator()
    {
        return new ArrayIntReversedIterator(this);
    }
}
public sealed class ArrayIntIterator : Iterator
{
    private int _index;
    private ArrayIntAggregate _aggregate;
    public ArrayIntIterator(ArrayIntAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    public override int GetNext()
    {
        return _aggregate.array[_index++];
    }
    public override bool HasNext()
    {
        return _index < _aggregate.array.Length;
    }
}

//Iterator zwracający elementy od ostatniego do pierwszego, np. dla {1,2,3,4} zwraca kolejno 4, 3, 2, 1
public sealed class ArrayIntReversedIterator : Iterator
{
    private int _index;
    private ArrayIntAggregate _aggregate;
    public ArrayIntReversedIterator(ArrayIntAggregate aggregate)
    {
        _aggregate = aggregate;
        _index = _aggregate.array.Length -1;
    }
    public override int GetNext()
    {
        return _aggregate.array[_index--];
    }
    public override bool HasNext()
    {
        return _index >= 0;
    }
}
#endregion

#region ZADANIE 6
//ZADANIE 6
class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

class Student : Person
{
    public int StudentID { get; set; }
}

class Lecturer : Person
{
    public string? AcademicDegree { get; set; }
}

class StudentLectureGroup
{
    public string? Name { get; set; }
    public void AddStudent(Student student)
    {
        Console.WriteLine($"Adding student {student.FirstName} {student.LastName} with ID: {student.StudentID} to group.");
    }
    public void SetLecturer(Lecturer lecturer)
    {
        Console.WriteLine($"Adding {lecturer.AcademicDegree} {lecturer.FirstName} {lecturer.LastName} as lecturer of the group.");
    }
}
#endregion