namespace MyLMS.Entities;

public class Members
        {
            public string Name { get; set; }
            public int Id { get; }
            public string Email { get; set; }
            public Members(int id, string name, string email)
            {
                Id = id;
                Name = name;
                Email = email;
            }
        }
