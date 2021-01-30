# “Like” Button Feature Api Project

The “Like” button serves two primary use cases:
- When a user visits an article, a like button is rendered and displays the total number of likes
- When a user clicks the like button, the count increments by one.

This project is server-side(back-end) of application. 
To see about the client-side(front-end) go to: https://github.com/fabiobelther/LikeFeatureProject.git


## Overview

This project is a .Net Core 3.1 implementation of Clean Arch with Domain Driven Design concepts.

The Clean Architecture provides a metodology to be used in coding, in order to facilitate code development, allowing a better maintenance, updates and less dependencies.
An important goal of Clean Architecture is to provide to developers a way to organize code encapsulating business logic, but keeps it separate from the delivery mechanism.  

## Project Structure

- LikeFeatureProject.Api							- Solution 
  - LikeFeatureProject.Api.Host						- Interface Adapters (Where are the Controllers )
  - LikeFeatureProject.Api.Domain					- Enterprise Business Rules (Where are the Entities, Constraints and Interfaces)
  - LikeFeatureProject.Api.Service					- Application Business Rules
  - LikeFeatureProject.Api.Repository				- Data Business Rules
  - LikeFeatureProject.Api.Service.Test				- Unit Test for Application Businesse Rules
  - LikeFeatureProject.Api.Service.IntegrationTest	- Integration Tests
  
## DataBase Strucuture

- Table Article (not implemented)
	id - primary Key - int
	
- Table Like
	id - primary Key - int
	articleId - foreign Key(Table Article) - int
	count - int

## Getting Started

To clone this project you need to install [Git](https://git-scm.com).
To run this project you need to download [Visual Studio Code](https://code.visualstudio.com) or [Visual Studio 2019](https://visualstudio.microsoft.com/) and have instaled [.net core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core) in your operating system.

### Cloning

Go to path and run the command on GitBash terminal

```powershell
git clone https://github.com/fabiobelther/LikeFeatureProject.Api.git
```

### Running

Go to root of application and run the commands on GitBash terminal

```powershell
dotnet build;
```

```powershell
cd LikeFeatureProject.API.Host; 
```

```powershell
dotnet run;
```

The main page should open automatically. If not, go to:
[Swagger - LikeFeatureProject.Api](https://localhost:5001)


## Running the tests

in the root of apllication run the command:

```powershell
dotnet test
```

## Improvements

- How can you improve the feature to make it more resilient against abuse/exploitation
- How can you improve the feature to make it scale to millions of users and perform without issues?
- A million concurrent users clicking the button at the same time
- A million concurrent users requesting the article's like count at the same time


## Built With

* [.Net Core Framework](https://dotnet.microsoft.com/download/dotnet-core) - Free, cross-platform, open-source framework;
* [xUnit](https://xunit.net) - Tests
* [Clean Arch](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) - Clean Architeture concepts

## Contributings

## Authors

* **Fabio Belther** - *Initial work* - [FabioBelther](https://github.com/fabiobelther/)

See also the list of [contributors](https://github.com/fabiobelther/LikeFeatureProject.Api/contributors) who participated in this project.

