class Utils
{
    public static int GetIntFromUser()
    {
        while (true)
        {  
            string? input = Console.ReadLine();
            if(int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Answer must be a whole number, try again");
            }
        }
    }
}