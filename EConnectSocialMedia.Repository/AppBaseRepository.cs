using System.Reflection;

namespace EConnectSocialMedia.Repository
{
    public abstract class AppBaseRepository<T> where T : class
    {
        private readonly DbContext DbContext;

        public AppBaseRepository(DbContext ElbaltoAppContext)
        {
            DbContext = ElbaltoAppContext;
        }

        public async Task<List<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            List<string> Includes = null,
            string OrderString = null)
        {
            return await GetQuery(expression, Includes, OrderString).ToListAsync();
        }

        public async Task<T> GetFirst(
            Expression<Func<T, bool>> expression = null,
            List<string> Includes = null,
            string OrderString = null)
        {
            return await GetQuery(expression, Includes, OrderString).FirstOrDefaultAsync();
        }

        public async Task<T> GetLast(
           Expression<Func<T, bool>> expression = null,
           List<string> Includes = null,
           string OrderString = null)
        {
            return await GetQuery(expression, Includes, OrderString).LastOrDefaultAsync();
        }


        public async Task<T> GetByID(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public T CreateEntity(T entity)
        {
            return DbContext.Set<T>().Add(entity).Entity;
        }

        public void CreateEntity(List<T> entities)
        {
            DbContext.Set<T>().AddRangeAsync(entities);
        }

        public void UpdateEntity(T entity)
        {
            DbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void UpdateEntity(List<T> entities)
        {
            entities.ForEach(entity => DbContext.Entry<T>(entity).State = EntityState.Modified);
        }

        public void DeleteEntity(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void DeleteEntity(List<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }

        public int Count(Expression<Func<T, bool>> expression = null)
        {
            return GetQuery(expression).Count();
        }

        public bool Any(Expression<Func<T, bool>> expression = null)
        {
            return GetQuery(expression).Any();
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public IDictionary<string, string> GetLookUp(
            Expression<Func<T, bool>> expression = null,
            string KeyString = "Id",
            string ValueString = "Name",
            string OrderString = null)
        {
            PropertyInfo KeyProperty = typeof(T).GetProperty(KeyString);
            PropertyInfo ValueProperty = typeof(T).GetProperty(ValueString);

            return GetQuery(expression, OrderString).Select(x => new
            {
                Key = KeyProperty.GetValue(x, null),
                Value = ValueProperty.GetValue(x, null).ToString()
            })
             .ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        {
            return GetQuery(expression, null, null);
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression, string OrderString)
        {
            return GetQuery(expression, null, OrderString);
        }

        public IQueryable<T> GetQuery(
            Expression<Func<T, bool>> expression = null,
            List<string> Includes = null,
            string OrderString = null)
        {
            expression ??= (a => true);

            IQueryable<T> Query = DbContext.Set<T>().Where(expression).AsQueryable();

            if (Includes != null)
            {
                Includes.ForEach(include => Query = Query.Include(include));
            }

            if (!string.IsNullOrEmpty(OrderString))
            {
                string[] OrderByProp = OrderString.Split(",");

                foreach (string PropString in OrderByProp)
                {
                    string Prop = PropString;
                    bool Desc = Prop.Contains("desc");

                    Prop = Prop.Replace("desc", "");
                    Prop = Prop.Replace(",", "");
                    Prop = Prop.Trim();

                    PropertyInfo propertyInfo = typeof(T).GetProperty(Prop);

                    if (propertyInfo != null)
                    {
                        ParameterExpression param = Expression.Parameter(typeof(T));

                        Expression<Func<T, object>> expr = Expression.Lambda<Func<T, object>>(
                            Expression.Convert(Expression.Property(param, propertyInfo), typeof(object)),
                            param
                        );
                        Query = Desc ? Query.OrderByDescending(expr) : Query.OrderBy(expr);
                    }
                }
            }

            if (Includes != null)
            {
                Includes.ForEach(include => Query = Query.Include(include));
            }

            return Query;
        }
    }
}
