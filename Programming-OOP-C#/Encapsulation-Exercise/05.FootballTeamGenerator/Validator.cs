using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public static class Validator
    {
        public static void SkillValidation(int min, int max, int value, string messagException) 
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(messagException);
            }
        
        }

        public static void NameValidation(string value, string messagException) 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(messagException);
            }       
        
        }
    }
}
