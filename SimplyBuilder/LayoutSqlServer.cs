﻿using Canducci.Simply.SqlBuilder.Interfaces;
namespace Canducci.Simply.SqlBuilder
{
    public class LayoutSqlServer : ILayout
    {
        public string Close()
            => "]";

        public string LastInsertedId(params string[] value)
            => $"SELECT CAST(SCOPE_IDENTITY() AS {value[0]});";

        public string Open()
            => "[";

        public string Param<T>(T value)
            => $"{Open()}{value}{Close()}";
    }
}
