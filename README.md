# Book Store

### Description
Sample Project (Rest API) yang mencakup ketentuan:
1. Menggunakan .NET Core
2. Terdapat Create, Read, Update, dan Delete Data (CRUD)
3. Terdapat 1 relasi antara Buku dan Author, dimana pada table Books terdapat AuthorId sebagai relasi
4. Terdapat validasi pada saat Create dan Update data, dimana user diharuskan menginputkan data pada field AuthorId, Title, Categories, dan Publisher

## How to Run at Local

Clone the Project on the folder
```bash
  git clone -b master https://github.com/Aizarrahima/Bookstore_BE.git
```

Open the project on Microsoft Visual Studio
```bash
  Open Project Bookstore
```

Open Package Manager Console (PMC) to run the migration: (run this script)
```bash
  update-database
```

Open Swagger to test the project
```bash
  Ctrl + F5
```

<br>

## Views

  ### Bookstore API
  <img width="1678" src="https://github.com/user-attachments/assets/aac2b344-a44f-4e18-b564-694b750131a5">
