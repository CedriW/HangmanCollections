using System;
using System.Collections.Generic;

namespace Hangman
{
    public class Game
    {
        private string word;
        private List<char> charas;
        private int remain;

        public Game(string word, int attempts)
        {
            this.word = word.ToUpper();
            charas = new List<char>();
            remain = attempts;
        }

        private string MaskWord()
        {
            string maskedWord = "";

            foreach (char letter in word)
            {
                if (charas.Contains(letter))
                    maskedWord += letter;
                else
                    maskedWord += "_";
            }

            return maskedWord;
        }

        private char ValidCheck()
        {
            char guess;

            while (true)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine().ToUpper();

                if (input.Length == 1 && char.IsLetter(input[0]))
                {
                    guess = input[0];
                    if (charas.Contains(guess))
                    {
                        Console.WriteLine("Character already attempted, please enter a different one");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("Invalid input: Please enter a single character.");
            }

            return guess;
        }

        private bool GameOver()
        {
            return remain == 0;
        }

        private bool WordCheck()
        {
            foreach (char letter in word)
            {
                if (!charas.Contains(letter))
                    return false;
            }

            return true;
        }

        public void Play()
        {
            Console.WriteLine("Starting Hangman Game");

            while (true)
            {
                Console.WriteLine("\nAttempts Remaining: {0}", remain);
                Console.WriteLine("Guessed Characters: {0}", string.Join(", ", charas));
                Console.WriteLine("Word: {0}", MaskWord());

                char guess = ValidCheck();

                charas.Add(guess);

                if (!word.Contains(guess))
                {
                    remain--;
                    Console.WriteLine("Wrong guess, try again");
                }

                if (GameOver())
                {
                    Console.WriteLine("\nGame Over");
                    Console.WriteLine("The word was: {0}", word);
                    break;
                }

                if (WordCheck())
                {
                    Console.WriteLine("\nGood job, you guessed the word: {0}", word);
                    break;
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }    

    class Program
    {
        static void Main()
        {
            string word = "HANGMAN";
            int attempts = 6;

            Game game = new Game(word, attempts);
            game.Play();
        }
    }
}

