# TestAlas App

TestAlas is an application designed to provide users with an ability to translate words/sentences from any language to English. 

The app is contained of 2 parts: 

1) Frontend part designed in Angular framework 
2) Backend part (.NET Core WebApi, Sql server)

## Installation of the Frontend part

1. Run the `npm install` to install all the dependecies required to run the project.

2. Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Installation of the Backend part
Open the solution using Visual Studio and run the server. Restore all the nuget packages that are required to build to project. The backend server is running on port 5000.

### Please note! 

#### You will need to have instance of Sql server running on local machine. In order to generate database needed, please run: `Update-Database` in order to create tables. You might need to modify the ConnectionString which is stored in appsettings.json depending on the machine used.




## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
