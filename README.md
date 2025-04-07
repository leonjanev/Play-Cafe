# Project Setup and Start Guide

This guide provides step-by-step instructions for setting up and starting the project, including the backend, frontend, and database.

---

## Prerequisites

Ensure the following are installed on your system:

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (LTS version recommended)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
  ```bash
  dotnet tool install --global dotnet-ef
  ```
- A package manager like `npm` or `yarn`.

---

## Project Setup

### 1. Clone the Repository

```bash
git clone <repository-url>
cd <repository-folder>
```

### 2. Configure the Database

1. Open the `appsettings.json` file in the backend project.
2. Update the `ConnectionStrings` section with your SQL Server details:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=<YourServer>;Database=<YourDatabase>;User Id=<YourUsername>;Password=<YourPassword>;TrustServerCertificate=True;"
   }
   ```
3. Apply Migrations to the Database:
   ```bash
   cd backend
   cd playcafe
   dotnet ef database update
   ```

### 3. Install Dependencies

#### Backend

Navigate to the backend project directory and install dependencies:

```bash
cd backend
 dotnet restore
```

#### Frontend

Navigate to the frontend project directory and install dependencies:

```bash
cd frontend
npm install
# or
yarn install
```

---

## Starting the Application

### 1. Start the Backend

Run the following command from the backend directory to start the API server:

```bash
cd backend
cd playcafe
dotnet run
```

The backend will be running on `https://localhost:5001` or `http://localhost:5000`.

### 2. Start the Frontend

Run the following commands from the frontend directory:

```bash
cd frontend
npm start
# or
yarn start
```

The frontend will be available at `http://localhost:3000`.

---

## Additional Notes

### Environment Variables

- Use the `.env` file to manage environment-specific configurations for both the backend and frontend.
- Example `.env` for the backend:
  ```env
  ASPNETCORE_ENVIRONMENT=Development
  ```

### Testing the Setup

1. Open your browser and navigate to `http://localhost:3000` for the frontend.
2. Use a tool like [Postman](https://www.postman.com/) or [Swagger UI](https://swagger.io/tools/swagger-ui/) to test backend API endpoints at `https://localhost:5001`.

### Troubleshooting

- If the database doesn't connect, verify your connection string and SQL Server status.
- For Node.js issues, ensure the correct version is installed using `node -v`.

---

## Contribution

Feel free to fork the repository and submit pull requests for improvements.

---

## License

This project is licensed under the [MIT License](LICENSE).

