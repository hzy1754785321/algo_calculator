using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace calculator
{
    public class calculate : Form1
    {
        public static Stack<double> numberStack = new Stack<double>();
        public static Stack<char> charStack = new Stack<char>();
        public static void Read()
        {
            for (int i = 0; i < inputStr.Count; i++)
            {
                if (!IsOperator(inputStr[i]))
                {
                    string s = null;
                    while (i < inputStr.Count && !IsOperator(inputStr[i]))
                    {
                        s += inputStr[i];
                        i++;
                    }
                    i--;
                    double temp = Convert.ToDouble(s);
                    numberStack.Push(temp);
                }
                else if (IsOper(inputStr[i]))
                {
                    if (charStack.Count == 0 || charStack.Peek().Equals('('))
                    {
                        charStack.Push(inputStr[i]);
                    }
                    else if (OperatorPrecedence(inputStr[i]) > OperatorPrecedence(charStack.Peek()))
                    {
                        charStack.Push(inputStr[i]);
                    }
                    else
                    {
                        double n1, n2;
                        char s1;
                        n2 = numberStack.Pop();
                        n1 = numberStack.Pop();
                        s1 = charStack.Pop();
                        double sum = Operat(n1, n2, s1);
                        numberStack.Push(sum);
                        charStack.Push(inputStr[i]);
                    }
                }
                else
                {
                    if (inputStr[i].Equals('('))
                    {
                        charStack.Push(inputStr[i]);
                    }
                    else if (inputStr[i].Equals(')'))
                    {
                        while (!charStack.Peek().Equals('('))
                        {
                            double n1, n2;
                            char s1;
                            n2 = numberStack.Pop();
                            n1 = numberStack.Pop();
                            s1 = charStack.Pop();
                            double sum = Operat(n1, n2, s1);
                            numberStack.Push(sum);
                        }
                        charStack.Pop();
                    }
                }
            }
        }

        public static string CalMain()
        {
            Read();
            return PopStack().ToString();
        }

        public static double PopStack()
        {
            double sum = 0;
            while (charStack.Count != 0)
            {
                double n1, n2;
                char s1;
                n2 = numberStack.Pop();
                n1 = numberStack.Pop();
                s1 = charStack.Pop();
                sum = Operat(n1, n2, s1);
                numberStack.Push(sum);
            }
            return sum;
        }

        public static bool IsOperator(char ch)
        {
            if (ch.Equals('+') || ch.Equals('-') || ch.Equals('*') || ch.Equals('/') || ch.Equals('%') || ch.Equals('^') || ch.Equals('(') || ch.Equals(')'))
            {
                return true;
            }
            return false;
        }

        public static bool IsOper(char ch)
        {
            if (ch.Equals('+') || ch.Equals('-') || ch.Equals('*') || ch.Equals('/') || ch.Equals('%') || ch.Equals('^'))
            {
                return true;
            }
            return false;
        }

        public static int OperatorPrecedence(char ch)
        {
            int i = 0;
            switch (ch)
            {
                case '+':
                    i = 3;
                    break;
                case '-':
                    i = 3;
                    break;
                case '*':
                    i = 4;
                    break;
                case '/':
                    i = 4;
                    break;
                case '%':
                    i = 4;
                    break;
                case '^':
                    i = 4;
                    break;
                default:
                    break;
            }
            return i;
        }

        public static float sqrt2(double num)
        {
            // return Math.Sqrt(num);  // Math函数 time:0.0002500  

            if (num < 0)
                return (float)num;
            float mid, last;
            float low, high;
            low = 0;
            high = (float)num;
            mid = (low + high) / 2;
            do
            {
                if ((mid * mid) > num)
                    high = mid;
                else
                    low = mid;
                last = mid;
                mid = (low + high) / 2;
            } while (Math.Abs(mid - last) > 1e-9);
            return mid;     //二分逼近法  time:0.0001500
        }

        public static float sqrt3(double num)
        {
            //     return (float)Math.Pow(num, 1 / 3); 

            double x1, x2, a;
            a = num;
            x2 = 1.0f;
            int i = 0;
            do
            {
                x1 = x2;
                x2 = (2 * x1 * x1 * x1 + a) / (3 * x1 * x1);
                i++;

            } while (Math.Abs(x1 - x2) >= 1e-5);
            return (float)x2;

        }

        public static double square(double num, int n)
        {
            return Math.Pow(num, n);
        }

        public static double square2(double num)
        {
            return Math.Pow(2, num);
        }

        public static double Sin(double num)
        {
            return Math.Sin(num);
        }

        public static double Cos(double num)
        {
            return Math.Cos(num);
        }

        public static double Tan(double num)
        {
            return Math.Tan(num);
        }

        public static double ReverseInt(int num)
        {
            int res = 0;
            while (num != 0)
            {
                var temp = res * 10 + num % 10;
                num = num / 10;
                if (temp / 10 != res)
                {
                    res = 0;
                    break;
                }
                res = temp;
            }
            if (res > Int32.MaxValue || res < Int32.MinValue)
                return 0;
            return res;
        }

        public static double Factorial(double num)
        {
            double sum = 0;
            for (double i = 1; i < num; i++)
            {
                sum = sum + CalFactorial(i);
            }
            return sum;
        }

        public static double CalFactorial(double num)
        {
            double mul = 1;
            for (double i = 1; i <= num; i++)
            {
                mul = mul * i;
            }
            return mul;
        }

        public static double Operat(double n1, double n2, char s1)
        {
            double sum = 0;
            switch (s1)
            {
                case '+':
                    sum = n1 + n2;
                    break;
                case '-':
                    sum = n1 - n2;
                    break;
                case '*':
                    sum = n1 * n2;
                    break;
                case '/':
                    sum = n1 / n2;
                    break;
                case '%':
                    sum = n1 % n2;
                    break;
                case '^':
                    sum = Math.Pow(n1, n2);
                    break;
                default:
                    break;
            }
            return sum;
        }
    }
}
