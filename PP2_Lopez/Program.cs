using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Welcome to Blackjack!");
                Console.WriteLine("Setting up the deck.");
                DeckOfCards doc = new DeckOfCards(true);

                Console.WriteLine("Setting up the players' decks.");
                List<Card> playerhand = new List<Card>();
                List<Card> dealerhand = new List<Card>();
                List<Card> splithand = new List<Card>();

                playerhand = doc.drawACard(2);
                dealerhand = doc.drawACard(2);

                int playerhandvalue = 0;
                int dealerhandvalue = 0;
                int splithandvalue = 0;
                _21Play play = new _21Play();

                Console.WriteLine("Starting play.");

                playerhand = play.GamePlay(playerhand, dealerhand[0].GetCardValue(), doc, true);
                playerhandvalue = play.deckvalue;
                splithand = play.splithand;
                if (splithand.Count > 0)
                {
                    splithand = play.GamePlay(splithand, dealerhand[0].GetCardValue(), doc, true);
                    splithandvalue = play.deckvalue;
                }
                dealerhand = play.GamePlay(dealerhand, dealerhand[0].GetCardValue(), doc, false);
                dealerhandvalue = play.deckvalue;

                Console.Clear();

                Console.WriteLine("Player Hand Value: " + playerhandvalue);
                foreach (Card c in playerhand)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()} - value of {c.GetCardValue()}");
                }
                Console.WriteLine();
                if (splithand.Count > 0)
                {
                    Console.WriteLine("Player Hand Value: " + splithandvalue);
                    foreach (Card c in splithand)
                    {
                        Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()} - value of {c.GetCardValue()}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Dealer Hand Value: " + dealerhandvalue);
                foreach (Card c in dealerhand)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()} - value of {c.GetCardValue()}");
                }
                Console.WriteLine();
                WinMessage win = new WinMessage();
                string winnermessage = "";
                winnermessage = win.DetermineWin(winnermessage, playerhandvalue, playerhand.Count, dealerhandvalue, dealerhand.Count);
                Console.WriteLine("Hand 1: " + winnermessage);
                Console.WriteLine();
                if (splithand.Count > 0)
                {
                    winnermessage = win.DetermineWin(winnermessage, splithandvalue, splithand.Count, dealerhandvalue, dealerhand.Count);
                    Console.WriteLine("Hand 2: " + winnermessage);
                    Console.WriteLine();
                }
                string UserInput = "";
                Console.WriteLine("Do you want to play again? (Y/N)");
                UserInput = Console.ReadLine();
                if (UserInput == "Y" || UserInput == "y")
                    continue;
                if (UserInput == "N" || UserInput == "n")
                    break;
                Console.ReadKey();
            }
        }
    }
}