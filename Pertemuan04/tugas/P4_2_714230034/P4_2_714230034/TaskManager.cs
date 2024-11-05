using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskManagement
{
    // Kelas untuk mengelola tugas
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        // Menambahkan tugas ke dalam daftar
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        // Menampilkan semua tugas
        public void DisplayAllTasks()
        {
            Console.WriteLine("Daftar Tugas Harian:");
            foreach (var task in tasks)
            {
                task.DisplayTaskDetails();
            }
        }

        // Menampilkan tugas berdasarkan prioritas
        public void DisplayTasksByPriority(string priority)
        {
            var filteredTasks = tasks.Where(t => t.Priority == priority && !t.IsCompleted);
            Console.WriteLine($"\nTugas dengan Prioritas {priority}:");
            foreach (var task in filteredTasks)
            {
                task.DisplayTaskDetails();
            }
        }

        // Menampilkan tugas yang belum selesai
        public void DisplayIncompleteTasks()
        {
            Console.WriteLine("\nTugas yang Belum Selesai:");
            foreach (var task in tasks.Where(t => !t.IsCompleted))
            {
                task.DisplayTaskDetails();
            }
        }
    }
}