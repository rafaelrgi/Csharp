using System.Linq.Expressions;
using AutoMapper;
using Domain;

namespace Application;

//TODO: subclassess
public abstract class Service<T> : IService<T> where T : Dto
{
  IRepository<T> _repository;
  IMapper _mapper;

  public Service(IRepository<T> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public abstract bool Delete(T entity);
  public abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
  public abstract T Get(int id);
  public abstract IEnumerable<T> GetAll();
  public abstract bool Insert(T entity);
  public abstract bool Save(T entity);
  public abstract bool Update(T entity);
}
