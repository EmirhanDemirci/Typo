using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Typo.Controllers
{
    public class LetterCheck
    {
        /* 
            Bovenaan heb ik even de variabelen gezet die gebruikt worden. 
            Deze zijn terug te vinden binnen de functies, even kijken hoe deze
            gekoppeld worden.
        */

        string userInput; // wat user typt;
        string diffLetters; // output verkeerde letters;
        string currentWord; // huidige random woord;

        private void CurrentWord()
        {
            string wordList = ""; // Moet nog even over overlegd worden.

            // var path = File.ReadAllLines(wordList);
            List<string> woordenLijst = File.ReadAllLines(wordList).ToList();

            Random rnd = new Random();
            int randomWord = rnd.Next(woordenLijst.Count);

            string wordUser = woordenLijst[randomWord];

            currentWord = wordUser;
        }

        private bool WordCheck(string user, string typo)
        {
            
            string diffLetters;

            List<char> userChar = new List<char>();
            List<char> typoChar = new List<char>();

            userChar.AddRange(user);
            typoChar.AddRange(typo);

            string addLetters = "";

            if (user == typo)
            {
                diffLetters = "Correct!";
                return true;
            }
            else
            {
                foreach (char c in typoChar)
                {
                    if (userChar.Contains(c) == false)
                    {
                        addLetters += c;
                        diffLetters = addLetters;

                        // diffLetters = addLetters;
                        return true;
                    }
                }
            }
            return false;
        }

        private void wordChecker()
        {
            try
            {
                if (userInput != "")
                {
                    WordCheck(userInput, currentWord);
                }
                else
                {
                    diffLetters = "Niks ingevuld";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("foutmelding: \n\n " + ex);
            }
        }


        private void ResetItems()
        {
            diffLetters = "";
            userInput = "";
            CurrentWord();
        }
    }
}

