using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
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
            get =>this.length;       
            
            private set
            {
                ThrowIfLessOrEqualToZero(value, nameof(this.Length));

                this.length = value; 
            } 
        }
        public double Width 
        {
            get => this.width;

            private set
            {
                ThrowIfLessOrEqualToZero(value, nameof(this.Width));

                this.width = value;
            }
        }
        public double Height 
        {
            get => this.height;

            private set
            {
                ThrowIfLessOrEqualToZero(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double SurfaceArea() => 2 * (this.Length + this.Width) * this.Height + 2 * this.Length * this.Width;

        public double LateralSurfaceArea() => 2 * (this.Length + this.Width) * this.Height;

        public double Volume() => this.Length * this.Width * this.Height;

        private static void ThrowIfLessOrEqualToZero(double value, string dimension)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{dimension} cannot be zero or negative.");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {Volume():F2}");

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
