# To-Do List API

## Overview

This project implements a simple RESTful API for managing a to-do list, built using ASP.NET Core. 
The API supports basic CRUD operations (Create, Read, Update, Delete) and includes additional features like marking items as completed, 
filtering by due date or completion status, and sorting by due date. Input validation also implemented.

## Design Choices

### 1. Framework
   - The API is built using ASP.NET Core Web API, leveraging its capabilities for easy routing, model binding, and JSON serialization.
   - ASP.NET Core provides a lightweight and scalable framework ideal for building RESTful APIs.

### 2. Data Storage
   - In-memory storage is used for simplicity and to avoid the need for database setup. In a production environment, a more persistent data store (e.g., SQL database, NoSQL) would be preferred.

### 3. Architecture
   - The application follows a service-oriented approach with the business logic encapsulated in a separate `TodoService` class that implements the `ITodoService` interface. This makes the application easily extendable and testable.
   - Controllers are kept lightweight, primarily focusing on handling HTTP requests and responses, while delegating logic to the service layer.

### 4. Unique ID Generation
   - To-do items are assigned a unique identifier (`Guid`) upon creation to ensure each item has a globally unique reference.

### 5. Input Validation
   - Data annotations (like `[Required]`) are used to ensure that the `Title` field is always provided in the request payload. This ensures that the API receives valid input and returns appropriate error responses when invalid data is submitted.

### 6. Filtering and Sorting
   - The `FilterByStatusAndDate` method allows users to filter to-do items by their completion status and due date. Sorting by due date is optional, allowing flexibility in how data is presented to the client.
   - This feature showcases how filtering logic can be applied on the server side to reduce the burden on clients and improve performance for large data sets.

### 7. Marking as Completed
   - To-do items can be marked as completed via a PATCH request to `api/todo/{id}/complete`. This feature separates business actions (like marking completed) from general updates, making the API easier to understand and use.

### 8. Error Handling
   - The API includes proper error handling, returning appropriate HTTP status codes such as `404 Not Found` for missing resources and `400 Bad Request` for invalid inputs.


