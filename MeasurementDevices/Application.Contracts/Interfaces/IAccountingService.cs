using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Dtos;

namespace Application.Contracts.Interfaces
{
    public interface IAccountingService
	{
		Task<IEnumerable<AccountingUnitDto>> GetByDateAsync(DateTime startDate, DateTime? endDate = null);
	}
}