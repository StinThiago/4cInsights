#ASSIGNMENT

##Required feature:

- Provide 2 http endpoints (that accept JSON containing base64 encoded binary data on both endpoints.
)
	- <host>/v1/diff/<ID>/left 	-> DONE
	- <host>/v1/diff/<ID>/right	-> DONE
	- third endpoint (<host>/v1/diff/<ID>) -> DONE
		
- The provided data needs to be diff-ed and the results shall be available on a third endpoint.
- The results shall provide the following info in JSON format:
	- If "equal" return that -> DONE
	- If "not of equal size just" return that -> DONE
	- If of same size provide insight in where the diff are, actual diffs are not needed.
		- So mainly offsets + length in the data -> DONE

- Make assumptions in the implementation explicit, choices are good but need to be communicated

##Required technology:

- C# - DONE
- functionality shall be under integration test -> DONE (Only the HealthCheck)
- internal logic shall be under unit test -> DONE
	- Unit test
		- Xunit
			- http://www.centare.com/asp-net-core-1-0-unit-testing/
			- https://wildermuth.com/2016/05/13/Getting-Ready-for-ASP-NET-Core-RC2
			- https://xunit.github.io/docs/getting-started-dotnet-core.html
			
			- [FACT] - Facts are tests which are always true. They test invariant conditions.
			- [THEORY] - Theories are tests which are only true for a particular set of data.
			
- documentation in code
	- All methods has summary description to generate auto documentation.
- short readme on usage
	- Write the description.

#APPLICATION 

##RESUME
	This application was built using the Asp.net Core with Visual Studio Code under MAC OS X environment.
	Follow bellow some datas e instructions to procede with the usage.

##ARCHITECTURE

- Controller
	- Layer responsible to receive and ask business the result of.
- Busines
	- Layer resposible to process all methods to calculate the diferences between those strings (right and left)
- Model
	- Layer resposible to provide the model entity to store the data and be an data transfer objects if needed.
- Tests 
	- In this folder  have unit tests developed to cover the features and the result expected.
- TestsIntegration
	- in this folder have the tests developed to cover the integrated test by inicializing the webserver and request the endpoints.
- 
#TESTING APPLICATION

- (Mac OS X  - instructions)
	- Git clone this address
		- https://github.com/StinThiago/4cInsights.git
	- Open the terminal
	- Seek for the folder where the project was downloded from git
	- Garantee that NPM was intalled and Asp.net Core either, bellow have the microsoft instructions
	
	- After those instructions proceed in the same folder this commands.
		- dotnet restore
		- dotnet build
		- dotnet test
		- dotnet run 

## TESTING THE ENDPOINTS 

- LEFT VALUE
	- curl -X POST -H "Content-Type: application/json" -H "Cache-Control: no-cache" -H "Postman-Token: ffaa6c29-1f34-f03d-c3c0-3febb4b5785a" -d '{"value":"Zm9yIHN1cmUgWW91IFdJTEw="}' "http://localhost:5000/v1/diff/1/left"

- RIGHT VALUE
	- curl -X POST -H "Content-Type: application/json" -H "Cache-Control: no-cache" -H "Postman-Token: cdea9937-edef-1827-9e21-2601ac53f668" -d '{"value":"Zm9yIHN1cmUgWW91IFdJTEw="}' "http://localhost:5000/v1/diff/1/right"

- GET VALUE (of specfic ID)
	- curl -X GET -H "Cache-Control: no-cache" -H "Postman-Token: a01c355d-bdfe-5a01-813b-bb6e45fdbfef" "http://localhost:5000/v1/diff/1"




###############################------------###############################
#Microsoft documentation
###############################------------###############################

# Welcome to ASP.NET Core

We've made some big updates in this release, so it’s **important** that you spend a few minutes to learn what’s new.

You've created a new ASP.NET Core project. [Learn what's new](https://go.microsoft.com/fwlink/?LinkId=518016)

## This application consists of:

*   Sample pages using ASP.NET Core MVC
*   [Bower](https://go.microsoft.com/fwlink/?LinkId=518004) for managing client-side libraries
*   Theming using [Bootstrap](https://go.microsoft.com/fwlink/?LinkID=398939)

## How to

*   [Add a Controller and View](https://go.microsoft.com/fwlink/?LinkID=398600)
*   [Add an appsetting in config and access it in app.](https://go.microsoft.com/fwlink/?LinkID=699562)
*   [Manage User Secrets using Secret Manager.](https://go.microsoft.com/fwlink/?LinkId=699315)
*   [Use logging to log a message.](https://go.microsoft.com/fwlink/?LinkId=699316)
*   [Add packages using NuGet.](https://go.microsoft.com/fwlink/?LinkId=699317)
*   [Add client packages using Bower.](https://go.microsoft.com/fwlink/?LinkId=699318)
*   [Target development, staging or production environment.](https://go.microsoft.com/fwlink/?LinkId=699319)

## Overview

*   [Conceptual overview of what is ASP.NET Core](https://go.microsoft.com/fwlink/?LinkId=518008)
*   [Fundamentals of ASP.NET Core such as Startup and middleware.](https://go.microsoft.com/fwlink/?LinkId=699320)
*   [Working with Data](https://go.microsoft.com/fwlink/?LinkId=398602)
*   [Security](https://go.microsoft.com/fwlink/?LinkId=398603)
*   [Client side development](https://go.microsoft.com/fwlink/?LinkID=699321)
*   [Develop on different platforms](https://go.microsoft.com/fwlink/?LinkID=699322)
*   [Read more on the documentation site](https://go.microsoft.com/fwlink/?LinkID=699323)

## Run & Deploy

*   [Run your app](https://go.microsoft.com/fwlink/?LinkID=517851)
*   [Run tools such as EF migrations and more](https://go.microsoft.com/fwlink/?LinkID=517853)
*   [Publish to Microsoft Azure Web Apps](https://go.microsoft.com/fwlink/?LinkID=398609)

We would love to hear your [feedback](https://go.microsoft.com/fwlink/?LinkId=518015)
