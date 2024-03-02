namespace PruebaTecnicaNet.Infraestructure.EntityConfigurations;

public class SettlementBankTypeConfiguration : IEntityTypeConfiguration<SettlementBank>
{
    public void Configure(EntityTypeBuilder<SettlementBank> builder)
    {
        builder.ToTable("banks");

        builder.Ignore(b => b.DomainEvents);

        builder.Property(b => b.Id)
            .UseHiLo("bankseq");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Country)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(b => b.Bic)
            .IsRequired()
            .HasMaxLength(8);

        builder.HasIndex(b => b.Bic)
            .IsUnique();

        builder.HasIndex(b => b.Country);

        builder.HasIndex(b => b.Name);
    }
}
