﻿using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services.Interfaces
{
    public interface ITransactionsService
    {
        IEnumerable<Transaction> GetByBudgetId(int budgetId);
        Task Insert(Transaction transaction);
    }
}
