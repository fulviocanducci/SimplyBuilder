using System.Data.Common;

namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IWhereUpdate: IBuilder, IWhereType<IWhereUpdate>
    {
        IWhereUpdate SetValue<T>(string field, T value) where T : DbParameter;
    }
}
