using System;
using System.Linq;
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
        private string[,] pif;
        private int pif_length;

        public Scanner()
        {
            h1 = new MyHashMap();
            pif_length = 0;
        }

        public void genPif(string token,string position)
        {
            pif[pif_length, 0] = token;
            pif[pif_length, 1] = position;
            pif_length++;
        }
        public void Scan()
        {
            bool found_errors = false;
            
            string[] tokenLines = System.IO.File.ReadAllLines(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\input\token.in");
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
            string path = new string(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\input\p2.txt");
            string[] programLines = System.IO.File.ReadAllLines(path);
            int line_count = 1;
            string program = System.IO.File.ReadAllText(path);
            string[] programWords = program.Split(" ");
            pif = new string[programWords.Length,2]; // initializare PIF
            
            foreach (string line in programLines)
            {
                string[] words = line.Split(' ');
                int word_count = 0;
                foreach (string word in words)
                {
                    if (Array.IndexOf(tokensSimple, word) >= 0)
                    {
                        string index = h1.search(word);
                        if (index.Equals("Not found !")) // if identifier or constant is not already in the PIF , we add it then get the position
                        {
                            h1.add(word);
                            genPif(word,"0");
                        } 
                    }
                    else if (Regex.IsMatch(word, @"^[a-zA-Z0-9]+$"))
                    {
                        string index = h1.search(word);
                        if (index.Equals("Not found !")) // if identifier or constant is not already in the PIF , we add it then get the position
                        {
                            h1.add(word);
                            genPif(word,h1.search(word));
                        } 
                        //index = h1.search(word);
                        //int int_index = Int32.Parse(index.Split(" ")[0]);
                    }
                    else
                    {
                        Console.WriteLine("Lexical error at line "+line_count.ToString() + " word " + word);
                        found_errors = true;
                    }

                    word_count++;
                }
                
                line_count++;
            }
            //Console.WriteLine(h1.ToString());
            // WRITE H1 TO FILE
            if (!found_errors)
            {
                Console.WriteLine("Lexically correct !");
                System.IO.File.WriteAllText(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\output\ST.out", h1.ToString());
                string string_pif = new string("");
                for (int index = 0; index < pif_length; index++)
                {
                    string_pif += pif[index, 0] + " " + pif[index, 1] + "\n";
                }
                System.IO.File.WriteAllText(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\output\PIF.out", string_pif);

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