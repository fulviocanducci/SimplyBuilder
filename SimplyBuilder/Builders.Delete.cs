using System.Data;
using Canducci.Simply.SqlBuilder.Interfaces;

namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders: IWhereDelete
    {
        public IWhereDelete Delete(string table, string schema = "")
        {
            if (string.IsNullOrWhiteSpace(schema))
                StrQuery.Append($"DELETE FROM {Layout.Param(table)}");
            else
                StrQuery.Append($"DELETE FROM {Layout.Param(schema)}.{Layout.Param(table)}");
            return this;
        }


        IWhereDelete IWhereType<IWhereDelete>.OrWhere<T>(string column, T parameter)
        {
            return (IWhereDelete)OrWhere(column, parameter);
        }

        IWhereDelete IWhereType<IWhereDelete>.OrWhere<T>(string column, string compare, T parameter)
        {
            return (IWhereDelete)OrWhere(column, compare, parameter);
        }

        IWhereDelete IWhereType<IWhereDelete>.OrWhere<ParameterType, T>(string column, string compare, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereDelete)OrWhere<ParameterType, T>(column, compare, value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        IWhereDelete IWhereType<IWhereDelete>.OrWhere<ParameterType, T>(string column, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereDelete)OrWhere<ParameterType, T>(column, "=", value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        IWhereDelete IWhereType<IWhereDelete>.OrWhereNull(string column)
        {
            return (IWhereDelete)OrWhereNull(column);
        }

        IWhereDelete IWhereType<IWhereDelete>.Where<T>(string column, T parameter)
        {
            return (IWhereDelete)Where(column, "=", parameter);
        }

        IWhereDelete IWhereType<IWhereDelete>.Where<T>(string column, string compare, T parameter)
        {
            return (IWhereDelete)Where(column, compare, parameter);
        }

        IWhereDelete IWhereType<IWhereDelete>.Where<ParameterType, T>(string column, string compare, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereDelete)Where<ParameterType, T>(column, compare, value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        IWhereDelete IWhereType<IWhereDelete>.Where<ParameterType, T>(string column, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereDelete)Where<ParameterType, T>(column, "=", value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        IWhereDelete IWhereType<IWhereDelete>.WhereBetween<T1, T2>(string column, T1 param1, T2 param2)
        {
            return (IWhereDelete)WhereBetween(column, param1, param2);  
        }

        IWhereDelete IWhereType<IWhereDelete>.WhereNull(string column)
        {
            return (IWhereDelete)WhereNull(column);
        }
    }
}
