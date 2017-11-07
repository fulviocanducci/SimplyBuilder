using Canducci.Simply.SqlBuilder.Interfaces;
using System.Data.Common;
namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders : IInsert, IColumns, IValues, IBuilder, IIdentity
    {
        IValues IColumns.Columns(string value)
        {
            string[] c = value.Trim().TrimEnd().TrimStart().Replace(" ", "").Split(',');
            return Columns(c);
        }

        public IValues Columns(params string[] values)
        {
            StrQuery.AppendFormat("({0}) ", Layout.Open() + string.Join($"{Layout.Close()},{Layout.Open()}", values) + Layout.Close());
            return this;
        }

        public IIdentity Values(params DbParameter[] values)
        {
            Parameters.AddRange(values);
            StrQuery.Append("VALUES(");
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) StrQuery.AppendFormat(",");
                StrQuery.Append(values[i].ParameterName);                
            }
            StrQuery.Append(");");
            return this; 
        }

        public IResultBuilder Builder()
        {            
            return new ResultBuilder(StrQuery.ToString(), Parameters.ToArray());
        }

        public IBuilder Identity(IdentityResult result = IdentityResult.Integer)
        {
            string returnType = "";
            switch(result)
            {
                case IdentityResult.Integer:
                    {
                        returnType = "INT";
                        break;
                    }
                case IdentityResult.BigInteger:
                    {
                        returnType = "BIGINT";
                        break;
                    }
            }
            StrQuery.Append($"{Layout.LastInsertedId(returnType)}");
            return this;
        }
        
        public IColumns Insert(string table, string schema = "")
        {
            if (string.IsNullOrWhiteSpace(schema))
                StrQuery.Append($"INSERT INTO {Layout.Param(table)}");
            else
                StrQuery.Append($"INSERT INTO {Layout.Param(schema)}.{Layout.Param(table)}");
            return this;
        }

        
    }
}
