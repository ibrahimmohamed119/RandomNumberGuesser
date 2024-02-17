// See https://aka.ms/new-console-template for more information
using RandomNumberGuesser;

List<Player> players = new List<Player>();
List<string> names = new List<string>();
while (true)
{
    Console.Clear();
    Console.WriteLine("==================== Number Guesser Game =======================");
    Console.WriteLine("1. Play");
    Console.WriteLine("2. Leaderboard");
    Console.WriteLine("3. Exit");
    Console.WriteLine("\n\n\n\n\n\n\n");
    Console.WriteLine("Please make a selection from the menu:");
    string selection = Console.ReadLine();
    if (selection == "1")
    {
        bool playAgain = true;
        Console.WriteLine("Enter your name:");
        string playerName = Console.ReadLine();
        while (playAgain)
        {
            Console.Clear();
            bool found = false;
            Random rnd = new Random();
            int num = rnd.Next(1, 101);
            Console.WriteLine("I'm thinking about a number from 1 to 100. Can you guess the number?");
            int numberOfGuesses = 0;
            while (!found)
            {
                numberOfGuesses++;
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userGuess))
                {
                    if (userGuess < 1 || userGuess > 100)
                    {
                        Console.WriteLine("Your number is out of bounds! Pick a number between 1 and 100!");
                    }
                    else if (userGuess == num)
                    {
                        found = true;
                        Console.WriteLine($"You guessed the right number! It took you {numberOfGuesses} guesses!");
                    }
                    else if (userGuess > num + 5)
                    {
                        Console.WriteLine("Your number is too high! Try again!");
                    }
                    else if (userGuess > num)
                    {
                        Console.WriteLine("Your number is close but a bit high! Try again!");
                    }
                    else if (userGuess < num - 5)
                    {
                        Console.WriteLine("Your number is too low! Try again!");
                    }
                    else
                    {
                        Console.WriteLine("Your number is close but a bit low! Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a numerical value!");
                }
            }
            if (names.Contains(playerName))
            {
                List<Player> player = players.Where(x => x.Name == playerName).ToList();
                foreach (var p in player)
                {
                    if (p.BestScore > numberOfGuesses)
                    {
                        p.BestScore = numberOfGuesses;
                        Console.WriteLine("NEW HIGH SCORE! CONGRATULATIONS!");
                    }
                }
            }
            else
            {
                names.Add(playerName);
                players.Add(new Player(playerName, numberOfGuesses));
            }
            Console.WriteLine("Do you want to play again? (Enter 'Y' if yes, any other key if no)");
            if (Console.ReadLine().ToLower() != "y")
            {
                playAgain = false;
            }
        }
        
    }
    else if (selection == "2")
    {
        int ranking = 1;
        Console.Clear();
        List<Player> leaderboard = players.OrderBy(x => x.BestScore).ToList();
        foreach (var player in leaderboard)
        {
            Console.Write($"{ranking}.   ");
            Console.WriteLine(player);
            ranking++;
        }
        Console.WriteLine("\n\n\n\n\n\n\n\nPress any key to return to main menu.");
        Console.ReadLine();
    }
    else if (selection == "3")
    {
        Console.Clear();
        Console.WriteLine("Thanks for playing!");
        break;
    }
}
