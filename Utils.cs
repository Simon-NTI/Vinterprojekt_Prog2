class Utils
{
    public static int GetIntFromUser(int largestPossibleInt)
    {
        while (true)
        {  
            string? input = Console.ReadLine();
            if(int.TryParse(input, out int result))
            {
                if(result > largestPossibleInt)
                {
                    Console.WriteLine($"Input must not be larger than {largestPossibleInt}");
                    continue;
                }
                else if(result < 1)
                {
                    Console.WriteLine("Input must not be larger than 0");
                    continue;
                }
                return result;
            }
            else
            {
                Console.WriteLine("Answer must be a whole number, try again");
            }
        }
    }

    public static string GetStringFromUser(bool allowSpaces)
    {
        while(true)
        {
            string? input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input must not be empty");
                continue;
            }

            if(input.Contains(' ') && !allowSpaces)
            {
                Console.WriteLine("Input must not contain spaces");
                continue;
            }
            return input; 
        }
    }
}