Email Service Integration API

Overview

Email Service Integration API is a backend application developed using ASP.NET Core Web API. The project provides a centralized email service that supports sending Welcome Emails, OTP Verification Emails, Password Reset Emails, and Custom Notification Emails. All email activities are logged and stored in a SQL Server database for tracking and auditing purposes.

This project demonstrates email integration using Gmail SMTP and MailKit, database operations using Entity Framework Core, API documentation using Swagger, and SQL Server containerization using Docker.

⸻

Features

Email Functionality

* Send Custom Emails
* Send Welcome Emails
* Send OTP Verification Emails
* Send Password Reset Emails
* Dynamic HTML Email Templates
* OTP Generation
* Asynchronous Email Sending
* Email Logging and Tracking

Database Functionality

* Store Email Logs in SQL Server
* Retrieve All Email Logs
* Retrieve Email Log by ID
* Entity Framework Core Migrations

API Features

* RESTful API Architecture
* DTO-Based Request Models
* Dependency Injection
* Swagger API Documentation
* Clean Folder Structure

⸻

Technology Stack

* ASP.NET Core 8 Web API
* C#
* Entity Framework Core
* SQL Server
* Docker
* MailKit
* Gmail SMTP
* Swagger / OpenAPI

⸻

Project Structure

EmailServiceApi
├── Controllers
├── Services
├── Interfaces
├── Models
├── DTOs
├── Templates
├── Data
├── Migrations
├── Program.cs
├── appsettings.json
└── README.md

⸻

API Endpoints

Send Custom Email

POST /api/Email/send

Send Welcome Email

POST /api/Email/welcome

Send OTP Verification Email

POST /api/Email/send-otp

Send Password Reset Email

POST /api/Email/reset-password

Get All Email Logs

GET /api/Email/logs

Get Email Log By ID

GET /api/Email/{id}

⸻

Database Schema

EmailLogs

Field	Type
Id	int
ToEmail	string
Subject	string
Body	string
Status	string
SentAt	datetime

⸻

Email Templates

The application uses HTML-based email templates stored in the Templates folder.

Supported Templates

* Welcome.html
* Otp.html
* ResetPassword.html

Dynamic Placeholders

Placeholder	Description
{{NAME}}	User Name
{{OTP}}	Generated OTP
{{LINK}}	Password Reset Link

⸻

Setup Instructions

1. Clone Repository

git clone https://github.com/ayushsingh007dev/EmailServiceApi.git
cd EmailServiceApi

2. Restore Packages

dotnet restore

3. Configure SQL Server

Update the connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=EmailServiceDb;User Id=sa;Password=YourStrongPassword123!;TrustServerCertificate=True"
}

4. Configure Email Settings

Update SMTP settings:

"EmailSettings": {
  "SmtpServer": "smtp.gmail.com",
  "Port": 587,
  "SenderName": "Email Service API",
  "SenderEmail": "your-email@gmail.com",
  "Username": "your-email@gmail.com",
  "Password": "your-app-password"
}

5. Run Database Migrations

dotnet ef database update

6. Run Application

dotnet run

7. Open Swagger

http://localhost:5094/swagger

⸻

Docker SQL Server Setup

docker run -e 'ACCEPT_EULA=Y' \
-e 'MSSQL_SA_PASSWORD=YourStrongPassword123!' \
-p 1433:1433 \
--name sqlserver \
-d mcr.microsoft.com/mssql/server:2022-latest

⸻

Sample Features Demonstrated

* Welcome Email Delivery
* OTP Verification Email Delivery
* Password Reset Email Delivery
* Custom Notification Email Delivery
* Email Activity Logging
* Database Persistence
* API Documentation using Swagger

⸻

Screenshots

Include the following screenshots:

* Swagger Endpoints
* Custom Email Response
* Welcome Email
* OTP Email
* Password Reset Email
* Email Logs Response

⸻

Future Enhancements

* Background Email Queue
* Retry Mechanism
* Scheduled Emails
* JWT Authentication
* Serilog Logging
* Email Attachments

⸻

Author

Ayush Kumar Singh

B.Tech Computer Science & Engineering (2023–2027)

GitHub: https://github.com/ayushsingh007dev

⸻

Project Status

✅ Completed and Tested Successfully

* Email Sending Working
* SMTP Integration Working
* SQL Server Connected
* Email Logging Working
* Swagger Documentation Available
* GitHub Repository Published
