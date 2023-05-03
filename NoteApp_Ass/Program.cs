namespace NoteApp_Ass
{
    class Note
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; private set; }

        private static int nextId = 1;
        public Note(string title, string description)
        {
            Id = nextId++;
            Title = title;
            Description = description;
            Date = DateTime.Now;
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Id,-5}{Title,-20}{Description,-30}{Date.ToString("dd-MMM-yyyy"),-12}";
        }
    }

    class TakeNoteApp
    {
        public List<Note> notes = new List<Note>();

        public void Run()
        {
            LoadNotes();

            while (true)
            {
                Console.WriteLine("Welcome To Take Note App");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Note");
                Console.WriteLine("2. View Note");
                Console.WriteLine("3. View All Notes");
                Console.WriteLine("4. Update Note");
                Console.WriteLine("5. Delete Note");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateNote();
                        break;
                    case "2":
                        ViewNote();
                        break;
                    case "3":
                        ViewAllNotes();
                        break;
                    case "4":
                        UpdateNote();
                        break;
                    case "5":
                        DeleteNote();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice Entered");
                        break;
                }

                Console.WriteLine();
            }
        }

        public void LoadNotes()
        {
            notes.Add(new Note("Meeting", "Meeting with Client @ 9 AM"));
            notes.Add(new Note("Pay Bills", "Pay Electricity Bills"));
        }

        public void CreateNote()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Note note = new Note(title, description);
            notes.Add(note);

            Console.WriteLine($"Note created with id {note.Id}");
        }

        public void ViewNote()
        {
            Console.Write("Enter Note Id: ");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                Note note = notes.Find(n => n.Id == id);

                if (note != null)
                {
                    Console.WriteLine(note.ToString());
                }
                else
                {
                    Console.WriteLine("Note not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }

        public void ViewAllNotes()
        {
            Console.WriteLine("id     title              description                        date");
            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Note note in notes)
            {
                Console.WriteLine(note.ToString());
            }

            Console.WriteLine($"Total Notes: {notes.Count}");
        }

        public void UpdateNote()
        {
            Console.Write("Enter Note Id: ");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                Note note = notes.Find(n => n.Id == id);
             
                if (note != null)
                {
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter Description: ");
                    string description = Console.ReadLine();

                    note.Update(title, description);
                    Console.WriteLine($"Note with id {id} has been updated");


                }
                else
                {
                    Console.WriteLine($"Note with id {id} updated");
                }
            }
            else
            {
                Console.WriteLine("Note not found");
            }
        }


        public void DeleteNote()
        {
            Console.Write("Enter Note Id: ");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                Note note = notes.Find(n => n.Id == id);

                if (note != null)
                {
                    notes.Remove(note);
                    Console.WriteLine($"Note with id {id} deleted");
                }
                else
                {
                    Console.WriteLine("Note not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TakeNoteApp app = new TakeNoteApp();
            app.Run();
        }
    }
}
       