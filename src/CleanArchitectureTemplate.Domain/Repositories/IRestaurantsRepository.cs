﻿using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Domain.Repositories;

public interface IRestaurantsRepository : IGenericRepository<Restaurant>
{
    /*Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task<int> Create(Restaurant entity);
    Task Delete(Restaurant entity);
    Task SaveChanges();
    Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);*/
}
