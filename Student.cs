namespace GradeCalculator;

public class Student
{
        
    internal string Name { get; }
    internal double Mark { get; }
    private bool IsHigher { get; }
    internal bool AddAnother { get; }
    internal string Grade { get; }
    public bool HasPassed { get; }


    public Student()
    {
        Name = GetName();
        Mark = GetMark();
        IsHigher = GetBand();
        AddAnother = GetAddAnother();
        Grade = CalculateGrade(IsHigher, Mark);
        HasPassed = CalculatePassed(Grade);

    }

    /// <summary>
    /// Gets user input for student name
    /// </summary>
    /// <returns>The name of the student</returns>
    private static string GetName()
    {
        return InputValidation.GetNonEmptyStringInput("Enter a student's name:");
    }

    /// <summary>
    /// Gets user input for student mark out of 100
    /// </summary>
    /// <returns>The mark of the student as a double</returns>
    private static double GetMark()
    {
        return InputValidation.GetValidMarkInput("Enter the student's mark:");
    }


    /// <summary>
    /// Gets user input for if the student is on the higher band
    /// </summary>
    /// <returns>True if the user inputs Y on the question, otherwise false if the user inputs N, otherwise reruns if user input is invalid</returns>
    private static bool GetBand()
    {
        return InputValidation.GetYOrNInput("Is the student on the higher grade list? [Y/N]");
    }

    /// <summary>
    /// Gets user input for if the user would like to add another student
    /// </summary>
    /// <returns>True if the user inputs Y on the question, otherwise false if the user inputs N, otherwise reruns if user input is invalid</returns>
    private static bool GetAddAnother()
    {
        return InputValidation.GetYOrNInput("Would you like to add another student? [Y/N]");
    }

    /// <summary>
    /// Calculates student grade from mark and band
    /// </summary>
    /// <param name="isHigher"></param>
    /// <param name="mark"></param>
    /// <returns>The grade (A*-U) as a string</returns>
    internal static string CalculateGrade(bool isHigher, double mark)
    {
        if (isHigher)
        {
            return mark switch
            {
                < 10 => "U",
                < 30 => "F",
                < 50 => "E",
                < 60 => "D",
                < 70 => "C",
                < 80 => "B",
                < 90 => "A",
                _ => "A*"
            };
        }

        {
            return mark switch
            {
                < 20 => "U",
                < 40 => "F",
                < 60 => "E",
                < 80 => "D",
                < 90 => "C",
                _ => "B"
            };
        }
    }

    /// <summary>
    /// Calculates if the user has passed based on their grade
    /// </summary>
    /// <param name="grade"></param>
    /// <returns>True if the grade is A*, A, B or C, otherwise false</returns>
    private static bool CalculatePassed(string grade)
    {
        return grade is "C" or "B" or "A" or "A*";
    }
        
}