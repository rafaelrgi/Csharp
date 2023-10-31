namespace Application;

public interface IService<T> where T : Dto
{
  T Get(int id);
  IEnumerable<T> GetAll();
  IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
  bool Save(T entity);
  bool Insert(T entity);
  bool Update(T entity);
  bool Delete(T entity);
}
