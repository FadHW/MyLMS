namespace MyLMS.Entities;

public class Book
        {
            private static int _id = 0;
            public int Id { get; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string BookHealth { get; set; }
            public string Category { get; set; }
            public bool AvailableBook { get; set; }
            public DateTime? BorrowedDate { get; set; }
            public int AllowedDays { get; set; } = 14;

            public void Borrowed() { 
                AvailableBook = false;
                BorrowedDate = DateTime.Now;
            }
            public void Available() {
                AvailableBook = true;
                BorrowedDate = null;
            }
         
            public Book (string title, string auth, string cat, string health)
            {
              Title = title; Author = auth; Category = cat;
                BookHealth = health;
                Id = ++_id;
                AvailableBook = true;
            }

        }
