using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class _21Play
    {
        public int deckvalue = 0;
        public List<Card> splithand = new List<Card>();
        private string player = "player";
        private string dealer = "dealer";
        private bool hasSplit = false;
        public List<Card> GamePlay(List<Card> hand, int dealercard, DeckOfCards deck, bool isPlayer)
        {
            if(isPlayer)
            {
                while (true)
                {
                    Console.Clear();
                    deckvalue = 0;
                    int value = 0;
                    value = DisplayDeck(hand, dealercard, value, true);
                    if ((hand[0].GetCardValue() == hand[1].GetCardValue()) && hasSplit == false) 
                    {
                        string split = "";
                        Console.WriteLine("Do you want to split the deck? (Y/N)");
                        split = Console.ReadLine();
                        if(split == "Y" || split == "y")
                        {
                            splithand.Clear();
                            splithand.Add(hand[1]);
                            hand.RemoveAt(1);
                            hasSplit = true;
                            value = 0;
                            value = DisplayDeck(hand, dealercard, value, true);
                        }
                        else
                            continue;
                    }
                    if(hasSplit == true)
                    {
                        if(splithand.Count < 2 && hand.Count < 2)
                        {
                            splithand.Add(deck.drawACard());
                            hand.Add(deck.drawACard());
                            Console.Clear();
                            value = 0;
                            value = DisplayDeck(hand, dealercard, value, true);
                        }
                    }
                    string UserInput = "";
                    Console.WriteLine("Do you want to hit (H) or stand (S)?");
                    UserInput = Conditions(value, hand, UserInput, player);
                    if(value < 21)
                        UserInput = Console.ReadLine();
                    if (UserInput == "H" || UserInput == "h")
                    {
                        AddACard(hand, deck, player);
                    }
                    if (UserInput == "S" || UserInput == "s")
                    {
                        if (value < 21)
                            deckvalue = Stand(value, player);
                        else
                            deckvalue = value;
                        break;
                    }
                }
            }
            if (!isPlayer)
            {
                while (true)
                {
                    Console.Clear();
                    deckvalue = 0;
                    string UserInput = "";
                    int value = 0;
                    value = DisplayDeck(hand, dealercard, value, false);
                    Console.WriteLine("Do you want to hit (H) or stand (S)?");
                    UserInput = Conditions(value, hand, UserInput, dealer);
                    if (value <= 16)
                        UserInput = "H";
                    if (value >= 17)
                        UserInput = "S";
                    if (UserInput == "H" || UserInput == "h")
                    {
                        AddACard(hand, deck, dealer);
                    }
                    if (UserInput == "S" || UserInput == "s")
                    {
                        if (value < 21)
                            deckvalue = Stand(value, dealer);
                        else
                            deckvalue = value;
                        break;
                    }
                }
            }
            Console.ReadKey();
            return hand;
        }
        public string Conditions(int value, List<Card> hand, string UserInput, string identifier)
        {
            if (value == 21 && hand.Count == 2)
            {
                UserInput = "S";
                Console.WriteLine("A blackjack has occurred for the " + identifier + ".");
            }
            if (value > 21)
            {
                UserInput = "S";
                Console.WriteLine("A bust has occurred!");
            }
            if (value == 21 && hand.Count > 2)
            {
                UserInput = "S";
                Console.WriteLine("The " + identifier + " has reached 21.");
            }
            return UserInput;
        }
        public int DisplayDeck(List<Card> hand, int dealercard, int value, bool isPlayer)
        {
            foreach (Card c in hand)
            {
                value += c.GetCardValue();
            }
            foreach (Card c in hand)
            {
                if (c.GetCardValue() == 1)
                    value += 10;
            }
            foreach (Card c in hand)
            {
                if (c.GetCardValue() == 1 && value > 21)
                    value -= 10;
            }
            Console.WriteLine("The value of the deck is " + value + ".");
            Console.WriteLine();
            foreach (Card c in hand)
            {
                Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()} - value of {c.GetCardValue()}");
            }
            Console.WriteLine();
            if(isPlayer)
            {
                Console.WriteLine("The value of the dealer's first card is " + dealercard + ".");
            }
            return value;
        }
        public List<Card> AddACard(List<Card> hand, DeckOfCards deck, string identifier)
        {
            Card card = deck.drawACard();
            hand.Add(card);
            Console.WriteLine("The " + identifier + " took a card.");
            return hand;
        }
        public int Stand(int deckvalue, string identifier)
        {
            Console.WriteLine("The " + identifier + " chose not to take a card.");
            return deckvalue;
        }
    }
}