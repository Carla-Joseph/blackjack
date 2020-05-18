using System;
using System.Collections.Generic;

namespace blackjack

    static string GetCardValue(int cards)
{
    string Card;
    switch (cards)
    {
        case 1:
            Card = "Two"; playerTotal += 2;
            break;
        case 2:
            Card = "Three"; playerTotal += 3;
            break;
        case 3:
            Card = "Four"; playerTotal += 4;
            break;
        case 4:
            Card = "Five"; playerTotal += 5;
            break;
        case 5:
            Card = "Six"; playerTotal += 6;
            break;
        case 6:
            Card = "Seven"; playerTotal += 7;
            break;
        case 7:
            Card = "Eight"; playerTotal += 8;
            break;
        case 8:
            Card = "Nine"; playerTotal += 9;
            break;
        case 9:
            Card = "Ten"; playerTotal += 10;
            break;
        case 10:
            Card = "Jack"; playerTotal += 10;
            break;
        case 11:
            Card = "Queen"; playerTotal += 10;
            break;
        case 12:
            Card = "King"; playerTotal += 10;
            break;
        case 13:
            Card = "Ace"; playerTotal += 11;
            break;
    }
    return Card;
}
class Card
{
    public string Face { get; set; }
    public string Suit { get; set; }
}
static string DealCard()
{
    int cards = cardRandomizer.Next(1, 14);
    string Card = GetCardValue(cards);
    return Card;
}