using System.Linq.Expressions;
using Domain;

namespace Data;

public abstract class Repository<T> : IRepository<T> where T : class
{
  protected ApplicationDbContext _context;

  protected Repository(ApplicationDbContext context)
  {
    _context = context;
  }

  public abstract T Get(int id);
  public abstract IEnumerable<T> GetAll();
  public abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
  public abstract bool Insert(T entity);
  public abstract bool Save(T entity);
  public abstract bool Update(T entity);
  public abstract bool Delete(T entity);
}
