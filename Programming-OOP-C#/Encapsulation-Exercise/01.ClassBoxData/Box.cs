using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{

    public class Box
    {
        private const string INVALID_SIDE_EXP_MSG = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.Validation(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.Validation(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.Validation(value, nameof(this.Height));

                this.height = value;
            }
        }

        public void Validation(double side, string paramName) 
        {
            if (side <= 0)
            {
                throw new ArgumentException(String.Format(INVALID_SIDE_EXP_MSG, paramName));
            }

        }

        public double Volume() 
        {
            return this.Length * this.Width * this.Height;        
        }

        public double LateralSurfaceArea()
        {
            return (2 * this.Width * this.Height) + (2 * this.Length * this.Height);
        
        }

        public double SurfaceArea() 
        {
            return (2 * this.Width * this.Length) + LateralSurfaceArea();
        
        }

        public override string ToString()
        {
            StringBuilder boxInfo = new StringBuilder();

            boxInfo.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            boxInfo.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            boxInfo.AppendLine($"Volume - {Volume():f2}");

            return boxInfo.ToString().TrimEnd();
        }


    }
}
