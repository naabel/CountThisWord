//Write a program in the C# programming language that reads in a file containing a list of words.
//The program should take a word as input and output the number of times that word appears in the file.

namespace CountThisWordLibrary
{
    public static class CountThisWordLibrary
    {
        public static int CountWordAppearances(string word, string[] wordList, bool caseSensitive = false)
        {
            int count = 0;
            if (!caseSensitive )
            {
                word = word.ToLower();
            }
            for (int i = 0; i < wordList.Length; i++)
            {
                string current = wordList[i];
                if (string.IsNullOrEmpty(current))
                {
                    continue;
                }
                current = current.Trim();
                if (string.IsNullOrEmpty(current))
                {
                    continue;
                }
                if (word.Equals(caseSensitive ? current : current.ToLower()))
                {
                    count++;
                }
            }
            return count;
        }
    }
}