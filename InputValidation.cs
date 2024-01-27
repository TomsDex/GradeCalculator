public static class InputValidation
{
    /// <summary>
    /// Ensures a string is not empty or null
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns>A user input</returns>
    public static string GetNonEmptyStringInput(string prompt)
    {
        while (true)
        {
            //Output user prompt to enter name
            Console.WriteLine(prompt);
            string? userInput = Console.ReadLine();

            //if input is not null/empty return input
            if (!string.IsNullOrEmpty(userInput)) return userInput;
            //otherwise prompt again
            Console.WriteLine("Input is empty! Please try again.");
        }
    }

    /// <summary>
    /// Ensures an entered mark is valid
    /// </summary>
    /// <param name="input"></param>
    /// <returns>A number between 0 and 100</returns>
    public static double GetValidMarkInput(string prompt)
    {
        while (true)
        {
            //gets user input of mark as string and performs validation
            string userInput = GetNonEmptyStringInput(prompt);

            //parses user input to double, checks if valid range and returns valid input
            if (double.TryParse(userInput, out double mark) && (mark >= 0 && mark <= 100)) return mark;
            //otherwise prompt again
            Console.WriteLine("Please enter a valid input between 0 and 100!");
        }
    }

    public static bool GetYOrNInput(string prompt)
    {
        while (true)
        {
            //gets user input as string and performs validation
            string userInput = GetNonEmptyStringInput(prompt).ToUpper();

            //converts y/n to bool
            if (userInput == "Y") return true;
            if (userInput == "N") return false;
            Console.WriteLine("Please enter a Y or N!");
        }
    }
}