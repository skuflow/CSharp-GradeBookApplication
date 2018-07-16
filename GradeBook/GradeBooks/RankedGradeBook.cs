using System;
using System.Collections.Generic;
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
            char returnValue = 'F';

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("At least five(5) students are required for ranked grading.");
            }

            if (averageGrade >= 80) returnValue = 'A';
            if (averageGrade >= 60 && averageGrade < 80) returnValue = 'B';
            if (averageGrade >= 40 && averageGrade < 60) returnValue = 'C';
            if (averageGrade >= 20 && averageGrade < 40) returnValue = 'D';
            return returnValue;
        }
    }
}
