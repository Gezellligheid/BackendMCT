# Backend development MCT

## Working with CSV files

    dotnet add package CsvHelper

[Docs](httpsL//joshclose.github.io/CsvHelper/)

## AutoMapper

    dotnet add package AutoMapper
    dotnet add package AutoMapper.Extensions.Microsoft.DependecyInjection

### Steps

1. Create DTO object of model you want an alternative of
2. Add the following line to Startup.cs in `ConfigureServices`,

    `services.AddAutoMapper(typeof(Startup))`

3. Add Class `AutoMapping` that extends `Profile`
4. in the constructor add the following:

    `CreateMap<ClassFrom, DTOModel>`

5. add `IMapper` as an argument in the controllers constructor where you want to use the automapping


## Validation

### Example

    public class Car {

      public int Id {get; set;}

      [Required]
      public string name {get; set}

    }

[Docs](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-5.0#validation-attributes)


## QueryStrings

### Example

    [HttpGet]
    [Route("apples")]
    public static async Task<ActionResult> getX(string type, string color) {}

Type and Color will be a querystring `https://base/apples?type=...&color=...`


## Url parameters

### Example

    [HttpGet]
    [Route("apples/{id}")]
    public static async Task<ActionResult> getX(string id) {}

id will be an url parameter. Don't forget to add it to the route between `{}`


## Versioning

    dotnet add package Microsoft.AspNetCore.Mvc.Versioning

### Configuring

placed in `ConfigureServices()`

    services.AddVersionedApiExplorer(c => {
        c.GroupNameFormat = "'v'VVV";
        c.SubstituteApiVersionInUrl = true;
    });

    services.AddApiVersioning(config => {
        config.DefaultApiVersion = new ApiVersion(1,0);
        config.AssumeDefaultVersionWhenUnspecified = true;
        config.ReportApiVersions = true;

        // If the apiversion is specified in the header
        config.ApiVersionReader = new HeaderApiVersionReader("api-version");
    });

Add to controller with version they use:

    [ApiController]
    [ApiVersion("1.0", Depricated=true)]
    [ApiVersion("2.0")]

Add endpoint to version

    [HttpGet]
    [MapToApiVersion("2.0")]


## Cahching

in `ConfigureServices()`

    services.AddResponseChachin();

in `Configure();`

    app.UseResponseCaching();

above an endpoint

    [HttpGet]
    [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Any)]


## Entity Framework **!! Follow carefully !!**

1. Import packages

    ```
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```

2. Create your models

3. Create `ConnectionStrings` Class
    ```CSharp
    public class ConnectionStrings
    {
        public string SQL { get; set; }
    }
    ```

4. initialize ConnectionStrings</br>
In `Startup.cs` add the following line in the `ConfigureServices()`</br>
    ```
    services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
    ```

    and make sure you have your connectionString in `application.json` or `application.Docker.json` or `application.Development.json`

    </br>
    Example: Add this under "logging"

    ```JSON
    "ConnectionStrings": {
      "SQL": ""
    }
    ```

5. Create the context</br> extend with `DbContext`
    ```CSharp
    public class Context : DbContext {

      // Add for every model your DbSet
      public DbSet<ModelName> models {get; set;}

      // Your ConnectionString
      private ConnectionStrings _connectionStrings

      // Constructor
      public Context(DbContextOptions<Context> FileOptions, IOptions<ConnectionStrings> connectionStrings) {

        _connectionStrings = connectionStrings;

      }

      public override void OnConfiguring(DbContextOptionsBuilder options) {



      }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {

        //Creating of models at first initialize of database

      }

    }

6. Add to Startup.cs in `ConfigureServices()`
    ```CSharp
    services.AddDbContext<Context>();
    ```

7. install dotnet ef

    ```
    dotnet tool install --global dotnet-ef
    ```

8. Time to migrate</br>
When all your models have a DbSet in the Context. It's then time to put all changes in the database.

    ```
    dotnet ef migrate "migration name"
    dotnet ef database update
    ```

    **These commands must be ran if a model changes, database is reset or models are added or removed.**
