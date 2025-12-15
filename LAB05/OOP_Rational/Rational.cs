using System;

namespace OOP_Rational
{
    public class Rational
    {
        private int numerator;
        public int Numerator
        {
            get { return this.numerator; }
            set {
                this.numerator = value;
                Simplify();
             }
        
        }

        private int denominator;
        public int Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator should not be =0");
                }
                this.denominator = value;
                Simplify();
            }
        }

        public Rational(int numerator, int denominator)
        {
            this.numerator = numerator;
            if (denominator == 0)
            {
                throw new DivideByZeroException("Denomenator cant be = 0");
            }

            this.denominator = denominator;
            Simplify();

        }

        public Rational(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
            Simplify();
        }

        public override string ToString()
        {
            return $"Rational: {Numerator}/ {Denominator}";
        }
        public Rational Add(Rational a)
        {
            int newDenominator = this.Denominator * a.Denominator;
            int newNumerator = this.Numerator * a.Denominator + a.Numerator * this.Denominator;
            return new Rational(newNumerator, newDenominator);
        }
        
        public Rational Sub(Rational s)
        {
            int newDenominator = this.Denominator * s.Denominator;
            int newNumerator = this.Numerator * s.Denominator - s.Numerator * this.Denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public Rational Mult(Rational m)
        {
            int newDenominator = this.Denominator * m.Denominator;
            int newNumerator = this.Numerator * m.Numerator;
            return new Rational(newNumerator, newDenominator);
        }
        public Rational Div(Rational d)
        {
            int newDenominator = this.Denominator * d.Numerator;
            int newNumerator = this.Numerator * d.Denominator;
            return new Rational(newNumerator, newDenominator);
        }
        public static Rational operator +(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Denominator;
            int newNumerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
            return new Rational(newNumerator, newDenominator);
        }
                public static Rational operator -(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Denominator;
            int newNumerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
            return new Rational(newNumerator, newDenominator);
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Denominator;
            int newNumerator = r1.Numerator *  r2.Numerator;
            return new Rational(newNumerator, newDenominator);
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Numerator;
            int newNumerator = r1.Numerator *  r2.Denominator;
            return new Rational(newNumerator, newDenominator);
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void Simplify()
        {
            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }

            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));

            numerator /= gcd;
            denominator /= gcd;
        }

        }
    }
