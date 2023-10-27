using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class WinMessage
    {
        public string DetermineWin(string msg, int playervalue, int playerhandcount, int dealervalue, int dealerhandcount)
        {
            if(playervalue == 21 && dealervalue == 21)
            {
                if(playerhandcount == 2 && dealerhandcount > 2)
                    msg = "Player wins due to having a blackjack.";
                if(dealerhandcount == 2 && playerhandcount > 2)
                    msg = "Dealer wins due to having a blackjack.";
                if(playerhandcount == 2 && dealerhandcount == 2)
                    msg = "It's a draw.";
            }
            if(playervalue > dealervalue)
            {
                if (playervalue == 21 && playerhandcount == 2)
                    msg = "Player wins due to having a blackjack.";
                if (playervalue == 21)
                    msg = "Player wins due to reaching 21.";
                if (playervalue > 21 && dealervalue <= 21)
                    msg = "Dealer wins due to the player having gone bust.";
                if (playervalue < 21)
                    msg = "Player wins due to having a higher value than the dealer.";
                if (playervalue > 21 && dealervalue > 21)
                    msg = "Dealer wins due to favor by the draw.";
            }
            if(dealervalue > playervalue)
            {
                if (dealervalue == 21 && dealerhandcount == 2)
                    msg = "Dealer wins due to having a blackjack.";
                if (dealervalue == 21)
                    msg = "Dealer wins due to reaching 21.";
                if (dealervalue > 21 && playervalue <= 21)
                    msg = "Player wins due to the dealer having gone bust.";
                if (dealervalue < 21)
                    msg = "Dealer wins due to having a higher value than the player.";
                if (playervalue > 21 && dealervalue > 21)
                    msg = "Dealer wins due to favor by the draw.";
            }
            if (playervalue == dealervalue)
            {
                if (playervalue > 21 && dealervalue > 21)
                    msg = "Dealer wins due to favor by the draw.";
                else
                    msg = "It's a draw.";
            }
            return msg;
        }
    }
}
