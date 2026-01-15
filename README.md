Asset Management System

A full-stack Asset Management System built using ASP.NET Core Web API and plain HTML, CSS, and JavaScript.
The system allows organizations to manage assets, employees, assignments, and asset history with a clean and simple architecture.

🚀 Features
🔐 Authentication

Basic login system (Username & Password)

Role-based access:

Admin

Employee

🧑‍💼 Admin Features

Add and manage assets

Add and manage employees

Assign and unassign assets

Approve or reject asset requests

View complete asset assignment history

Dashboard with clean UI

👨‍💻 Employee Features

Login and access employee dashboard

View assets assigned to them

Request new assets

Simple and clean user interface

🛠 Tech Stack
Backend

Language: C#

Framework: ASP.NET Core Web API

ORM: Entity Framework Core

Database: SQL Server / Azure SQL

API Documentation: Swagger

Frontend

HTML

CSS

JavaScript (Fetch API)

Tools

Visual Studio

Git & GitHub

🧱 Architecture

The project follows a clean and simple layered architecture:

Controller → Service → Data (DbContext)


Controllers handle HTTP requests

Business logic is separated

Entity Framework Core manages database operations

🗄 Database Design

Main tables used:

Users

Employees

Assets

AssetAssignments

AssetRequests

AssetHistory

The database is seeded with sample data for easy demo and testing.

🔑 Sample Login Credentials
Admin
Username: admin
Password: admin123

Employee
Username: amit
Password: amit123

(Additional employees are available in seeded data.)

▶️ How to Run the Project
Backend

Open the solution in Visual Studio

Update the database:

dotnet ef database update


Run the project

Swagger will open at:

https://localhost:{port}/swagger

Frontend

Open the frontend folder

Open login.html in a browser

Login using the credentials above

☁️ Cloud Deployment (Overview)

This API can be deployed to:

Azure App Service

Azure SQL Database

Environment-based configuration is handled using appsettings.json.

📌 Key Highlights

Clean and readable code

Proper HTTP status codes

Exception handling

Role-based UI flow

Real-world use case

Interview-ready project


👨‍💻 Author

Tushar Bhosale
Aspiring Full Stack Developer
Focused on building clean and practical applications.

📄 License

This project is created for learning and demonstration purposes.
