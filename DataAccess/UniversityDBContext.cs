using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    /* Tenemos que heredar de DbContext */
    public class UniversityDBContext : DbContext
    {

        private readonly ILoggerFactory _loggerFactory;



        /* Creamos un constructor de clase que tiene que tener el mismo nombre de la clase UniversityDBContext
         * entre () ponemos DbContextOptions y entre <> ponemos el tipo que es el mismo tipo de la clase UniversityDBContext
         * ahora le vamos a poner opcions para que el constructor reciba una serie de opciones
         * y le ponemos el base que sera nuestro DbContext pasandole las opcions
         */
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        // TO DO: Add DbSets (Tables of our Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            //  optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
            //  optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
                


        }




    }
}
