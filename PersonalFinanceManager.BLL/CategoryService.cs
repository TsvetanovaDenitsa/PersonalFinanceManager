using System;
using System.Collections.Generic;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL;

public sealed class CategoryService
{
    private readonly CategoryRepository _repository;

    public CategoryService(CategoryRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public List<Category> GetAllCategories()
    {
        var cats = _repository.GetAllCategories();
        return cats ?? new List<Category>();
    }
}
