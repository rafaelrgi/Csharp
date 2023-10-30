namespace Domain;

public interface IRepository<T> where T : class
{
  T Get(int id);
  IEnumerable<T> GetAll();
  IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
  bool Save(T entity);
  bool Insert(T entity);
  bool Update(T entity);
  bool Delete(T entity);
}
