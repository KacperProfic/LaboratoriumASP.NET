using Microsoft.VisualBasic.CompilerServices;

namespace WebApp.Models
{
    public class Calculator
    {
        // Properties for operator and numbers
        public Operators? Operator { get; set; }  // Maps to the "op" input field
        public double? X { get; set; }            // Maps to the first number input field
        public double? Y { get; set; }            // Maps to the second number input field

        // Returns the string representation of the selected operator
        public string Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.Add:
                        return "+";
                    case Operators.Sub:
                        return "-";
                    case Operators.Mul:
                        return "*";
                    case Operators.Div:
                        return "/";
                    case Operators.Pow:
                        return "^";
                    case Operators.Sin:
                        return "sin";
                    default:
                        return "";
                }
            }
        }

        // Validation method to check if inputs are valid
        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        // Method to perform the calculation based on the operator
        public double Calculate()
        {
            if (!IsValid()) return double.NaN;

            switch (Operator)
            {
                case Operators.Add:
                    return (double)(X + Y);
                case Operators.Sub:
                    return (double)(X - Y);
                case Operators.Mul:
                    return (double)(X * Y);
                case Operators.Div:
                    return Y != 0 ? (double)(X / Y) : double.NaN;  // Avoid division by zero
                case Operators.Pow:
                    return Math.Pow((double)X, (double)Y);
                case Operators.Sin:
                    return Math.Sin((Math.PI / 180) * (double)X);  // Calculate sine in degrees
                default:
                    return double.NaN;
            }
        }

        // Enum for operators
        public enum Operators
        {
            Add, Sub, Mul, Div, Pow, Sin
        }
    }
}