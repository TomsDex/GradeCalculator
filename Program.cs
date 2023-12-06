namespace TW_Deliverable_One___Refactored
{
    internal class Program
    {
        static void Main()
        {
            List<Student> studentsInput = new List<Student>();

            do //initialise overall input loop
            {
                Student inStudent = new Student();
                studentsInput.Add(inStudent);
                if (!inStudent.AddAnother) break;

            } while (true);

            Logic.OutputAllStudents(studentsInput);
            Logic.GetHighestGrade(studentsInput);
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
    public bool AddAnother { get; set; }


    public Student()
        {
            Name = GetName();
            Mark = GetMark();
            IsHigher = GetBand();
        Grade = CalculateGrade(IsHigher, Mark);
        HasPassed = CalculatePassed(Grade);
        AddAnother = CalculateAddAnother();

        }

    /// <summary>
    /// Gets user input for student name
    /// </summary>
    /// <returns>The name of the student as a string</returns>
        private static string GetName()
        {
            string? inName;

            while (true) //initialise student name loop
            {
                Console.WriteLine("Enter a student's name:");
                try
                {
                    inName = Console.ReadLine();
                    if (inName == string.Empty) throw new Exception("Name input is empty! Please try again.");
                    else return inName;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            } //end of name loop
        }

    /// <summary>
    /// Gets user input for student mark out of 100
    /// </summary>
    /// <returns>The mark of the student as a double</returns>
    private static double GetMark()
        {
            double inMark;

            while (true) //initialise student grade loop
            {
                Console.WriteLine("Enter the student's mark: ");
                try
                {
                    string? sGrade = Console.ReadLine();
                    if (sGrade == string.Empty) throw new Exception("Grade input is empty! Please try again.");
                    else
                    {
                        if (double.TryParse(sGrade, out inMark) && 0 <= inMark && inMark <= 100) return inMark; 
                        //parse input to double and perform input validatioon that 0 <= inMark <= 100
                        else throw new FormatException("Please enter a valid number between 0 and 100!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            } //end of grade loop
        }

    /// <summary>
    /// Gets user input for if the student is on the higher band
    /// </summary>
    /// <returns>True if the user inputs Y on the question, otherwise false if the user inputs N, otherwise reruns if user input is invalid</returns>
        private static bool GetBand()
        {
            while (true) //initialise higher grade storage loop
            {
                Console.WriteLine("Is this student on the higher grade list? [Y/N]");
                try
                {
                    string? input = Console.ReadLine()?.ToUpper();

                    if (input == "Y") return true;
                    else if (input == "N") return false;
                    else throw new Exception("Please respond with Y or N");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }//end of high/low loop
        }

    /// <summary>
    /// Calculates student grade from mark and band
    /// </summary>
    /// <param name="isHigher"></param>
    /// <param name="mark"></param>
    /// <returns>The grade (A*-U) as a string</returns>
    private static string CalculateGrade(bool isHigher, double mark)
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
        if (grade == "C" || grade == "B" || grade == "A" || grade == "A*") return true;
        else return false;
    }

    /// <summary>
    /// Asks if the user wants to add another student
    /// </summary>
    /// <returns>True if the user inputs Y, false if the user inputs N, repeats if otherwise</returns>
    private static bool CalculateAddAnother()
    {
        Console.WriteLine("Would you like to add another student? [Y/N]");
        while (true)
        {
            try
            {
                string? input = Console.ReadLine()?.ToUpper();
                if (input == "Y") return true;
                else if (input == "N") return false;
                else throw new Exception("Please respond with Y or N");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}

public class Logic
{
    public static void OutputAllStudents(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.Write(student.Name + " has ");

            if (student.HasPassed) Console.Write("passed");
            else Console.Write("failed");

            Console.WriteLine(" with a Grade " + student.Grade + "!");
        }
    }
    public static void GetHighestGrade(List<Student> studentsInput)
    {
        //sorts student list by highest grade. this list stores A above A*
        List<Student> studentsByOrdinal = studentsInput.OrderBy(student => student.Grade, StringComparer.Ordinal).ToList();

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

        //output result
        foreach (var student in studentsByGrade) Console.WriteLine(student.Grade);
    }
}
