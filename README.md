# User Management

This has been as much of an assessment as a learning exercise for me. I tried to focus on the backend more than the front end. This lacks validation on the front end, but I do not think I want to put any more time into Fluent UI or rewriting the UI.

## Installation

* Install and run SQL Server instance (I used 2022). Make sure to change the connection strings in UserApi.MVC
/appsettings.json. 

* Then open an instance of UserApi.MVC and UserManagement.UI and you are good to go.

* To run migrations go to Package Manager Console, set the Default Project to UserManagement.Data and Startup Project to UserApi.MVC and type **Update-Database** in the Package Manager Console

## Usage

* Run an instance of the UserApi.MVC for the backend API
* Run an instance of UserManagement.UI

You should be able to use the Application freely now.

## License

[MIT](https://choosealicense.com/licenses/mit/)
