## Job Candidate API

## Description

This web application provides an API for storing and managing information about job candidates. The application is developed using .NET Web API and follows the repository pattern to ensure clean and maintainable code. The API supports CRUD (Create, Read, Update, Delete) operations for candidate information.

## Features

- **Create Candidate**: Add a new candidate to the system.
- **Read Candidate**: Retrieve candidate information by email.
- **Update Candidate**: Update existing candidate information.
- **Delete Candidate**: Remove a candidate from the system.
- **Repository Pattern**: Ensures clean code architecture and separation of concerns.

## Functional Requirements

The API endpoint allows adding or updating candidate information. The candidate's email serves as the unique identifier. If a candidate profile already exists in the system, it is updated; otherwise, a new profile is created. The endpoint expects the following information for each candidate:

- **First Name** (required)
- **Last Name** (required)
- **Phone Number**
- **Email** (required, unique)
- **Preferred Call Time** (time interval for preferred call)
- **LinkedIn Profile URL**
- **GitHub Profile URL**
- **Comment** (required, free text)

## Technology Stack

- **.NET 6**: Framework for building the API.
- **Entity Framework Core**: ORM for database operations.
- **SQL Server**: Database for storing candidate information.
- **AutoMapper**: Library for object-object mapping.
- **Repository Pattern**: Ensures separation of data access logic and business logic.
