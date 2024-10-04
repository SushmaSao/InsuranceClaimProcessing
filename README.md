# EClaimInsuranceProcessing
EClaimInsuranceProcessing is a microservice-based insurance claim processing system. It follows the principles of Clean Architecture and CQRS (Command Query Responsibility Segregation) to ensure a maintainable, scalable, and modular architecture. The project is implemented using .NET Core with PostgreSQL as the database.

## **Key Features**
* Microservices architecture for scalability.
* Clean Architecture to ensure separation of concerns.
* Implements CQRS for better command and query segregation.
* CustomerService API handles customer-related data and requests.
* Role-based authentication and authorization for different users.
* Uses Entity Framework Core for database management.
* AutoMapper for object-to-object mapping.

## **Project Structure**
The solution consists of several components following the Clean Architecture pattern:

* API Layer: - The main entry point for the service, handles HTTP requests and routes them to appropriate handlers.
* Application Layer: Handles business logic, use cases, and interaction with the core.
* Core Layer: Contains the domain entities, value objects, and interfaces.
* Infrastructure Layer: Handles data persistence, integrates with external services, and provides implementation for interfaces defined in the core.

# **Modules**
* Customer Portal
     * Customer can create a login using their policy details
     * Customer should be able to change the correspondence address
     * Customer should be able to submit claims.
       
 # **Technologies Used**
* **.NET Core 8** for developing microservices.
* **Entity Framework Core** for data access.
* **PostgreSQL** as the relational database.
* **CQRS Pattern** for segregating read and write operations.
* **AutoMapper** for mapping between objects.
* **Docker**

# Getting Started
  **Prerequisites**
    * .NET Core 8 SDK
    * Docker / WSL
    * PostgreSQL
    
## Running Locally
* **Clone the repository:** git clone https://github.com/SushmaSao/InsuranceClaimProcessing.git
* **Navigate to the project directory:** cd EClaimInsuranceProcessing
* **Build and run Docker containers:** docker-compose up
*** Access the API:**
    * Open http://localhost:5001 in your browser for IdentityService 
        * Can perform sign up and login, grab token and used in below service access.
           ![image](https://github.com/user-attachments/assets/bcdf72e0-76ec-4909-a9d4-2e55a04fecec)
          
    * Open http://localhost:5002 in your browser for CustomerService  -
        * Can perform customer related actions like Get info and post info, add bearer token using authorize button, and add above token "Bearer{token}"
           ![image](https://github.com/user-attachments/assets/6584127f-ed98-4687-968f-94ecc4a1c525)

    * Open http://localhost:5003 in your browser for ClaimService -
        * can perform claim submission, add bearer token using authorize button, and add above token "Bearer{token}"
            ![image](https://github.com/user-attachments/assets/5e446934-18c4-4643-ada1-a5e29771c4a1)


