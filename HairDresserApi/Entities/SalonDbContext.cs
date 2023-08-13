using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDresserApi.Entities
{

    public class SalonDbContext : DbContext
    {
        public SalonDbContext(DbContextOptions<SalonDbContext> options)
             : base(options)
        {

        }
        private string connectionString = "Data Source=KSA-304;Initial Catalog=salonDB;User Id=sa; Password=root;";
        //private string con5 = "Data Source = Application.db; Cache=Shared;";
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ServiceTable> ServiceTables { get; set; }
        public DbSet<StatusTable> StatusTables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<WorkPlan> WorkPlans { get; set; }

        public static string BuildConnectionString(string instanceName = null, string databaseName = null, string user = null, string password = null,
               string applicationName = null, int? connectTimeout = null, bool? integratedSecurity = null)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = instanceName;
            sqlConnectionStringBuilder.InitialCatalog = databaseName ;
            sqlConnectionStringBuilder.UserID = user ;
            sqlConnectionStringBuilder.Password = password ;
            sqlConnectionStringBuilder.ApplicationName = applicationName ;
            sqlConnectionStringBuilder.ConnectTimeout = connectTimeout.Value;
            sqlConnectionStringBuilder.IntegratedSecurity = integratedSecurity.Value;

            return sqlConnectionStringBuilder.ConnectionString;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Client>()
                .Property(x => x.client_name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Client>()
                .Property(x => x.client_phone)
                .IsRequired()
                .HasMaxLength(12);
           
            modelBuilder.Entity<Client>()
                .HasKey(x => x.client_id);

            modelBuilder.Entity<Employee>()
                .HasKey(x => x.employee_id);

            modelBuilder.Entity<Reservation>()
                .Property(x => x.reservation_date)
                .IsRequired();

            modelBuilder.Entity<ServiceTable>()
                .Property(x => x.service_price)
                .HasPrecision(4, 2);

            modelBuilder.Entity<StatusTable>()
                .HasData(new StatusTable { status_id = 1, status_name = "Rezerwacja" },
                         new StatusTable { status_id = 2, status_name = "W trakcie" },
                         new StatusTable { status_id = 3, status_name = "Zakończone" },
                         new StatusTable { status_id = 4, status_name = "Anulowane" }
                        );

            modelBuilder.Entity<WorkPlan>()
                .Property(x => x.ShiftTypeSecond)
                .HasConversion<int>(); 

            modelBuilder.Entity<WorkPlan>()
                .Property(x => x.ShiftTypeSecondName)
                .HasConversion<string>();

        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {string tmp = Environment.GetEnvironmentVariable("salonBase");
            if (!optionsBuilder.IsConfigured)
			{

                optionsBuilder.UseSqlServer(connectionString);
			}
        }
    }
}
