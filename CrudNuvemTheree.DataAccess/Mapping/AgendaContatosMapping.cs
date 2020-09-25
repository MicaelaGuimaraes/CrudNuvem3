


namespace CrudNuvemTheree.DataAccess.Mapping
{
    using CrudNuvemTheree.DataAccess.Context;
    using CrudNuvemTheree.Entity;

    public class AgendaContatosMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AgendaContatos>
    {
        public AgendaContatosMapping()
            : this("dbo")
        {
        }

        public AgendaContatosMapping(string schema)
        {
            ToTable("AgendaContatos", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NomeContato).HasColumnName(@"NomeContato").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.EmailContato).HasColumnName(@"EmailContato").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.TelefoneContato).HasColumnName(@"TelefoneContato").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.Status).HasColumnName(@"Status").HasColumnType("bit").IsOptional();
        }
    }

}

