using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.Utilities
{
    public class CaptchaToken
    {
        private string _question = "";
        private string _answer = "";
        private string[] methodarr = new string[] { "加", "减", "乘" };
        private string methodname = "";
        private int num1 = 0;
        private int num2 = 0;
        private int result = 0;

        public CaptchaToken()
        {
        }

        public void Random()
        {
            Random Rdm = new Random();
            int r1 = Rdm.Next(0, 3);
            methodname = methodarr[r1];
            switch (methodname)
            {
                case "加":
                    num1 = Rdm.Next(10, 30);
                    num2 = Rdm.Next(1, 10);
                    result = num1 + num2;
                    break;
                case "减":
                    num1 = Rdm.Next(20, 30);
                    num2 = Rdm.Next(1, 10);
                    result = num1 - num2;
                    break;
                case "乘":
                    num1 = Rdm.Next(1, 12);
                    num2 = Rdm.Next(1, 12);
                    result = num1 * num2;
                    break;
            }
            _question = num1.ToString() + methodname + num2.ToString();
            _answer = result.ToString();
        }

        public string GetQuestion()
        {
            return _question;
        }

        public string GetAnswer()
        {
            return _answer;
        }
    }
}
