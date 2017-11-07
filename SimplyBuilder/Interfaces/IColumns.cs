namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IColumns
    {
        IValues Columns(params string[] values);
        IValues Columns(string value);
    }
}
