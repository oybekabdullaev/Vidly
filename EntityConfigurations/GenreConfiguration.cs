using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}