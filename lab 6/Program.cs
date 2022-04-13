using System;
using System.Collections.Generic;

namespace lab_6
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   FirstName == student.FirstName &&
                   LastName == student.LastName &&
                   Grade == student.Grade;
        }

        public override int GetHashCode()
        {
            Console.WriteLine($"Student GetHashCode");
            return HashCode.Combine(FirstName, LastName, Grade);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Grade}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICollection<Student> students = new List<Student>();
            students.Add(new Student { FirstName = "Jakub", LastName = "Szela", Grade = 2 });
            students.Add(new Student { FirstName = "Tomasz", LastName = "Kemot", Grade = 3 });
            students.Add(new Student { FirstName = "Andrzej", LastName = "Kat", Grade = 4 });
            students.Add(new Student { FirstName = "Mariusz", LastName = "Pudzianowski", Grade = 5 });

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(students.Contains(new Student { FirstName = "Jakub", LastName = "Szela", Grade = 2 }));
            Console.WriteLine(students.Remove(new Student { FirstName = "Andrzej", LastName = "Kat", Grade = 4 }));
            List<Student> list = (List<Student>)students;
            list.Insert(1, new Student() { FirstName = "Kamil", LastName = "Idzik", Grade = 2 });
            Console.WriteLine();
            
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine();
            ISet<string> set = new HashSet<string>();
            set.Add("Ewa");
            set.Add("Karol");
            set.Add("Ania");

            Console.WriteLine(set.Contains("Ewa"));
            Console.WriteLine(set.Remove("Karol"));

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            ISet<Student> group = new HashSet<Student>(list);
            group.Add(new Student() { FirstName = "Jakub", LastName = "Szela", Grade = 2 });
            foreach (var item in group)
            {
                Console.WriteLine(item);
            }

            ISet<int> s1 = new HashSet<int>(new int[] { 1, 2, 5, 6, 7 });
            ISet<int> s2 = new HashSet<int>(new int[] { 4, 7, 9, 8, 3 });
            s1.IntersectWith(s2);
            foreach (var item in s1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook.Add("Adam", "123123123");
            phoneBook["Gerwazy"] = "321321321";
            Console.WriteLine(phoneBook["Adam"]);

            foreach (var item in phoneBook)
            {
                Console.WriteLine(item);
            }

            //libed ot kainhciM kemoT
            //tsej ąwruk edeT ogezcalD
            //żet kemoT I

            string[] arr = { "Ewa", "Adam", "Ewa", "Karol", "Ania", "Ewa", "Adam" };
            //Podaj ile razy występuje każde imię w tabeli arr
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in arr)
            {
                if (dic.ContainsKey(item))
                    dic[item]++;
                else
                    dic.Add(item, 1);
            }

            foreach (var item in dic)
            {
                Console.WriteLine(item);
            }
        }
    }
}
