#nullable enable
using System;
namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.OfName("Jakub");
            Console.WriteLine(person.FirstName);

            var money = Money.OfWithException(5, Currency.EUR);
            Console.WriteLine(money.Value + " " + money.Currency);

            Money result = money * 0.2m;
            Console.WriteLine(result.Value);
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

        public static Money operator*(Money money, decimal factor)
        {
            return Money.Of(money.Value * factor, money.Currency);
        }

        public Currency Currency
        {
            get { return _currency; }
        }

        public decimal Value
        {
            get { return _value; }
        }

        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }

        public static Money? OfWithException(decimal value, Currency currency)
        {
            if (value < 0)
                throw new ArgumentException();
            else
                return new Money(value, currency);
        }
    }

}
