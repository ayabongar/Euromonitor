Euromonitor Book Subscription System
A full-stack application for managing users, books, and subscriptions. The project features a RESTful API backend with ASP.NET Core and a frontend interface built with Angular, allowing users to register, view available books, and manage their book subscriptions. Additionally, the application provides an API endpoint for third-party resellers to access the book catalog.
Features
•	User Management: Add, retrieve, and manage users.
•	Book Catalog: Add, retrieve, and manage book entries.
•	Subscriptions: Users can subscribe and unsubscribe to books in the catalog.
•	API Access for Third-Parties: Provides HTTP API endpoints to enable external services to interact with the system.
Technology Stack
•	Backend: ASP.NET Core Web API (C#)
•	Frontend: Angular
•	Database: Microsoft SQL Server
•	Swagger: API documentation and testing
•	Stored Procedures: All database interactions are handled via stored procedures for optimized database operations
Project Structure
•	Api/ - Contains the ASP.NET Core Web API backend project
•	WebUI/ - Angular frontend application
•	DATABASE/ - SQL files for creating the database and stored procedures
•	README.md - Documentation for the project
Getting Started
Prerequisites
•	.NET 6 SDK or later
•	Node.js and npm
•	Microsoft SQL Server
•	Angular CLI
•	Git
Installation and Setup
1.	Clone the Repository:
bash
Copy code
git clone https://github.com/ayabongar/Euromonitor.git
cd Euromonitor
2.	Database Setup:
o	Open Microsoft SQL Server Management Studio and execute the SQL files located in the DATABASE/ folder to create the required database (Euromonitor) and stored procedures.
3.	Backend Setup:
o	Navigate to the Api/EuromonitorApi directory:
bash
Copy code
cd Api/EuromonitorApi
o	Update the appsettings.json file with your SQL Server connection string:
json
Copy code
"ConnectionStrings": {
    "EuromonitorConnection": "Server=YOUR_SERVER_NAME;Database=Euromonitor;Integrated Security=True;"
}
o	Run the backend server:
bash
Copy code
dotnet run --project EuromonitorApi.csproj
o	The API should be available at https://localhost:5001 (or the default port if configured differently).
4.	Frontend Setup:
o	Navigate to the WebUI/ directory:
bash
Copy code
cd WebUI
o	Install dependencies:
bash
Copy code
npm install
o	Run the Angular application:
bash
Copy code
ng serve
o	The frontend should be accessible at http://localhost:4200.
API Documentation
Swagger is enabled in the backend for API testing and documentation. Once the backend is running, navigate to https://localhost:5001/swagger to view and interact with the available API endpoints.
Key Functionalities
1. Users
•	Add User: Register a new user.
•	View All Users: Retrieve a list of all registered users.
2. Books
•	Add Book: Create a new book entry.
•	View All Books: Retrieve a list of all available books in the catalog.
3. Subscriptions
•	Subscribe/Unsubscribe: Allows users to manage their subscriptions to available books.
•	View Subscriptions: Retrieve a list of books a user is subscribed to by entering their user ID.
4. Third-Party Access
•	The API allows third-party resellers to retrieve books and manage subscriptions through a secured HTTP API.
Notes
•	CORS: If accessing the backend from http://localhost:4200 causes CORS issues, ensure the Startup.cs file has been configured to allow requests from that origin.
•	Stored Procedures: The backend uses stored procedures for all database interactions, located in DATABASE/StoredProcedures.sql.

