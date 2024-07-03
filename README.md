# Clean Architecture Template 

This is a sample WEBAPI project using clean architecture, .NET 8, and the latest libraries as of July 3, 2024

![Clean Architecture!](/assets/images/clean-architecture.png 'Clean Architecture')



## Frameworks - Libraries - Pattern

1. Entity Framework core 
2. Mapster
3. Fluent Validation
4. MediaR (CQRS)
5. GenericRepository
6. UnitOfWork 
7. ExceptionHandler
8. Pagination


## run with VSCode
cd to the ```clean-architecture-template``` folder run command below
```
dotnet run --project .\src\CleanArchitectureTemplate.API\
```
## run with VisualStudio
open file ```clean-architecture-template.sln``` and run

## EF migration
1. install global tool to make migration(do only 1 time & your machine is good to go for the next)
```
dotnet tool install --global dotnet-ef
```
2. create migrations & the dbcontext snapshot will rendered.
   Open CLI at folder & run command
   -s is startup project(create dbcontext instance at design time)
   -p is migrations assembly project
```
dotnet ef migrations add NewMigration -s .\src\CleanArchitectureTemplate.API\ -p .\src\CleanArchitectureTemplate.Infrastructure\ 
```

3. apply the change
```
dotnet ef database update -s .\src\CleanArchitectureTemplate.API\ -p .\src\CleanArchitectureTemplate.Infrastructure\
```


## License

[MIT]