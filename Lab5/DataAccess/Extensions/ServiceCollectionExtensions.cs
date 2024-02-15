using Abstractions.Repositories;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
   public static IServiceCollection AddInfrastructureDataAccess(this IServiceCollection collection)
   {
      collection.AddScoped<IUserRepository, UserRepository>();
      collection.AddScoped<IAdminRepository, AdminRepository>();
      collection.AddScoped<ITransactionRepository, TransactionRepository>();

      return collection;
   }
}