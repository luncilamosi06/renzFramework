using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RivTech.WebService.Generic.DataProvider
{
    public class DefinedDataContext : IDefinedDataContext
    {
        private readonly IConfiguration _config;
        public DefinedDataContext(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("ConDefinedData"));
            }
        }

    }
}
