# Console CRUD Project with Repository Pattern

## Overview

This Console Application demonstrates the use of the Repository Pattern in a .NET Framework environment. It performs basic CRUD (Create, Read, Update, Delete) operations on `Course` records, using XML files as the data source. The project is divided into several components, each represented by a separate project within the solution.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete course records.
- **Repository Pattern**: Utilizes the Repository Pattern to manage data access.
- **XML Data Source**: Uses XML files for data persistence.
- **Console Interface**: Command-line interface for user interactions.

## Project Structure

The solution is organized into multiple projects, each responsible for different aspects of the application:

### 1. `Course_Project` (Console Application)

- **Description**: The main console application that interacts with users and performs CRUD operations through the repository.
- **Key Files**:
  - `Program.cs`: Entry point of the application, manages user input and invokes repository methods.
  - `App.config`: Configuration file for application settings.

### 2. `Repository_Domain` (Domain Layer)

- **Description**: Contains the domain model and entities.
- **Key Files**:
  - `Course.cs`: Represents the `Course` entity.
  - `IEntity.cs`: Defines a generic interface for domain entities.
  - `App.config`: Configuration settings relevant to this project.

### 3. `Repository_Pattern` (Repository Layer)

- **Description**: Implements the repository pattern and manages data access.
- **Key Files**:
  - `ICourseRepository.cs`: Interface defining repository methods for `Course` operations.
  - `CourseXMLRepository.cs`: Concrete implementation of `ICourseRepository` for XML data handling.
  - `RepositoryFactory.cs`: Factory class to create repository instances.
  - `ContextTypes.cs`: Defines context types for data sources.
  - `XMLRepositoryBase.cs`: Base class for XML-based repositories.

### 4. `Repository_Source` (Data Source Layer)

- **Description**: Handles data source operations, including XML file management.
- **Key Files**:
  - `XMLSet.cs`: Manages XML data set and operations related to XML data handling.
  - `App.config`: Configuration settings relevant to this project.

## Getting Started

### Prerequisites

- **.NET Framework**: Ensure .NET Framework 4.7.2 or later is installed.
- **IDE**: Visual Studio or another .NET-compatible IDE.

### Installation

1. **Clone the Repository**:
  
   git clone https://github.com/Sohail-IDB57/ConsoleCrudProject_With_Repository.git
 
2. **Open Solution**:
   - Open the solution file (`.sln`) in Visual Studio.

3. **Restore NuGet Packages**:
   - Use NuGet Package Manager to restore any required packages.

### Configuration

1. **Data File**:
   - Ensure `data.xml` is placed in the appropriate directory as specified in `App.config`.

2. **Application Settings**:
   - Verify and adjust settings in `App.config` files as necessary.

## Usage

1. **Run the Application**:
   - Build and run the `Course_Project` project in Visual Studio or using the command line:
    
     dotnet run --project Course_Project
     

2. **Interact with the Console**:
   - **Create**: Add new courses by entering course details.
   - **Read**: Retrieve course information by ID, name, type, or get all courses.
   - **Update**: Modify existing course details.
   - **Delete**: Remove courses by ID, type, or delete all courses.

3. **Example Commands**:
   - Press `1` to retrieve course information.
   - Press `2` to create a new course.
   - Press `3` to update a course.
   - Press `4` to remove a course.
   - Press `5` to exit the application.

## Code Structure

### `Course_Project`

- **`Program.cs`**: Handles user input and CRUD operations. 
  - **Example**:
    
    ICourseRepository source = RepositoryFactory.Create<ICourseRepository>(ContextTypes.XMLSource);
   

### `Repository_Domain`

- **`Course.cs`**: Defines the course entity with properties such as `CourseID`, `CourseName`, etc.

### `Repository_Pattern`

- **`ICourseRepository.cs`**: Interface for course repository operations.
- **`CourseXMLRepository.cs`**: Implements repository operations using XML data source.

### `Repository_Source`

- **`XMLSet.cs`**: Manages XML file operations and data serialization.

## Repository Pattern

The Repository Pattern is used to encapsulate data access logic, providing a clean separation between the application's business logic and data access code.

- **`ICourseRepository`**: Interface for course data operations.
- **`CourseXMLRepository`**: Concrete implementation for XML-based data storage.

## XML Data Handling

- **XML Structure**: Data is stored in `data.xml`. Ensure the XML schema aligns with the application's expectations.
- **Serialization/Deserialization**: Handled by `XMLSet.cs`.

## Contributing

1. **Fork the Repository**: Create a personal fork of the repository.
2. **Create a Feature Branch**:
   
   git checkout -b feature/YourFeature
  
3. **Commit Changes**:
   
   git commit -am 'Add new feature'
   
4. **Push to Branch**:
   
   git push origin feature/YourFeature
   
5. **Submit a Pull Request**: Open a pull request to merge changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For questions or issues, please contact [Sohail-IDB57](https://github.com/Sohail-IDB57) or open an issue in the repository.

