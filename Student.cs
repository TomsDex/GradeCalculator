namespace GradeCalculator
{
    public class Student
    {
        
            public string Name { get; set; }
            public double Mark { get; set; }
            public bool IsHigher { get; set; }
            public bool AddAnother { get; set; }
            public string Grade { get; set; }
            public bool HasPassed { get; set; }


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
                    if (mark < 10) return "U";
                    if (mark < 30) return "F";
                    if (mark < 50) return "E";
                    if (mark < 60) return "D";
                    if (mark < 70) return "C";
                    if (mark < 80) return "B";
                    if (mark < 90) return "A";
                    return "A*";
                }
                {
                    if (mark < 20) return "U";
                    if (mark < 40) return "F";
                    if (mark < 60) return "E";
                    if (mark < 80) return "D";
                    if (mark < 90) return "C";
                    return "B";
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
}
