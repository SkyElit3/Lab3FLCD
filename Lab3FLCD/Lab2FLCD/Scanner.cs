using System;
using System.Linq;

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
        public void Scan()
        {
            string[] tokenLines = System.IO.File.ReadAllLines(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\input\token.in");
            string[,] tokens = new string[tokenLines.Length,2];
            string[] tokensSimple = new string[tokenLines.Length];
            int i = 0;
            foreach (string s in tokenLines)
            {
                tokens[i,0] = s.Split(' ')[0];
                tokensSimple[i] = s.Split(' ')[0];
                tokens[i,1] = s.Split(' ')[1];
                i++;
            }
            /*
            string splitString = new string("");
            foreach (string s in tokensSimple)
            {
                splitString += s;
            }
            */

            foreach (string s in tokens)
            {
                //System.Console.WriteLine(s);
            }

            string[] programLines = System.IO.File.ReadAllLines(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\input\p1.txt");
            foreach (string line in programLines)
            {
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    int index = 0;
                    string formedString = new string("");
                    while (index < word.Length)
                    {
                        if (!tokensSimple.Contains(word[index].ToString()) || !tokensSimple.Contains(formedString)) // daca litera curenta nu e separator sau cuvantul compus nu e in tokens.in
                        {
                            formedString.Append(word[index]);
                            if (index + 1 < word.Length) // daca nu am ajuns la finalul stringului
                            {
                                if (!tokensSimple.Contains(word[index + 1].ToString())) // daca urmatoarea litera nu este separator
                                {
                                    
                                }
                            }
                            else if (tokensSimple.Contains(word[index].ToString()))
                            {
                                
                            }
                            
                        }
                        else // daca litera curenta ESTE separator sau cuvantul compus ESTE in tokens.in
                        {
                            Console.WriteLine(formedString);// salvam cuvantul unde trebuie in PIF si resetam cuvantul compus
                            formedString = "";
                            
                        }

                        index += 1;
                    }
                }
                
                // abra*cadabra=weioda
                //System.Console.WriteLine(line);
            }
        }
    }
}