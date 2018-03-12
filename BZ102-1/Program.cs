using System;

namespace BZ102_1
{
    static class Program
    {
        static void Main()
        {
            ReadInt("Vize", out var vize);
            ReadInt("Final", out var final);

            var ort = vize * 0.4 + final * 0.6;
            Console.WriteLine($"Vize: {vize}, Final: {final}, ort: {ort:F} {(ort > 50 && final > 50? "GECTI" : "KALDI")}");
            Console.ReadKey();
        }

        static void ReadInt(string name, out int result)
        {
            result = 0;
            Console.Write($"{name} gir: ");
            string s = Console.ReadLine();
            if (!int.TryParse(s, out result))
            {
                Console.WriteLine($"\"{name}\" hatali giris!!");
                ReadInt(name, out result);
            }
        }
    }
}
