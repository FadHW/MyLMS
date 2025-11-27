# MyLMS - Library Management System
A simple console-based Library Management System built using C#.  
The project manages books, readers, members, and employees with CRUD operations.
## Features
- Add, update, delete books
- Manage readers and members
- Track issued books
- Separate Entities, Repositories, Services, and Interfaces
- Clean folder structure using OOP + SOLID basics
## Folder Structure
  MyLMS/  
│  
├── Program.cs  
│  
├── Entities/  
│   ├── Book.cs  
│   ├── Employee.cs  
│   ├── Reader.cs  
│   └── Member.cs  
│  
├── Interfaces/  
│   ├── IEmployeeService.cs  
│   ├── IBookService.cs  
│   ├── IReaderService.cs  
│   └── ILibraryManagement.cs  
│  
├── Repositories/  
│   ├── EmployeeRepository.cs  
│   ├── BookRepository.cs  
│   └── ReaderRepository.cs  
│  
└── Services/  
    └── LibraryServices.cs  
  
## How to Run

1. Make sure .NET SDK is installed (version 7.0+).
2. Clone the repository:
   ```bash
   git clone https://github.com/FadHW/MyLMS.git
## Technologies Used
- C#
- .NET
- OOP principles
