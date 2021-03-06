﻿using PersonalAccounting.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> GetCategoriesByBudgetId(int budgetId);
    }
}
