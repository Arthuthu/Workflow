using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workflow.Domain.Entities;

namespace Workflow.Infrastructure.Mapping
{
    public class WorkHistoryMapping : BaseMapping<WorkHistory>
    {
        public WorkHistoryMapping() : base("WorkHistory") { }

        public override void Configure(EntityTypeBuilder<WorkHistory> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.FromStatus).HasConversion<string>().IsRequired();
            builder.Property(x => x.ToStatus).HasConversion<string>().IsRequired();

            builder.HasOne(x => x.Work)
                   .WithMany(w => w.Histories)
                   .HasForeignKey(x => x.WorkId);

            builder.HasIndex(x => x.WorkId);
            builder.HasIndex(x => x.FromStatus);
            builder.HasIndex(x => x.ToStatus);
        }
    }
}