using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Encryption
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            //Encryption

            //Read Excel File
            Console.WriteLine("Enter file path?");
            string path = Console.ReadLine();

            //Read the excel file into dictionary
            Dictionary<string, passData> InDict = ReadExceltoObject(path);

            //Encrypted Password Dictionary
            Dictionary<string, passData> OutDict = new Dictionary<string, passData>();

            //Decrypted Password Dictionary
            Dictionary<string, passData> DecryptedDict = new Dictionary<string, passData>();

            //Request for Encryption/Decryption Key
            Console.WriteLine("Please enter key input1");
            int keyinput1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter key input2");
            int keyinput2 = Int32.Parse(Console.ReadLine());
            //TODO : ASCII Wrapping

            //Encrypt
            Encrypt(InDict,OutDict,keyinput1,keyinput2);

            //Decrypt
            Decrypt(DecryptedDict,OutDict,keyinput1,keyinput2);

        }

        public static void Encrypt(Dictionary<string,passData> InDict, Dictionary<string, passData> OutDict, int key1, int key2)
        {
            foreach (var p in InDict)
            {
                string encryptedPassword = encryptPassword(p.Value.password, key1, key2);

                OutDict.Add(p.Key, new passData()
                {
                    username = p.Value.username,
                    password = encryptedPassword
                });
            }

        }

        public static void Decrypt(Dictionary<string, passData> DecryptedDict, Dictionary<string, passData> OutDict, int key1, int key2)
        {
            foreach (var p in OutDict)
            {
                string decryptedPassword = decrypt(p.Value.password, key1, key2);

                DecryptedDict.Add(p.Key, new passData()
                {
                    username = p.Value.username,
                    password = decryptedPassword
                });
            }
        }

        public static Dictionary<string, string> ReadExcel(string path)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();

            //Loop through Excel file and add username and passwords to dictionary.

            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Open(path);
            Worksheet ws = wb.Worksheets[1];

            string u = "", p = "";
            int i = 1;



            while (ws.Cells[i, 1].Value != null)
            {
                u = ws.Cells[i, 1].Value;
                p = ws.Cells[i, 2].Value;

                i++;

                passwords.Add(u, p);
            }

            return passwords;
        }

        public static Dictionary<string, passData> ReadExceltoObject(string path)
        {
            Dictionary<string, passData> passwords = new Dictionary<string, passData>();

            //Loop through Excel file and add username and passwords to dictionary.

            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Open(path);
            Worksheet ws = wb.Worksheets[1];

            string n="",u = "", p = "";
            int i = 1;



            while (ws.Cells[i, 1].Value != null)
            {
                n = ws.Cells[i, 1].Value;
                u = ws.Cells[i, 2].Value;
                p = ws.Cells[i, 3].Value;

                i++;

                passData pD = new passData();
                
                passwords.Add(n, new passData()
                {
                    username=u,
                    password=p
                });
            }

            return passwords;
        }
        public static string encryptPassword(string password, int key1, int key2)
        {

            string encryptedPassword = "";

            for (int i = 0; i < password.Length; i += 2)
            {
                encryptedPassword += Convert.ToChar(((int)password[i] + key1));
            }

            for (int i = 1; i < password.Length; i += 2)
            {
                encryptedPassword += Convert.ToChar(((int)password[i] + key2));
            }

            return encryptedPassword;
        }

        public static string decrypt(string encryptedPassword, int key1, int key2)
        {

            string decriptedPassword = "";

            int splitter = (int)Math.Ceiling((double)(encryptedPassword.Length) / 2.0);
            Console.WriteLine(splitter);

            string pass1 = encryptedPassword.Substring(0, splitter);
            string pass2 = encryptedPassword.Substring(splitter);

            //LmT   qg
            Console.WriteLine(encryptedPassword);
            Console.WriteLine(pass1 + " " + pass2);
            int i1 = 0;
            int i2 = 0;

            //Decription
            for (int i = 0; i < encryptedPassword.Length; i++)
            {

                if (i % 2 == 0)
                {
                    decriptedPassword += Convert.ToChar(((int)pass1[i1] - key1));
                    i1++;
                }
                else
                {
                    decriptedPassword += Convert.ToChar(((int)pass2[i2] - key2));
                    i2++;
                }
            }
            return decriptedPassword;
        }

        

    }
    public class passData
    {
        public string username { get; set; }

        public string password { get; set; }
    }

}


