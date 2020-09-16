using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var count = Students.Count;
            if (count < 5)
            {
                throw new InvalidOperationException("5 students are needed for ranked grade");
            }

            Students.Sort((x, y) => y.AverageGrade.CompareTo(x.AverageGrade));
            var grades = Students.OrderByDescending(e => e.AverageGrade)
                .Select(e => e.AverageGrade).ToList();

            int pos = 0;
            for (var i = 0; i < count; i++)
            {
                if (grades[i] == averageGrade)
                {
                    pos = i;
                    break;
                }
            }

            var percentage = pos / count;
            if (percentage <= 0.20)
            {
                return 'A';
            }
            else if (percentage <= 0.40)
            {
                return 'B';
            }
            else if (percentage <= 0.60)
            {
                return 'C';
            }
            else if (percentage <= 0.80)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
