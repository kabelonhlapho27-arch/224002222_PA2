using SQLitePCL;
using ASPNETCore_DB.Data;


namespace BoardAppDB.Interfaces
{
    public interface IDBInitializer
    {
        void Initialize(SQLiteDBContext context);
    }
}
