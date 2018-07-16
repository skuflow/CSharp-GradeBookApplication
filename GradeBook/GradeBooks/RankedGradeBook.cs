using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
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
            char returnValue = '';

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var threshold = (int)Math.Ceiling(Students.Count * .2);
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select( i => i.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
            {
                returnValue = 'A';
            }
            else if (grades[(threshold*2) - 1] <= averageGrade)
            {
                returnValue = 'B';
            }
            else if (grades[(threshold * 3) - 1] <= averageGrade)
            {
                returnValue = 'C';
            }
            else if (grades[(threshold * 4) - 1] <= averageGrade)
            {
                returnValue = 'D';
            }
            else
            {
                returnValue = 'F';
            }

            return returnValue;
        }
    }
}
