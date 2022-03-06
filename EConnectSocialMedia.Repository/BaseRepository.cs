namespace GangstersAPP.Repository
{
    public class BaseRepository<T> : AppBaseRepository<T> where T : class
    {
        private readonly DatabaseContext DBContext;

        public BaseRepository(DatabaseContext DBContext) : base(DBContext)
        {
            this.DBContext = DBContext;
        }
    }
}
