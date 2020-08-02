using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q67_StringToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.StrToInt("   12  ");

            //MaxValue = 2147483647;
            //MinValue = -2147483648;
            //bool re = s.BeyondMaxOrMin("-2147483649");
            //string av = "0012300";
            //var q = av.Trim('0');
            //string aaa = int.MinValue.ToString();
            //string faaa = int.MaxValue.ToString();
            var b = s.StrToInt(" ");

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int StrToInt(string str)
        {
            // 全部为空格 或者 字符串为空 无法转换
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            // 处理字符串前后的空格
            string strTrim = str.Trim();
            if (strTrim.Length == 0)
            {
                return 0;
            }

            int lastNumberIndex = 0;

            // 第一个非空格为字符（非正负号或者数字） 无法转换
            if (strTrim[lastNumberIndex] != '-' && strTrim[lastNumberIndex] != '+' &&
                strTrim[lastNumberIndex] - '0' <= 0 && strTrim[lastNumberIndex] - '9' >= 0)
            {
                return 0;
            }

            // 第一个非空格为数字 并且后面全部是数字
            // 第一个非空格为数字 最后一个数字后面是其它字符或空格
            if (strTrim[lastNumberIndex] - '0' >= 0 && strTrim[lastNumberIndex] - '0' <= 9)
            {
                lastNumberIndex++;

                while (lastNumberIndex < strTrim.Length)
                {
                    if (strTrim[lastNumberIndex] - '0' >= 0 && strTrim[lastNumberIndex] - '0' <= 9)
                    {
                        lastNumberIndex++;
                        continue;
                    }

                    break;
                }

                // 判断是否为0

                if (IsZero(strTrim.Substring(0, lastNumberIndex)))
                {
                    // 等于0 
                    return 0;
                }

                // 判断无符号整数是否越界,实际上是int存储，默认是正数。只是没有+号而已，因此范围是[ 0 , 2^31-1 ]
                if (BeyondMaxOrMin(strTrim.Substring(0, lastNumberIndex)))
                {
                    // 越界了 , 或者等于0，直接返回0
                    return int.MaxValue;
                }
                else
                {
                    // 在int正数的范围内，字符串转整数
                    return StringToInt(strTrim.Substring(0, lastNumberIndex));
                }
            }

            // 第一个非空格为正负号 并且后面为数字
            // 第一个非空格为正负号 并且后面为数字 数字后面是其它字符或空格
            // 第一个非空格为正负号 但是后面没有紧跟着数字
            if (strTrim[lastNumberIndex] == '+' || strTrim[lastNumberIndex] == '-')
            {
                lastNumberIndex++;

                while (lastNumberIndex < strTrim.Length)
                {
                    if (strTrim[lastNumberIndex] - '0' >= 0 && strTrim[lastNumberIndex] - '0' <= 9)
                    {
                        lastNumberIndex++;
                        continue;
                    }

                    break;
                }

                // 排除只有正负号的情况
                if (lastNumberIndex == 1)
                {
                    // 正负号后面不是数字
                    return 0;
                }
                else
                {
                    string tem2 = strTrim.Substring(1);
                    // 是否等于0
                    if (IsZero(tem2))
                    {
                        // 等于0 
                        return 0;
                    }


                    // 判断带符号的整数是否越界
                    if (BeyondMaxOrMin(strTrim.Substring(0, lastNumberIndex)))
                    {
                        // 越界了 , 按照正负返回
                        if (strTrim[0] == '+')
                        {
                            return int.MaxValue;
                        }
                        else
                        {
                            return int.MinValue;
                        }

                    }
                    else
                    {
                        // 没有越界，返回正确的字符串
                        return StringToInt(strTrim.Substring(0, lastNumberIndex));
                    }
                }
            }

            return 0;
        }

        public int StringToInt(string substring)
        {
            char[] charArray = substring.ToCharArray();
            int count = 0;
            int num = 0;

            if (charArray[0] != '+' && charArray[0] != '-')
            {

                for (int i = substring.Length - 1; i >= 0; i--)
                {
                    num += ((int)(charArray[i] - '0') * (int)Math.Pow(10, count++));
                }


            }
            else if (substring[0] == '+')
            {
                for (int i = substring.Length - 1; i >= 1; i--)
                {
                    num += ((int)(charArray[i] - '0') * (int)Math.Pow(10, count++));
                }
            }
            else
            {
                for (int i = substring.Length - 1; i >= 1; i--)
                {
                    num += ((int)(charArray[i] - '0') * (int)Math.Pow(10, count++));
                }

                num *= -1;
            }

            return num;
        }

        public bool BeyondMaxOrMin(string str)
        {
            // 判断是否等于0，无论正负号，字符串多长，只要为0 就返回true

            // 有符号
            if (str[0] == '+' || str[0] == '-')
            {
                // 去掉正负号
                string tem = str.Substring(1);

                //if (IsZero(tem))
                //{
                //    // 等于0 
                //    return true;
                //}

                // 去掉高位的0
                tem = tem.TrimStart('0');

                if (str[0] == '+')
                {
                    // 判断是否大于最大值
                    //StringBuilder temSB = new StringBuilder(int.MaxValue.ToString());
                    //while (temSB.Length < tem.Length)
                    //{
                    //    temSB.Insert(0, '0');
                    //}

                    string strMaxValue = int.MaxValue.ToString();

                    if (tem.Length < strMaxValue.Length)
                    {
                        return false;
                    }
                    else if (tem.Length > strMaxValue.Length)
                    {
                        return true;
                    }
                    else
                    {
                        if (tem.CompareTo(strMaxValue) > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                if (str[0] == '-')
                {
                    // 判断是否小于最小值

                    string strMaxValue = "2147483648";

                    if (tem.Length < strMaxValue.Length)
                    {
                        return false;
                    }
                    else if (tem.Length > strMaxValue.Length)
                    {
                        return true;
                    }
                    else
                    {
                        if (tem.CompareTo(strMaxValue) > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }



                    //string minStr = int.MinValue.ToString();
                    //minStr = minStr.Substring(1);

                    //StringBuilder temSB = new StringBuilder(minStr);
                    //while (temSB.Length < tem.Length)
                    //{
                    //    temSB.Insert(0, '0');
                    //}

                    //string strMinValue = temSB.ToString();

                    //if (tem.CompareTo(strMinValue) > 0)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    StringBuilder tem1SB = new StringBuilder(uint.MaxValue.ToString());
                    //    while (tem1SB.Length < tem.Length)
                    //    {
                    //        tem1SB.Insert(0, '0');
                    //    }

                    //    string strMaxValue = tem1SB.ToString();

                    //    if (tem.CompareTo(strMaxValue) > 0)
                    //    {
                    //        return true;
                    //    }
                    //    else
                    //    {
                    //        return false;
                    //    }
                    //}
                }

                return true;
            }
            // 无符号
            else
            {
                //if (IsZero(str))
                //{
                //    // 等于0 
                //    return true;
                //}

                // 去掉高位的0
                string tem = str.TrimStart('0');

                string strMaxValue = int.MaxValue.ToString();

                if (tem.Length < strMaxValue.Length)
                {
                    return false;
                }
                else if (tem.Length > strMaxValue.Length)
                {
                    return true;
                }
                else
                {
                    if (tem.CompareTo(strMaxValue) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }

        public bool IsZero(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append("0");
            }

            string zeroString = sb.ToString();

            if (zeroString.CompareTo(str) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Solution2
    {
        public int StrToInt(string str)
        {

        }
    }
}
