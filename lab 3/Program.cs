using System;

class Program
{
    static void Main()
    {
        var guitarist = new Guitarist();
        var drummer = new Drummer();
        var bassist = new Bassist();
        var keyboardist = new Keyboardist();

        Duo<Musician> duo = new Duo<Musician>(bassist, guitarist);

        duo.Play();
        duo.Squad();

        Console.WriteLine();
        duo.Clear();

        duo.Add(drummer, keyboardist);
        duo.Play();
        duo.Squad();
    }
}

class Musician
{
    public virtual void play()
    {

    }
}

class Guitarist : Musician
{
    public override void play()
    {
        Console.WriteLine("Gra gitara.");
    }
    public override string ToString()
    {
        return "Guitarist";
    }
}

class Drummer : Musician
{
    public override void play()
    {
        Console.WriteLine("Gra perkusja.");
    }
    public override string ToString()
    {
        return "Drummer";
    }
}

class Bassist : Musician
{
    public override void play()
    {
        Console.WriteLine("Gra bas.");
    }
    public override string ToString()
    {
        return "Bassist";
    }
}

class Keyboardist : Musician
{
    public override void play()
    {
        Console.WriteLine("Gra keyboard.");
    }
    public override string ToString()
    {
        return "Keyboardist";
    }
}

class Duo <T> where T : Musician
{
    public Duo()
    {

    }
    public Duo(T first, T second)
    {
        this.first = first;
        this.second = second;
    }
    T? first;
    T? second;
    public void Add(T first, T second)
    {
        this.first = first;
        this.second = second;
    }
    public void Play()
    {
        first?.play();
        second?.play();
    }
    public void Squad()
    {
        Console.WriteLine(first);
        Console.WriteLine(second);
    }
    public void Change(T first, T second)
    {
        this.first = first;
        this.second = second;
    }
    public void Clear()
    {
        this.first = null;
        this.second = null;
    }
}