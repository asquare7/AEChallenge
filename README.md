<h1 align="center">Welcome to AEDemo</h1>
<p>
</p>

Purpose
-------
The goal of this challenge is to build a solution comprised of REST APIs that finds the closest port to a given ship and calculates the estimated arrival time based on velocity and geolocation (longitude and latitude) of given ship.

Pre-Requisits
-------------
1. Visual Studio 2022
2. SQL Server 2016+

## Application Architecture

<code>Our application is built upon a robust architectural foundation, incorporating the Mediator pattern, CQRS pattern, and Repository pattern. This architecture promotes a clean and scalable design, enabling efficient separation of concerns and improved maintainability.</code>

## Mediator Pattern

<code>The Mediator pattern is utilized to facilitate communication between components of our application. It acts as a central hub for coordinating interactions between various modules, reducing direct dependencies and promoting loose coupling. By employing the Mediator pattern, we achieve better modularity, extensibility, and testability within our codebase.</code>


## CQRS Pattern

<code>We have adopted the CQRS (Command Query Responsibility Segregation) pattern to separate the responsibility for handling commands (write operations) from queries (read operations). This pattern allows us to optimize and scale our application based on the specific needs of each operation. By segregating the read and write sides, we can design dedicated components that efficiently handle data retrieval and data modification independently.</code>

## Repository Pattern

<code>The Repository pattern is employed to provide a standardized and consistent way of accessing and manipulating data in our application. This pattern abstracts the data access layer, providing a clean interface for querying and persisting data without exposing the underlying data storage mechanisms. The Repository pattern promotes code reuse, simplifies unit testing, and enhances maintainability by encapsulating data access logic within dedicated repository classes.</code>

<code>By combining these architectural patterns, our application benefits from improved modularity, separation of concerns, scalability, and testability. The Mediator pattern enables flexible communication, while the CQRS pattern allows us to optimize read and write operations independently. Finally, the Repository pattern provides a clear and consistent data access layer.</code>



Usage
-------------
1. Set SQL Server instance name in 'appsettings.json' against 'DefaultConnection' key.
2. Executing the 'Update-Database' command in Package Manager Console will initiate the creation of a fresh database, including the necessary tables. Additionally, this command will populate the database with dummy data related to ports.

## Author

👤 **Ali Avais**
