using Microsoft.Extensions.DependencyInjection;
using RedisCrudCommon.Repositories;
using RedisCrudCommon.Settings;
using StackExchange.Redis;

namespace RedisCrudCommon.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddRedisServices(this IServiceCollection services, Action<RedisConfiguration> configure)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        var redisConfiguration = new RedisConfiguration();
        configure(redisConfiguration);

        services.AddSingleton<IConnectionMultiplexer>(opt =>
            ConnectionMultiplexer.Connect(redisConfiguration.RedisConnection)
        );
        return services;
    }
}

//dotnet pack -o ..\Nuget\ 