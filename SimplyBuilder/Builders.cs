using Canducci.Simply.SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders
    {
        private StringBuilder StrQuery { get; set; } = new StringBuilder();
        private List<DbParameter> Parameters { get; set; } = new List<DbParameter>();
        public ILayout Layout { get; private set; }

        public Builders(ILayout layout)
        {
            Layout = layout; 
        }

        public static IColumns InsertFrom(ILayout layout, string table)
        {
            return (new Builders(layout).Insert(table));
        }

        public static ISetValue UpdateFrom(ILayout layout, string table)
        {
            return (new Builders(layout).Update(table));
        }

        public static IWhereDelete DeleteFrom(ILayout layout, string table)
        {
            return (new Builders(layout).Delete(table));
        }

        public static ISelect SelectFrom(ILayout layout, string table)
        {
            return (new Builders(layout).From(table));
        }

        public void AddWhere(string value)
        {
            if (StrQuery.ToString().Contains("WHERE") == false)
                StrQuery.AppendFormat(" WHERE ");
            else
                StrQuery.AppendFormat($" {value} ");
        }       

        public void AddSetSeparator()
        {
            if (!StrQuery.ToString().Contains("SET"))
                StrQuery.AppendFormat(" SET ");
            else
                StrQuery.AppendFormat(",");
        }
    }
}
