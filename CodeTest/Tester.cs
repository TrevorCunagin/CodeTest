using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CodeTest
{
    public static class Tester
    {
        /// <summary>
        /// Function that take a string and returns true if the string is a palindrome
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>bool</returns>
        public static bool IsPalindrome(string input)
        {
            //To find whether two strings are palindromes, words that are the same forwards and backwards, 
            //you should reverse it and see if it stays the same.

            //I like solutions with as few lines as possible, so I have two methods that each use the SequenceEqual function, which, as the name suggests,
            //checks if two sequences are equal to each other.
            //The main difference between these two approaches is the first uses a built-in .NET reverse function while the other uses a VisualBasic funtion.
            //Reverse() converts the string into an IEnumerable<char> of the reverse order of the characters in the string. 'hello' would be converted into
            //{'o', 'l', 'l', 'e', 'h'}. Meanwhile, Strings.StrReverse directly converts the string into a reversed string. SequenceEqual can read both
            //equally well, but StrReverse would be more useful if you ever need a reversed string to be returned.
            return input.SequenceEqual(input.Reverse());
            //return input.SequenceEqual(Strings.StrReverse(input));
        }

        /// <summary>
        /// Function that takes a string and returns the count of each character in the string
        /// </summary>
        /// <param name="inpput">input string</param>
        /// <returns>Dictionary with each character from the string as the key and the count of each character as the value</returns>
        public static Dictionary<char, int> CharacterCount(string inpput)
        {
            //create a blank dictionary output with a char key and int value
            Dictionary<char, int> output = new Dictionary<char, int>();
            
            //iterate over each char in the inpput string
            foreach (char c in inpput)
            {
                //if we find a certain char is already in the dictionary, we increment its count
                if (output.ContainsKey(c))
                {
                    output[c]++;
                }
            //otherwise, we initialize its count at 1
            else
            {
                output[c] = 1;
            }
        }
            //finally, we return the resulting dictionary
            return output;
        }


        /// <summary>
        /// Function that accepts two arrays of integers and returns an array of integers that are in both arrays.
        /// </summary>
        /// <param name="input1">an array of integers</param>
        /// <param name="input2">an array of integers</param>
        /// <returns>an array of integers</returns>
        public static int[] GetMatches(int[] input1, int[] input2)
        {
            //I wanted to try a C# specific way to accomplish this one. Intersect() is another built-in function that returns the intersection of two sequences.
            //In other words, it would return any shared values between two sequences. This method is both visually clean and far more effecient than, say,
            //brute forcing the problem with nested for loops. It should be as efficient as using HashSets to solve the problem since Intersect() uses HashSet.  
            int[] output = input1.Intersect(input2).ToArray();            

            return output;
        }


        /// <summary>
        /// Function that accepts two arrays of integers and returns an array of integers that are not in both arrays.
        /// </summary>
        /// <param name="input1">an array of integers</param>
        /// <param name="input2">an array of integers</param>
        /// <returns>an array of integers</returns>
        public static int[] GetDiff(int[] input1, int[] input2)
        {
            //This method uses another C# function to accomplish this easily. Except() returns any values that are in the first sequence but not in the second sequence.
            //Because it does not do the reverse, we concatenate the result of another use of Except() with the inputs reversed to get all of the values that are
            //not in both input arrays.
            int[] output = input1.Except(input2).Concat(input2.Except(input1)).ToArray();

            return output;
        }
    }
}
