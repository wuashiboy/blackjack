using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public enum Suit 
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum Rank
    {
        Ace,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }


    class Program
    {
        static void Main(string[] args)

        {
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();
            var count = 0;
            var Pvalue = 0;
            var Dvalue = 0;
            var Dtotal = (Dvalue);
            var PCardN = 0;
            var DCardN = 0;
            

            //Deal the cards
            Card Player;
            Card Dealer;

            Player = randomDeck[count];
            count++;
            Pvalue = Player.GetCardValue();
            PCardN++;
            
            Console.WriteLine($"Player card #{PCardN} is: {Player}");

            Dealer = randomDeck[count];
            count++;
            Dvalue = Dealer.GetCardValue();
            DCardN++;

            Console.WriteLine();
            Console.WriteLine($"Dealer card #{DCardN} is: {Dealer}");

            Player = randomDeck[count];
            count++;
            Pvalue += Player.GetCardValue();
            PCardN++;

            Console.WriteLine();
            Console.WriteLine($"Player card #{PCardN} is: {Player}");
            Console.WriteLine();
            Console.WriteLine("Player has: " + Pvalue);
            Console.WriteLine("Dealer show: " +Dvalue);

            Dealer = randomDeck[count];
            count++;
            Dvalue += Dealer.GetCardValue();
            DCardN++;
                            
            //Player rules//
            while (true)
            {
                if (Pvalue == 21)
                {
                    Console.WriteLine("BlackJack...You win!!!");
                    Console.WriteLine();
                    Console.WriteLine("Dealer has: " + Dvalue);
                    break;
                }
                else if (Pvalue < 21)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player hit: y/n" + "?"); 
                    var answer = Console.ReadLine();

                    if (answer == "y")
                    {
                        Player = randomDeck[count];
                        count++;
                        Pvalue += Player.GetCardValue();
                        PCardN++;
                        Console.WriteLine();
                        Console.WriteLine($"Player card #{PCardN} is: {Player}");
                        Console.WriteLine("Player has: " + Pvalue);

                        if (Pvalue > 21)
                        {
                            Console.WriteLine("You are busted!!!");
                            Console.WriteLine();
                            //Console.WriteLine("Dealer has: " + Dvalue);
                            break;
                        }
                        else if (PCardN == 6 && Pvalue < 21)
                        {
                            Console.WriteLine("Player has: " + Pvalue);
                            Console.WriteLine("Winner...You are a very lucky person");
                            break;
                        }
                        else
                            continue;
                    }
                    else if (answer == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You must enter a y or a n");
                    }
                }
                break;
            }


            //Dealer Rules//

            Console.WriteLine();
            Console.WriteLine($"Dealer card #{DCardN} is: {Dealer}");
            Console.WriteLine("Dealer has: " + Dvalue);

            while (true)
            {
                if (Dvalue == 21 && Pvalue < 21)
                {
                    Console.WriteLine("Dealer Win...Sorry!!!");
                    break;
                }
                else if (Dvalue == 18 && Pvalue < 18)
                {
                    Console.WriteLine("Dealer Win!!!");
                    break;
                }
                    else if (Dvalue == Pvalue && Dvalue <21 && Pvalue <21 )
                    {
                    Console.WriteLine("We are tied...shall we play again?");
                    }

                if (Pvalue < 21 && Dvalue < 18)
                {
                    Console.WriteLine("Dealer hit: y/n" + "?");
                    var answer = Console.ReadLine();

                    if (answer == "y")
                    {
                        Dealer = randomDeck[count];
                        count++;
                        Dvalue += Dealer.GetCardValue();
                        DCardN++;

                        Console.WriteLine();
                        Console.WriteLine($"Dealer card #{DCardN} is: {Dealer}");
                        Console.WriteLine("Dealer has: " + Dvalue);
                    }
                    else if (answer == "n")
                    {
                        break;
                    }
                    else if (Dvalue < Pvalue)
                    {
                        Console.WriteLine("Player win!!!");
                        break;
                    }
                }
                else
                { break; }
            }


            Console.ReadLine();
        }
        
        }

    
           
        
    }

