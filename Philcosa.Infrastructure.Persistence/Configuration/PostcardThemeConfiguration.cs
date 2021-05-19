using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Persistence.Configuration
{
    public class PostcardThemeConfiguration : IEntityTypeConfiguration<PostcardTheme>
    {
        public void Configure(EntityTypeBuilder<PostcardTheme> builder)
        {
            builder.HasKey(pt => new { pt.PostcardId, pt.ThemeId });

            builder.HasOne<Postcard>(pt => pt.Postcard)
                .WithMany(p => p.PostcardThemes)
                .HasForeignKey(pt => pt.PostcardId);

            builder.HasOne<Theme>(pt => pt.Theme)
                .WithMany(p => p.PostcardThemes)
                .HasForeignKey(pt => pt.ThemeId);
            
        }
    }
}
