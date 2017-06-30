using System;

namespace typoglycemia
{
    class Program
    {
        static string GenerateTypoglycemia(string text)
        {
            char[] seq = text.ToCharArray();
            int len = seq.Length;
            int word_start = 0;
            var rand = new Random();

            for (int i = 0; i < len; i++)
            {
                if (!Char.IsLetter(seq[i]))
                {
                    int shuffle_start = word_start + 1,
                        k = i - 2;
                    
                    while (k > shuffle_start)
                    {
                        var j = rand.Next(shuffle_start, k);
                        seq[k] ^= seq[j];
                        seq[j] ^= seq[k];
                        seq[k] ^= seq[j];
                        k--;
                    }

                    word_start = i + 1;
                }
            }

            return new String(seq);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a paragraph:\n");
            var text = Console.ReadLine();
            Console.WriteLine("\nResult:\n");
            Console.WriteLine(GenerateTypoglycemia(text));
            Console.ReadLine();
        }
    }
}
