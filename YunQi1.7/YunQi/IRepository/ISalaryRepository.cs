using DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ISalaryRepository
    {
        string constr { get; set; }

        Task<long> GetSalaryClassCount(string SalaryClass);

        Task<List<SalaryClassListViewModel>> GetSalaryClassList(string SalaryClass, int Skip, int RowsPerPage);

        Task<int> InsertSalaryClass(string SalaryClass, int ClassSalary, string SalaryClassDescription);

        Task<int> UpdateSalaryClass(string SalaryClass, int ClassSalary, string SalaryClassDescription, int SalaryClassId);

        Task<int> DeleteSalaryClass(int SalaryClassId);

        //20181210 ---棋
        Task<int> AccountSalary(int Month);

        Task<List<SalaryClassListViewModel>> GetSalaryClassList();

        Task<int> InsertSalary(int Month, string EmployeeMobile, List<SalaryDataModel> SalaryDatas);

        Task<List<SalaryMonthEmployeeDetailListViewModel>> GetSalaryMonthEmployeeDetailList(string EmployeeMobile, int Month, int Skip, int RowsPerPage);

        Task<int> GetDeleteSalary(string EmployeeMobile, int Month);

        Task<List<GetEmployeeBaseSalaryViewModel>> GetEmployeeBaseSalary(string EmployeeMobile);

        //20181213 ---棋
        //會計-分類帳
        Task<long> GetLedgerListCount(string AccountingSubject, int Month);

        Task<List<LedgerListViewModel>> GetLedgerList(string AccountingSubject, int Month, int Skip, int RowsPerPage);

        Task<long> InsertLedger(string AccountingId, int Month, string InvoiceId, string LedgerDescription, long Money);

        Task<long> UpdateLedger(string AccountingId, int LedgerId, long Money, string InvoiceId, string LedgerDescription, int Month);

        Task<long> DeleteLedger(string AccountingId, int LedgerId);

        //20181214 ---棋
        //會計-總帳
        Task<List<GetLedgerMonthListViewModel>> GetLedgerMonthList(int Month);

        Task<long> GetLedgerMonthAddMoney(int Month);

        Task<long> GetLedgerMonthMinusMoney(int Month);
    }
}