namespace GradeCalculator;

internal abstract class InputLoop
{
    public static void Loop()
    {
        while (true)
        {
            List<Student> studentsInput = [];

            do
            {
                Student inStudent = new();
                studentsInput.Add(inStudent);
                if (!inStudent.AddAnother) break;
            } while (true);

            Logic.OutputAllStudents(studentsInput);
            Logic.GetAndOutputHighestGrade(studentsInput);
            Logic.OutputAverageMark(studentsInput);

            Console.WriteLine("Hit enter to rerun the calculator!");
            if (Console.ReadKey().Key != ConsoleKey.Enter) return;
            Console.Clear();
        }
    }
}