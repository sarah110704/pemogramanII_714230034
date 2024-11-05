using System;

namespace DailyTaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Pilihan Menu:");
                Console.WriteLine("1. Tambah Tugas");
                Console.WriteLine("2. Tampilkan Semua Tugas");
                Console.WriteLine("3. Tampilkan Tugas yang Belum Selesai");
                Console.WriteLine("4. Keluar");
                Console.Write("Pilih opsi (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(manager);
                        break;
                    case "2":
                        manager.DisplayAllTasks();
                        break;
                    case "3":
                        manager.DisplayIncompleteTasks();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                }
            }
        }

        static void AddTask(TaskManager manager)
        {
            Console.Write("Masukkan judul tugas: ");
            string title = Console.ReadLine();
            Console.Write("Masukkan deskripsi tugas: ");
            string description = Console.ReadLine();
            Console.Write("Masukkan tanggal jatuh tempo (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Masukkan prioritas (High/Medium/Low): ");
            string priority = Console.ReadLine();

            Console.Write("Apakah ini tugas kerja? (y/n): ");
            char taskType = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (taskType == 'y' || taskType == 'Y')
            {
                Console.Write("Masukkan waktu rapat (yyyy-mm-dd hh:mm): ");
                DateTime meetingTime = DateTime.Parse(Console.ReadLine());
                manager.AddTask(new WorkTask(title, description, dueDate, priority, meetingTime));
            }
            else
            {
                Console.Write("Masukkan lokasi: ");
                string location = Console.ReadLine();
                manager.AddTask(new PersonalTask(title, description, dueDate, priority, location));
            }

            Console.WriteLine("Tugas berhasil ditambahkan!");
        }
    }
}