README

-------------------------------------------------------------------------------------------------------------
About: Sample assessment for King Price interview process
-------------------------------------------------------------------------------------------------------------

Implementation details:

1. Clean architecture used for separation of concerns
2. Repository pattern used to provide abstraction of underlying details of the data storage and details thereof
3. Mediatr pattern used to reduce dependencies between objects
4. Builder pattern to build up complex object of smaller pieces
5. Added OpenAPI documentation and a Swagger UI to easily visualize and describe REST endpoints available
6. Added AutoMapper to reduce dependency on DB models for the presentation layer
7. Enabled EF data migrations for ease of DB maintainability (especially since this is code-first)
8. Use host environment details to pull in relevant config file (appsetting)
9. Did not build fully fledged UI (time constraints), use Swagger UI on project run to perform REST API calls
   
What can still be added?

1. Proper logging framework
2. Global exception handler
3. Integrate with test Db to make sure migrations will not break the application
4. Could add more logic to maintain groups and permissions instead of relying on a static list (add controllers etc for those types)
5. More test cases scenarios (only added the basic scenarios)
6. Optimized DB calls and setup
7. Better exception handling
8. Automated UI tests (Selenium)
9. Depending on the use-case, make user input/output requirements more user-friendly
10. Add controller tests to test exceptions
11. Add foreighn keys to get rid of 'exists' checks (additional DB queries)
12. Can add more repositories if needed
13. Additional validations for duplicate user checks
14. Pre-commit hooks for git to prevent sensitive config from being comitted

-------------------------------------------------------------------------------------------------------------
To create DB migration: 
-------------------------------------------------------------------------------------------------------------
1. Set host environment (ASPNETCORE_ENVIRONMENT) for startup project to applicable environment (local/dev)

2. Update connection string in config file

Example for Local:

In appsettings.local.json (School\Config\appsettings.local.json)

Replace "ConnectionStrings.SqlServer" to the connection string of a DB used for local development / testing.


3. Create migration 

- Ensure to build the project first which will make sure microsoft.entityframeworkcore.tools gets installed to run the migration command

- Set startup project to School

- In the Package Manager console, make sure the Default project is School.Domain

- Set the ASPNETCORE_ENVIRONMENT environment variable to match to the relevant config file that contains your connections string , i.e $env:ASPNETCORE_ENVIRONMENT='local' (can be run in PM)

- In the Package Manager Console run: Add-Migration [good-formatted-migration-name]

-------------------------------------------------------------------------------------------------------------
To run DB migration: 
-------------------------------------------------------------------------------------------------------------

1. Set host environment (ASPNETCORE_ENVIRONMENT) for startup project to applicable environment (local/dev)

2. Update connection string in config file

Example Local:

In appsettings.local.json (School\Config\appsettings.local.json)

Replace "ConnectionStrings.SqlServer" to the connection string of a DB used for local development / testing.

3. Run migration 

- Ensure to build the project first which will make sure microsoft.entityframeworkcore.tools gets installed to run the migration command

- Set startup project to School

- In the Package Manager console, make sure the Default project is School.Domain

- Set the ASPNETCORE_ENVIRONMENT environment variable to match to the relevant config file that contains your connections string , i.e $env:ASPNETCORE_ENVIRONMENT='local' (can be run in PM)

- In the Package Manager Console run: Update-Database

-------------------------------------------------------------------------------------------------------------
