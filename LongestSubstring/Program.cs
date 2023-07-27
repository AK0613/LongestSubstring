/* Given a string, find the length of the longest substring without repeating chars
 */

namespace LongestSubstring
{
    public class Program
    {
        static int CheckString_bf(string input)
        {
            // Initialize variables
            // Length does not need a -1 since the pointer runs only while it is a smaller number than length
            int length = input.Length;
            // p is the pointer that iterates through the strnig
            // total holds the length of the longest string with unique characters
            // curr_max holds the current max length of the substring
            int p = 0, total = 0, curr_max = 0;
            // Dictionary holds the value of each letter in the substring as key and its index as value
            var dict = new Dictionary<char, int>();
            // While pointer p is within the length of the string
            while (p < length)
            {                
                // If the dictionary does not contain the current character at index p
                if(!dict.ContainsKey(input[p]))
                {
                    // Add the character as key and the index as value
                    dict[input[p]] = p;
                    // Move p to the right
                    p += 1;
                    // the current max is the same size as the number of items in the dictionary
                    curr_max = dict.Count;
                }
                // If the character is in the dictionary
                else
                {
                    // Move the pointer to the right of the repeated character
                    p = dict[input[p]] + 1;
                    //Clear dictionary
                    dict.Clear();
                    //Add the first letter of the new substring and its index
                    dict.Add(input[p], p);
                    //Move p ahead
                    p += 1;
                }
                // The total is always the biggest number we get for curr_max
                total = Math.Max(total, curr_max);
            }

            // Print the longest string
            Console.Write("The longest string, not in a specific order, is: ");
            foreach (var item in dict)
                Console.Write(item.Key);

            Console.WriteLine();
            return total;
        }

        static int CheckString(string input)
        {
            // Initializing variables
            int total = 0, left = 0, right = 0, curr_max= 0;
            //Initialized length as such since the right pointer runs while it's less than length
            int length = input.Length;

            // Dictionary holds the value of each letter in the substring as key and its index as value
            var dict = new Dictionary<char, int>();
            //If the string has only one or less characters just return the current length
            if (length <= 1)
                return length;
            else
            {   
                //While the right pointer is less than the length of the string (-1 not needed)
                while(right < length)
                {
                    // If the dictionary does not contain the letter at index p or if the letter's index is less than the left pointer (outside of the current substring)
                    if(!dict.ContainsKey(input[right]) || dict[input[right]] < left)
                    {
                        // Add the key value pair
                        dict[input[right]] = right;
                        // Move right pointer 
                        right += 1;
                    }
                    // Otherwise move the left pointer forward based on the index of the last character found in the dictionary
                    else
                    {
                        left = dict[input[right]] + 1;
                    }

                    // The max length of the current string is the difference between right and left pointers
                    curr_max = right - left;
                    //Total is the Max between curr_max and the running total
                    total = Math.Max(total, curr_max);
                }
            }

            return total;
        }

        static void Main(string[] args)
        {
            string input = "abcbda";

            Console.WriteLine(CheckString_bf(input));

            Console.WriteLine(CheckString(input));

        } 
    }
}


/* other implementation 
public static int CheckString(string str)
        {
            int length = str.Length;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int left = 0, right = 0, total = 0;

            if (length <= 1)
            {
                return length;
            }
            else
            {
                while (right < length)
                {
                    if (!dict.ContainsKey(str[right]) || dict[str[right]] < left)
                    {
                        dict[str[right]] = right;
                        right++;
                    }
                    else
                    {
                        left = dict[str[right]] + 1;
                    }

                    int curr_max = right - left;
                    total = Math.Max(curr_max, total);
                }
                return total;
            }
        }

        public static void Main()
        {
            string input = "abcbd";
            int result = CheckString(input);
            Console.WriteLine("Longest substring length: " + result);
        } 


 */
