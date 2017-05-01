// Not written by Ben or GameDev.tv, copied from web for speed
public static class StringExtension
{
    public static string Shuffle(this string str) // Note use of this
    {
        char[] array = str.ToCharArray();
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return new string(array);
    }
}