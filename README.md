TO RUN THE PROJECT
-----------------
-----------------
1. Clone the repository.
2. Open the repository with visual studio for easy setup.
3. By the buttom-right-hand corner of your visual studio, change the branch to "theo".
4. Next, double-click on the solution called "SalesPortalAPIProject.sln".
5. Click the drop-down button of the solution to display all the solution's contents, you will see a file called "appSettings.json"
6. Open the "appSettings.json" file and change the database connection string to  your desired Database 
   (Please note that the project is configured to work with sqlServer database). 
7. Go to the Package manager console, and run the command "update-database". This command will automatically update your desired database with all the necessary tables and pre-seeded data.
8. At the top of the visual studio screen , click on the first green play button to run the project.


TO AUTOMATICALLY GET DockerFile
-------------------------------
-------------------------------
1. Right-click on the project "ipNXSalesPortalApis".
2. Click on "Add Docker Support".
3. Select "Dockerfile"  as container build type and "Windows" as the target OS.
4. A Docker file will be automatically generated for you. You can further right click on the generated docker file to build an image.
6. you can type "Docker --version" to be sure you have docker engine(docker desktop) installed.
7. To see all available docker images, you can type "Docker images".
8. "Docker ps" to see a list of all running containers
9  "Docker stop 1d64822851e2" to stop the running container. where "1d64822851e2" is the container Id.
10. To push the image to docker hub: "docker push unekwu001/salesportalimage:ipnxsalesportalapis" where unekwu001/salesportalimage is
the username/repoName and ipnxsalesportalapis 
is the local image name.


TO Deploy To API Project to Azure App Service
----------------------------------------------
----------------------------------------------
1. Go to connected services within vs, create a db using vs. 
2. Get the connectionString of the created db , also ensure you note your pwd and username.
3. within appsettings.json, replace connstring with the newly created azure db connString.
4. Ensure the db network allows your machine on firewall rules (configure on azure).

5. Next , right click on your api in vs and follow the prompt to publish to Azure appService(windows).
6. When every thing is done, click on publish. your api should be ready for use.

7. To use Swagger ensure you remove "Isindevelopment" braces from program.cs  @ app.UseSwaggerUi.

8.If you encounter swagbuckle error,  Right click on the Api project, open it in file explorer, go to the .config file, right click on dotnet-tools, click on properties,
and finally you may see an "Unblock" button. Click on it and then click "Apply" or "OK" to unblock the file.
(do this step 8 only if you encounter "installing swashbuckle.aspnetcore.cli tool failed" error.)

9. Click publish , and visit your api page with the "/swagger" suffix.



TO VIEW API LOGIC 
-----------------
-----------------
1. Click on the dropdown of "ipNXSalesPortalApis" project.
2. You will see "Controllers" folder. Open up the folder and navigate to your desired controller.


Core Installations
--------------------
--------------------
1. EntityFramworkCore
2. EntityFrameworkCore tools
3. EntityFrameWorkCore useSqlServer
4. AutoMapper. 

Note that these dependencies are already installed.


Error Logging 
----------------------
Step 1:
 add package Serilog.AspNetCore
 add package Serilog.Settings.Configuration
 add package Serilog.Sinks.Console
 add package Serilog.Sinks.Seq
 add package Serilog.Sinks.File

 Step 2:
 Include the below in your app.Development.json
 "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.Seq" ,"Serilog.Sinks.File"],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "Seq",
        "Args": { "serverUrl": "http://localhost:5341" }
      },
      {
        "Name": "File",
        "Args": {"path": "Logs/log.txt"}
      }
    ],
    "Enrich": [ "FromLogContext" ]
  }

  Step 3:
  Configure Serilog as Default log, and then further configure it to push to console seq and file.
  (ensure to download seq locally and make sure its server is running from ;https://datalust.co/download).
  In the programSetup folder, add this:
   public static class LoggingSetup
    {
        public static void ConfigureLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq(builder.Configuration["Serilog:WriteTo:1:Args:serverUrl"])
                .WriteTo.File("Logs/log.txt")
                .CreateLogger();
            builder.Host.UseSerilog();
        }
     }
  }
     then call this in program.cs.
     builder.ConfigureLogging();

Step 4 :
Visit \Log\read to view application error logs.