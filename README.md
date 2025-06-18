# 🛠️ San3a | Freelance Handcraft Services Platform

San3a is a web platform developed using **ASP.NET Core** that connects **freelancers in handcraft fields** with **customers** in a secure and user-friendly environment.

---

## 📌 Project Overview

This project aims to empower skilled workers by allowing them to showcase their services online and helping customers easily access those services.

The platform allows customers to browse services, place orders, and interact with freelancers through reviews and messaging.

---

## 🎯 Key Features

- User registration with three roles: Customer, Freelancer, and Admin.
- Customers can choose to register as a **Freelancer** during the sign-up process.
- Clean, responsive front-end built with Bootstrap and HTML/CSS.
- Full freelancer service management:
  - Add, edit, pause, or delete services.
- Customers can:
  - Browse and order services.
  - Pay via **Cash** or **Credit Card**.
  - Rate and comment on services.
  - Report inappropriate content.
- Freelancer profile page showcasing services and personal information.
- Admin dashboard to manage users, services, and complaints.

---

## 🛠️ Technologies Used

| Layer       | Tools & Technologies            |
|-------------|----------------------------------|
| Back-End    | ASP.NET Core MVC, C#             |
| Front-End   | HTML, CSS, Bootstrap             |
| Database    | SQL Server                       |
| Development | Visual Studio 2022               |

---

## 📁 Project Structure
San3a-Project/
├── Controllers/ # Handles user requests and business logic
├── Models/ # Entity models for database
├── ViewModels/ # Data models for passing info between views/controllers
├── Views/ # Razor views (UI pages)
├── Migrations/ # EF Core migrations
├── wwwroot/ # Static files (CSS, JS, images)
├── Data/ # DbContext and data configuration
├── Repositories/ # Interfaces and repository classes
├── appsettings.json # Project configuration file
├── Program.cs # App entry point
├── Startup.cs # Middleware and service configuration
└── README.md # Project documentation
---

## 🚀 Getting Started

1. Open the project in Visual Studio 2022.
2. Ensure SQL Server is running and update your connection string in `appsettings.json`.
3. Build and run the project using IIS Express or Kestrel.
4. Use EF Core Migrations to set up the database or generate it manually.
5. Register as a user (Customer or Freelancer) and start using the platform.

---

## 📌 Notes

- The front-end design was initially prepared by team members and customized to fit the backend functionality.
- This project was developed as a **graduation project** by **Fouad Alkhateb** as part of the Software Engineering program at **Hashemite University**, Jordan.

---

## 📧 Contact

- GitHub: [@Fouad-2](https://github.com/Fouad-2)
- Email: *fouadkhatib2@gmail.com*
