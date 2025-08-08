using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace TextToCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int state = 1;
            while (state == 1)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("---Choose an Operation---");
                Console.WriteLine("-------------------------");
                Console.WriteLine("- 1. Text to Code       -");
                Console.WriteLine("- 2. Decoder            -");
                Console.WriteLine("- 3. Code Generator     -");
                Console.WriteLine("- 4. Close Application  -");
                Console.WriteLine("- 5. Test(s)            -");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TextToCode();
                        break;
                    case "2":
                        Decoder();
                        break;
                    case "3":
                        CodeSetGenerator();
                        break;
                    case "4":
                        state = 0;
                        Console.WriteLine("Goodbye");
                        break;
                    case "5":
                        Test();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        Console.WriteLine("");
                        break;
                }
            }
            Console.WriteLine("Goodbye :)");


        }
        static void Test()
        {
            Random rng = new Random();
            int L1 = rng.Next(33, 127);
            int L2 = rng.Next(33, 127);
            char letter = 'a';
            int letterNum = Convert.ToInt32(letter);

            char L1Char = (char)L1;

            string L1L2String = $"{L1}{L2}";
            Console.WriteLine($"{L1L2String}");
            Console.WriteLine(letterNum);
            Console.WriteLine(L1Char);
        }
        static void TextToCode()
        {
            
            Console.Write("Enter Title of Work: ");

            string ArtWorkTitle = Console.ReadLine();


            foreach (char letter in ArtWorkTitle)
            {
                string codeVal = "";
                string letterString = Convert.ToInt32(letter).ToString();

                Random rng = new Random();

                int codeSet = rng.Next(5);
                //int codeSet = 0;

                switch (codeSet)
                {
                    case 0:
                        codeVal = CodeSet0(letterString);
                        break;
                    case 1:
                        codeVal = CodeSet1(letterString);
                        break;
                    case 2:
                        codeVal = CodeSet2(letterString);
                        break;
                    case 3:
                        codeVal = CodeSet3(letterString);
                        break;
                    case 4:
                        codeVal = CodeSet4(letterString); 
                        break;

                    default:
                        codeVal = "error";
                        break;
                }
               
                // Output each codeSet value
                Console.Write(codeVal + " ");
            }

            // Keep the console window open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void Decoder()
        {
            Console.Clear();

            Console.WriteLine("Paste the cipher below:");
            string totalCipher = Console.ReadLine();

            string[] cipherSets = totalCipher.Split(' ');
            string[] codeSet = new string[cipherSets.Length];

            for (int i = 0; i < cipherSets.Length; i++)
            {
                //Variables
                int L1 = 0;
                int L2 = 0;
                string letterKey = "";
                string letter = "";

                //Indentify CodeSet
                codeSet[i] = cipherSets[i].Substring(cipherSets[i].Length - 2);

                //Get pattern for CodeSet Identified
                string codeSetPattern = CodeSetValueChecker(codeSet[i]);

                //check if codeSetChars are valid
                if (codeSetPattern == "0")
                {
                    Console.WriteLine("Invalid CodeSet Characters, Please Update CodeSet Libraries");
                    i = cipherSets.Length; 
                }
                else
                {
                    switch(codeSet[i])
                    {
                        case "2P":
                            L1 = cipherSets[i][0];
                            L2 = cipherSets[i][3];
                            letterKey = $"{L1}{L2}";
                            letter = CodeSet0(letterKey);
                            break;
                        case "eV":
                            L1 = cipherSets[i][1];
                            L2 = cipherSets[i][3];
                            letterKey = $"{L1}{L2}";
                            letter = CodeSet1(letterKey);
                            break;
                        case ";o":
                            L1 = cipherSets[i][0];
                            L2 = cipherSets[i][2];
                            letterKey = $"{L1}{L2}";
                            letter = CodeSet2(letterKey);
                            break;
                        case "DK":
                            L1 = cipherSets[i][2];
                            L2 = cipherSets[i][3];
                            letterKey = $"{L1}{L2}";
                            letter = CodeSet3(letterKey);
                            break;
                        case "/V":
                            L1 = cipherSets[i][0];
                            L2 = cipherSets[i][1];
                            letterKey = $"{L1}{L2}";
                            letter = CodeSet4(letterKey);
                            break;
                    }
                    //Write Text to console
                    Console.Write(letter);
                }
            }
            Console.WriteLine("");
        }
        static void CodeSetGenerator()
        {
            Console.Clear();

            char[] availableCharacters = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '.', '!', '?', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', ',', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            string[] letterKey = new string[availableCharacters.Count()];

            bool state = true;
            while(state)
            {
                int switchState;

                Console.WriteLine("run = 1, 2 = L Value for Set, stop = 0");
                switchState = Convert.ToInt32(Console.ReadLine());

                switch (switchState)
                {
                    case 1:

                        //Determines -CodeSet Value
                        for(int i = 0; i < 27; i++)
                        {
                            //Random rng = new Random();
                            //int value1 = rng.Next(33, 127);
                            //int value2 = rng.Next(33, 127);

                            //char charVal1 = Convert.ToChar(value1);
                            //char charVal2 = Convert.ToChar(value2);
                            //Console.WriteLine($"{charVal1}{charVal2}");
                            // 2P
                            // eV
                            // ;o
                            // DK
                            // /V

                        }

                        //Console.WriteLine("Enter a value");
                        //int value = Convert.ToInt32(Console.ReadLine());

                        break;
                    case 2:

                        int loopCount = 0;

                        //int[] L1 = new int[alphabet.Count()];
                        //int[] L2 = new int[alphabet.Count()];

                        int[] charVal1 = new int[availableCharacters.Count()];
                        int[] charVal2 = new int[availableCharacters.Count()];
                        string newLetterKey = "";
                        string codeSetPattern = "";

                        string[] codeSet = {"2P", "eV", ";o", "DK", "/V"};
                        

                    //creates each codeSet Library with decoder
                        for (int x = 0; x < codeSet.Length; x++)
                        {

                            //Get CodeSet's Pattern to find the key
                            codeSetPattern = CodeSetValueChecker(codeSet[x]);
                            string[] codeSetPatternPos = codeSetPattern.Split(' ');

                            Console.WriteLine($"static string CodeSet{x}(string letter)");
                            Console.WriteLine($"{{");
                            Console.WriteLine($"    string codeSetVal = \"{codeSet[x]}\";");
                            Console.WriteLine("");
                            Console.WriteLine($"    int L1 = 0;");
                            Console.WriteLine($"    int L2 = 0;");
                            Console.WriteLine($"");
                            Console.WriteLine($"    Random rng = new Random();");
                            Console.WriteLine($"    int Fval1 = rng.Next(33, 127);");
                            Console.WriteLine($"    int Fval2 = rng.Next(33, 127);");
                            Console.WriteLine($"    char F1 = Convert.ToChar(Fval1);");
                            Console.WriteLine($"    char F2 = Convert.ToChar(Fval2);");
                            Console.WriteLine("     char L1Char = ' ';");
                            Console.WriteLine("     char L2Char = ' ';");
                            Console.WriteLine($"");
                            Console.WriteLine($"    string letterVal = \"\";");
                            Console.WriteLine($"");
                            Console.WriteLine($"    switch(letter)");
                            Console.WriteLine($"    {{");

                            for (int i = 0; i < availableCharacters.Count(); i++)
                            {

                                bool duplicateCheck = false;

                                Random rng = new Random();
                                int L1 = rng.Next(33, 127);
                                int L2 = rng.Next(33, 127);
                                //L1[i] = rng.Next(33, 127);
                                //L2[i] = rng.Next(33, 127);

                                //Generates values which represent the letter to be encoded
                                charVal1[i] = L1;
                                charVal2[i] = L2;
                                newLetterKey = $"{charVal1[i]}{charVal2[i]}";

                                
                                

                                //Checking if determined L1 & L2 value are already made
                                for (int j = 0; j < letterKey.Count(); j++)
                                {
                                    if (letterKey[j] == newLetterKey)
                                    {
                                        duplicateCheck = true;
                                        j = letterKey.Count();
                                    }
                                }
                                //Finalize or start again
                                if (duplicateCheck == true)
                                {
                                    loopCount++;
                                    i--;
                                }
                                else
                                {
                                    loopCount = 0;
                                    letterKey[i] = newLetterKey;
                                }
                                // Make sure program doesn't run forever
                                if (loopCount >= 200)
                                {
                                    i = availableCharacters.Count();
                                }
                            }
                            if (loopCount == 200)
                            {
                                Console.WriteLine("Too many attempts, try again");
                            }
                            else //Print code to be copied
                            {

                                for (int i = 0; i < letterKey.Count(); i++)
                                {
                                    //Convert Character to Number value
                                    int charNum = Convert.ToInt32(availableCharacters[i]);

                                    Console.WriteLine($"case \"{charNum}\":");
                                    Console.WriteLine($"    L1 = {charVal1[i]};");
                                    Console.WriteLine($"    L2 = {charVal2[i]};");                                   
                                    Console.WriteLine("    break;");
                                    Console.WriteLine($"case \"{letterKey[i]}\":");
                                    Console.WriteLine($"    letterVal = \"{availableCharacters[i]}\";");
                                    Console.WriteLine("    break;");

                                    //Console.WriteLine($"case '{alphabet[i]}':");
                                    //Console.WriteLine($"    L1 = '{L1[i]}';");
                                    //Console.WriteLine($"    L2 = '{L2[i]}';");
                                }
                            }
                            Console.WriteLine($"}}");
                            //Create Cipher, if not true it will decrypt
                            Console.WriteLine("if(letterVal == \"\")");
                            Console.WriteLine("{");
                            Console.WriteLine("L1Char = Convert.ToChar(L1);");
                            Console.WriteLine("L2Char = Convert.ToChar(L2);");
                            Console.WriteLine("");
                            Console.WriteLine($"letterVal = $\"{{{codeSetPatternPos[0]}}}{{{codeSetPatternPos[1]}}}{{{codeSetPatternPos[2]}}}{{{codeSetPatternPos[3]}}}{{codeSetVal}}\";");
                            Console.WriteLine("}");
                            Console.WriteLine("return letterVal;");
                            Console.WriteLine($"}}");

                        }                       
                        break;
                    //Exit Code Generator
                    case 0:
                        state = false;
                        break;

                }
                
            }
            
        }
        static void CodeSetGenerator2()
        {
            Console.Write("Total Charecters for CodeSet: ");
            int codeSetTotal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Total Chars representing a single Char: ");
            int numCipherChars = Convert.ToInt32(Console.ReadLine());

            Console.Write("Number of CodeSet Libraries: ");
            int numCodesetLibraries = Convert.ToInt32(Console.ReadLine());

        }
        static string CodeSetValueChecker(string codeSet)
        {
            string codeSetPattern = "";

            switch (codeSet)
            {
                case "2P":
                    codeSetPattern = "L1Char F1 F2 L2Char";
                    break;
                case "eV":
                    codeSetPattern = "F1 L1Char F2 L2Char ";
                    break;
                case ";o":
                    codeSetPattern = "L1Char F1 L2Char F2 ";
                    break;
                case "DK":
                    codeSetPattern = "F1 F2 L1Char L2Char";
                    break;
                case "/V":
                    codeSetPattern = "L1Char L2Char F1 F2";
                    break;
                default:
                    codeSetPattern = "0";
                    break;
            }

            return codeSetPattern;
        }        
        static string CodeSet0(string letter)
        {
            string codeSetVal = "2P";

            int L1 = 0;
            int L2 = 0;

            Random rng = new Random();
            int Fval1 = rng.Next(33, 127);
            int Fval2 = rng.Next(33, 127);
            char F1 = Convert.ToChar(Fval1);
            char F2 = Convert.ToChar(Fval2);
            char L1Char = ' ';
            char L2Char = ' ';

            string letterVal = "";

            switch (letter)
            {
                case "32":
                    L1 = 33;
                    L2 = 45;
                    break;
                case "3345":
                    letterVal = " ";
                    break;
                case "97":
                    L1 = 104;
                    L2 = 72;
                    break;
                case "10472":
                    letterVal = "a";
                    break;
                case "98":
                    L1 = 50;
                    L2 = 124;
                    break;
                case "50124":
                    letterVal = "b";
                    break;
                case "99":
                    L1 = 85;
                    L2 = 79;
                    break;
                case "8579":
                    letterVal = "c";
                    break;
                case "100":
                    L1 = 88;
                    L2 = 103;
                    break;
                case "88103":
                    letterVal = "d";
                    break;
                case "101":
                    L1 = 110;
                    L2 = 126;
                    break;
                case "110126":
                    letterVal = "e";
                    break;
                case "102":
                    L1 = 120;
                    L2 = 66;
                    break;
                case "12066":
                    letterVal = "f";
                    break;
                case "103":
                    L1 = 93;
                    L2 = 38;
                    break;
                case "9338":
                    letterVal = "g";
                    break;
                case "104":
                    L1 = 66;
                    L2 = 59;
                    break;
                case "6659":
                    letterVal = "h";
                    break;
                case "105":
                    L1 = 102;
                    L2 = 113;
                    break;
                case "102113":
                    letterVal = "i";
                    break;
                case "106":
                    L1 = 63;
                    L2 = 120;
                    break;
                case "63120":
                    letterVal = "j";
                    break;
                case "107":
                    L1 = 44;
                    L2 = 48;
                    break;
                case "4448":
                    letterVal = "k";
                    break;
                case "108":
                    L1 = 41;
                    L2 = 124;
                    break;
                case "41124":
                    letterVal = "l";
                    break;
                case "109":
                    L1 = 101;
                    L2 = 81;
                    break;
                case "10181":
                    letterVal = "m";
                    break;
                case "110":
                    L1 = 105;
                    L2 = 102;
                    break;
                case "105102":
                    letterVal = "n";
                    break;
                case "111":
                    L1 = 62;
                    L2 = 109;
                    break;
                case "62109":
                    letterVal = "o";
                    break;
                case "112":
                    L1 = 36;
                    L2 = 62;
                    break;
                case "3662":
                    letterVal = "p";
                    break;
                case "113":
                    L1 = 98;
                    L2 = 59;
                    break;
                case "9859":
                    letterVal = "q";
                    break;
                case "114":
                    L1 = 124;
                    L2 = 115;
                    break;
                case "124115":
                    letterVal = "r";
                    break;
                case "115":
                    L1 = 126;
                    L2 = 67;
                    break;
                case "12667":
                    letterVal = "s";
                    break;
                case "116":
                    L1 = 40;
                    L2 = 114;
                    break;
                case "40114":
                    letterVal = "t";
                    break;
                case "117":
                    L1 = 98;
                    L2 = 73;
                    break;
                case "9873":
                    letterVal = "u";
                    break;
                case "118":
                    L1 = 87;
                    L2 = 56;
                    break;
                case "8756":
                    letterVal = "v";
                    break;
                case "119":
                    L1 = 59;
                    L2 = 61;
                    break;
                case "5961":
                    letterVal = "w";
                    break;
                case "120":
                    L1 = 105;
                    L2 = 95;
                    break;
                case "10595":
                    letterVal = "x";
                    break;
                case "121":
                    L1 = 35;
                    L2 = 120;
                    break;
                case "35120":
                    letterVal = "y";
                    break;
                case "122":
                    L1 = 62;
                    L2 = 34;
                    break;
                case "6234":
                    letterVal = "z";
                    break;
                case "65":
                    L1 = 86;
                    L2 = 74;
                    break;
                case "8674":
                    letterVal = "A";
                    break;
                case "66":
                    L1 = 39;
                    L2 = 104;
                    break;
                case "39104":
                    letterVal = "B";
                    break;
                case "67":
                    L1 = 111;
                    L2 = 74;
                    break;
                case "11174":
                    letterVal = "C";
                    break;
                case "68":
                    L1 = 120;
                    L2 = 55;
                    break;
                case "12055":
                    letterVal = "D";
                    break;
                case "69":
                    L1 = 114;
                    L2 = 63;
                    break;
                case "11463":
                    letterVal = "E";
                    break;
                case "70":
                    L1 = 65;
                    L2 = 95;
                    break;
                case "6595":
                    letterVal = "F";
                    break;
                case "71":
                    L1 = 118;
                    L2 = 113;
                    break;
                case "118113":
                    letterVal = "G";
                    break;
                case "72":
                    L1 = 79;
                    L2 = 121;
                    break;
                case "79121":
                    letterVal = "H";
                    break;
                case "73":
                    L1 = 126;
                    L2 = 114;
                    break;
                case "126114":
                    letterVal = "I";
                    break;
                case "74":
                    L1 = 78;
                    L2 = 90;
                    break;
                case "7890":
                    letterVal = "J";
                    break;
                case "75":
                    L1 = 103;
                    L2 = 34;
                    break;
                case "10334":
                    letterVal = "K";
                    break;
                case "76":
                    L1 = 52;
                    L2 = 48;
                    break;
                case "5248":
                    letterVal = "L";
                    break;
                case "77":
                    L1 = 58;
                    L2 = 76;
                    break;
                case "5876":
                    letterVal = "M";
                    break;
                case "78":
                    L1 = 102;
                    L2 = 71;
                    break;
                case "10271":
                    letterVal = "N";
                    break;
                case "79":
                    L1 = 108;
                    L2 = 100;
                    break;
                case "108100":
                    letterVal = "O";
                    break;
                case "80":
                    L1 = 71;
                    L2 = 106;
                    break;
                case "71106":
                    letterVal = "P";
                    break;
                case "81":
                    L1 = 77;
                    L2 = 55;
                    break;
                case "7755":
                    letterVal = "Q";
                    break;
                case "82":
                    L1 = 91;
                    L2 = 77;
                    break;
                case "9177":
                    letterVal = "R";
                    break;
                case "83":
                    L1 = 103;
                    L2 = 60;
                    break;
                case "10360":
                    letterVal = "S";
                    break;
                case "84":
                    L1 = 41;
                    L2 = 118;
                    break;
                case "41118":
                    letterVal = "T";
                    break;
                case "85":
                    L1 = 48;
                    L2 = 66;
                    break;
                case "4866":
                    letterVal = "U";
                    break;
                case "86":
                    L1 = 50;
                    L2 = 116;
                    break;
                case "50116":
                    letterVal = "V";
                    break;
                case "87":
                    L1 = 120;
                    L2 = 37;
                    break;
                case "12037":
                    letterVal = "W";
                    break;
                case "88":
                    L1 = 87;
                    L2 = 83;
                    break;
                case "8783":
                    letterVal = "X";
                    break;
                case "89":
                    L1 = 54;
                    L2 = 81;
                    break;
                case "5481":
                    letterVal = "Y";
                    break;
                case "90":
                    L1 = 86;
                    L2 = 58;
                    break;
                case "8658":
                    letterVal = "Z";
                    break;
                case "46":
                    L1 = 70;
                    L2 = 112;
                    break;
                case "70112":
                    letterVal = ".";
                    break;
                case "33":
                    L1 = 64;
                    L2 = 38;
                    break;
                case "6438":
                    letterVal = "!";
                    break;
                case "63":
                    L1 = 64;
                    L2 = 59;
                    break;
                case "6459":
                    letterVal = "?";
                    break;
                case "64":
                    L1 = 59;
                    L2 = 52;
                    break;
                case "5952":
                    letterVal = "@";
                    break;
                case "35":
                    L1 = 51;
                    L2 = 117;
                    break;
                case "51117":
                    letterVal = "#";
                    break;
                case "36":
                    L1 = 75;
                    L2 = 46;
                    break;
                case "7546":
                    letterVal = "$";
                    break;
                case "37":
                    L1 = 85;
                    L2 = 88;
                    break;
                case "8588":
                    letterVal = "%";
                    break;
                case "94":
                    L1 = 116;
                    L2 = 42;
                    break;
                case "11642":
                    letterVal = "^";
                    break;
                case "38":
                    L1 = 103;
                    L2 = 72;
                    break;
                case "10372":
                    letterVal = "&";
                    break;
                case "42":
                    L1 = 113;
                    L2 = 115;
                    break;
                case "113115":
                    letterVal = "*";
                    break;
                case "40":
                    L1 = 67;
                    L2 = 48;
                    break;
                case "6748":
                    letterVal = "(";
                    break;
                case "41":
                    L1 = 99;
                    L2 = 89;
                    break;
                case "9989":
                    letterVal = ")";
                    break;
                case "45":
                    L1 = 95;
                    L2 = 123;
                    break;
                case "95123":
                    letterVal = "-";
                    break;
                case "95":
                    L1 = 57;
                    L2 = 93;
                    break;
                case "5793":
                    letterVal = "_";
                    break;
                case "61":
                    L1 = 70;
                    L2 = 47;
                    break;
                case "7047":
                    letterVal = "=";
                    break;
                case "43":
                    L1 = 122;
                    L2 = 98;
                    break;
                case "12298":
                    letterVal = "+";
                    break;
                case "44":
                    L1 = 80;
                    L2 = 92;
                    break;
                case "8092":
                    letterVal = ",";
                    break;
                case "48":
                    L1 = 106;
                    L2 = 53;
                    break;
                case "10653":
                    letterVal = "0";
                    break;
                case "49":
                    L1 = 47;
                    L2 = 94;
                    break;
                case "4794":
                    letterVal = "1";
                    break;
                case "50":
                    L1 = 73;
                    L2 = 45;
                    break;
                case "7345":
                    letterVal = "2";
                    break;
                case "51":
                    L1 = 53;
                    L2 = 67;
                    break;
                case "5367":
                    letterVal = "3";
                    break;
                case "52":
                    L1 = 106;
                    L2 = 35;
                    break;
                case "10635":
                    letterVal = "4";
                    break;
                case "53":
                    L1 = 122;
                    L2 = 69;
                    break;
                case "12269":
                    letterVal = "5";
                    break;
                case "54":
                    L1 = 122;
                    L2 = 55;
                    break;
                case "12255":
                    letterVal = "6";
                    break;
                case "55":
                    L1 = 56;
                    L2 = 76;
                    break;
                case "5676":
                    letterVal = "7";
                    break;
                case "56":
                    L1 = 66;
                    L2 = 55;
                    break;
                case "6655":
                    letterVal = "8";
                    break;
                case "57":
                    L1 = 39;
                    L2 = 69;
                    break;
                case "3969":
                    letterVal = "9";
                    break;
            }
            if (letterVal == "")
            {
                L1Char = Convert.ToChar(L1);
                L2Char = Convert.ToChar(L2);

                letterVal = $"{L1Char}{F1}{F2}{L2Char}{codeSetVal}";
            }
            return letterVal;
        }
        static string CodeSet1(string letter)
        {
            string codeSetVal = "eV";

            int L1 = 0;
            int L2 = 0;

            Random rng = new Random();
            int Fval1 = rng.Next(33, 127);
            int Fval2 = rng.Next(33, 127);
            char F1 = Convert.ToChar(Fval1);
            char F2 = Convert.ToChar(Fval2);
            char L1Char = ' ';
            char L2Char = ' ';

            string letterVal = "";

            switch (letter)
            {
                case "32":
                    L1 = 106;
                    L2 = 59;
                    break;
                case "10659":
                    letterVal = " ";
                    break;
                case "97":
                    L1 = 59;
                    L2 = 38;
                    break;
                case "5938":
                    letterVal = "a";
                    break;
                case "98":
                    L1 = 58;
                    L2 = 40;
                    break;
                case "5840":
                    letterVal = "b";
                    break;
                case "99":
                    L1 = 46;
                    L2 = 41;
                    break;
                case "4641":
                    letterVal = "c";
                    break;
                case "100":
                    L1 = 111;
                    L2 = 118;
                    break;
                case "111118":
                    letterVal = "d";
                    break;
                case "101":
                    L1 = 105;
                    L2 = 119;
                    break;
                case "105119":
                    letterVal = "e";
                    break;
                case "102":
                    L1 = 79;
                    L2 = 70;
                    break;
                case "7970":
                    letterVal = "f";
                    break;
                case "103":
                    L1 = 52;
                    L2 = 86;
                    break;
                case "5286":
                    letterVal = "g";
                    break;
                case "104":
                    L1 = 107;
                    L2 = 70;
                    break;
                case "10770":
                    letterVal = "h";
                    break;
                case "105":
                    L1 = 104;
                    L2 = 120;
                    break;
                case "104120":
                    letterVal = "i";
                    break;
                case "106":
                    L1 = 70;
                    L2 = 117;
                    break;
                case "70117":
                    letterVal = "j";
                    break;
                case "107":
                    L1 = 103;
                    L2 = 68;
                    break;
                case "10368":
                    letterVal = "k";
                    break;
                case "108":
                    L1 = 109;
                    L2 = 76;
                    break;
                case "10976":
                    letterVal = "l";
                    break;
                case "109":
                    L1 = 87;
                    L2 = 34;
                    break;
                case "8734":
                    letterVal = "m";
                    break;
                case "110":
                    L1 = 93;
                    L2 = 74;
                    break;
                case "9374":
                    letterVal = "n";
                    break;
                case "111":
                    L1 = 123;
                    L2 = 72;
                    break;
                case "12372":
                    letterVal = "o";
                    break;
                case "112":
                    L1 = 38;
                    L2 = 95;
                    break;
                case "3895":
                    letterVal = "p";
                    break;
                case "113":
                    L1 = 110;
                    L2 = 101;
                    break;
                case "110101":
                    letterVal = "q";
                    break;
                case "114":
                    L1 = 64;
                    L2 = 93;
                    break;
                case "6493":
                    letterVal = "r";
                    break;
                case "115":
                    L1 = 120;
                    L2 = 53;
                    break;
                case "12053":
                    letterVal = "s";
                    break;
                case "116":
                    L1 = 34;
                    L2 = 76;
                    break;
                case "3476":
                    letterVal = "t";
                    break;
                case "117":
                    L1 = 105;
                    L2 = 41;
                    break;
                case "10541":
                    letterVal = "u";
                    break;
                case "118":
                    L1 = 73;
                    L2 = 117;
                    break;
                case "73117":
                    letterVal = "v";
                    break;
                case "119":
                    L1 = 120;
                    L2 = 58;
                    break;
                case "12058":
                    letterVal = "w";
                    break;
                case "120":
                    L1 = 82;
                    L2 = 82;
                    break;
                case "8282":
                    letterVal = "x";
                    break;
                case "121":
                    L1 = 106;
                    L2 = 70;
                    break;
                case "10670":
                    letterVal = "y";
                    break;
                case "122":
                    L1 = 115;
                    L2 = 96;
                    break;
                case "11596":
                    letterVal = "z";
                    break;
                case "65":
                    L1 = 103;
                    L2 = 42;
                    break;
                case "10342":
                    letterVal = "A";
                    break;
                case "66":
                    L1 = 34;
                    L2 = 89;
                    break;
                case "3489":
                    letterVal = "B";
                    break;
                case "67":
                    L1 = 86;
                    L2 = 109;
                    break;
                case "86109":
                    letterVal = "C";
                    break;
                case "68":
                    L1 = 111;
                    L2 = 70;
                    break;
                case "11170":
                    letterVal = "D";
                    break;
                case "69":
                    L1 = 38;
                    L2 = 80;
                    break;
                case "3880":
                    letterVal = "E";
                    break;
                case "70":
                    L1 = 115;
                    L2 = 124;
                    break;
                case "115124":
                    letterVal = "F";
                    break;
                case "71":
                    L1 = 92;
                    L2 = 38;
                    break;
                case "9238":
                    letterVal = "G";
                    break;
                case "72":
                    L1 = 98;
                    L2 = 124;
                    break;
                case "98124":
                    letterVal = "H";
                    break;
                case "73":
                    L1 = 117;
                    L2 = 87;
                    break;
                case "11787":
                    letterVal = "I";
                    break;
                case "74":
                    L1 = 79;
                    L2 = 94;
                    break;
                case "7994":
                    letterVal = "J";
                    break;
                case "75":
                    L1 = 125;
                    L2 = 81;
                    break;
                case "12581":
                    letterVal = "K";
                    break;
                case "76":
                    L1 = 71;
                    L2 = 65;
                    break;
                case "7165":
                    letterVal = "L";
                    break;
                case "77":
                    L1 = 74;
                    L2 = 43;
                    break;
                case "7443":
                    letterVal = "M";
                    break;
                case "78":
                    L1 = 39;
                    L2 = 59;
                    break;
                case "3959":
                    letterVal = "N";
                    break;
                case "79":
                    L1 = 57;
                    L2 = 66;
                    break;
                case "5766":
                    letterVal = "O";
                    break;
                case "80":
                    L1 = 47;
                    L2 = 46;
                    break;
                case "4746":
                    letterVal = "P";
                    break;
                case "81":
                    L1 = 45;
                    L2 = 94;
                    break;
                case "4594":
                    letterVal = "Q";
                    break;
                case "82":
                    L1 = 97;
                    L2 = 62;
                    break;
                case "9762":
                    letterVal = "R";
                    break;
                case "83":
                    L1 = 64;
                    L2 = 40;
                    break;
                case "6440":
                    letterVal = "S";
                    break;
                case "84":
                    L1 = 114;
                    L2 = 55;
                    break;
                case "11455":
                    letterVal = "T";
                    break;
                case "85":
                    L1 = 123;
                    L2 = 96;
                    break;
                case "12396":
                    letterVal = "U";
                    break;
                case "86":
                    L1 = 120;
                    L2 = 67;
                    break;
                case "12067":
                    letterVal = "V";
                    break;
                case "87":
                    L1 = 55;
                    L2 = 72;
                    break;
                case "5572":
                    letterVal = "W";
                    break;
                case "88":
                    L1 = 105;
                    L2 = 82;
                    break;
                case "10582":
                    letterVal = "X";
                    break;
                case "89":
                    L1 = 77;
                    L2 = 119;
                    break;
                case "77119":
                    letterVal = "Y";
                    break;
                case "90":
                    L1 = 65;
                    L2 = 114;
                    break;
                case "65114":
                    letterVal = "Z";
                    break;
                case "46":
                    L1 = 91;
                    L2 = 46;
                    break;
                case "9146":
                    letterVal = ".";
                    break;
                case "33":
                    L1 = 113;
                    L2 = 102;
                    break;
                case "113102":
                    letterVal = "!";
                    break;
                case "63":
                    L1 = 48;
                    L2 = 33;
                    break;
                case "4833":
                    letterVal = "?";
                    break;
                case "64":
                    L1 = 42;
                    L2 = 64;
                    break;
                case "4264":
                    letterVal = "@";
                    break;
                case "35":
                    L1 = 33;
                    L2 = 43;
                    break;
                case "3343":
                    letterVal = "#";
                    break;
                case "36":
                    L1 = 119;
                    L2 = 47;
                    break;
                case "11947":
                    letterVal = "$";
                    break;
                case "37":
                    L1 = 69;
                    L2 = 74;
                    break;
                case "6974":
                    letterVal = "%";
                    break;
                case "94":
                    L1 = 56;
                    L2 = 94;
                    break;
                case "5694":
                    letterVal = "^";
                    break;
                case "38":
                    L1 = 105;
                    L2 = 53;
                    break;
                case "10553":
                    letterVal = "&";
                    break;
                case "42":
                    L1 = 108;
                    L2 = 48;
                    break;
                case "10848":
                    letterVal = "*";
                    break;
                case "40":
                    L1 = 41;
                    L2 = 54;
                    break;
                case "4154":
                    letterVal = "(";
                    break;
                case "41":
                    L1 = 63;
                    L2 = 100;
                    break;
                case "63100":
                    letterVal = ")";
                    break;
                case "45":
                    L1 = 45;
                    L2 = 46;
                    break;
                case "4546":
                    letterVal = "-";
                    break;
                case "95":
                    L1 = 113;
                    L2 = 48;
                    break;
                case "11348":
                    letterVal = "_";
                    break;
                case "61":
                    L1 = 110;
                    L2 = 55;
                    break;
                case "11055":
                    letterVal = "=";
                    break;
                case "43":
                    L1 = 111;
                    L2 = 88;
                    break;
                case "11188":
                    letterVal = "+";
                    break;
                case "44":
                    L1 = 126;
                    L2 = 122;
                    break;
                case "126122":
                    letterVal = ",";
                    break;
                case "48":
                    L1 = 101;
                    L2 = 125;
                    break;
                case "101125":
                    letterVal = "0";
                    break;
                case "49":
                    L1 = 95;
                    L2 = 103;
                    break;
                case "95103":
                    letterVal = "1";
                    break;
                case "50":
                    L1 = 55;
                    L2 = 89;
                    break;
                case "5589":
                    letterVal = "2";
                    break;
                case "51":
                    L1 = 107;
                    L2 = 121;
                    break;
                case "107121":
                    letterVal = "3";
                    break;
                case "52":
                    L1 = 59;
                    L2 = 69;
                    break;
                case "5969":
                    letterVal = "4";
                    break;
                case "53":
                    L1 = 36;
                    L2 = 69;
                    break;
                case "3669":
                    letterVal = "5";
                    break;
                case "54":
                    L1 = 90;
                    L2 = 53;
                    break;
                case "9053":
                    letterVal = "6";
                    break;
                case "55":
                    L1 = 76;
                    L2 = 49;
                    break;
                case "7649":
                    letterVal = "7";
                    break;
                case "56":
                    L1 = 116;
                    L2 = 63;
                    break;
                case "11663":
                    letterVal = "8";
                    break;
                case "57":
                    L1 = 95;
                    L2 = 86;
                    break;
                case "9586":
                    letterVal = "9";
                    break;
            }
            if (letterVal == "")
            {
                L1Char = Convert.ToChar(L1);
                L2Char = Convert.ToChar(L2);

                letterVal = $"{F1}{L1Char}{F2}{L2Char}{codeSetVal}";
            }
            return letterVal;
        }
        static string CodeSet2(string letter)
        {
            string codeSetVal = ";o";

            int L1 = 0;
            int L2 = 0;

            Random rng = new Random();
            int Fval1 = rng.Next(33, 127);
            int Fval2 = rng.Next(33, 127);
            char F1 = Convert.ToChar(Fval1);
            char F2 = Convert.ToChar(Fval2);
            char L1Char = ' ';
            char L2Char = ' ';

            string letterVal = "";

            switch (letter)
            {
                case "32":
                    L1 = 65;
                    L2 = 125;
                    break;
                case "65125":
                    letterVal = " ";
                    break;
                case "97":
                    L1 = 114;
                    L2 = 88;
                    break;
                case "11488":
                    letterVal = "a";
                    break;
                case "98":
                    L1 = 33;
                    L2 = 121;
                    break;
                case "33121":
                    letterVal = "b";
                    break;
                case "99":
                    L1 = 107;
                    L2 = 97;
                    break;
                case "10797":
                    letterVal = "c";
                    break;
                case "100":
                    L1 = 86;
                    L2 = 61;
                    break;
                case "8661":
                    letterVal = "d";
                    break;
                case "101":
                    L1 = 33;
                    L2 = 117;
                    break;
                case "33117":
                    letterVal = "e";
                    break;
                case "102":
                    L1 = 61;
                    L2 = 49;
                    break;
                case "6149":
                    letterVal = "f";
                    break;
                case "103":
                    L1 = 107;
                    L2 = 111;
                    break;
                case "107111":
                    letterVal = "g";
                    break;
                case "104":
                    L1 = 45;
                    L2 = 68;
                    break;
                case "4568":
                    letterVal = "h";
                    break;
                case "105":
                    L1 = 42;
                    L2 = 69;
                    break;
                case "4269":
                    letterVal = "i";
                    break;
                case "106":
                    L1 = 76;
                    L2 = 34;
                    break;
                case "7634":
                    letterVal = "j";
                    break;
                case "107":
                    L1 = 79;
                    L2 = 103;
                    break;
                case "79103":
                    letterVal = "k";
                    break;
                case "108":
                    L1 = 45;
                    L2 = 104;
                    break;
                case "45104":
                    letterVal = "l";
                    break;
                case "109":
                    L1 = 120;
                    L2 = 63;
                    break;
                case "12063":
                    letterVal = "m";
                    break;
                case "110":
                    L1 = 58;
                    L2 = 123;
                    break;
                case "58123":
                    letterVal = "n";
                    break;
                case "111":
                    L1 = 97;
                    L2 = 78;
                    break;
                case "9778":
                    letterVal = "o";
                    break;
                case "112":
                    L1 = 106;
                    L2 = 65;
                    break;
                case "10665":
                    letterVal = "p";
                    break;
                case "113":
                    L1 = 60;
                    L2 = 72;
                    break;
                case "6072":
                    letterVal = "q";
                    break;
                case "114":
                    L1 = 71;
                    L2 = 97;
                    break;
                case "7197":
                    letterVal = "r";
                    break;
                case "115":
                    L1 = 38;
                    L2 = 96;
                    break;
                case "3896":
                    letterVal = "s";
                    break;
                case "116":
                    L1 = 62;
                    L2 = 105;
                    break;
                case "62105":
                    letterVal = "t";
                    break;
                case "117":
                    L1 = 115;
                    L2 = 36;
                    break;
                case "11536":
                    letterVal = "u";
                    break;
                case "118":
                    L1 = 41;
                    L2 = 46;
                    break;
                case "4146":
                    letterVal = "v";
                    break;
                case "119":
                    L1 = 49;
                    L2 = 90;
                    break;
                case "4990":
                    letterVal = "w";
                    break;
                case "120":
                    L1 = 83;
                    L2 = 34;
                    break;
                case "8334":
                    letterVal = "x";
                    break;
                case "121":
                    L1 = 103;
                    L2 = 39;
                    break;
                case "10339":
                    letterVal = "y";
                    break;
                case "122":
                    L1 = 120;
                    L2 = 88;
                    break;
                case "12088":
                    letterVal = "z";
                    break;
                case "65":
                    L1 = 61;
                    L2 = 92;
                    break;
                case "6192":
                    letterVal = "A";
                    break;
                case "66":
                    L1 = 70;
                    L2 = 67;
                    break;
                case "7067":
                    letterVal = "B";
                    break;
                case "67":
                    L1 = 107;
                    L2 = 40;
                    break;
                case "10740":
                    letterVal = "C";
                    break;
                case "68":
                    L1 = 47;
                    L2 = 35;
                    break;
                case "4735":
                    letterVal = "D";
                    break;
                case "69":
                    L1 = 93;
                    L2 = 50;
                    break;
                case "9350":
                    letterVal = "E";
                    break;
                case "70":
                    L1 = 44;
                    L2 = 42;
                    break;
                case "4442":
                    letterVal = "F";
                    break;
                case "71":
                    L1 = 40;
                    L2 = 56;
                    break;
                case "4056":
                    letterVal = "G";
                    break;
                case "72":
                    L1 = 118;
                    L2 = 113;
                    break;
                case "118113":
                    letterVal = "H";
                    break;
                case "73":
                    L1 = 69;
                    L2 = 53;
                    break;
                case "6953":
                    letterVal = "I";
                    break;
                case "74":
                    L1 = 87;
                    L2 = 84;
                    break;
                case "8784":
                    letterVal = "J";
                    break;
                case "75":
                    L1 = 112;
                    L2 = 101;
                    break;
                case "112101":
                    letterVal = "K";
                    break;
                case "76":
                    L1 = 52;
                    L2 = 53;
                    break;
                case "5253":
                    letterVal = "L";
                    break;
                case "77":
                    L1 = 81;
                    L2 = 47;
                    break;
                case "8147":
                    letterVal = "M";
                    break;
                case "78":
                    L1 = 105;
                    L2 = 77;
                    break;
                case "10577":
                    letterVal = "N";
                    break;
                case "79":
                    L1 = 34;
                    L2 = 104;
                    break;
                case "34104":
                    letterVal = "O";
                    break;
                case "80":
                    L1 = 119;
                    L2 = 53;
                    break;
                case "11953":
                    letterVal = "P";
                    break;
                case "81":
                    L1 = 100;
                    L2 = 100;
                    break;
                case "100100":
                    letterVal = "Q";
                    break;
                case "82":
                    L1 = 125;
                    L2 = 105;
                    break;
                case "125105":
                    letterVal = "R";
                    break;
                case "83":
                    L1 = 64;
                    L2 = 38;
                    break;
                case "6438":
                    letterVal = "S";
                    break;
                case "84":
                    L1 = 67;
                    L2 = 106;
                    break;
                case "67106":
                    letterVal = "T";
                    break;
                case "85":
                    L1 = 90;
                    L2 = 65;
                    break;
                case "9065":
                    letterVal = "U";
                    break;
                case "86":
                    L1 = 41;
                    L2 = 91;
                    break;
                case "4191":
                    letterVal = "V";
                    break;
                case "87":
                    L1 = 47;
                    L2 = 117;
                    break;
                case "47117":
                    letterVal = "W";
                    break;
                case "88":
                    L1 = 69;
                    L2 = 110;
                    break;
                case "69110":
                    letterVal = "X";
                    break;
                case "89":
                    L1 = 82;
                    L2 = 59;
                    break;
                case "8259":
                    letterVal = "Y";
                    break;
                case "90":
                    L1 = 51;
                    L2 = 119;
                    break;
                case "51119":
                    letterVal = "Z";
                    break;
                case "46":
                    L1 = 101;
                    L2 = 44;
                    break;
                case "10144":
                    letterVal = ".";
                    break;
                case "33":
                    L1 = 60;
                    L2 = 101;
                    break;
                case "60101":
                    letterVal = "!";
                    break;
                case "63":
                    L1 = 83;
                    L2 = 84;
                    break;
                case "8384":
                    letterVal = "?";
                    break;
                case "64":
                    L1 = 34;
                    L2 = 42;
                    break;
                case "3442":
                    letterVal = "@";
                    break;
                case "35":
                    L1 = 95;
                    L2 = 96;
                    break;
                case "9596":
                    letterVal = "#";
                    break;
                case "36":
                    L1 = 57;
                    L2 = 84;
                    break;
                case "5784":
                    letterVal = "$";
                    break;
                case "37":
                    L1 = 104;
                    L2 = 36;
                    break;
                case "10436":
                    letterVal = "%";
                    break;
                case "94":
                    L1 = 100;
                    L2 = 89;
                    break;
                case "10089":
                    letterVal = "^";
                    break;
                case "38":
                    L1 = 106;
                    L2 = 86;
                    break;
                case "10686":
                    letterVal = "&";
                    break;
                case "42":
                    L1 = 110;
                    L2 = 35;
                    break;
                case "11035":
                    letterVal = "*";
                    break;
                case "40":
                    L1 = 49;
                    L2 = 73;
                    break;
                case "4973":
                    letterVal = "(";
                    break;
                case "41":
                    L1 = 120;
                    L2 = 65;
                    break;
                case "12065":
                    letterVal = ")";
                    break;
                case "45":
                    L1 = 74;
                    L2 = 111;
                    break;
                case "74111":
                    letterVal = "-";
                    break;
                case "95":
                    L1 = 119;
                    L2 = 124;
                    break;
                case "119124":
                    letterVal = "_";
                    break;
                case "61":
                    L1 = 89;
                    L2 = 117;
                    break;
                case "89117":
                    letterVal = "=";
                    break;
                case "43":
                    L1 = 125;
                    L2 = 63;
                    break;
                case "12563":
                    letterVal = "+";
                    break;
                case "44":
                    L1 = 123;
                    L2 = 125;
                    break;
                case "123125":
                    letterVal = ",";
                    break;
                case "48":
                    L1 = 75;
                    L2 = 46;
                    break;
                case "7546":
                    letterVal = "0";
                    break;
                case "49":
                    L1 = 117;
                    L2 = 117;
                    break;
                case "117117":
                    letterVal = "1";
                    break;
                case "50":
                    L1 = 71;
                    L2 = 41;
                    break;
                case "7141":
                    letterVal = "2";
                    break;
                case "51":
                    L1 = 126;
                    L2 = 88;
                    break;
                case "12688":
                    letterVal = "3";
                    break;
                case "52":
                    L1 = 109;
                    L2 = 33;
                    break;
                case "10933":
                    letterVal = "4";
                    break;
                case "53":
                    L1 = 46;
                    L2 = 41;
                    break;
                case "4641":
                    letterVal = "5";
                    break;
                case "54":
                    L1 = 119;
                    L2 = 70;
                    break;
                case "11970":
                    letterVal = "6";
                    break;
                case "55":
                    L1 = 42;
                    L2 = 37;
                    break;
                case "4237":
                    letterVal = "7";
                    break;
                case "56":
                    L1 = 100;
                    L2 = 80;
                    break;
                case "10080":
                    letterVal = "8";
                    break;
                case "57":
                    L1 = 43;
                    L2 = 111;
                    break;
                case "43111":
                    letterVal = "9";
                    break;
            }
            if (letterVal == "")
            {
                L1Char = Convert.ToChar(L1);
                L2Char = Convert.ToChar(L2);

                letterVal = $"{L1Char}{F1}{L2Char}{F2}{codeSetVal}";
            }
            return letterVal;
        }
        static string CodeSet3(string letter)
        {
            string codeSetVal = "DK";

            int L1 = 0;
            int L2 = 0;

            Random rng = new Random();
            int Fval1 = rng.Next(33, 127);
            int Fval2 = rng.Next(33, 127);
            char F1 = Convert.ToChar(Fval1);
            char F2 = Convert.ToChar(Fval2);
            char L1Char = ' ';
            char L2Char = ' ';

            string letterVal = "";

            switch (letter)
            {
                case "32":
                    L1 = 69;
                    L2 = 34;
                    break;
                case "6934":
                    letterVal = " ";
                    break;
                case "97":
                    L1 = 116;
                    L2 = 55;
                    break;
                case "11655":
                    letterVal = "a";
                    break;
                case "98":
                    L1 = 91;
                    L2 = 109;
                    break;
                case "91109":
                    letterVal = "b";
                    break;
                case "99":
                    L1 = 61;
                    L2 = 35;
                    break;
                case "6135":
                    letterVal = "c";
                    break;
                case "100":
                    L1 = 62;
                    L2 = 49;
                    break;
                case "6249":
                    letterVal = "d";
                    break;
                case "101":
                    L1 = 42;
                    L2 = 58;
                    break;
                case "4258":
                    letterVal = "e";
                    break;
                case "102":
                    L1 = 121;
                    L2 = 43;
                    break;
                case "12143":
                    letterVal = "f";
                    break;
                case "103":
                    L1 = 44;
                    L2 = 62;
                    break;
                case "4462":
                    letterVal = "g";
                    break;
                case "104":
                    L1 = 117;
                    L2 = 53;
                    break;
                case "11753":
                    letterVal = "h";
                    break;
                case "105":
                    L1 = 43;
                    L2 = 92;
                    break;
                case "4392":
                    letterVal = "i";
                    break;
                case "106":
                    L1 = 71;
                    L2 = 39;
                    break;
                case "7139":
                    letterVal = "j";
                    break;
                case "107":
                    L1 = 116;
                    L2 = 122;
                    break;
                case "116122":
                    letterVal = "k";
                    break;
                case "108":
                    L1 = 81;
                    L2 = 90;
                    break;
                case "8190":
                    letterVal = "l";
                    break;
                case "109":
                    L1 = 122;
                    L2 = 104;
                    break;
                case "122104":
                    letterVal = "m";
                    break;
                case "110":
                    L1 = 105;
                    L2 = 50;
                    break;
                case "10550":
                    letterVal = "n";
                    break;
                case "111":
                    L1 = 61;
                    L2 = 52;
                    break;
                case "6152":
                    letterVal = "o";
                    break;
                case "112":
                    L1 = 94;
                    L2 = 84;
                    break;
                case "9484":
                    letterVal = "p";
                    break;
                case "113":
                    L1 = 91;
                    L2 = 46;
                    break;
                case "9146":
                    letterVal = "q";
                    break;
                case "114":
                    L1 = 93;
                    L2 = 92;
                    break;
                case "9392":
                    letterVal = "r";
                    break;
                case "115":
                    L1 = 77;
                    L2 = 65;
                    break;
                case "7765":
                    letterVal = "s";
                    break;
                case "116":
                    L1 = 76;
                    L2 = 33;
                    break;
                case "7633":
                    letterVal = "t";
                    break;
                case "117":
                    L1 = 74;
                    L2 = 54;
                    break;
                case "7454":
                    letterVal = "u";
                    break;
                case "118":
                    L1 = 117;
                    L2 = 87;
                    break;
                case "11787":
                    letterVal = "v";
                    break;
                case "119":
                    L1 = 42;
                    L2 = 36;
                    break;
                case "4236":
                    letterVal = "w";
                    break;
                case "120":
                    L1 = 115;
                    L2 = 55;
                    break;
                case "11555":
                    letterVal = "x";
                    break;
                case "121":
                    L1 = 59;
                    L2 = 104;
                    break;
                case "59104":
                    letterVal = "y";
                    break;
                case "122":
                    L1 = 71;
                    L2 = 50;
                    break;
                case "7150":
                    letterVal = "z";
                    break;
                case "65":
                    L1 = 84;
                    L2 = 58;
                    break;
                case "8458":
                    letterVal = "A";
                    break;
                case "66":
                    L1 = 84;
                    L2 = 86;
                    break;
                case "8486":
                    letterVal = "B";
                    break;
                case "67":
                    L1 = 82;
                    L2 = 74;
                    break;
                case "8274":
                    letterVal = "C";
                    break;
                case "68":
                    L1 = 87;
                    L2 = 103;
                    break;
                case "87103":
                    letterVal = "D";
                    break;
                case "69":
                    L1 = 85;
                    L2 = 38;
                    break;
                case "8538":
                    letterVal = "E";
                    break;
                case "70":
                    L1 = 79;
                    L2 = 125;
                    break;
                case "79125":
                    letterVal = "F";
                    break;
                case "71":
                    L1 = 62;
                    L2 = 36;
                    break;
                case "6236":
                    letterVal = "G";
                    break;
                case "72":
                    L1 = 43;
                    L2 = 49;
                    break;
                case "4349":
                    letterVal = "H";
                    break;
                case "73":
                    L1 = 116;
                    L2 = 62;
                    break;
                case "11662":
                    letterVal = "I";
                    break;
                case "74":
                    L1 = 110;
                    L2 = 78;
                    break;
                case "11078":
                    letterVal = "J";
                    break;
                case "75":
                    L1 = 101;
                    L2 = 110;
                    break;
                case "101110":
                    letterVal = "K";
                    break;
                case "76":
                    L1 = 53;
                    L2 = 110;
                    break;
                case "53110":
                    letterVal = "L";
                    break;
                case "77":
                    L1 = 95;
                    L2 = 79;
                    break;
                case "9579":
                    letterVal = "M";
                    break;
                case "78":
                    L1 = 73;
                    L2 = 94;
                    break;
                case "7394":
                    letterVal = "N";
                    break;
                case "79":
                    L1 = 103;
                    L2 = 123;
                    break;
                case "103123":
                    letterVal = "O";
                    break;
                case "80":
                    L1 = 43;
                    L2 = 114;
                    break;
                case "43114":
                    letterVal = "P";
                    break;
                case "81":
                    L1 = 114;
                    L2 = 72;
                    break;
                case "11472":
                    letterVal = "Q";
                    break;
                case "82":
                    L1 = 39;
                    L2 = 95;
                    break;
                case "3995":
                    letterVal = "R";
                    break;
                case "83":
                    L1 = 34;
                    L2 = 48;
                    break;
                case "3448":
                    letterVal = "S";
                    break;
                case "84":
                    L1 = 57;
                    L2 = 69;
                    break;
                case "5769":
                    letterVal = "T";
                    break;
                case "85":
                    L1 = 39;
                    L2 = 115;
                    break;
                case "39115":
                    letterVal = "U";
                    break;
                case "86":
                    L1 = 104;
                    L2 = 119;
                    break;
                case "104119":
                    letterVal = "V";
                    break;
                case "87":
                    L1 = 35;
                    L2 = 97;
                    break;
                case "3597":
                    letterVal = "W";
                    break;
                case "88":
                    L1 = 97;
                    L2 = 106;
                    break;
                case "97106":
                    letterVal = "X";
                    break;
                case "89":
                    L1 = 83;
                    L2 = 79;
                    break;
                case "8379":
                    letterVal = "Y";
                    break;
                case "90":
                    L1 = 82;
                    L2 = 86;
                    break;
                case "8286":
                    letterVal = "Z";
                    break;
                case "46":
                    L1 = 51;
                    L2 = 81;
                    break;
                case "5181":
                    letterVal = ".";
                    break;
                case "33":
                    L1 = 52;
                    L2 = 44;
                    break;
                case "5244":
                    letterVal = "!";
                    break;
                case "63":
                    L1 = 88;
                    L2 = 89;
                    break;
                case "8889":
                    letterVal = "?";
                    break;
                case "64":
                    L1 = 124;
                    L2 = 39;
                    break;
                case "12439":
                    letterVal = "@";
                    break;
                case "35":
                    L1 = 71;
                    L2 = 80;
                    break;
                case "7180":
                    letterVal = "#";
                    break;
                case "36":
                    L1 = 110;
                    L2 = 72;
                    break;
                case "11072":
                    letterVal = "$";
                    break;
                case "37":
                    L1 = 113;
                    L2 = 99;
                    break;
                case "11399":
                    letterVal = "%";
                    break;
                case "94":
                    L1 = 109;
                    L2 = 55;
                    break;
                case "10955":
                    letterVal = "^";
                    break;
                case "38":
                    L1 = 97;
                    L2 = 101;
                    break;
                case "97101":
                    letterVal = "&";
                    break;
                case "42":
                    L1 = 66;
                    L2 = 66;
                    break;
                case "6666":
                    letterVal = "*";
                    break;
                case "40":
                    L1 = 81;
                    L2 = 87;
                    break;
                case "8187":
                    letterVal = "(";
                    break;
                case "41":
                    L1 = 119;
                    L2 = 44;
                    break;
                case "11944":
                    letterVal = ")";
                    break;
                case "45":
                    L1 = 101;
                    L2 = 52;
                    break;
                case "10152":
                    letterVal = "-";
                    break;
                case "95":
                    L1 = 76;
                    L2 = 70;
                    break;
                case "7670":
                    letterVal = "_";
                    break;
                case "61":
                    L1 = 50;
                    L2 = 111;
                    break;
                case "50111":
                    letterVal = "=";
                    break;
                case "43":
                    L1 = 75;
                    L2 = 68;
                    break;
                case "7568":
                    letterVal = "+";
                    break;
                case "44":
                    L1 = 102;
                    L2 = 89;
                    break;
                case "10289":
                    letterVal = ",";
                    break;
                case "48":
                    L1 = 46;
                    L2 = 77;
                    break;
                case "4677":
                    letterVal = "0";
                    break;
                case "49":
                    L1 = 69;
                    L2 = 66;
                    break;
                case "6966":
                    letterVal = "1";
                    break;
                case "50":
                    L1 = 53;
                    L2 = 87;
                    break;
                case "5387":
                    letterVal = "2";
                    break;
                case "51":
                    L1 = 84;
                    L2 = 75;
                    break;
                case "8475":
                    letterVal = "3";
                    break;
                case "52":
                    L1 = 105;
                    L2 = 44;
                    break;
                case "10544":
                    letterVal = "4";
                    break;
                case "53":
                    L1 = 53;
                    L2 = 39;
                    break;
                case "5339":
                    letterVal = "5";
                    break;
                case "54":
                    L1 = 60;
                    L2 = 117;
                    break;
                case "60117":
                    letterVal = "6";
                    break;
                case "55":
                    L1 = 115;
                    L2 = 40;
                    break;
                case "11540":
                    letterVal = "7";
                    break;
                case "56":
                    L1 = 102;
                    L2 = 117;
                    break;
                case "102117":
                    letterVal = "8";
                    break;
                case "57":
                    L1 = 94;
                    L2 = 106;
                    break;
                case "94106":
                    letterVal = "9";
                    break;
            }
            if (letterVal == "")
            {
                L1Char = Convert.ToChar(L1);
                L2Char = Convert.ToChar(L2);

                letterVal = $"{F1}{F2}{L1Char}{L2Char}{codeSetVal}";
            }
            return letterVal;
        }
        static string CodeSet4(string letter)
        {
            string codeSetVal = "/V";

            int L1 = 0;
            int L2 = 0;

            Random rng = new Random();
            int Fval1 = rng.Next(33, 127);
            int Fval2 = rng.Next(33, 127);
            char F1 = Convert.ToChar(Fval1);
            char F2 = Convert.ToChar(Fval2);
            char L1Char = ' ';
            char L2Char = ' ';

            string letterVal = "";

            switch (letter)
            {
                case "32":
                    L1 = 116;
                    L2 = 119;
                    break;
                case "116119":
                    letterVal = " ";
                    break;
                case "97":
                    L1 = 47;
                    L2 = 45;
                    break;
                case "4745":
                    letterVal = "a";
                    break;
                case "98":
                    L1 = 118;
                    L2 = 41;
                    break;
                case "11841":
                    letterVal = "b";
                    break;
                case "99":
                    L1 = 95;
                    L2 = 44;
                    break;
                case "9544":
                    letterVal = "c";
                    break;
                case "100":
                    L1 = 59;
                    L2 = 109;
                    break;
                case "59109":
                    letterVal = "d";
                    break;
                case "101":
                    L1 = 87;
                    L2 = 125;
                    break;
                case "87125":
                    letterVal = "e";
                    break;
                case "102":
                    L1 = 109;
                    L2 = 106;
                    break;
                case "109106":
                    letterVal = "f";
                    break;
                case "103":
                    L1 = 60;
                    L2 = 118;
                    break;
                case "60118":
                    letterVal = "g";
                    break;
                case "104":
                    L1 = 116;
                    L2 = 66;
                    break;
                case "11666":
                    letterVal = "h";
                    break;
                case "105":
                    L1 = 74;
                    L2 = 35;
                    break;
                case "7435":
                    letterVal = "i";
                    break;
                case "106":
                    L1 = 79;
                    L2 = 82;
                    break;
                case "7982":
                    letterVal = "j";
                    break;
                case "107":
                    L1 = 87;
                    L2 = 84;
                    break;
                case "8784":
                    letterVal = "k";
                    break;
                case "108":
                    L1 = 116;
                    L2 = 58;
                    break;
                case "11658":
                    letterVal = "l";
                    break;
                case "109":
                    L1 = 119;
                    L2 = 114;
                    break;
                case "119114":
                    letterVal = "m";
                    break;
                case "110":
                    L1 = 47;
                    L2 = 53;
                    break;
                case "4753":
                    letterVal = "n";
                    break;
                case "111":
                    L1 = 91;
                    L2 = 52;
                    break;
                case "9152":
                    letterVal = "o";
                    break;
                case "112":
                    L1 = 124;
                    L2 = 50;
                    break;
                case "12450":
                    letterVal = "p";
                    break;
                case "113":
                    L1 = 93;
                    L2 = 52;
                    break;
                case "9352":
                    letterVal = "q";
                    break;
                case "114":
                    L1 = 123;
                    L2 = 99;
                    break;
                case "12399":
                    letterVal = "r";
                    break;
                case "115":
                    L1 = 87;
                    L2 = 104;
                    break;
                case "87104":
                    letterVal = "s";
                    break;
                case "116":
                    L1 = 48;
                    L2 = 95;
                    break;
                case "4895":
                    letterVal = "t";
                    break;
                case "117":
                    L1 = 77;
                    L2 = 113;
                    break;
                case "77113":
                    letterVal = "u";
                    break;
                case "118":
                    L1 = 44;
                    L2 = 105;
                    break;
                case "44105":
                    letterVal = "v";
                    break;
                case "119":
                    L1 = 90;
                    L2 = 52;
                    break;
                case "9052":
                    letterVal = "w";
                    break;
                case "120":
                    L1 = 63;
                    L2 = 65;
                    break;
                case "6365":
                    letterVal = "x";
                    break;
                case "121":
                    L1 = 92;
                    L2 = 102;
                    break;
                case "92102":
                    letterVal = "y";
                    break;
                case "122":
                    L1 = 121;
                    L2 = 98;
                    break;
                case "12198":
                    letterVal = "z";
                    break;
                case "65":
                    L1 = 119;
                    L2 = 90;
                    break;
                case "11990":
                    letterVal = "A";
                    break;
                case "66":
                    L1 = 95;
                    L2 = 76;
                    break;
                case "9576":
                    letterVal = "B";
                    break;
                case "67":
                    L1 = 84;
                    L2 = 107;
                    break;
                case "84107":
                    letterVal = "C";
                    break;
                case "68":
                    L1 = 60;
                    L2 = 103;
                    break;
                case "60103":
                    letterVal = "D";
                    break;
                case "69":
                    L1 = 109;
                    L2 = 117;
                    break;
                case "109117":
                    letterVal = "E";
                    break;
                case "70":
                    L1 = 85;
                    L2 = 73;
                    break;
                case "8573":
                    letterVal = "F";
                    break;
                case "71":
                    L1 = 59;
                    L2 = 54;
                    break;
                case "5954":
                    letterVal = "G";
                    break;
                case "72":
                    L1 = 123;
                    L2 = 33;
                    break;
                case "12333":
                    letterVal = "H";
                    break;
                case "73":
                    L1 = 50;
                    L2 = 72;
                    break;
                case "5072":
                    letterVal = "I";
                    break;
                case "74":
                    L1 = 102;
                    L2 = 97;
                    break;
                case "10297":
                    letterVal = "J";
                    break;
                case "75":
                    L1 = 69;
                    L2 = 95;
                    break;
                case "6995":
                    letterVal = "K";
                    break;
                case "76":
                    L1 = 87;
                    L2 = 33;
                    break;
                case "8733":
                    letterVal = "L";
                    break;
                case "77":
                    L1 = 81;
                    L2 = 102;
                    break;
                case "81102":
                    letterVal = "M";
                    break;
                case "78":
                    L1 = 38;
                    L2 = 126;
                    break;
                case "38126":
                    letterVal = "N";
                    break;
                case "79":
                    L1 = 58;
                    L2 = 57;
                    break;
                case "5857":
                    letterVal = "O";
                    break;
                case "80":
                    L1 = 125;
                    L2 = 79;
                    break;
                case "12579":
                    letterVal = "P";
                    break;
                case "81":
                    L1 = 60;
                    L2 = 56;
                    break;
                case "6056":
                    letterVal = "Q";
                    break;
                case "82":
                    L1 = 79;
                    L2 = 78;
                    break;
                case "7978":
                    letterVal = "R";
                    break;
                case "83":
                    L1 = 43;
                    L2 = 70;
                    break;
                case "4370":
                    letterVal = "S";
                    break;
                case "84":
                    L1 = 43;
                    L2 = 47;
                    break;
                case "4347":
                    letterVal = "T";
                    break;
                case "85":
                    L1 = 103;
                    L2 = 75;
                    break;
                case "10375":
                    letterVal = "U";
                    break;
                case "86":
                    L1 = 92;
                    L2 = 79;
                    break;
                case "9279":
                    letterVal = "V";
                    break;
                case "87":
                    L1 = 54;
                    L2 = 96;
                    break;
                case "5496":
                    letterVal = "W";
                    break;
                case "88":
                    L1 = 93;
                    L2 = 79;
                    break;
                case "9379":
                    letterVal = "X";
                    break;
                case "89":
                    L1 = 90;
                    L2 = 115;
                    break;
                case "90115":
                    letterVal = "Y";
                    break;
                case "90":
                    L1 = 76;
                    L2 = 89;
                    break;
                case "7689":
                    letterVal = "Z";
                    break;
                case "46":
                    L1 = 38;
                    L2 = 61;
                    break;
                case "3861":
                    letterVal = ".";
                    break;
                case "33":
                    L1 = 70;
                    L2 = 124;
                    break;
                case "70124":
                    letterVal = "!";
                    break;
                case "63":
                    L1 = 117;
                    L2 = 100;
                    break;
                case "117100":
                    letterVal = "?";
                    break;
                case "64":
                    L1 = 123;
                    L2 = 87;
                    break;
                case "12387":
                    letterVal = "@";
                    break;
                case "35":
                    L1 = 120;
                    L2 = 45;
                    break;
                case "12045":
                    letterVal = "#";
                    break;
                case "36":
                    L1 = 36;
                    L2 = 92;
                    break;
                case "3692":
                    letterVal = "$";
                    break;
                case "37":
                    L1 = 54;
                    L2 = 78;
                    break;
                case "5478":
                    letterVal = "%";
                    break;
                case "94":
                    L1 = 51;
                    L2 = 97;
                    break;
                case "5197":
                    letterVal = "^";
                    break;
                case "38":
                    L1 = 33;
                    L2 = 33;
                    break;
                case "3333":
                    letterVal = "&";
                    break;
                case "42":
                    L1 = 107;
                    L2 = 107;
                    break;
                case "107107":
                    letterVal = "*";
                    break;
                case "40":
                    L1 = 124;
                    L2 = 101;
                    break;
                case "124101":
                    letterVal = "(";
                    break;
                case "41":
                    L1 = 71;
                    L2 = 40;
                    break;
                case "7140":
                    letterVal = ")";
                    break;
                case "45":
                    L1 = 67;
                    L2 = 78;
                    break;
                case "6778":
                    letterVal = "-";
                    break;
                case "95":
                    L1 = 67;
                    L2 = 118;
                    break;
                case "67118":
                    letterVal = "_";
                    break;
                case "61":
                    L1 = 80;
                    L2 = 66;
                    break;
                case "8066":
                    letterVal = "=";
                    break;
                case "43":
                    L1 = 43;
                    L2 = 72;
                    break;
                case "4372":
                    letterVal = "+";
                    break;
                case "44":
                    L1 = 103;
                    L2 = 55;
                    break;
                case "10355":
                    letterVal = ",";
                    break;
                case "48":
                    L1 = 43;
                    L2 = 76;
                    break;
                case "4376":
                    letterVal = "0";
                    break;
                case "49":
                    L1 = 61;
                    L2 = 54;
                    break;
                case "6154":
                    letterVal = "1";
                    break;
                case "50":
                    L1 = 123;
                    L2 = 67;
                    break;
                case "12367":
                    letterVal = "2";
                    break;
                case "51":
                    L1 = 76;
                    L2 = 116;
                    break;
                case "76116":
                    letterVal = "3";
                    break;
                case "52":
                    L1 = 102;
                    L2 = 121;
                    break;
                case "102121":
                    letterVal = "4";
                    break;
                case "53":
                    L1 = 122;
                    L2 = 34;
                    break;
                case "12234":
                    letterVal = "5";
                    break;
                case "54":
                    L1 = 51;
                    L2 = 86;
                    break;
                case "5186":
                    letterVal = "6";
                    break;
                case "55":
                    L1 = 84;
                    L2 = 70;
                    break;
                case "8470":
                    letterVal = "7";
                    break;
                case "56":
                    L1 = 58;
                    L2 = 55;
                    break;
                case "5855":
                    letterVal = "8";
                    break;
                case "57":
                    L1 = 40;
                    L2 = 65;
                    break;
                case "4065":
                    letterVal = "9";
                    break;
            }
            if (letterVal == "")
            {
                L1Char = Convert.ToChar(L1);
                L2Char = Convert.ToChar(L2);

                letterVal = $"{L1Char}{L2Char}{F1}{F2}{codeSetVal}";
            }
            return letterVal;
        }


    }
}
