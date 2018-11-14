using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace calculator
{
    public partial class Form1 : Form
    {
        public static List<char> inputStr = new List<char>(1000);
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonSBracketL_Click(object sender, EventArgs e)
        {
            if (inputStr.Count != 0)
            {
                if (!calculate.IsOper(inputStr[inputStr.Count - 1]))
                {
                    return;
                }
            }
            inputStr.Add('(');
            showTextBox.AppendText("(");
        }

        private void ButtonSBracketR_Click(object sender, EventArgs e)
        {
            inputStr.Add(')');
            showTextBox.AppendText(")");
        }


        private void Button7_Click(object sender, EventArgs e)
        {
            inputStr.Add('7');
            showTextBox.AppendText("7");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            inputStr.Add('8');
            showTextBox.AppendText("8");
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            inputStr.Add('9');
            showTextBox.AppendText("9");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            inputStr.Add('4');
            showTextBox.AppendText("4");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            inputStr.Add('5');
            showTextBox.AppendText("5");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            inputStr.Add('6');
            showTextBox.AppendText("6");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            inputStr.Add('1');
            showTextBox.AppendText("1");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            inputStr.Add('2');
            showTextBox.AppendText("2");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            inputStr.Add('3');
            showTextBox.AppendText("3");
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            inputStr.Add('0');
            showTextBox.AppendText("0");
        }

        private void ButtonDecimal_Click(object sender, EventArgs e)
        {
            inputStr.Add('.');
            showTextBox.AppendText(".");
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            //inputStr.Add('=');
            if(!IsValid(showTextBox.Text))
            {
                MessageBox.Show("括号不匹配,请重新输入!");
                return;
            }
            showTextBox.AppendText("=");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.CalMain();
            string str = calculate.CalMain();
            inputStr.Clear();
            for (int i = 0; i < str.Length; i++)
            {
                inputStr.Add(str[i]);
            }
            watch.Stop();
            TimeSpan timeSpan = watch.Elapsed;
            timeTextBox.Text = timeSpan.TotalSeconds.ToString() + "s";
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            inputStr.Add('/');
            showTextBox.AppendText("/");
        }

        private void ButtonMul_Click(object sender, EventArgs e)
        {
            inputStr.Add('*');
            showTextBox.AppendText("*");
        }

        private void ButtonSub_Click(object sender, EventArgs e)
        {
            inputStr.Add('-');
            showTextBox.AppendText("-");
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            inputStr.Add('+');
            showTextBox.AppendText("+");
        }

        private void ButtonDelivery_Click(object sender, EventArgs e)
        {
            inputStr.Add('%');
            showTextBox.AppendText("%");
        }

        private void ButtonCaret_Click(object sender, EventArgs e)
        {
            inputStr.Add('^');
            showTextBox.AppendText("^");
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            inputStr.Add(',');
            showTextBox.AppendText(",");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            inputStr.RemoveAt(inputStr.Count - 1);
            showTextBox.Text = "";
            var builder = new StringBuilder();
            builder.Append(showTextBox.Text);
            for (int i = 0; i < inputStr.Count; i++)
            {
                builder.Append(inputStr[i]);
            }
            showTextBox.Text = builder.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

            showTextBox.Text = "";
            inputStr.Clear();
        }

        private void ButtonSqrt2_Click(object sender, EventArgs e)
        {
            var num = Convert.ToDouble(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.sqrt2(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonSqrt3_Click_1(object sender, EventArgs e)
        {
            var num = Convert.ToDouble(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.sqrt3(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonSquare_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var temp = showTextBox.Text.Split('^');
            var leftNumber = Convert.ToDouble(temp[0]);
            var rightNumber = Convert.ToInt32(temp[1]);
            showTextBox.Text = calculate.square(leftNumber, rightNumber).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonSquare2_Click(object sender, EventArgs e)
        {
            var num = Convert.ToDouble(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.square2(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonCos_Click(object sender, EventArgs e)
        {
            var num = Convert.ToDouble(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.Cos(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonSin_Click(object sender, EventArgs e)
        {
            var num = Convert.ToDouble(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.Sin(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonTan_Click(object sender, EventArgs e)
        {
            var num = Convert.ToDouble(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.Tan(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonFactorial_Click(object sender, EventArgs e)
        {
            var num = Convert.ToDouble(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.Factorial(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        private void ButtonPi_Click(object sender, EventArgs e)
        {
            inputStr.Add('3');
            inputStr.Add('.');
            inputStr.Add('1');
            inputStr.Add('4');
            inputStr.Add('1');
            showTextBox.AppendText("3.141");
            showTextBox.AppendText(Convert.ToDouble("π").ToString());
        }

        private void ReverseButton(object sender, EventArgs e)
        {
            if (!IsInt(showTextBox.Text))
                return;
            var num = Convert.ToInt32(showTextBox.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            showTextBox.Text = calculate.ReverseInt(num).ToString();
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
        }

        public IList<int> ConverToList()
        {
            var source = showTextBox.Text.Split(',');
            var nums = new List<int>();
            for (int i = 0; i < source.Count(); i++)
            {
                nums.Add(Convert.ToInt32(source[i]));
            }
            return nums;
        }

        public void Swap(ref IList<int> nums, int i, int j)
        {
            if (nums.Count < i || nums.Count < j)
                return;
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private void SelectSort(object sender, EventArgs e)
        {
            var nums = ConverToList();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < nums.Count() - 1; i++)
            {
                int min = i;
                int temp = nums[i];
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[j] < temp)
                    {
                        min = j;
                        temp = nums[j];
                    }
                }
                if (min != i)
                    Swap(ref nums, min, i);
            }
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalMilliseconds + "ms";
            showTextBox.Text = string.Join(",", nums.ToArray());
        }

 

        private void BubbleSort(object sender,EventArgs e)
        {
            var nums = ConverToList();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            /*  经典冒泡
            for (int i = nums.Count() - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[j + 1])
                        Swap(ref nums, j, j + 1);
                }
            }
            */
            /*  冒泡改进
            bool flag;
            for (int i = nums.Count() - 1; i > 0; i--)
            {
                flag = true;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        Swap(ref nums, j, j + 1);
                        flag = false;
                    }
                }
                if (flag)
                    break;
            }
            */

            //鸡尾酒排序
            bool flag;
            int m = 0, n = 0;
            for (int i = nums.Count() - 1; i > 0; i--)
            {
                flag = true;
                if (i % 2 == 0)
                {
                    for (int j = n; j < nums.Count() - 1; j++)
                    {
                        if (nums[j] > nums[j + 1])
                        {
                            Swap(ref nums, j, j + 1);
                            flag = false;
                        }
                    }
                    if (flag)
                        break;
                    m++;
                }
                else
                {
                    for (int k = nums.Count() - 1 - m; k > n; k--)
                    {
                        if (nums[k] < nums[k-1])
                        {
                            Swap(ref nums, k, k - 1);
                            flag = false;
                        }
                    }
                    if (flag)
                        break;
                    n++;
                }
            }
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalMilliseconds + "ms";
            showTextBox.Text = string.Join(",", nums.ToArray());
        }

        public void InsertSort(object sender, EventArgs e)
        {
            var nums = ConverToList();
            var watch = new Stopwatch();
            watch.Start();
            /*  经典插入
            int temp;
            for (int i = 1; i < nums.Count(); i++)
            {
                temp = nums[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[j] > temp)
                    {
                        nums[j + 1] = nums[j];
                        if (j == 0)
                        {
                            nums[0] = temp;
                            break;
                        }
                        else
                        {
                            nums[j + 1] = temp;
                            break;
                        }
                    }
                }
            }
            */

            //二分插入
            int temp;
            int tempIndex;
            for (int i = 1; i < nums.Count(); i++)
            {
                temp = nums[i];
                tempIndex = BinarySearchForInsertSort(nums,0,i,i);
                for (int j = i - 1; j >= tempIndex; j--)
                {
                    nums[j + 1] = nums[j];
                }
                nums[tempIndex] = temp;
            }
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
            showTextBox.Text = string.Join(",", nums.ToArray());
        }

        public static int BinarySearchForInsertSort(IList<int> nums, int low, int high, int key)
        {
            if (low >= nums.Count - 1)
                return nums.Count - 1;
            if (high <= 0)
                return 0;
            int mid = (low + high) / 2;
            if (mid == key)
                return mid;
            if (nums[key] > nums[mid])
            {
                if (nums[key] < nums[mid + 1])
                    return mid + 1;
                return BinarySearchForInsertSort(nums, mid + 1, high, key);
            }
            else
            {
                if (mid - 1 < 0)
                    return 0;
                if (nums[key] > nums[mid - 1])
                    return mid;
                return BinarySearchForInsertSort(nums, low, mid - 1, key);
            }
        }

        public static bool IsValid(string str)
        {
            int len = str.Length;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < len; i++)
            {
                if (str[i] == '(')
                {
                    stack.Push(str[i]);
                }
                else if (str[i] == ')')
                {
                    if (stack.Count == 0)
                        return false;
                    var top = stack.ElementAt(stack.Count - 1);
                    if (str[i] == ')' && top != '(')
                        return false;
                    stack.Pop();
                }
                else
                    continue;
            }
            if (stack.Count > 0)
                return false;
            return true;
        }

        private void QuickSort(object sender, EventArgs e)
        {
            var nums = ConverToList();
            var watch = new Stopwatch();
            watch.Start();
            QuickSort(nums, 0, nums.Count() - 1);
            watch.Stop();
            timeTextBox.Text = watch.Elapsed.TotalSeconds + "s";
            showTextBox.Text = string.Join(",", nums.ToArray());
        }


        public void QuickSort(IList<int> nums, int low, int high)
        {
            /*   经典快排
            if (low >= high)
                return;
            int temp = nums[low];
            int i = low + 1, j = high;
            while (true)
            {
                while (nums[j] > temp)
                    j--;
                while (nums[i] < temp && i < j)
                    i++;
                if (i >= j)
                    break;
                Swap(ref nums, i, j);
                i++;
                j--;
            }
            if (low != j)
                Swap(ref nums, low, j);
            QuickSort(nums, j + 1, high);
            QuickSort(nums, low, j - 1);
            */

            if (low >= high)
                return;
            int temp = nums[(low + high) / 2];
            int i = low - 1, j = high + 1;
            int index = (low + high) / 2;
            while (true)
            {
                while (nums[++i] < temp) ;
                while (nums[--j] > temp) ;

                if (i >= j)
                    break;
                Swap(ref nums, i, j);
                if (i == index)
                    index = j;
                else if (j == index)
                    index = i;
            }
            if (i == j)
            {
                QuickSort(nums, j + 1, high);
                QuickSort(nums, low, i - 1);
            }
            else
            {
                if (index >= i)
                {
                    if (index != i)
                        Swap(ref nums, index, i);
                    QuickSort(nums, i + 1, high);
                    QuickSort(nums, low, i - 1);
                }
                else
                {
                    if (index != j)
                        Swap(ref nums, index, j);
                    QuickSort(nums, j + 1, high);
                    QuickSort(nums, low, j - 1);
                }
            }

        }



public static bool IsInt(string str)
        {
            try
            {
                var result = Convert.ToInt32(str);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool IsDouble(string str)
        {
            try
            {
                var result = Convert.ToDouble(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
