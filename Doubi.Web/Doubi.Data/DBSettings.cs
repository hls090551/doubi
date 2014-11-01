using FluentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Data
{
   public class DBSettings
    {
        public const string ConnectionStringName = "doubi";        

        public static IDbContext TransactionContext()
        {
            return new DbContext().ConnectionStringName(ConnectionStringName,
                    new SqlServerProvider()).UseTransaction(true);
        }
    }
}
