using System;

namespace DailyTaskManagement
{
    // Kelas WorkTask yang mewarisi dari Task
    public class WorkTask : Task
    {
        public DateTime MeetingTime { get; set; }

        public WorkTask(string title, string description, DateTime dueDate, string priority, DateTime meetingTime)
            : base(title, description, dueDate, priority)
        {
            MeetingTime = meetingTime;
        }

        // Implementasi metode untuk menampilkan detail tugas
        public override void DisplayTaskDetails()
        {
            Console.WriteLine($"[Work Task] {Title}\nDeskripsi: {Description}\nDue: {DueDate}\nPriority: {Priority}\nMeeting Time: {MeetingTime}\nSelesai: {IsCompleted}\n");
        }
    }
}