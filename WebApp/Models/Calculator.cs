using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace WebApp.Models
{
    public class Calculator
    {
        public Operators? op { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public String Op
        {
            get
            {
                switch (op)
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

        public bool IsValid()
        {
            // Dla Sin tylko X musi być ustawione
            if (op == Operators.Sin)
                return X != null;
            return op != null && X != null && Y != null;
        }

        public double Calculate()
        {
            switch (op)
            {
                case Operators.Add:
                    return (double)(X + Y);
                case Operators.Sub:
                    return (double)(X - Y);
                case Operators.Mul:
                    return (double)(X * Y);
                case Operators.Div:
                    return Y != 0 ? (double)(X / Y) : double.NaN;
                case Operators.Pow:
                    return Math.Pow((double)X, (double)Y);
                case Operators.Sin:
                    return Math.Sin((Math.PI / 180) * (double)X); // X w stopniach
                default:
                    return double.NaN;
            }
        }
    }
}

public enum Operators
{
    Add, Sub, Mul, Div, Pow, Sin
}
