using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Dtos;
using Application.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Domain.Services
{
    public class AccountingService : IAccountingService
	{
		private readonly AppDbContext _dbContext;

		public AccountingService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<AccountingUnitDto>> GetByDateAsync(DateTime startDate, DateTime? endDate = null)
		{
			return await _dbContext.AccountingUnits
				.Where(u => u.MeasurementPeriods
				.Any(p => p.Start <= endDate && startDate <= p.End))
				.Select(u => new AccountingUnitDto { Id = u.Id })
				.ToListAsync().ConfigureAwait(false);
		}
	}
}
