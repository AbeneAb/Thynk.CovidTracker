# Thynk.CovidTracker
**Thynk Challenge**


I have used Clean Architecture for this POC, and here is how it is organized.
This project is organized in such a way that there is loose coupling between layers and embraces dependency inversion principle. At the core of the application is **TestManagment.Domain** where entities,interfaces, domain exceptions and seeds are defined. The domain is independent of any feature laden tool or framework, which makes it ideal for long term use. On top of this layer is the **TestManagement.Application** layer where we have our CQRS implementation,Fluent validation and Publisher for our events and messages.Next in line of dependency id **TestManagement.Infrastructure** layer where frameworks and tools are used. This project uses Entity framework core as our ORM & SQL database for storage.

**A little about the Domain Entities Design**

*We have **TestCenter** where we define differnt test centers along with address as owned entity. So I have assumed that *TestCenter* Entity is an aggregate root. Under Test center we have different **Bookings** along with the user Name,Age,gender has it own **SpecimenInformation** where there are going to be  **Results** participating in an **Events.** So for each event we are going to have **Markets** and **Participant Detail**. Each Market will have offers called **Selection**, where we are going to have our Odds. To elaborate furthur Let's take **Euro** 2020 as an example. A game between **Spain and Denmark** is an event.We will have **Markets** like <ins>Match Winner, Goals Under 2.5</ins> and so on. The values for markets will be contained by our **selection** which may be <ins>Spain</ins> <ins>Draw</ins> or <ins>Denmark</ins> for our <ins>Match winner</ins> market. The selection will hold the odds along with index and other fields like label. So we have API controllers defined for various business points. But the main scope of the project, as I understand it is around **Selection Entity**.*

---

## Project Structure

The project is orgainized with microservice architecture in mind, hence I have 
#### Service
* Implemented **DDD, CQRS, and Clean Architecture** with Best Practices.
* Developed **CQRS with using MediatR, FluentValidation  packages**
* **SQL database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to DB on application startup.
* Created a react SPA application
#### Docker Compose  with all dependencies on docker;
* Containerization of API & DB
* Containerization of databases
* Override Environment variables
#### Test Client Webapp
* Implemented SPA with create react app that uses functional components

## Running The Project
We will need the following tools:

* [Visual Studio 2019 or later](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 6 or later](https://dotnet.microsoft.com/download/dotnet-core/6)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

Follow these steps to get your development environment set up: (Before Running Start the Docker Desktop)
1. Clone the repository
. At the root directory which include **docker-compose.yml** files, run below command:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```



## Improvements that I would have done had I had more time
* Time didn't allow me to work on event driven architecture, when ever there is a change in booking, we will have a pub/syb model to be notified of the process.
* Background chron job to deallocate expired booking.
* Non-relatiional DB[mongo] for booking, so that it can handle large set of data. We will have to use a microservice architecture.
* Add distributed cache[Redis] to decrease db overhead and improve response times.
* Work on Idempotency for some Commands


Thank you.


