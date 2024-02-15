using ApplicationMain.Admins;
using ApplicationMain.Transactions;
using ApplicationMain.Users;
using Contracts.Administrators;
using Contracts.Transactions;
using Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationMain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<ITransactionService, TransactionService>();
        collection.AddScoped<CurrentUserManager>();

        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());
        return collection;
    }
}