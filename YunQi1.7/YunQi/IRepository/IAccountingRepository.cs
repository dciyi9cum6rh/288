using DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IAccountingRepository
    {
        string constr { get; set; }

        Task<long> GetAccountingCount(string AccountingSubject);

        Task<List<AccountingListViewModel>> GetAccountingList(string AccountingSubject, int Skip, int RowsPerPage);

        Task<int> InsertAccounting(string AccountingId, string AccountingSubject, string AccountingDescription);

        Task<int> UpdateAccounting(string AccountingId, string AccountingSubject, string AccountingDescription);

        Task<int> DeleteAccounting(string AccountingId);
    }
}