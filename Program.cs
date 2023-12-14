namespace D1
{
    internal class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            LogicTemplate logic = new LogicTemplate();

            do //initialise overall input loop
            {
                Student inStudent = new Student();
                students.Add(inStudent);
                addAnother = Logic.AddAnother;
            }

            Logic.OutputAllStudents(students);
            Logic.GetHighestGrade(students);
        }
            
    }
}
public class Student
    {
        public string Name { get; set; }
        public double Mark { get; set; }
        public bool IsHigher { get; set; }
    public string Grade { get; set; }
    public bool HasPassed { get; set; }


    public Student()
        {
            Name = GetName();
            Mark = GetMark();
            IsHigher = GetBand();
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
            if (mark < 10) return "U";
            else if (mark < 30) return "F";
            else if (mark < 50) return "E";
            else if (mark < 60) return "D";
            else if (mark < 70) return "C";
            else if (mark < 80) return "B";
            else if (mark < 90) return "A";
            else return "A*";
        }
        else
        {
            if (mark < 20) return "U";
            else if (mark < 40) return "F";
            else if (mark < 60) return "E";
            else if (mark < 80) return "D";
            else if (mark < 90) return "C";
            else return "B";
        }
    }

    /// <summary>
    /// Calculates if the user has passed based on their grade
    /// </summary>
    /// <param name="grade"></param>
    /// <returns>True if the grade is A*, A, B or C, otherwise false</returns>
    private static bool CalculatePassed(string grade)
    {
        return grade == "C" || grade == "B" || grade == "A" || grade == "A*";
    }
}


public class LogicTemplate
{
    /// <summary>
    /// Outputs all student details, including a pass/fail and their grade
    /// </summary>
    /// <param name="students"></param>
    public static void OutputAllStudents(List<Student> students)
    {
        Console.WriteLine();
        foreach (var student in students)
        {
            Console.Write(student.Name + " has ");

            if (student.HasPassed) Console.Write("passed");
            else Console.Write("failed");

            Console.WriteLine(" with a Grade " + student.Grade + "!");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Sorts all students into a new list by grade, then outputs the students who achieved the highest grade
    /// </summary>
    /// <param name="studentsInput"></param>
    public static void GetAndOutputHighestGrade(List<Student> students)
    {
        //sorts student list alphabetically, this list stores A above A*
        List<Student> studentsByOrdinal = students.OrderBy(student => student.Grade, StringComparer.Ordinal).ToList();

        //begin process to move A* above A

        //initialise new list to store final result
        List<Student> studentsByGrade = new List<Student>();

        //for every student input
        for (int i = 0; i < studentsByOrdinal.Count; i++)
        {
            var student = studentsByOrdinal[i];

            if (student.Grade == "A*")
            {
                //add A* students to final list
                studentsByGrade.Add(student);
                //remove A* students from old list
                studentsByOrdinal.Remove(student);
            }
        }

        //add all other students to final list
        foreach (var student in studentsByOrdinal) studentsByGrade.Add(student);

        //gets the highest grade
        string highestGrade = studentsByGrade[0].Grade;

        //initialise list for all students with that grade
        List<Student> studentsWithHighestGrade = new List<Student>();

        foreach (var student in studentsByGrade)
        {
            if (student.Grade == highestGrade)
            {
                //add all highest grade students to highest grade list
                studentsWithHighestGrade.Add(student);
            }
        }

        Console.Write("There ");
        if (studentsWithHighestGrade.Count == 1) Console.Write("is ");
        else Console.Write("are ");
        Console.Write(studentsWithHighestGrade.Count + " student");
        if (studentsWithHighestGrade.Count != 1) Console.Write("s");
        Console.Write(" with the highest grade of a");
        if (highestGrade == "E" || highestGrade == "A" || highestGrade == "A*") Console.Write("n");
        Console.WriteLine(" " + highestGrade + "!");
        if (studentsWithHighestGrade.Count == 1) Console.WriteLine("This was achieved by " + studentsWithHighestGrade[0].Name + ".");
        else
        {
            Console.WriteLine("This was achieved by the following students:");
            foreach (var student in studentsWithHighestGrade)
            {
                if (student.Grade == highestGrade)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
    }

    public Logic() 
    {
        AddAnother = CalculateAddAnother();
    }

/// <summary>
/// Contains the whole program's input validation
/// </summary>
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
            //Output user propmpt to enter name
            Console.WriteLine(prompt);
            string? userInput = Console.ReadLine();

            //if input is not null/empty return input
            if (!string.IsNullOrEmpty(userInput)) return userInput;
            //otherwise reprompt
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
        while(true)
        {
            //gets user input of mark as string and performs validation
            string userInput = GetNonEmptyStringInput(prompt);

            //parses user input to double, checks if valid range and returns valid input
            if (double.TryParse(userInput, out double mark) && (mark >= 0 && mark <= 100)) return mark;
            //otherwise reprompt
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
            else if (userInput == "N") return false;
            else Console.WriteLine("Please enter a Y or N!");
        }
    }
}