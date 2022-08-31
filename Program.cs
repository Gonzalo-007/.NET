// 1. Using to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityApiBackend;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;
// 10. Use Serilog to log events
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 11. Config Serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
{
    loggerConf
        .WriteTo.Console()
        .WriteTo.Debug()
        .ReadFrom.Configuration(hostBuilderCtx.Configuration);
});




// 2. Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME); // busca en appsettings.json la cadena de texto que hay en "UniversityDB" dentro del objeto "ConnectionStrings"


//3. Add Context to Services of builder

/*A�adimos un servicio de AddDbContext, ahora tenemos que darle un tipo que va a ser 
 UniversityDBContext y despues le especificamos las opciones y dentro de las opciones 
 UseSqlServer(connectionString)
*/
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add Service  of JWT Authorization
builder.Services.AddJwtTokenServices(builder.Configuration);



// Add services to the container.
builder.Services.AddControllers();

// 4. Add Custom Services (folder Services)
builder.Services.AddScoped<IStudentsService, StudentsService>();
// TODO: Add the rest of services



// 8.  Add Authorization 
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// 9. Config Swagger to take care of Authorization of JWT
builder.Services.AddSwaggerGen(options =>
    {
        // We define the security for authorization
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization Header using bearer scheme"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                 new OpenApiSecurityScheme
                 {
                      Reference= new OpenApiReference
                      {
                        Type= ReferenceType.SecurityScheme,
                        Id = "Bearer" 
                      }
                 },
                new string[]{ }
            }
        });




    }
);







// 5. Cors Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 12. tell app to use serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// 6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
