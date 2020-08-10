using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            //Encryption

            string password = "JokeR";
            string encryptedPassword = "";

            Console.WriteLine("Please enter key input1");
            int keyinput1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter key input2");
            int keyinput2 = Int32.Parse(Console.ReadLine());

            for (int i=0;i<password.Length;i+=2)
            {
                encryptedPassword += Convert.ToChar(((int)password[i]+keyinput1));
            }

            for (int i = 1; i < password.Length; i += 2)
            {
                encryptedPassword += Convert.ToChar(((int)password[i] + keyinput2));
            }


            int splitter = (int)Math.Ceiling((double)(encryptedPassword.Length)/2.0);
            Console.WriteLine(splitter);

            string pass1 = encryptedPassword.Substring(0, splitter);
            string pass2 = encryptedPassword.Substring(splitter);

            //LmT   qg
            Console.WriteLine(encryptedPassword);
            Console.WriteLine(pass1 + " " +pass2);
            int i1 = 0;
            int i2 = 0;

            //Decription
            string decriptedPassword = "";

            for (int i = 0; i < encryptedPassword.Length; i++)
            {
                
                if(i%2==0)
                {
                    decriptedPassword += Convert.ToChar(((int)pass1[i1] - keyinput1));
                    i1++;
                }
                else
                {
                    decriptedPassword += Convert.ToChar(((int)pass2[i2] - keyinput2));
                    i2++;
                }
            }

            Console.WriteLine(decriptedPassword);

        }
    }
}
