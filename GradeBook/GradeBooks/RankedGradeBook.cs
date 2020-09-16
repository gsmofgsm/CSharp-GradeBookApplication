using System;
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
                throw new InvalidOperationException();
            }

            Students.Sort((x, y) => y.AverageGrade.CompareTo(x.AverageGrade));

            int pos = 0;
            for (var i = 0; i < count; i++)
            {
                if (Students[i].AverageGrade < averageGrade)
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
