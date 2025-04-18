# Employee Management System

## 📋 Overview
A comprehensive desktop application built with .NET MAUI and PostgreSQL for streamlined employee information management. This system provides an integrated solution for HR departments and administrators to manage organizational structure, personnel records, and compensation details.

## 🔍 Project Description
The Employee Management System is a robust, feature-rich application designed to digitize and centralize employee data management. Leveraging the cross-platform capabilities of .NET MAUI and the power of PostgreSQL, this system offers a seamless experience for managing departments, employee records, wage structures, and generating insightful reports.

## 💡 Problem Solved
This system addresses several key challenges faced in traditional employee management:

- Replaces error-prone spreadsheets and paper records with a structured database system
- Eliminates data redundancy and inconsistencies through relational database management
- Streamlines workflows for HR personnel and administrators
- Provides secure, centralized access to critical organizational data
- Enables data-driven decision making through comprehensive reporting

## 🎯 Purpose & Objectives
- **Educational Goal**: Demonstrate proficiency in object-oriented programming concepts including inheritance, encapsulation, polymorphism, and abstraction
- **Technical Implementation**: Apply database design principles, exception handling, and security best practices
- **User Experience**: Create an intuitive, responsive interface using MAUI's cross-platform GUI components
- **Business Value**: Provide a solution that improves operational efficiency in human resource management

## 🧩 Core Features

### 🏢 Department Management
- Create, view, update, and delete organizational departments
- Visualize department structures and hierarchies
- Track department-specific metrics and employee distribution

### 💰 Wage Grade Management
- Define and maintain wage structures with customizable parameters
- Set base wages and bonus percentages for different position levels
- Ensure standardized compensation across similar roles

### 👥 Employee Management
- Comprehensive employee profile management with personal and professional details
- Assign employees to departments with appropriate wage grades
- Track employment history including hire dates and termination information
- Handle employee status changes (active, terminated, on leave)

### 📊 Reporting & Analytics
- Generate detailed employee wage reports with department breakdowns
- View salary distributions across departments and roles
- Export reports in various formats for external use

## 🛠️ Technical Specifications

### Technology Stack
- **Frontend Framework**: .NET MAUI (Multi-platform App UI)
- **Database**: PostgreSQL
- **ORM**: Dapper for efficient data access
- **Architecture**: MVVM (Model-View-ViewModel) pattern

### Data Structure
- Relational database design with normalized tables for Departments, Employees, and Wage Grades
- Foreign key constraints to maintain data integrity
- Indexed fields for optimized query performance

## 🚀 Getting Started

### Prerequisites
- .NET 7.0 or later
- PostgreSQL 14.0 or later
- Visual Studio 2022 or compatible IDE

### Installation
1. Clone the repository
2. Run the included PostgreSQL script to create the database schema and sample data
3. Update the connection string in `ManagerDbAccessor.cs` with your PostgreSQL credentials
4. Build and run the application

## 🔄 Future Enhancements
- Attendance tracking module
- Leave management system
- Performance evaluation tools
- Advanced reporting and analytics
- User role-based access control
- Mobile application support