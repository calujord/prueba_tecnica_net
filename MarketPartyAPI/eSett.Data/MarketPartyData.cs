using eSett.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace eSett.Data
{
    public partial class MarketPartyData : DbContext
    {
        public MarketPartyData() { }

        public MarketPartyData(DbContextOptions<MarketPartyData> options) : base(options) { }

        public virtual DbSet<Retailer> Retailer { get; set; }
        public virtual DbSet<BalanceServiceProvider> BalanceServiceProvider { get; set; }
        public virtual DbSet<BalanceResponsibleParty> BalanceResponsibleParty { get; set; }
        public virtual DbSet<DistributionSystemOperator> DistributionSystemOperator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _connString;
            if (!optionsBuilder.IsConfigured)
            {
                var executingEnvironmment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                if (executingEnvironmment == "Development")
                {
                    //para el entorno de desarrollo se pueden usar credenciales en local, si está en intranet o no se ataca una máquina crítica
                    var configuration = new ConfigurationBuilder().AddJsonFile(Environment.CurrentDirectory + "/appsettings.json").Build();
                    _connString = configuration.GetSection("ConnectionStrings").GetSection("SqlServerConnection").Value;
                }
                else
                {
                    //Dependiendo de la configuración de Azure se utilizará el KeyVault o el ClientCredentialSecret
                    var aCredentials = new ClientSecretCredential(Environment.GetEnvironmentVariable("SecretCredentialTenantId"), Environment.GetEnvironmentVariable("SecretCredentialClientId"), Environment.GetEnvironmentVariable("SecretCredentialClientSecret"));
                    SecretClientOptions options = new()
                    {
                        Retry =
                        {
                            Delay= TimeSpan.FromSeconds(2),
                            MaxDelay = TimeSpan.FromSeconds(16),
                            MaxRetries = 5,
                            Mode = RetryMode.Exponential
                        }
                    };
                    var client = new SecretClient(new Uri("direccion de azure de keyvault"), aCredentials, options);
                    string secretName = Environment.GetEnvironmentVariable("CnnStrSecretName");

                    KeyVaultSecret secret = client.GetSecret(secretName);
                    _connString = secret.Value;
                }
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Retailer>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id).HasField("Id");

                entity.Property(r => r.Name).HasField("reName");

                entity.Property(r => r.Code).HasField("reCode");

                entity.Property(r => r.country).HasField("country");

                entity.Property(r => r.codingScheme).HasField("codingScheme");

            });
            modelBuilder.Entity<DistributionSystemOperator>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id).HasField("Id");

                entity.Property(r => r.Name).HasField("dsoName");

                entity.Property(r => r.Code).HasField("dsoCode");

                entity.Property(r => r.country).HasField("country");

                entity.Property(r => r.codingScheme).HasField("codingScheme");

            });
            modelBuilder.Entity<BalanceServiceProvider>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id).HasField("Id");

                entity.Property(r => r.Name).HasField("bspName");

                entity.Property(r => r.Code).HasField("bspCode");

                entity.Property(r => r.country).HasField("country");

                entity.Property(r => r.codingScheme).HasField("codingScheme");

                entity.Property(r => r.bussinesId).HasField("bussinesId");

            });
            modelBuilder.Entity<BalanceResponsibleParty>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id).HasField("Id");

                entity.Property(r => r.Name).HasField("brpName");

                entity.Property(r => r.Code).HasField("brpCode");

                entity.Property(r => r.country).HasField("country");

                entity.Property(r => r.codingScheme).HasField("codingScheme");

                entity.Property(r => r.bussinesId).HasField("bussinesId");

                entity.Property(r => r.validityEnd).HasField("validityEnd");

                entity.Property(r => r.validityStart).HasField("validityStart");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
