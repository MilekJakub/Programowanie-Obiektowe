using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_5
{
    public class App
    {
        public static void AppMain()
        {
            //Exercise1<string> team = new Exercise1<string>() { Manager = "Adam", MemberA = "Ola", MemberB = "Ewa" };
            //foreach (var member in team)
            //{
            //    Console.WriteLine(member);
            //}

            CurrencyRates rates = new CurrencyRates();
            rates[Currency.EUR] = 4.6m;
            Console.WriteLine(rates[Currency.EUR] + "\n");
            CurrencyRates.ShowRates();;
        }
    }
    //Cwiczenie 1 (2 punkty)
    public class Exercise1<T> : IEnumerable<T>
    {
        public T Manager { get; init; }
        public T MemberA { get; init; }
        public T MemberB { get; init; }

        public IEnumerator<T> GetEnumerator()
        {
            //Manager, MemberA, MemberB
            yield return Manager;
            yield return MemberA;
            yield return MemberB;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //Cwiczenie 2 (2 punkty)
    //Zdefiniuj indekser dla klasy CurrencyRates, aby umożliwiał przypisania i pobierania notowania dla danej waluty.
    //Zainicjuj tablice _rates, aby jej rozmiar byl równy liczbie stałych wyliczeniowych w klasie Currency i nie wymagał zmiany
    //gdy zostaną dodane następne stałe.
    //Przykład
    //CurrencyRates rates = new CurrencyRates();
    //rates[Currency.EUR] = 4.6m;
    //Console.WriteLine(rates[Currency.EUR]);

    public enum Currency
    {
        UNDEFINED,
        PLN,
        USD,
        EUR,
        CHF,
        GBP
    }
    class CurrencyRates
    {
        private static decimal[] _rates = new decimal[Enum.GetValues<Currency>().Length];

        public decimal this[Currency currency]
        {
            get
            {
                return _rates[(int)currency];
            }
            set
            {
                _rates[(int)currency] = value;
            }
        }

        public static void ShowRates()
        {
            Console.WriteLine("Currency rates:");
            for (int i = 0; i < _rates.Length; i++)
            {
                Console.WriteLine($"{_rates[i]} \t{Enum.GetName(typeof(Currency), i)}");
            }
        }
    }

    //Cwiczenie 3
    
    //Zdefiniuj enumerator zwracający kolejne liczby szesnastowe zapisane w łańcuchu o długości 8 znaków plus znaki 0x jako prefiks
    //Przykład 
    //0x00000000 0x00000001 0x00000002 0x00000003 ... 0x0000000A ... 0x000000010 ... 0xFFFFFFFF 
    
    //Zdefiniuj metodę GetLimitedHex(int digitCount), która zwraca enumerator z liczbami o podanej liczbie cyfr.
    //Przykład wykorzystania metody
    // var limitedHex = hex.GetLimitedHex(4);
    // while (limitedHex.MoveNext())
    // {
    //     Console.WriteLine(limitedHex.Current);
    // }
   
    //Wyjście:
    //0x0000
    //0x0001
    //...
    //0x2c7b
    //0x2c7c
    //0x2c7d
    //...
    //0xffff

    class Exercise3 : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<string> GetLimitedHex(int digitCount)
        {
            throw new NotImplementedException();
        }
    }

    enum ChessPiece
    {
        Empty,
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    enum ChessColor
    {
        Black,
        White
    }

    //Cwiczenie 4 (4 punkty)
    //Zdefiniuj klasę opisująca szachownicę z indekserem umożliwiającym dostęp do pola
    //na podstawie indeksu w postaci łańcucha np.: "A5" oznacza pierwszą kolumnę i 5 wiersz (od dołu).
    //W podanych współrzędnych należy umieścić krotkę z dwoma stałymi wyliczeniowymi (ChessPiece, ChessColor)
    //Przykład
    //Exercise4 board = new Exerceise4();
    //board["A5"] = (ChessPiece.King, ChessColor.White);
    //Console.WriteLine(board["A8"]); // pole bez figury w kolorze białym (ChessPiece.Empty, ChessColor.White)
    //Console.WriteLine(board["A1"]); // pole bez figury w kolorze czarnym (ChessPiece.Empty, ChessColor.Black)
    //Klasa powinna zachować zasadę, że nie można umieścić więcej niż dozwolona liczba figur danego typu:
    //1 królowa i król, 2 wieże, gońce, skoczki, 8 pionów
    //W sytuacji, gdy zostanie dodana nadmiarowa figura np. 3 skoczek w kolorze białym, klasa powinna zgłosić wyjątek InvalidChessPieceCount
    //W sytuacji podania niepoprawnych współrzednych np. K9 lub AA44, klasa powinna zgłosić wyjątek InvalidChessBoardCoordinates 
    class Exercise4
    {
        private (ChessPiece, ChessColor)[,] _board = new (ChessPiece, ChessColor)[8, 8];
    }

    class InvalidChessPieceCount : Exception
    {

    }

    class InvalidChessBoardCoordinates : Exception
    {

    }
}