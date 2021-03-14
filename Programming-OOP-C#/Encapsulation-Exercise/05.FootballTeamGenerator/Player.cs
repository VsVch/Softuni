using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {

        private const double NumberOfSkills = 5.0;
        private const int MinSkillPoints = 0;
        private const int MaxSkillPoints = 100;
       
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name 
        {
            get => this.name;
            private set 
            {
                Validator.NameValidation
                    (value, GlobalConstants.InvalideNameExeptionsMessege);
                this.name = value;            
            } 
        }

        public int Endurance 
        {
            get => this.endurance;
            private set 
            {
                Validator.SkillValidation
                    (MinSkillPoints, 
                    MaxSkillPoints, 
                    value, 
                    $"{nameof(Endurance)} should be between {MinSkillPoints} and {MaxSkillPoints}.");

                this.endurance = value;           
            } 
        }

        public int Sprint 
        {
            get => this.sprint;
            private set 
            {
                Validator.SkillValidation
                    (MinSkillPoints,
                    MaxSkillPoints,
                    value,
                    $"{nameof(Sprint)} should be between {MinSkillPoints} and {MaxSkillPoints}.");

                this.sprint = value;
            }
        }

        public int Dribble 
        {
            get => this.dribble;
            private set 
            {
                Validator.SkillValidation
                  (MinSkillPoints,
                  MaxSkillPoints,
                  value,
                  $"{nameof(Dribble)} should be between {MinSkillPoints} and {MaxSkillPoints}.");

                this.dribble = value;
            } 
        }

        public int Passing 
        {
            get => this.passing;
            private set
            {
                Validator.SkillValidation
                  (MinSkillPoints,
                  MaxSkillPoints,
                  value,
                  $"{nameof(Passing)} should be between {MinSkillPoints} and {MaxSkillPoints}.");

                this.passing = value;
            }

        }

        public int Shooting 
        {
            get => this.shooting;
            private set
            {
                Validator.SkillValidation
                  (MinSkillPoints,
                  MaxSkillPoints,
                  value,
                  $"{nameof(Shooting)} should be between {MinSkillPoints} and {MaxSkillPoints}.");

                this.shooting = value;
            }
        }


        public double AveragePlayerSkillLevel =>        
            Math.Round((endurance + sprint + dribble + passing + shooting) / NumberOfSkills);

                  
        
    }
}
