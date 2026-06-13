# FullStackGameManager
FullStackGameManager is a full-stack CRUD project with a Minimal API architecture for managing a database of video games.
Backend is coded in C# containing a SQLite database with a frontend integration in Angular.

## Used technologies and frameworks

### Backend (.NET 10)
**Entity Framework Core (EF Core)**
Used for SQLite management, handling DbContext migrations and communicating with the database.

**Minimal API**
Lightweight modern API framework used for more readable, minimalistic and clean code.


**Swagger UI**

### Frontend
**Angular**
Frontend created in Angular for modern responsive and interactive user interface with bootstrap.


**Bootstrap 5**

## API Preview

### Data seeding (FirstGame)
The first game record is seeded directly into the database from the application code.

<img src="https://github.com/Simon0824/FullStackGameManager/blob/5701a2acfc5742e2e75532447a0e0a0903c64b4d/Assets/Screenshots/Scr1.png" width="1200" height="1000">

### POST Endpoint
Form with input fields that allow adding a game to the database.

<img src="https://github.com/Simon0824/FullStackGameManager/blob/5701a2acfc5742e2e75532447a0e0a0903c64b4d/Assets/Screenshots/Scr2.png" width="1200" height="1000">

### PUT Endpoint
Form with input fields used to update data for a selected game.

<img src="https://github.com/Simon0824/FullStackGameManager/blob/5701a2acfc5742e2e75532447a0e0a0903c64b4d/Assets/Screenshots/Scr3.png" width="1200" height="1000">

### Dark Mode
Switch used to enable dark mode.

<img src="https://github.com/Simon0824/FullStackGameManager/blob/5701a2acfc5742e2e75532447a0e0a0903c64b4d/Assets/Screenshots/Scr4.png" width="1200" height="1000">

## Features
- Add, update and delete games from SQLite database
- Full CRUD operations via Angular frontend
- Data seeding with an initial game record on startup
- Dark mode toggle
- Swagger UI for API testing

## How to run

1. Clone the repository
```bash
   git clone https://github.com/Simon0824/FullStackGameManager
```

2. Run the backend:
```bash
   dotnet run
```

3. Run the frontend:
```bash
   cd FullStackGameManager
   ng serve
```

4. Open the app:
```
   http://localhost:4200
```
