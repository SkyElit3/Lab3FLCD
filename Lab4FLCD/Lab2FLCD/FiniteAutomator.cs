using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2FLCD
{
    public class FiniteAutomator
    {
        private List<string> states = new List<string>();
        private List<string> alphabet = new List<string>();
        private List<string> transitions = new List<string>();
        private List<string> initialStates = new List<string>();
        private List<string> finalStates = new List<string>();
        public void ScanFile(string path)
        {
            bool transitionFlag = false;
            
            string[] programLines = System.IO.File.ReadAllLines(path);
            foreach (string line in programLines)
            {
                string[] words = line.Split(' ');
                if (words[0].Equals("states:"))
                {
                    foreach (string state in words)
                    {
                        if (!state.Equals("states:"))
                            this.states.Add(state);
                    }
                }
                else if (words[0].Equals("alphabet:"))
                {
                    foreach (string character in words)
                    {
                        if (!character.Equals("alphabet:"))
                            this.alphabet.Add(character);
                    }
                }
                else if (words[0].Equals("transitions:"))
                    transitionFlag = true;
                else if (words[0].Equals("initialstate:"))
                {
                    transitionFlag = false;
                    foreach (string initialState in words)
                    {
                        if (!initialState.Equals("initialstate:"))
                            this.initialStates.Add(initialState);
                    }
                }
                else if (words[0].Equals("finalstate:"))
                {
                    foreach (string finalState in words)
                    {
                        if (!finalState.Equals("finalstate:"))
                            this.finalStates.Add(finalState);
                    }
                }
                else if (transitionFlag)
                    transitions.Add(line);
            }
        

        }

        public void Run()
        {
            while (true)
            {
                string s = new string("");
                Console.WriteLine("\nMenu :\n" +
                                  "1 - states\n" +
                                  "2 - alphabet\n" +
                                  "3 - transitions\n" +
                                  "4 - initial states\n" +
                                  "5 - final states\n" +
                                  "6 - dfa\n");
                s = Console.ReadLine();
                if (s.Equals("exit"))
                    break;
                else if (s.Equals("1"))
                {
                    Console.WriteLine("States :");
                    foreach (var forString in states)
                    Console.WriteLine(forString);
                }
                else if (s.Equals("2"))
                {
                    Console.WriteLine("Alphabet :");
                    foreach (var forString in alphabet)
                        Console.WriteLine(forString);
                }
                else if (s.Equals("3"))
                {
                    Console.WriteLine("Transitions :");
                    foreach (var forString in transitions)
                        Console.WriteLine(forString);
                }
                else if (s.Equals("4"))
                {
                    Console.WriteLine("Initial States :");
                    foreach (var forString in initialStates)
                        Console.WriteLine(forString);
                }
                else if (s.Equals("5"))
                {
                    Console.WriteLine("Final States :");
                    foreach (var forString in finalStates)
                        Console.WriteLine(forString);
                }
                else if (s.Equals("6"))
                {
                    Console.WriteLine("Enter word :");
                    string word = new string("");
                    word = Console.ReadLine();
                    Console.WriteLine(this.CheckWord(word));
                }
                
            }
            
        }

        public bool CheckWord(string word)
        {
            string initialState = this.initialStates[0];
            string finalState = this.finalStates[0];
            string wordBuilder = new string("");
            
            foreach (char c in word)
                if (!this.alphabet.Contains(c.ToString()))
                    return false;
            char[] charArray = word.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                foreach (var transition in this.transitions)
                {
                    string[] transitionTokens = transition.Split(' ');
                    if (transitionTokens[0].Equals(initialState) &&
                        transitionTokens[1].Equals(charArray[i] .ToString()))
                    {
                        initialState = transitionTokens[2];
                        wordBuilder += transitionTokens[1];
                        if (wordBuilder.Equals(word) && transitionTokens[2].Equals(finalState))
                        {
                            return true;
                        }
                        break;
                    }
                }
            }
            return false;
        }
    }
}