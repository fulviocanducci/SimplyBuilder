using Canducci.Simply.SqlBuilder.Interfaces;
using System;

namespace Canducci.Simply.SqlBuilder
{
    public sealed class LayoutMySqlServer : ILayout
    {
        public string Close()
            => "`";

        public string LastInsertedId(params string[] value)
            => "SELECT LAST_INSERT_ID();";

        public string Open() 
            => "`";

        public string Param<T>(T value)
            => $"{Open()}{value}{Close()}";
    }
}
