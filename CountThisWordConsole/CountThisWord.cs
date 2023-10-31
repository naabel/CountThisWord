namespace CountThisWordConsole
{
    public class CountThisWord
    {
        static void Main(string[] args)
        {
            string targetWord, filePath = string.Empty;
            
            try
            {
                targetWord = args[0];
                filePath = args[1];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            int count = 0;

            //Utilizing a StreamReader directly limits my ability to move string matching logic into a separate class or library, but means I don't have to read the file once into a string, then read it again to check the substrings
            StreamReader sr = new StreamReader(filePath);

            bool endOfStream = false;
            bool endOfWord = false;
            string current = string.Empty;

            // If I simple check sr.EndOfStream, I will exit the loop before I can count the last word, forcing me to duplicate the count logic.
            // Instead, I check EoS inside the loop and include the count even when EoS == true
            while (!endOfStream)
            {
                int currentRead = sr.Read();
                if (currentRead == -1)
                {
                    endOfStream = true;
                }
                else
                {
                    char currentChar = (char)currentRead;
                    if (!char.IsWhiteSpace(currentChar))
                    {
                        current += currentChar;
                    }
                    else
                    {
                        endOfWord = true;
                    }
                }

                if (endOfStream || endOfWord)
                {
                    if (current.Equals(targetWord))
                    {
                        count++;
                    }
                    endOfWord = false;
                    current = string.Empty;
                }
            }

            Console.WriteLine($"The number of times the word \"{targetWord}\" appeared in the input file is: {count}");
        }
    }
}
