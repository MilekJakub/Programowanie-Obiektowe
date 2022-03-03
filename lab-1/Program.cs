using System;
namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
//          KOD Z PRZYKŁADÓW NA ZAJĘCIACH
//          var person = Person.OfName("Jakub");
//          Console.WriteLine(person.FirstName);

            //ĆWICZENIE 1
            Console.WriteLine("ĆWICZENIE 1");
            var money1 = Money.OfWithException(5, Currency.EUR);
            Console.WriteLine(money1.Value + " " + money1.Currency);

            //ĆWICZENIE 2
            Console.WriteLine("\nĆWICZENIE 2");
            var money2 = Money.ParseValue("12.90", Currency.EUR);
            Console.WriteLine(money2.Value + " " + money2.Currency);

            //ĆWICZENIE 3
            Console.WriteLine("\nĆWICZENIE 3");
            Console.WriteLine("money2.Currency = " + money2.Currency);

            //ĆWICZENIE 4
            Console.WriteLine("\nĆWICZENIE 4");
            var result1 = money1 * 0.2m;
            Console.WriteLine(result1.Value + " " + result1.Currency);

            //ĆWICZENIE 5
            Console.WriteLine("\nĆWICZENIE 5");
            var result2 = money1 + money2;
            Console.WriteLine($"{money1.Value} {money1.Currency} + {money2.Value} {money2.Currency} = {result2.Value} {result2.Currency}");

            //ĆWICZENIE 6


        }
    }

    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR = 3
    }

    public class Money
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        //ĆWICZENIE 1
        public static Money OfWithException(decimal value, Currency currency)
        {
            if (value < 0 || Enum.IsDefined(currency) == false)
                throw new ArgumentException();
            else
                return new Money(value, currency);
        }
        
        //ĆWICZENIE 2
        public static Money ParseValue(string valueStr, Currency currency)
        {
            decimal value;
            if (Decimal.TryParse(valueStr, out value))
                return new Money(value, currency);

            else throw new ArgumentException("Niepoprawna wartość");
        }

        //ĆWICZENIE 3
        public decimal Value
        {
            get { return _value; }
        }
        public Currency Currency
        {
            get { return _currency; }
        }

        //ĆWICZENIE 4
        public static Money operator *(Money money, decimal factor)
        {
            return OfWithException(money.Value * factor, money.Currency);
        }

        //ĆWICZENIE 5
        public static Money operator +(Money money1, Money money2)
        {
            if (money1.Currency != money2.Currency)
                throw new ArgumentException("Nieprawidłowe waluty");

            return OfWithException(money1.Value + money2.Value, money1.Currency);
        }

        //ĆWICZENIE 6

    }

}
