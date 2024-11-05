using System;

namespace DailyTaskManagement
{
    // Kelas PersonalTask yang mewarisi dari Task
    public class PersonalTask : Task
    {
        public string Location { get; set; }

        public PersonalTask(string title, string description, DateTime dueDate, string priority, string location)
            : base(title, description, dueDate, priority)
        {
            Location = location;
        }

        // Implementasi metode untuk menampilkan detail tugas
        public override void DisplayTaskDetails()
        {
            Console.WriteLine($"[Personal Task] {Title}\nDeskripsi: {Description}\nDue: {DueDate}\nPriority: {Priority}\nLocation: {Location}\nSelesai: {IsCompleted}\n");
        }
    }
}