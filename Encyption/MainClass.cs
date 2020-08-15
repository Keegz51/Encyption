using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Encyption;
using System.IO;


namespace Encryption
{
    public class MainClass : Methods
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Would you like to Encrypt a File or Decrypt a File?");
            string action = Console.ReadLine();

            switch (action)
            {
                case "Encrypt":
                    //Encrypt
                    //Read Excel File
                    Console.WriteLine("Enter file path?");
                    string pathE = Console.ReadLine();

                    //Read the excel file into dictionary
                    Dictionary<string, passData> InDict = ReadExceltoObject(pathE);

                    //Encrypted Password Dictionary
                    Dictionary<string, passData> OutDict = new Dictionary<string, passData>();


                    //Request for Encryption/Decryption Key
                    Console.WriteLine("Please enter key input1");
                    int keyinput1 = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter key input2");
                    int keyinput2 = Int32.Parse(Console.ReadLine());

                    Encrypt(InDict, OutDict, keyinput1, keyinput2);

                    Console.WriteLine("Please enter the output filename");
                    string outputFileName = pathE.Substring(0, pathE.LastIndexOf(@"\") + 1) + Console.ReadLine() + ".xlsx";

                    while (File.Exists(outputFileName))
                    {
                        Console.WriteLine("File Already exists please enter a diferrent file name");
                        outputFileName = pathE.Substring(0, pathE.LastIndexOf(@"\") + 1) + Console.ReadLine() + ".xlsx";
                    }

                    WriteObjectToExcel(OutDict, outputFileName);
                    break;

                case "Decrypt":
                    //Decrypt
                    //Read Excel File
                    Console.WriteLine("Enter file path?");
                    string pathD = Console.ReadLine();

                    Dictionary<string, passData> OutDictD = ReadExceltoObject(pathD);

                    //Request for Encryption/Decryption Key
                    Console.WriteLine("Please enter key input1");
                    int Dkeyinput1 = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter key input2");
                    int Dkeyinput2 = Int32.Parse(Console.ReadLine());

                    //Decrypted Password Dictionary
                    Dictionary<string, passData> DecryptedDict = new Dictionary<string, passData>();

                    Decrypt(DecryptedDict, OutDictD, Dkeyinput1, Dkeyinput2);

                    Console.WriteLine("Please enter the output filename");
                    string outputFileNameD = pathD.Substring(0, pathD.LastIndexOf(@"\") + 1) + Console.ReadLine() + ".xlsx";

                    while (File.Exists(outputFileNameD))
                    {
                        Console.WriteLine("File Already exists please enter a diferrent file name");
                        outputFileNameD = pathD.Substring(0, pathD.LastIndexOf(@"\") + 1) + Console.ReadLine() + ".xlsx";
                    }

                    WriteObjectToExcel(DecryptedDict, outputFileNameD);
                    break;

            }
        }
    }
}


