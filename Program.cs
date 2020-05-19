using System;
using System.Collections.Generic;

namespace blackjack
{
    class Hand
    {
        public List<Card> CardsHeld = new List<Card>();
        public void Accept(Card cardDealt)
        {
            CardsHeld.Add(cardDealt);
        }
        public void ShowCards()
        {
            foreach (Card card in CardsHeld)
            {
                Console.WriteLine(card.Rank + " of " + card.Suit);
            }
        }
        public int TotalValue()
        {
            var total = 0;

            foreach (var card in CardsHeld)
            {
                var cardValue = card.Value();
                total = total + cardValue;
            }
            return total;
        }
    }
    class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
        public int Value()
        {
            switch (Rank)
            {
                case "Jack":
                    return 10;
                case "Queen":
                    return 10;
                case "King":
                    return 10;
                case "Ace":
                    return 11;
                default:
                    return int.Parse(Rank);
            }
        }
    }
    class Deck
    {
        private List<Card> Cards = new List<Card>();
        public Deck()
        {
            var suits = new List<string>() { "Spades", "Clubs", "Diamonds", "Hearts" };
            var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var newCard = new Card
                    {
                        Suit = suit,
                        Rank = rank,
                    };
                    Cards.Add(newCard);
                }
            }

        }

        public void Shuffle()
        {
            var rnd = new Random();
            for (int index = Cards.Count - 1; index >= 0; index--)
            {
                int k = rnd.Next(0, index);
                var value = Cards[k];
                Cards[k] = Cards[index];
                Cards[index] = value;
            }
        }

        public Card Deal()
        {
            var card = Cards[0];
            Cards.Remove(card);
            return card;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();

            var playerHand = new Hand();

            var dealerHand = new Hand();

            var firstCard = deck.Deal();
            playerHand.Accept(firstCard);

            var secondCard = deck.Deal();
            playerHand.Accept(secondCard);

            var dealerFirstCard = deck.Deal();
            dealerHand.Accept(firstCard);

            var dealerSecondCard = deck.Deal();
            dealerHand.Accept(secondCard);

            while (playerHand.TotalValue() <= 21)
            {
                Console.WriteLine();
                playerHand.ShowCards();
                Console.WriteLine($"The total value of your hand is: {playerHand.TotalValue()}");
                Console.WriteLine();

                Console.Write("(H)it or (S)tand: ");
                var answer = Console.ReadLine();

                if (answer == "H")
                {
                    var extraCard = deck.Deal();
                    playerHand.Accept(extraCard);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();
            playerHand.ShowCards();
            Console.WriteLine($"The total value of your hand is: {playerHand.TotalValue()}");
            Console.WriteLine();
            // Console.WriteLine("Your first card is " + firstCard.Rank + " of " + firstCard.Suit);

            while (dealerHand.TotalValue() < 17)
            {
                var extraCard = deck.Deal();
                dealerHand.Accept(extraCard);
                Console.WriteLine($"Your new total is: ");
            }

            Console.WriteLine();
            Console.WriteLine("Dealer has:");
            dealerHand.ShowCards();
            var computedTotalValueOfDealerHand = dealerHand.TotalValue();
            Console.WriteLine($"Total value of of dealer hand: {computedTotalValueOfDealerHand}");

            Console.WriteLine();

            if (playerHand.TotalValue() > 21)
            {
                Console.WriteLine("You busted. Dealer Wins!");
            }
            else if (dealerHand.TotalValue() > 21)
            {
                Console.WriteLine("Player Wins!");
            }
            else if (dealerHand.TotalValue() >= playerHand.TotalValue())
            {
                Console.WriteLine("Dealer totals more. Dealer Wins!");
            }
            else
            {
                Console.WriteLine("Player Wins!");
            }
            // else if (playerHand.TotalValue() == dealerHand.TotalValue())
            // {
            //     Console.WriteLine("It's a draw!");
            // }
        }
        // Console.Write("Do you want to play again? Y/N ");
        // playAgain = Console.ReadLine();
    }

}

