namespace FinalSurgeTests.Utils
{
    public static class GeneratorUtil
    {
        private static readonly Random random = new Random();
        public static string RandomEmail(int length = 8)
        {            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            string email = $"{new string(result)}@gmail.com";
            return email;
        }

        public static string RandomName(int length = 4)
        {            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            string name = new string(result);
            return name;
        }

        public static string RandomText(int length = 8)
        {            
            const string bigChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string smallChars = "abcdefghijklmnopqrstuvwxyz";
            char[] end = new char[length];
            for (int i = 0; i < length; i++)
            {
                end[i] = smallChars[random.Next(smallChars.Length)];
            }
            char begin = bigChars[random.Next(bigChars.Length)];
            string result = begin + new string(end);
            return result;
        }

        public static string RandomPass(int length = 8)
        {            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            string pass = $"1!A{new string(result)}";
            return pass;
        }    
        
        public static int RandomNumber()
        {
            int randomIndex = random.Next(0, 3);
            return randomIndex;
        }

        public static int RandomDistance(int min = 1, int max = 50)
        {            
            return random.Next(min, max + 1);
        }
    }
}
