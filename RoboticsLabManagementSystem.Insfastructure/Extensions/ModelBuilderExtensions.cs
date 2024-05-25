using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Insfastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SetDefaultSchema(this ModelBuilder modelBuilder, string schema)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetSchema(schema);
            }
        }
    }
    public static class SchemaChecker
    {
        public static bool SchemaExists(DbContext context, string schemaName)
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"
                SELECT CASE WHEN EXISTS (
                    SELECT * FROM INFORMATION_SCHEMA.SCHEMATA
                    WHERE SCHEMA_NAME = '{schemaName}'
                )
                THEN 1 ELSE 0 END";
                var result = command.ExecuteScalar();
                return (int)result == 1;
            }
        }
    }

}
