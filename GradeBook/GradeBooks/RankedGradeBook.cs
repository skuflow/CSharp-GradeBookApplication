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
                throw new InvalidOperationException();
            }

            if (averageGrade >= .8) returnValue = 'A';
            if (averageGrade >= .6 && averageGrade < .8) returnValue = 'B';
            if (averageGrade >= .4 && averageGrade < .6) returnValue = 'C';
            if (averageGrade >= .2 && averageGrade < .4) returnValue = 'D';
            return returnValue;
        }
    }
}
