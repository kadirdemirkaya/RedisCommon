using System.ComponentModel.DataAnnotations;
using DatabaseseCrudCommon.Models.Common;
using RedisCrudCommon.Enums;

namespace RedisCrudCommon.Repositories;

public interface IRepository<T> where T : EntityBase
{
    Task<bool> CreateAsync(string key, T value, RedisDataType dataType);
    bool Create(string key, T value, RedisDataType dataType);
    Task<T>? GetByIdAsync(string key, string? id, RedisDataType dataType);
    T? GetById(string key, string? id, RedisDataType dataType);
    IEnumerable<T?>? GetAll(string? key, RedisDataType dataType);
    bool Delete(string key, string? id, RedisDataType dataType);
    bool Update(string key, T value, RedisDataType dataType);
}