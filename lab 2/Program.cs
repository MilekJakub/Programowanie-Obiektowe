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

        //ĆWICZENIE 3
        var aggregate = new ArrayIntAggregate();
        for (var iterator = aggregate.CreateIterator(); iterator.HasNext();)
        {
            Console.WriteLine(iterator.GetNext());
        }
    }
}

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
public sealed class ArrayIntReversedIterator : Iterator
{
    private int _index;
    private ArrayIntAggregate _aggregate;
    public ArrayIntReversedIterator(ArrayIntAggregate aggregate)
    {
        _aggregate = aggregate;
        _index = _aggregate.array.Length;
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