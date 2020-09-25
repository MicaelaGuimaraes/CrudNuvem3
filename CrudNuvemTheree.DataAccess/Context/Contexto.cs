


namespace CrudNuvemTheree.DataAccess.Context
{
    using CrudNuvemTheree.DataAccess.Mapping;
    using CrudNuvemTheree.Entity;


    public class Contexto : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<AgendaContatos> AgendaContatos { get; set; }

        static Contexto()
        {
            System.Data.Entity.Database.SetInitializer<Contexto>(null);
        }

        public Contexto()
            : base("Name=conexao")
        {
        }

        public Contexto(string connectionString)
            : base(connectionString)
        {
        }

        public Contexto(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public Contexto(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public Contexto(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AgendaContatosMapping());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AgendaContatosMapping(schema));
            return modelBuilder;
        }
    }
}

