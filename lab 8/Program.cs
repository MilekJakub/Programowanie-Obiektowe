using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab_8
{
    public record Student(string Name, char Group, int ECTS);
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 4, 6, 1, 4, 7, 8, 3, 4, 9 };
            Predicate<int> oddPredicate = n =>
            {
                Console.WriteLine("Obliczanie predykatu dla n " + n);
                return n % 2 == 1;
            };
            Console.WriteLine("Przed wykonaniem wiersza 1");
            var odds = array.Where(n => n % 2 == 1);

            Console.WriteLine(string.Join(", ", odds));

            Console.WriteLine("Przed wykonaniem wiersza 2");
            odds = array.Where(n => n > 5);

            Console.WriteLine(string.Join(", ", odds));

            int limit = 5;
            odds = array.Where(n => n % 2 == 1 && n > limit);

            Console.WriteLine(string.Join(", ", odds));

            var strings = new string[] { "zz", "aa", "ee", "ccc", "fff", "bb", "ggggg" };

            var query = strings.Where(str => str.Length == 2);

            Console.WriteLine(string.Join(", ", query));

            query.OrderBy(str => str);

            Student[] students =
            {
                new Student("Ewa", 'A', 54),
                new Student("Karol", 'B', 31),
                new Student("Ewa", 'B', 38),
                new Student("Tomek", 'B', 44),
                new Student("Kasia", 'A', 24),
                new Student("Karol", 'A', 34)
            };

            var stud = students.OrderBy(n => n.Group);

            foreach (var student in stud)
            {
                Console.WriteLine(student);
            }

            string sentence = "ala ma kota ala lubi koty tomek lubi psy";
            string[] words = sentence.Split(' ');

            var ex = words.OrderBy(s => s.Length).ThenBy(s => s);

            Console.WriteLine(string.Join(", ", ex));

            int sum = Enumerable.Range(0, 10).Where(n => n % 2 == 1).Sum(n => n*n);
            Console.WriteLine(sum);
        }
    }
}
