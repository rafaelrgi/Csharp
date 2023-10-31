using Application;

namespace WebUi;

public static class AutoMapperConfig
{
  public static void AddAutoMapperConfiguration(this IServiceCollection services)
  {
    if (services == null) throw new ArgumentException("");

    services.AddAutoMapper(typeof(ToDto), typeof(FromDto));
  }
}
