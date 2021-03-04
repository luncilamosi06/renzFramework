using System.Data.SqlClient;

namespace RivTech.WebService.Generic.DataProvider
{
    public interface IDatabaseContext
    {
        SqlConnection Connection { get; }
    }


    public interface IDefinedDataContext : IDatabaseContext
    {

    }

    public interface IUserInfoDataContext : IDatabaseContext
    {

    }




}