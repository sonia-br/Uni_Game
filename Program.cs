namespace Game;

// Game options:
//1. Guess the word (User gives one letter at a time and if it is correct,
//the letters will be shown. (E.g.: _ _ _ A _ _ A _ S). 
// 2. Rock Paper Scissors (Rules should be clear)
// 3. Number Sequence Memory (Show each round one additional number, clear the screen and let the user put them in again.)

//Add a scoring system and a leaderboard to the game that is saved persistently in a file.

//Rules
// first user gets a description of the word
// then first letter - first attempt
// if the letter is correct, user gets a point
// there are 3 attempts to guess each letter
// if they are unsuccessful user gets 0 points and the game ends
// check the word for input letter

class Program
{


    static void Main()
    {
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

        int countOfWords = 0;
        foreach (string word in words)
        {
            countOfWords++;
        }

        //Console.WriteLine("Let's play a game 'Guess the letter'");
        //Console.WriteLine("You need to guess the word letter by letter");
        //Console.WriteLine("To start, please type in first letter");

        //string letterInput = Console.ReadLine();
        //char letterToCheck = letterInput[0];

        for (int i = 0; i <= countOfWords; i++)
        {
            string wordToGuess = words[i];
            int wordLength = 0;

            foreach (char letterInWord in words[i])
            {
                wordLength++;
            }

            string wordGuessed = new string('_', wordLength);

            Console.WriteLine("Let's play a game 'Guess the letter'");
            Console.WriteLine("You need to guess the word letter by letter");
            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();
            Console.WriteLine($"The word contains {wordLength} letters: {wordGuessed}");
            Console.WriteLine($"Here is a hint: {descriptions[i]}");
            Console.WriteLine("To start, please type in first letter");

            string letterInput = Console.ReadLine();
            char letterToCheck = char.ToUpper(letterInput[0]);

            bool LetterIsCorrect = true;
            foreach (char letter in words[i])
            {
                int points = 0;
                int numOfAttempts = 2;

                if (letterToCheck == letter)
                {
                    points++;
                    Console.WriteLine("This letter is correct, you get 1 point");
                    LetterIsCorrect = true;
                    //WriteWord(letterToCheck);
                    Console.WriteLine("Now type in second letter:");
                    letterInput = Console.ReadLine();
                }

                if (letterToCheck != letter)
                {
                    for (int t = 0; t <= 3; t++)
                    {
                        Console.WriteLine($"The word doesn't contain this letter. You have {numOfAttempts} attempts. Try again");
                        numOfAttempts--;
                        LetterIsCorrect = false;
                    }
                    

                    Console.WriteLine($"Unfortunately, you have {numOfAttempts} attempts left.\nGame is over");
                    //ShowLeaderBoard(userName);
                }
                else
                {
                    Console.WriteLine("Please type in a letter from english alphabet");
                    LetterIsCorrect = false;
                }
            }
        }

        /*void WriteWord(char letterToCheck)
        {

        }

        void ShowLeaderBoard()
        {

        }*/



    }
}