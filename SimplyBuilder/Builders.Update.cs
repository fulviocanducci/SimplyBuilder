using Canducci.Simply.SqlBuilder.Interfaces;
using System.Data.Common;
using System.Data;

namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders: ISetValue, IUpdate
    {
        public Builders()
        {
        }

        public ISetValue SetValue<T>(string field, T value) where T : DbParameter
        {
            AddSetSeparator();
            StrQuery.AppendFormat("[{0}]={1}", field, value.ParameterName);
            Parameters.Add(value);
            return this;
        }

        public ISetValue Update(string table, string schema = "")
        {
            if (string.IsNullOrWhiteSpace(schema))
                StrQuery.Append($"UPDATE {Layout.Param(table)}");
            else
                StrQuery.Append($"UPDATE INTO {Layout.Param(schema)}.{Layout.Param(table)}");
            return this;
        }

        IWhereUpdate IWhereType<IWhereUpdate>.OrWhere<T>(string column, T parameter)
        {
            return (IWhereUpdate)OrWhere(column, parameter);
        }

        IWhereUpdate IWhereType<IWhereUpdate>.OrWhere<T>(string column, string compare, T parameter)
        {
            return (IWhereUpdate)OrWhere(column, compare, parameter);
        }

        IWhereUpdate IWhereType<IWhereUpdate>.OrWhere<ParameterType, T>(string column, string compare, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereUpdate)OrWhere<ParameterType, T>(column, compare, value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        IWhereUpdate IWhereType<IWhereUpdate>.OrWhere<ParameterType, T>(string column, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereUpdate)OrWhere<ParameterType, T>(column, value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        IWhereUpdate IWhereUpdate.SetValue<T>(string field, T value)
        {
            return SetValue(field, value);
        }
        
        IWhereUpdate IWhereType<IWhereUpdate>.Where<T>(string column, T parameter)
        {
            return (IWhereUpdate)Where(column, "=", parameter);
        }

        IWhereUpdate IWhereType<IWhereUpdate>.Where<T>(string column, string compare, T parameter)
        {
            return (IWhereUpdate)Where(column, compare, parameter);
        }

        IWhereUpdate IWhereType<IWhereUpdate>.Where<ParameterType, T>(string column, string compare, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereUpdate)Where<ParameterType, T>(column, compare, value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        IWhereUpdate IWhereType<IWhereUpdate>.Where<ParameterType, T>(string column, T value, string parameterName, DbType? dbType, bool nullMapping, ParameterDirection parameterDirection, int? size)
        {
            return (IWhereUpdate)Where<ParameterType, T>(column, value, parameterName, dbType, nullMapping, parameterDirection, size);
        }


    }
}
