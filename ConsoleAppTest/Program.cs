using System;
using Canducci.Simply.SqlBuilder;
using System.Data.Common;
using System.Data.SqlClient;
using Canducci.Simply.SqlBuilder.Interfaces;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILayout layout = new LayoutSqlServer();
            IResultBuilder result0 = Builders.SelectFrom(layout, "test")
                .Columns("column1, column2")
                .Where<SqlParameter, int>("column1", 1)                
                .OrWhere<SqlParameter, int>("column2", 2)
                .WhereNull("column1")
                .WhereBetween("column1", new SqlParameter("@p1", 1), new SqlParameter("@p2", 1))
                .Builder();

            IResultBuilder result1 = Builders.InsertFrom(layout, "test")
                .Columns("column1", "column2")                
                .Values(new SqlParameter("@column1", 1), new SqlParameter("@column2", 1))                
                .Identity()
                .Builder();

            IResultBuilder result2 = Builders.UpdateFrom(layout, "test")
                .SetValue("column1", new SqlParameter("@column1", 1))
                .SetValue("column2", new SqlParameter("@column2", 2))
                .Where("id", new SqlParameter("@id", 1))
                .WhereNull("id")
                .Builder();

            IResultBuilder result3 = Builders.DeleteFrom(layout, "test")
                .Where<SqlParameter, int>("id", 10)
                .WhereNull("id")
                .WhereBetween("column1", new SqlParameter("@p1", 1), new SqlParameter("@p2", 1))
                .Builder();

            Console.WriteLine(result0.Sql);
            Console.WriteLine(result1.Sql);
            Console.WriteLine(result2.Sql);
            Console.WriteLine(result3.Sql);

            Console.ReadKey();
        }
    }
}
