namespace GradeCalculator;

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
            var userInput = Console.ReadLine();

            //if input is not null/empty return input
            if (!string.IsNullOrEmpty(userInput)) return userInput;
            //otherwise prompt again
            Console.WriteLine("Input is empty! Please try again.");
        }
    }

    /// <summary>
    /// Ensures mark input is valid
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns>The input as a double</returns>
    public static double GetValidMarkInput(string prompt)
    {
        while (true)
        {
            //gets user input of mark as string and performs validation
            var userInput = GetNonEmptyStringInput(prompt);

            //parses user input to double, checks if valid range and returns valid input
            if (double.TryParse(userInput, out var mark) && mark is >= 0 and <= 100) return mark;
            //otherwise prompt again
            Console.WriteLine("Please enter a valid input between 0 and 100!");
        }
    }

    public static bool GetYOrNInput(string prompt)
    {
        while (true)
        {
            //gets user input as string and performs validation
            var userInput = GetNonEmptyStringInput(prompt).ToUpper();

            switch (userInput)
            {
                case "Y":
                    return true;
                case "N":
                    return false;
                default:
                    Console.WriteLine("Please enter a Y or N!");
                    break;
            }
        }
    }
}