
namespace Game;
using System;

// Game options:
//1. Guess the word (User gives one letter at a time and if it is correct,
//the letters will be shown. (E.g.: _ _ _ A _ _ A _ S). 

//Add a scoring system and a leaderboard to the game that is saved persistently in a file.

//Rules
// first user gets a description of the word
// then first letter - first attempt
// if the letter is correct, user gets a point
// there are 3 attempts to guess each letter
// if they are unsuccessful user gets 0 points and the game ends

class Program
{
    static void Main()
    {
        LeaderBoard leaderboard = new LeaderBoard();
        
        List<string> words = new List<string>();
        words.Add("APPLE");
        words.Add("CHRISTMAS");
        words.Add("UNIVERSITY");
        words.Add("LAKE");

        List<string> descriptions = new List<string>();
        descriptions.Add("it is a fruit");
        descriptions.Add("it is a public holiday");
        descriptions.Add("it is a type of education");
        descriptions.Add("it is a body of water");
        while (true)
        {

            Console.WriteLine("Let's play a game 'Guess the letter'");
            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello, {userName}! Let's start!");
            
            int countOfWords = 0;
            foreach (string word in words) // counting words in the list
            {
                countOfWords++;
            }

            bool continueGuessing = true;
            
            for (int i = 0; i < countOfWords && continueGuessing; i++) //using words in the list for the game
            {
                string wordToGuess = words[i]; //taking first word from the list
                int wordLength = 0;

                foreach (char letterInWord in words[i]) //taking number of letters
                {
                    wordLength++;
                }

                char[] wordGuessed = new char[wordLength]; //replacing each letter with low dash
                for (int k = 0; k < wordLength; k++)
                {
                    wordGuessed[k] = '_';
                }

                Console.WriteLine($"The word contains {wordLength} letters: {new string(wordGuessed)}");
                Console.WriteLine($"Here is a hint: {descriptions[i]}");
                Console.WriteLine("To start, please type in first letter");

                int points = 0;
                int numOfAttempts = 3;

                bool wordIsGuessed = false; // boolean to end the loop when word is guessed

                while (!wordIsGuessed && numOfAttempts > 0)
                {
                    bool letterIsCorrect = false;
                    
                    string letterInput = Console.ReadLine();
                    char letterToCheck = char.ToUpper(letterInput[0]);

                    for (int j = 0; j < wordLength; j++)
                    {


                        if (wordToGuess[j] == letterToCheck)
                        {
                            wordGuessed[j] = letterToCheck;
                            letterIsCorrect = true;
                        }

                    }

                    if (letterIsCorrect && !wordIsGuessed)
                    {
                        points++;
                        Console.WriteLine($"You guessed a correct letter: {new string(wordGuessed)}, you get 1 point");
                        Console.WriteLine("Type in the next letter:");
                    }

                    else
                    {
                        numOfAttempts--;
                        if (points > 0) points--;
                        Console.WriteLine(
                            $"The word doesn't contain this letter. You have {numOfAttempts} attempts. Try again");
                    }



                    wordIsGuessed = true;
                    for (int index = 0; index < wordLength; index++)
                    {
                        if (wordGuessed[index] == '_')
                        {
                            wordIsGuessed = false;
                            break;
                        }
                    }
                }


                if (wordIsGuessed)
                {
                    Console.WriteLine($"Hooray! You've guessed the word: {new string(wordGuessed)}.\n" +
                                      $"You earned: {points} points.");
                    //Console.WriteLine("Type in the next letter:");
                }
                else
                {
                    Console.WriteLine($"You couldn't guess the word: {wordToGuess}.\n" +
                                      $"Game over ;(");
                    break;
                }
                
                Console.WriteLine($"Total number of points you earned:{points}");
                leaderboard.AddUser(userName, points);

                Console.WriteLine("Here is the leaderboard");
                GetLeader(leaderboard.entries);

                if (i < countOfWords - 1)
                {
                    Console.WriteLine("Do you want to guess another word?\nY/N");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        continue;
                    }

                    if (answer == "N")
                    {
                        continueGuessing=false;
                    }
                }
                
                Console.WriteLine("Do you want to start another game as another user?\nY/N");
                string answer2 = Console.ReadLine().ToUpper();
                if (answer2 == "Y")
                {
                    continue;
                }

                if (answer2 == "N")
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }
            }

            static void GetLeader(List<(string Username, int Points)> entries)
            {
                
                int leaderBoardCount = 0;
                
                foreach (var user in entries) // counting users in the leaderboard
                {
                    leaderBoardCount ++;
                }
                
                if (leaderBoardCount == 0)
                {
                    Console.WriteLine("The leaderboard is empty.");
                    return;
                }

                for (int i = 0; i < leaderBoardCount - 1; i++)
                {
                    for (int j = 0; j < leaderBoardCount - i - 1; j++)
                    {
                        if (entries[j].Points < entries[j + 1].Points)
                        {
                            var temp = entries[j];
                            entries[j] = entries[j + 1];
                            entries[j + 1] = temp;
                        }
                    }
                }
                
                Console.WriteLine("Leaderboard:");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Username}: {entry.Points}");
                }
            }
        }

        
    }
}