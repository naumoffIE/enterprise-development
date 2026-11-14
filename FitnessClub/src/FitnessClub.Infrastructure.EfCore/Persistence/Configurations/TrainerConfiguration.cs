using FitnessClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessClub.Infrastructure.EfCore.Persistence.Configurations;

/// <summary>
/// Конфигурация маппинга тренера в базу данных
/// </summary>
public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.PassportNumber).HasMaxLength(20).IsRequired();
        builder.Property(t => t.FullName).HasMaxLength(200).IsRequired();
        builder.Property(t => t.PhoneNumber).HasMaxLength(20);
        builder.Property(t => t.Gender).HasConversion<string>().HasMaxLength(20);

        builder.HasIndex(t => t.PassportNumber).IsUnique();

        builder.Property(t => t.Experience).IsRequired();

        builder.HasOne(t => t.Specialization)
            .WithMany()
            .HasForeignKey("SpecializationId")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable("trainers");
    }
}