using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
