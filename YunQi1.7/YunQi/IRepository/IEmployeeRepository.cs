using DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IEmployeeRepository
    {
        string constr { get; set; }

        //SqlConnection con { get; set; }
        Task<int> EmployeeLogin(string EmployeeMobile, string Password);

        Task<int> InsertEmployee(string EmployeeMobile, string Password, int PositionId, string Name, DateTime Birthday, DateTime Duedate, byte sex, int BaseSalary, string ID, string EmergencyContact, string EmergencyContactPhone, string ContactPhone, string ContactAddress, string eMail, DateTime UpdateTime, string UpdateEmployeeMobile, string LineId = "");

        Task<List<int>> GetEmployeeRights(string EmployeeMobile);

        Task<long> GetDepartmentListCount(int DepartmentId, string Department = "");

        Task<List<DepartmentListViewModel>> GetDepartmentList(int DepartmentId, string Department = "", int Skip = 0, int RowsPerPage = 10);

        Task<List<DepartmentLevelPathViewModel>> GetDepartmentLevelPath(int DepartmentId);

        Task<int> InsertDepartment(int ParentDepartmentId, string Department, string DepartmentDescription);

        Task<int> UpdateDepartment(int DepartmentId, string Department, string DepartmentDescription);

        Task<int> DeleteDepartment(int DepartmentId);

        Task<int> InsertPosition(int DepartmentId, string Position, string PositionDescription);

        Task<long> GetPositionListCount(int DepartmentId);

        Task<List<PositionListViewModel>> GetPositionList(int DepartmentId, int Skip, int RowsPerPage);

        Task<int> UpdatePosition(int PositionId, string Position, string PositionDescription);

        Task<int> DeletePosition(int PositionId);

        Task<long> GetEmployeeListCount(string Department, string Position, string EmployeeName);

        Task<List<EmployeeListViewModel>> GetEmployeeList(string Department, string Position, string EmployeeName, int Skip, int RowsPerPage);

        Task<int> UpdateEmployee(string EmployeeMobile, string Name, DateTime Birthday, DateTime Duedate, byte sex, int BaseSalary, string ID, string EmergencyContact, string EmergencyContactPhone, string ContactPhone, string ContactAddress, string eMail, DateTime UpdateTime, string UpdateEmployeeMobile, string LineId);

        Task<int> DeleteEmployee(string EmployeeMotile);

        Task<PositionViewModel> ValidatePosition(string Position);

        Task<int> UpdateEmployeePosition(string EmployeeMobile, string Position, DateTime UpdateTime, string UpdateEmployeeMobile);

        Task<List<EmplyoeeRightViewModel>> GetEmployeeRight(string EmployeeMobile);

        Task<int> UpdateEmployeeRights(string EmployeeMobile, string rights);

        Task<int> UpdateEmployeePassword(string EmployeeMobile, string OldPassword, string NewPassword, DateTime UpdateTime, string UpdateEmployeeMobile);

        //20181210 ---棋
        //YunQiERP 薪資類別管理
        Task<long> GetEmployeeMonthSalaryListCount(string EmployeeMobile, int Month);

        Task<List<EmployeeMonthSalaryViewModel>> GetEmployeeMonthSalaryList(string EmployeeMobile, int Month, int Skip = 0, int RowsPerPage = 10);

        //20181218 ---棋
        //YunQiERP 訊息中心
        Task<long> GetMailCenterMessageCount(int MemberLevelId, string MessageValue, DateTime? sDate, DateTime? eDate);

        Task<List<GetMailCenterMessageListViewModel>> GetMailCenterMessageList(int MemberLevelId, string MessageValue, DateTime? sDate, DateTime? eDate, int Skip = 0, int RowsPerPage = 10);

        Task<int> DeleteMailCenterMessage(int MessageId);

        Task<int> InsertMailCenterMessage(List<MailCenterDataModel> MailCenter);

        Task<int> GetMailCenterTop1();

        //20181220 ---棋
        //YunQiERP 留言板管理
        Task<long> GetMessageManagementCount(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string MemberMobile, string NickName);

        Task<List<MessageManagementListViewModel>> GetMessageManagementList(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string MemberMobile, string NickName, int Skip = 0, int RowsPerPage = 10);

        Task<long> GetReplyMessageManagementCount(int MessageId);

        Task<List<ReplyMessageManagementDataListviewModel>> GetReplyMessageManagementList(int MessageId, int Skip, int RowsPerPage);

        Task<List<VersionListViewModel>> GetVersion();

        Task<long> DeleteMessageManagement(int MessageId);

        Task<long> DeleteReplyMessageManagement(int ReplyMessageId);

        Task<long> InsertReplyMessageManagement(int MessageId, string ReplyMessageValue, string ReplyMobile);

        Task<int> UpdateMemberLevelCart(int VersionId, byte[] PictureContent, string PictureType, string FileName);

        Task<GetImgVersionRuleViewModel> GetCagegoryImage(int VersionId);
    }
}