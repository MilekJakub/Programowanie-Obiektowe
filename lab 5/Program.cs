using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_5
{
    class Ingredient
    {
        public double Calories { get; init; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Calories: {Calories} kcal Name: {Name}";
        }
    }

    class Sandwitch : IEnumerable<Ingredient>
    {
        public Ingredient Bread { get; init; }
        public Ingredient Butter { get; init; }
        public Ingredient Salad { get; init; }
        public Ingredient Ham { get; init; }

        public IEnumerator<Ingredient> GetEnumerator()
        {
            //return new SandwitchEnumerator(this);
            yield return Bread; //Zwrócone w Current po pierwszym wywołaniu MoveNext
            yield return Butter; //Zwrócone w Current po drugim wywołaniu MoveNext
            yield return Salad;
            yield return Ham;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Parking : IEnumerable<string>
    {
        private string[] _arr = new string[] { "GDI3769", null, "TKI7898", "KMI85ER", null, "KOL19SA", "KRA49FA", null };
        public string this[char slot]
        {
            get
            {
                //test poprawności czy slot jest między 'A' a 'Z'
                return _arr[slot - 'A'];
            }
            set
            {
                _arr[slot - 'A'] = value;
            }
        }
        public string this[int index]
        {
            get
            {
                //test poprawności czy slot jest między 'A' a 'Z'
                return _arr[index];
            }
            set
            {
                _arr[index] = value;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var car in _arr)
            {
                if (car is not null)
                    yield return car;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region kod z przykładów
            //Sandwitch sandwitch = new Sandwitch()
            //{
            //    Bread = new Ingredient() { Calories = 100, Name = "Bułka wrocławska" },
            //    Ham = new Ingredient() { Calories=400, Name="Z kota"},
            //    Salad = new Ingredient() { Calories=10, Name="Lodowa"},
            //    Butter = new Ingredient() { Calories=120, Name="Śmietankowe"}
            //};
            //IEnumerator<Ingredient> enumerator = sandwitch.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}

            //foreach (var item in sandwitch)
            //{
            //    Console.WriteLine(item);
            //}

            //var parking = new Parking();
            //foreach (var car in parking)
            //{
            //    Console.WriteLine(car);
            //}

            //Console.WriteLine(String.Join(", ", parking));
            //Console.WriteLine(String.Join(", ", sandwitch));

            //Console.WriteLine(parking['C']);
            //parking['B'] = "WWA1234";
            //Console.WriteLine(parking['B']);

            //Console.WriteLine(parking[5]);
            #endregion
            App.AppMain();
        }
    }
}
