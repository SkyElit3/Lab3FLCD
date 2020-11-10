using System;
using System.Text.RegularExpressions;

namespace Lab2FLCD
{
    /*
 * While (not(eof)) do
    detect(token);
    if token is reserved word OR operator OR separator
            then genPIF(token, -1)
        else
            if token is identifier OR constant
                then index = pos(token, ST);
                genPIF(token, index)
            else message “Lexical error”
        endif
    endif
endwhile	

 */
/*
 *  operators + - * / % < <= = >= > != ==
    separators [ ] { } ; space ( ) , newline
    reserved words : write read go times start stop int char bool
 */
    public class Scanner
    {
        private MyHashMap h1;
        private string[,] _pif;
        private int _pifLength;
        private FiniteAutomator f;

        public Scanner()
        {
            f = new FiniteAutomator();
            h1 = new MyHashMap();
            _pifLength = 0;
        }

        public void GenPif(string token,string position)
        {
            _pif[_pifLength, 0] = token;
            _pif[_pifLength, 1] = position;
            _pifLength++;
        }
        public void Scan(string path,string tokenPath)
        {
            f.ScanFile(@"C:\Users\SkyElit3\RiderProjects\Lab4FLCD\Lab2FLCD\input\FA.in");

            bool foundErrors = false;
            
            string[] tokenLines = System.IO.File.ReadAllLines(tokenPath);
            string[,] tokens = new string[tokenLines.Length,2];
            string[] tokensSimple = new string[tokenLines.Length];
            int counter = 0;
            foreach (string s in tokenLines)
            {
                tokens[counter,0] = s.Split(' ')[0];
                tokensSimple[counter] = s.Split(' ')[0];
                tokens[counter,1] = s.Split(' ')[1];
                counter++;
            }
            string[] programLines = System.IO.File.ReadAllLines(path);
            int lineCount = 1;
            string program = System.IO.File.ReadAllText(path);
            string[] programWords = program.Split(" ");
            _pif = new string[programWords.Length,2]; // initializare PIF
            
            foreach (string line in programLines)
            {
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    if (Array.IndexOf(tokensSimple, word) >= 0)
                    {
                        string index = h1.Search(word);
                        if (index.Equals("Not found !")) // if identifier or constant is not already in the PIF , we add it then get the position
                        {
                            h1.Add(word);
                            GenPif(word,"0");
                        } 
                    }
                    else if (f.CheckWord(word) && !Regex.IsMatch(word, @"^\d+$") )
                    {
                        string index = h1.Search(word);
                        if (index.Equals("Not found !")) // if identifier or constant is not already in the PIF , we add it then get the position
                        {
                            h1.Add(word);
                            GenPif(word,h1.Search(word));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lexical error at line "+lineCount.ToString() + " word " + word);
                        foundErrors = true;
                    }
                }
                
                lineCount++;
            }
            if (!foundErrors)
            {
                Console.WriteLine("Lexically correct !");
                System.IO.File.WriteAllText(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\output\ST.out", h1.ToString());
                string stringPif = new string("");
                for (int index = 0; index < _pifLength; index++)
                {
                    stringPif += _pif[index, 0] + " " + _pif[index, 1] + "\n";
                }
                System.IO.File.WriteAllText(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\output\PIF.out", stringPif);

            }
            else
            {
                System.IO.File.WriteAllText(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\output\ST.out",
                    "Lexically incorrect !");
                System.IO.File.WriteAllText(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\output\PIF.out",
                    "Lexically incorrect !");
            }


        }
    }
}