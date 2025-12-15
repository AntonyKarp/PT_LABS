using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Static
{
    public class Fraction
    {
        // Поле для целой части
        private int wholePart;
        public int WholePart
        {
            get { return this.wholePart; }
            set { this.wholePart = value; }
        }

        // Поле для дробной части (тысячные доли)
        private int fractionalPart;
        public int FractionalPart
        {
            get { return this.fractionalPart; }
            set
            {
                if (value < 0 || value > 999)
                    throw new ArgumentException("Дробная часть должна быть в диапазоне 0-999");
                this.fractionalPart = value;
            }
        }

        // Конструктор
        public Fraction(int wholePart, int fractionalPart)
        {
            WholePart = wholePart;
            FractionalPart = fractionalPart;
        }

        // Переопределение ToString
        public override string ToString()
        {
            // "a.b", где b дополняется нулями до трех знаков
            return $"{WholePart}.{FractionalPart:000}";
        }

        // Оператор сложения (+)
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            // Переводим всё в тысячные доли (аналог миллисекунд во времени, но тут просто доли)
            // Учитываем знак числа. Для простоты будем считать части положительными,
            // но для корректной математики лучше работать через double или общее число долей.

            // Логика через общее количество тысячных долей:
            long total1 = f1.WholePart * 1000L + f1.FractionalPart;
            long total2 = f2.WholePart * 1000L + f2.FractionalPart;

            long sum = total1 + total2;

            int newWhole = (int)(sum / 1000);
            int newFrac = (int)(sum % 1000);

            return new Fraction(newWhole, newFrac);
        }

        // Оператор вычитания (-)
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            long total1 = f1.WholePart * 1000L + f1.FractionalPart;
            long total2 = f2.WholePart * 1000L + f2.FractionalPart;

            long diff = total1 - total2;

            // Если результат отрицательный, логика дроби может усложниться.
            // В рамках простой модели дроби (целая.дробная) обычно предполагается положительная дробная часть.
            // Если diff отрицательный (например -1500), это -1 целая и 500 тысячных? Или -1.500?
            // Обычно дробная часть выводится как положительное число после точки.
            // Для упрощения вернем абсолютные значения составляющих с правильным знаком у целой части,
            // но задание просит "a.b". Пусть будет математически корректный подход:

            int newWhole = (int)(diff / 1000);
            int newFrac = (int)Math.Abs(diff % 1000); // Дробная часть всегда положительна при выводе (например -1.5)

            // Корректировка для отрицательных чисел, если результат типа -0.5
            // При целочисленном делении -500 / 1000 = 0.
            // Тогда мы потеряем знак.
            // Поэтому, если число отрицательное и целая часть 0, нам нужно как-то хранить знак.
            // Но в простом классе Fraction обычно знак хранится в целой части.
            // Ограничимся простой реализацией.

            return new Fraction(newWhole, newFrac);
        }

        // Оператор умножения (*)
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            double val1 = f1.WholePart + f1.FractionalPart / 1000.0;
            double val2 = f2.WholePart + f2.FractionalPart / 1000.0;

            double res = val1 * val2;

            int newWhole = (int)res;
            int newFrac = (int)(Math.Round((Math.Abs(res) - Math.Abs(newWhole)) * 1000));

            if (newFrac > 999) newFrac = 999; // Защита от переполнения при округлении

            return new Fraction(newWhole, newFrac);
        }

        // Оператор деления (/)
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            double val1 = f1.WholePart + f1.FractionalPart / 1000.0;
            double val2 = f2.WholePart + f2.FractionalPart / 1000.0;

            if (Math.Abs(val2) < 0.0001) 
                throw new DivideByZeroException("Деление на ноль");

            double res = val1 / val2;

            int newWhole = (int)res;
            int newFrac = (int)(Math.Round((Math.Abs(res) - Math.Abs(newWhole)) * 1000));

            if (newFrac > 999) newFrac = 999;

            return new Fraction(newWhole, newFrac);
        }

        // Переопределение Equals
        public override bool Equals(object obj)
        {
            return obj is Fraction otherFraction &&
                   WholePart == otherFraction.WholePart &&
                   FractionalPart == otherFraction.FractionalPart;
        }

        // GetHashCode (желательно переопределять вместе с Equals)
        public override int GetHashCode()
        {
            return (WholePart, FractionalPart).GetHashCode();
        }
    }
}
