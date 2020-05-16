using System;
using System.Collections.Generic;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var suits = new List<string>() { "Spades", "Clubs", "Diamonds", "Hearts" };
            var ranks = new List<string>() {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King};
            var deck = new List<string> ();
            var shuffled = new List<string>();

            for (var suitIndex = 0; suitIndex < suits.Count; suitIndex++)
            {
                for (var rankIndex = 0; rankIndex < ranks.Count; rankIndex++)
                {
                    deck.Add($"{suits[suitIndex]} of {ranks[rankIndex]}");
                }
            }
            for (var deckIndex = 0; deckIndex < deck.Count; deckIndex++)
            {
                Console.WriteLine(deck[deckIndex]);
            }
        }
    } 