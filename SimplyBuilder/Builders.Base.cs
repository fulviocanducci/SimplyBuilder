using Canducci.Simply.SqlBuilder.Interfaces;
using System;
using System.Data;
using System.Data.Common;

namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders : ISelect
    {

        #region OrWhere

        public ISelect OrWhere<T>(string column, T parameter) where T : DbParameter
        {
            return OrWhere(column, "=", parameter);
        }

        public ISelect OrWhere<T>(string column, string compare, T parameter) where T : DbParameter
        {
            AddWhereOr();
            StrQuery.AppendFormat($"{Layout.Param(column)} {compare} {parameter.ParameterName}");
            Parameters.Add(parameter);
            return this;
        }

        public ISelect OrWhere<ParameterType, T>(string column, string compare, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct
        {
            ParameterType parameter = Activator.CreateInstance<ParameterType>();
            parameter.ParameterName = parameterName ?? $"@{column}";
            parameter.Value = value;
            parameter.SourceColumn = column;
            parameter.SourceColumnNullMapping = nullMapping;
            parameter.Direction = parameterDirection;
            if (dbType != null) parameter.DbType = dbType.Value;
            if (size != null) parameter.Size = size.Value;
            return OrWhere(column, compare, parameter);
        }

        public ISelect OrWhere<ParameterType, T>(string column, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct
        {
            return OrWhere<ParameterType, T>(column, "=", value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        #endregion

        #region Where

        public ISelect Where<T>(string column, string compare, T parameter) where T : DbParameter
        {
            AddWhereAnd();
            StrQuery.AppendFormat($"{Layout.Param(column)} {compare} {parameter.ParameterName}");
            Parameters.Add(parameter);
            return this;
        }

        public ISelect Where<ParameterType, T>(string column, string compare, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct
        {
            ParameterType parameter = Activator.CreateInstance<ParameterType>();
            parameter.ParameterName = parameterName ?? $"@{column}";
            parameter.Value = value;
            parameter.SourceColumn = column;
            parameter.SourceColumnNullMapping = nullMapping;
            parameter.Direction = parameterDirection;
            if (dbType != null) parameter.DbType = dbType.Value;
            if (size != null) parameter.Size = size.Value;
            return Where(column, compare, parameter);
        }

        public ISelect Where<ParameterType, T>(string column, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct
        {
            return Where<ParameterType, T>(column, "=", value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        ISelect IWhereType<ISelect>.Where<T>(string column, T parameter)
        {
            return Where(column, "=", parameter);
        }

        #endregion

    }
}
