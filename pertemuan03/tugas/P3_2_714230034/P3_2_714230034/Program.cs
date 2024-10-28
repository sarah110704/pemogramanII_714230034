using System;

namespace P3_2_714230034
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ulangi = true;

            while (ulangi)
            {
                Console.Clear();
                Console.WriteLine("Menu Pilihan:");
                Console.WriteLine("1. Hitung Luas Persegi Panjang");
                Console.WriteLine("2. Hitung Keliling Persegi Panjang");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu (1/2/3): ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        Console.Write("Masukkan panjang: ");
                        double panjang = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Masukkan lebar: ");
                        double lebar = Convert.ToDouble(Console.ReadLine());

                        double luas = panjang * lebar;
                        Console.WriteLine($"Luas persegi panjang: {luas}");
                        break;

                    case "2":
                        Console.Write("Masukkan panjang: ");
                        panjang = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Masukkan lebar: ");
                        lebar = Convert.ToDouble(Console.ReadLine());

                        double keliling = 2 * (panjang + lebar);
                        Console.WriteLine($"Keliling persegi panjang: {keliling}");
                        break;

                    case "3":
                        ulangi = false;
                        Console.WriteLine("Program berhenti.");
                        break;

                    default:
                        Console.WriteLine("Menu tidak valid. Silakan pilih 1, 2, atau 3.");
                        break;
                }

                if (ulangi)
                {
                    Console.Write("\nKetik 'Y' untuk kembali ke menu atau 'T' untuk keluar: ");
                    string kembali = Console.ReadLine().ToUpper();

                    if (kembali == "T")
                    {
                        ulangi = false;
                        Console.WriteLine("Program berhenti.");
                    }
                }
            }
        }
    }
}