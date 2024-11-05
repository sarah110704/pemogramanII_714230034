using System;

namespace DailyTaskManagement
{
    // Kelas Abstrak Task
    public abstract class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; private set; }

        // Constructor
        public Task(string title, string description, DateTime dueDate, string priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            IsCompleted = false;
        }

        // Metode Abstrak
        public abstract void DisplayTaskDetails();

        // Menandai tugas sebagai selesai
        public void MarkAsCompleted()
        {
            IsCompleted = true;
            Console.WriteLine($"{Title} telah selesai!");
        }
    }
}