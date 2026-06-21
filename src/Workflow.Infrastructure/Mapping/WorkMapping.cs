using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workflow.Domain.Entities;

namespace Workflow.Infrastructure.Mapping
{
    public class WorkMapping : BaseMapping<Work>
    {
        public WorkMapping() : base("Work") { }

        public override void Configure(EntityTypeBuilder<Work> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.Status).HasConversion<string>().IsRequired();
            builder.Property(x => x.Priority).HasConversion<string>().IsRequired();

            builder.HasMany(x => x.Histories)
                   .WithOne(h => h.Work)
                   .HasForeignKey(h => h.WorkId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Status);
            builder.HasIndex(x => x.Priority);
        }
    }
}