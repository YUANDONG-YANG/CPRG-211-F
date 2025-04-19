# Employee Management System

## Overview
A comprehensive Employee Management System built with C#, Blazor, and PostgreSQL. This application allows organizations to efficiently manage their employees, departments, and wage structures through a responsive web interface.

## Features
- **Employee Management**: Add, edit, delete, and manage employee records including employment status
- **Department Management**: Create, update, and delete organizational departments
- **Wage Grade Management**: Define and manage different salary grades with base wages and bonus percentages
- **Reporting**: Generate employee wage reports with statistics and visualized charts
- **Data Validation**: Input validation for email formats, phone numbers, and other critical data
- **User-Friendly Interface**: Intuitive navigation with responsive design

## Technologies Used
- C# programming language
- Blazor framework for frontend
- PostgreSQL database
- Dapper ORM for database operations
- Bootstrap for UI components

## Project Structure
- **Models**: Contains data models such as Employee, Department, Wage, and Person
- **Services**: Database access classes for each entity type
- **Pages**: Blazor components for UI presentation
- **SQL Scripts**: Database initialization and sample data

## Setup Instructions

### Prerequisites
- .NET 8.0 SDK or newer
- PostgreSQL 13 or newer
- Visual Studio 2022 or other compatible IDE

### Database Setup
1. Create a PostgreSQL database named `employee_management`
2. Execute the `ini_data.sql` script to create tables and insert sample data

### Application Setup
1. Clone the repository
2. Open the solution in Visual Studio
3. Update the connection string in `BaseDbAccessor.cs` if needed
4. Build and run the application

## Usage Guide
- **Dashboard**: Access system overview and quick links to main features
- **Employees**: View, add, edit, and manage employee records
- **Departments**: Manage organizational departments
- **Wages**: Define and manage wage grades
- **Reports**: View employee wage statistics and charts

## Screenshots
(Screenshots would be included here)

## Future Improvements
- User authentication and role-based access control
- Advanced reporting features with export options
- Employee attendance tracking
- Performance evaluation integration
- Mobile application support

## Author
YUANDONG YANG (Student ID: 000949205)

## License
This project is licensed for educational purposes only.

---

© 2025 YUANDONG YANG(000949205). All Rights Reserved.