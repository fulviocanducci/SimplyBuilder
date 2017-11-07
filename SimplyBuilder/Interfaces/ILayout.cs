namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface ILayout
    {
        string Open();
        string Close();
        string Param<T>(T value);
        string LastInsertedId(params string[] value);
    }
}
