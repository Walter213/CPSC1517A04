﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReviewReal
{
    class Program
    {
        static void Main(string[] args)
        {   
            //new cause an instance (occurance) of the specified
            //   class to be created and placed in the
            //   receiving variable
            //the variable is a pointer address to the actual
            //   physical memory location of the instance


            //declaring an instance (occurance) of the specified
            //   class will not create a physical instance, just a 
            //   a pointer which can hold a physical instance
            Turn theTurn;
            List<Turn> rounds = new List<Turn>();

            //new cause the constructor of a class to execute
            //   and a phyiscal instance to be created
            Die Player1 = new Die();       // Default Constructor
            Die Player2 = new Die(6, "Green");    // Greedy Constructor

            //basic menu logic
            string menuChoice = "";
            do
            {
                //Console is a static class
                Console.WriteLine("\nMake a choice\n");
                Console.WriteLine("A) Roll");
                Console.WriteLine("B) Set number of dice sides");
                Console.WriteLine("C) Display Current Game Stats");
                Console.WriteLine("X) Exit\n");
                Console.Write("Enter your choice:\t");
                menuChoice = Console.ReadLine();

                //user friendly error handling
                try
                {
                    switch (menuChoice.ToUpper())
                    {
                        case "A":
                            {
                                //Turn is a non-static class
                                theTurn = new Turn();

                                //generate a new FaceValue
                                Player1.Roll();
                                //generate a new FaceValue
                                Player2.Roll();

                                // save the roll 
                                // .Player1 and .Facevalue are properties
                                //  set          get
                                theTurn.Player1 = Player1.Facevalue;
                                theTurn.Player2 = Player2.Facevalue;

                                //method a) default constructor and individual setting


                                //method b) greedy constructor


                                //display the round results
                                Console.WriteLine("Player 1 rolled {0}", theTurn.Player1);
                                Console.WriteLine("Player 2 rolled {0}", theTurn.Player2);

                                if (Player1.Facevalue > Player2.Facevalue)
                                {
                                    Console.WriteLine("Player 1 wins");
                                }
                                else if (Player2.Facevalue > Player1.Facevalue)
                                {
                                    Console.WriteLine("Player 2 wins");
                                }
                                else
                                {
                                    Console.WriteLine("Turn is a draw");
                                }

                                //track the round
                                rounds.Add(theTurn); 

                                break;
                            }
                        case "B":
                            {
                                string inputSides = "";
                                int sides = 0;

                                Console.Write("Enter your number of desired sides (greater than 1):\t");
                                inputSides = Console.ReadLine();

                                //using the conversion try version of parsing
                                // TryParse has two parameters
                                // one: in string to convert
                                // two: the output conversion value if the string can be
                                //      converted
                                // successful conversion returns a true bool
                                // failed conversion returns a false bool
                                if (int.TryParse(inputSides, out sides))
                                {
                                    //validation of the incoming value
                                    if (sides > 1)
                                    {
                                        //set the die instance Sides
                                        Player1.Side = sides;
                                        Player2.Side = sides;

                                    }
                                    else
                                    {
                                        throw new Exception("You did not enter a numeric value greater than 1.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("You did not enter a numeric value.");
                                }
                                break;
                            }
                        case "C":
                            {
                                //Display the current players' stats
                                
                                DisplayCurrentPlayerStats(rounds);
                                break;
                            }
                        case "X":
                            {
                                //Display the final players' stats
                                DisplayCurrentPlayerStats(rounds);
                                Console.WriteLine("\nThank you for playing.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Your choice was invalid. Try again.");
                                break;
                            }
                    }//eos
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                }
            } while (menuChoice.ToUpper() != "X");
        }//eomain

        public static void DisplayCurrentPlayerStats(List<Turn> rounds)
        {

            int wins1 = 0;
            int wins2 = 0;
            int draws = 0;

            //travser the List<Turn> to calculate wins, losses, and draws
            foreach(Turn item in rounds)
            {
                if (item.Player1 > item.Player2)
                {
                    wins1 = wins1 + 1;
                }

                else if (item.Player2 > item.Player1)
                {
                    wins2 += 1;
                }

                else
                {
                    draws++;
                }
            }

            //display the results
            Console.WriteLine("\n Total Rounds: " + (wins1 + wins2 + draws).ToString());
            Console.WriteLine("\nPlayer1: Wins: {0}  Player2: Wins: {1}  Total Draws: {2}",
                wins1, wins2, draws);

        }
    }
}
