using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KekaWear.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    namespace Xhr.Core
    {

        /// <summary>
        /// Enum AuthenticationType
        /// </summary>
        public enum AuthenticationType
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The basic
            /// </summary>
            Basic = 1,
            /// <summary>
            /// The office365
            /// </summary>
            Office365 = 2,
            /// <summary>
            /// The google
            /// </summary>
            Google = 3
        }
        /// <summary>
        /// ENUM Leave Request Status
        /// </summary>
        public enum LeaveRequestStatus
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,

            /// <summary>
            /// The pending
            /// </summary>
            Pending = 1,

            /// <summary>
            /// The approved
            /// </summary>
            Approved = 2,

            /// <summary>
            /// The rejected
            /// </summary>
            Rejected = 3,

            /// <summary>
            /// The cancelled
            /// </summary>
            Cancelled = 4,

            /// <summary>
            /// The in approval process
            /// </summary>
            InApprovalProcess = 5
        }

        /// <summary>
        /// LeaveRequestType
        /// </summary>
        public enum LeaveRequestType
        {
            /// <summary>
            /// The sick leave
            /// </summary>
            SickLeave = 0,
            /// <summary>
            /// The paid leave
            /// </summary>
            PaidLeave = 1,
            /// <summary>
            /// The other leave
            /// </summary>
            OtherLeave = 2
        }

        /// <summary>
        /// AttendanceDayStatus
        /// </summary>
        public enum AttendanceDayStatus
        {
            NoEntriesLogged = 0,
            LogsRecorded = 1,
            WFH = 2,
            OnDuty = 3
        }

        /// <summary>
        /// Announcement Status.
        /// </summary>
        public enum AnnouncementStatus
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The draft
            /// </summary>
            Draft,
            /// <summary>
            /// The publish
            /// </summary>
            Publish
        }

        /// <summary>
        /// Enum SessionType
        /// </summary>
        public enum SessionType
        {
            /// <summary>
            /// The first half
            /// </summary>
            FirstHalf = 0,
            /// <summary>
            /// The second half
            /// </summary>
            SecondHalf = 1
        }


        /// <summary>
        /// Mode
        /// </summary>
        public enum Mode
        {
            /// <summary>
            /// The single selection
            /// </summary>
            SingleSelection,
            /// <summary>
            /// The single selection_ one always open
            /// </summary>
            SingleSelection_OneAlwaysOpen,
            /// <summary>
            /// The multiple selection
            /// </summary>
            MultipleSelection
        }

        /// <summary>
        /// ViewModelType
        /// </summary>
        public enum ViewModelType
        {
            /// <summary>
            /// The time off
            /// </summary>
            TimeOff = 0,
            /// <summary>
            /// The apply leave
            /// </summary>
            ApplyLeave,
            /// <summary>
            /// The leave approvals
            /// </summary>
            LeaveApprovals,
            /// <summary>
            /// The leave approval details
            /// </summary>
            LeaveApprovalDetails,
            /// <summary>
            /// The clock in
            /// </summary>
            ClockIn,
            /// <summary>
            /// The attendance approvals
            /// </summary>
            AttendanceApprovals,
            /// <summary>
            /// The attendance approval details
            /// </summary>
            AttendanceApprovalDetails,

            /// <summary>
            /// AttendanceViewModel
            /// </summary>
            AttendanceViewModel,

            /// <summary>
            /// AttendanceLogs
            /// </summary>
            AttendanceLogs,

            TaxDeclaration
        }

        /// <summary>
        /// Punch Status
        /// </summary>
        public enum PunchStatus
        {
            [Description(Title = "IN")]
            In = 0,
            [Description(Title = "OUT")]
            Out = 1,
            [Description(Title = "IN WITH OUT MISS")]
            InWithOutMiss = 2,  ////first out log is missing we have in log
            [Description(Title = "OUT WITH IN MISS")]
            OutWithInMiss = 3,  ////in log is missing we have out log
            [Description(Title = "OUT MISS")]
            OutMiss = 4,
            [Description(Title = "PUNCH")]
            LocationPunch = 5,
            [Description(Title = "In MIss")]
            InMiss = 6,
            [Description(Title = "INVALID PUNCH STATE")]
            InvalidPunchState = 99
        }

        /// <summary>
        /// Leave Type 
        /// </summary>
        public enum LeaveTypeEnum
        {
            /// <summary>
            /// The paid time off
            /// </summary>
            [Description(Title = "Paid Time Off")]
            PaidTimeOff = 0,
            /// <summary>
            /// The sick leave
            /// </summary>
            [Description(Title = "Sick Leave")]
            SickLeave = 1,
            /// <summary>
            /// The others
            /// </summary>
            [Description(Title = "Others")]
            Others = 2
        }

        /// <summary>
        /// Enum TimesheetStatus
        /// </summary>
        public enum TimesheetStatus
        {
            UnSubmitted = 0, // default status when the entry is created it is un submitted
            Submitted = 1, // when the timesheet is submitted by employee
            Approved = 2, // when the timesheet has gone through all the approval process and approved by all
            Rejected = 3, // when the timesheet is rejected by any of the person in the approval chain
            PartiallyApproved = 4 // when the timesheet is approved by one and the other person need to approve in the process of approval
        }

        /// <summary>
        /// Enum TimeEntryStatus
        /// </summary>
        public enum TimeEntryStatus
        {
            UnSubmitted = 0, // when the timesheet entry is created, the default would be un submitted
            Submitted = 1, // when the timesheet is submitted by employee, then the entry status change to submitted
            Approved = 2, // when the timesheet is approved by all the managers, then the entry status change to approved
            Rejected = 3, // when the timesheet is rejected by any one of the manager, then the entry status is rejected
            InApprovalProcess = 4, // if one of the managers approved as part approval process, then the entry status changes to in approval process
            Invoiced = 5 // when the time entries are invoiced
        }
        /// <summary>
        /// Enum ApproverType
        /// </summary>
        public enum ApproverType
        {
            Employee = 0,
            ReportingManager = 1,
            ProjectManager = 2,
            AccountManager = 3,
            L2Manager = 4,
            DepartmentHead = 5,
            BusinessUnitHead = 6,
        }

        /// <summary>
        /// LeaveDayStatus
        /// </summary>
        public enum LeaveDayStatus
        {
            None = 0,
            FullDayLeave = 1,
            FirstHalfLeave = 2,
            SecondHalfLeave = 3,
        }

        /// <summary>
        /// WorkingDayType
        /// </summary>
        public enum WorkingDayType
        {
            None,
            FullDay,
            HalfDay
        }
        /// <summary>
        /// Gender
        /// </summary>
        public enum Gender
        {
            /// <summary>
            /// The not specified
            /// </summary>
            NotSpecified = 0,
            /// <summary>
            /// The male
            /// </summary>
            Male = 1,
            /// <summary>
            /// The female
            /// </summary>
            Female = 2,
            /// <summary>
            /// The other
            /// </summary>
            Other = 3
        }

        /// <summary>
        /// AttendanceLogSource
        /// </summary>
        public enum AttendanceLogSource
        {
            Mobile = 0,
            Web = 1
        }

        /// <summary>
        /// Enum SystemLeaveType
        /// </summary>
        public enum SystemLeaveType
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The floater
            /// </summary>
            Floater = 1,
            /// <summary>
            /// The special
            /// </summary>
            Special = 2,
            /// <summary>
            /// The compoff
            /// </summary>
            Compoff = 3
        }


        /// <summary>
        /// BorderEdge
        /// </summary>
        public enum BorderEdge
        {
            /// <summary>
            /// All
            /// </summary>
            All,
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The right
            /// </summary>
            Right,
            /// <summary>
            /// The top
            /// </summary>
            Top,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom
        }

        /// <summary>
        /// Section
        /// </summary>
        public enum Section
        {
            /// <summary>
            /// The side menu
            /// </summary>
            SideMenu,
            /// <summary>
            /// The dashboard
            /// </summary>
            Dashboard,
            /// <summary>
            /// The unknown
            /// </summary>
            Unknown,
            /// <summary>
            /// The time sheet
            /// </summary>
            TimeSheet,
            /// <summary>
            /// The time off
            /// </summary>
            TimeOff,
            /// <summary>
            /// The holidays
            /// </summary>
            Holidays,
            /// <summary>
            /// The employee hub
            /// </summary>
            EmployeeHub,
            /// <summary>
            /// The employee profile
            /// </summary>
            EmployeeProfile,
            /// <summary>
            /// The clockin
            /// </summary>
            Clockin,
            /// <summary>
            /// The pay slip
            /// </summary>
            PaySlip,
            /// <summary>
            /// The pay slip detail
            /// </summary>
            PaySlipDetail,
            /// <summary>
            /// Me
            /// </summary>
            Me,
            /// <summary>
            /// The team
            /// </summary>
            Team,
            /// <summary>
            /// The company
            /// </summary>
            Company,
            /// <summary>
            /// The leave calendar
            /// </summary>
            LeaveCalendar
        }

        /// <summary>
        /// Enum DayOff
        /// </summary>
        public enum DayFrequencyType
        {
            /// <summary>
            /// All
            /// </summary>
            All = 0,
            /// <summary>
            /// The first
            /// </summary>
            First = 1,
            /// <summary>
            /// The second
            /// </summary>
            Second = 2,
            /// <summary>
            /// The third
            /// </summary>
            Third = 3,
            /// <summary>
            /// The fourth
            /// </summary>
            Fourth = 4,
            /// <summary>
            /// The fifth
            /// </summary>
            Fifth = 5,
            /// <summary>
            /// The odd
            /// </summary>
            Last = 6,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DownloadItemType
        {
            /// <summary>
            /// The employees
            /// </summary>
            Employees,
            /// <summary>
            /// The holidays
            /// </summary>
            Holidays,
            /// <summary>
            /// The time sheets
            /// </summary>
            TimeSheets,
            /// <summary>
            /// The projects
            /// </summary>
            Projects,
            /// <summary>
            /// The clients
            /// </summary>
            Clients,
        }

        /// <summary>
        /// Enum AttendanceRequestStatus
        /// </summary>
        public enum AttendanceRequestStatus
        {
            /// <summary>
            /// The none
            /// </summary>
            [Description(Title = "None")]
            None = 0,
            /// <summary>
            /// The pending
            /// </summary>
            [Description(Title = "Pending for Approval")]
            Pending = 1,
            /// <summary>
            /// The approved
            /// </summary>
            [Description(Title = "Approved")]
            Approved = 2,
            /// <summary>
            /// The rejected
            /// </summary>
            [Description(Title = "Rejected")]
            Rejected = 3,
            /// <summary>
            /// The cancelled
            /// </summary>
            [Description(Title = "Cancelled")]
            Cancelled = 4,

            /// <summary>
            /// The partially approved
            /// </summary>
            [Description(Title = "Partially Approved")]
            PartiallyApproved = 5
        }

        /// <summary>
        /// Manual Clock-in Type
        /// </summary>
        public enum ManualClockinType
        {
            [Description(Title = "None")]
            None = 0,
            [Description(Title = "WEB CLOCK IN")]
            WebClockIn,
            [Description(Title = "ADJUSTMENT ATTENDANCE")]
            Adjustment,
            [Description(Title = "REMOTE CLOCK IN")]
            RemoteClockin,
            [Description(Title = "WFH FULL DAY")]
            FullDayWFH,
            [Description(Title = "WFH FIRST HALF")]
            FirstHalfWFH,
            [Description(Title = "WFH SECOND HALF")]
            SecondHalfWFH,
            [Description(Title = "FORGOT ID ")]
            ForgotIdCard,
            [Description(Title = "LOCATION PUNCH")]
            LocationPunch,
            [Description(Title = "ON DUTY FULL DAY")]
            FullDayOnDuty,
            [Description(Title = "ON DUTY FIRST HALF")]
            FirstHalfOnDuty,
            [Description(Title = "ON DUTY SECOND HALF")]
            SecondHalfOnDuty
        }

        /// <summary>
        /// Enum AttendanceRequestType
        /// </summary>
        public enum AttendanceRequestType
        {


            /// <summary>
            /// The office
            /// </summary>
            [Description(Title = "Office")]
            Office = 0,
            /// <summary>
            /// The web
            /// </summary>
            [Description(Title = "Web")]
            Web,
            /// <summary>
            /// Work from home full day
            /// </summary>
            [Description(Title = "WFH Full Day")]
            WFH,
            /// <summary>
            /// The WFH first half
            /// </summary>
            [Description(Title = "WFH First Half")]
            WFHFirstHalf,
            /// <summary>
            /// The WFH second half
            /// </summary>
            [Description(Title = "WFH Second Half")]
            WFHSecondHalf,
            /// <summary>
            /// The attendance adjustment
            /// </summary>
            [Description(Title = "Attendance Adjustment")]
            AttendanceAdjustment,
            /// <summary>
            /// The remote clock in
            /// </summary>
            [Description(Title = "Remote Clock-In")]
            RemoteClockIn,

            /// <summary>
            /// Forget Id Card
            /// </summary>
            [Description(Title = "Forgot Id")]
            ForgotIDCard,


            [Description(Title = "On Duty")]
            OnDuty, // N/A in app





            [Description(Title = "On Duty First Half")]
            OnDutyFirstHalf, // N/A in app
            [Description(Title = "OnDuty Second Half")]
            OnDutySecondHalf

        }

        /// <summary>
        /// Enum ClockedStatus
        /// </summary>
        public enum ClockedStatus
        {
            /// <summary>
            /// The clocked in
            /// </summary>
            ClockedIn = 0,
            /// <summary>
            /// The clocked out
            /// </summary>
            ClockedOut = 1
        }

        /// <summary>
        /// Enum SwipeStatus
        /// </summary>
        public enum SwipeStatus
        {
            /// <summary>
            /// The full swipe
            /// </summary>
            FullSwipe,
            /// <summary>
            /// The swipe in missing
            /// </summary>
            SwipeInMissing,
            /// <summary>
            /// The swipe out missing
            /// </summary>
            SwipeOutMissing
        }

        /// <summary>
        /// Attendance modification status
        /// </summary>
        public enum AttendanceModificationStatus
        {
            /// <summary>
            /// The none
            /// </summary>
            [Description(Title = "")]
            None = 0,

            /// <summary>
            /// The request to modify
            /// </summary>
            [Description(Title = "Request to modify")]
            RequestToModify,

            /// <summary>
            /// The request to add
            /// </summary>
            [Description(Title = "Request to add")]
            RequestToAdd,

            /// <summary>
            /// The request to delete
            /// </summary>
            [Description(Title = "Request to delete")]
            RequestToDelete,

            /// <summary>
            /// The request to add web log
            /// </summary>
            [Description(Title = "Request to add web log")]
            RequestToAddWebLog,

            /// <summary>
            /// The request to add remote log
            /// </summary>
            [Description(Title = "Request to add remote log")]
            RequestToAddRemoteLog
        }

        /// <summary>
        /// ExceptionType
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// The ip outof range exception
            /// </summary>
            IPOutofRangeException,
        }

        /// <summary>
        /// Month
        /// </summary>
        public enum Month
        {
            /// <summary>
            /// The january
            /// </summary>
            [Description(Title = "Jan")]
            January = 1,
            /// <summary>
            /// The february
            /// </summary>
            [Description(Title = "Feb")]
            February = 2,
            /// <summary>
            /// The march
            /// </summary>
            [Description(Title = "Mar")]
            March = 3,
            /// <summary>
            /// The april
            /// </summary>
            [Description(Title = "Apr")]
            April = 4,
            /// <summary>
            /// The may
            /// </summary>
            [Description(Title = "May")]
            May = 5,
            /// <summary>
            /// The june
            /// </summary>
            [Description(Title = "Jun")]
            June = 6,
            /// <summary>
            /// The july
            /// </summary>
            [Description(Title = "Jul")]
            July = 7,
            /// <summary>
            /// The august
            /// </summary>
            [Description(Title = "Aug")]
            August = 8,
            /// <summary>
            /// The september
            /// </summary>
            [Description(Title = "Sep")]
            September = 9,
            /// <summary>
            /// The october
            /// </summary>
            [Description(Title = "Oct")]
            October = 10,
            /// <summary>
            /// The november
            /// </summary>
            [Description(Title = "Nov")]
            November = 11,
            /// <summary>
            /// The december
            /// </summary>
            [Description(Title = "Dec")]
            December = 12
        }

        /// <summary>
        /// Salary head type. model script file mimics the same components type. If updated here need to update model script too.
        /// </summary>
        public enum SalaryComponentType
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The allowance
            /// </summary>
            Allowance = 1,
            /// <summary>
            /// The contribution
            /// </summary>
            Contribution = 2,
            /// <summary>
            /// The adhoc
            /// </summary>
            Adhoc = 3,
            /// <summary>
            /// The reimbursement
            /// </summary>
            Reimbursement = 4,
            /// <summary>
            /// The tax
            /// </summary>
            Tax = 5,
            /// <summary>
            /// The fixed
            /// </summary>
            Fixed = 6,
            /// <summary>
            /// The arrear
            /// </summary>
            Arrear = 7,
            /// <summary>
            /// The deduction
            /// </summary>
            Deduction = 8,
            /// <summary>
            /// The reimbursable
            /// </summary>
            Reimbursable = 9,
            /// <summary>
            /// The others
            /// </summary>
            Others = 50,
        }

        /// <summary>
        /// How did the payroll record get created.
        /// </summary>
        public enum PayRecordItemSource
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The regular payroll processing
            /// </summary>
            RegularPayrollProcessing = 0,
            /// <summary>
            /// The adhoc adjustment
            /// </summary>
            AdhocAdjustment = 1
        }

        /// <summary>
        /// 
        /// </summary>
        public enum Platform
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The android
            /// </summary>
            Android,
            /// <summary>
            /// The ios
            /// </summary>
            IOS,
            /// <summary>
            /// The windows phone
            /// </summary>
            WindowsPhone
        }

        /// <summary>
        /// Enum CreditSource
        /// </summary>
        public enum CreditSource
        {
            /// <summary>
            /// The compoff
            /// </summary>
            Compoff = 0,
            /// <summary>
            /// The automatic
            /// </summary>
            Auto = 1,
            /// <summary>
            /// The excel import summary
            /// </summary>
            ExcelImportSummary = 2,
            /// <summary>
            /// The excel import carryover
            /// </summary>
            ExcelImportCarryover = 3
        }

        /// <summary>
        /// Enum LeaveStatus
        /// </summary>
        public enum LeaveStatus
        {
            /// <summary>
            /// The pending
            /// </summary>
            Pending = 0, // Leave has not been consumed. Will be consumed in future.
                         /// <summary>
                         /// The cancelled
                         /// </summary>
            Cancelled = 1, // Leave was canceled most probably due to leave request cancellation.
                           /// <summary>
                           /// The consumed
                           /// </summary>
            Consumed = 2, // Leaves have been consumed.
        }

        /// <summary>
        /// Enum SpecialDays
        /// </summary>
        public enum SpecialDays
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The birth day
            /// </summary>
            BirthDay,
            /// <summary>
            /// The marriage anniversary
            /// </summary>
            MarriageAnniversary,
            /// <summary>
            /// The joining day
            /// </summary>
            JoiningDay
        }

        /// <summary>
        /// Enum TimeDuration
        /// </summary>
        public enum TimeDuration
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The hours
            /// </summary>
            Hours,
            /// <summary>
            /// The days
            /// </summary>
            Days,
            /// <summary>
            /// The weeks
            /// </summary>
            Weeks,
            /// <summary>
            /// The months
            /// </summary>
            Months,
        }

        /// <summary>
        /// Enum LeaveAccrualRate
        /// </summary>
        public enum LeaveAccrualRate
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The monthly
            /// </summary>
            Monthly,
            /// <summary>
            /// The quarterly
            /// </summary>
            Quarterly,
            /// <summary>
            /// The half yearly
            /// </summary>
            HalfYearly,
            /// <summary>
            /// The semi monthly
            /// </summary>
            SemiMonthly
        }

        /// <summary>
        /// Enum CarryOverType
        /// </summary>
        public enum CarryOverType
        {
            /// <summary>
            /// All leaves expire
            /// </summary>
            AllLeavesExpire = 0,
            /// <summary>
            /// The pay and carry
            /// </summary>
            PayAndCarry,
            /// <summary>
            /// The carry and pay
            /// </summary>
            CarryAndPay
        }

        /// <summary>
        /// Enum LeavesLimit
        /// </summary>
        public enum LeavesLimit
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The accrued balance
            /// </summary>
            AccruedBalance,
            /// <summary>
            /// The yearly limit
            /// </summary>
            YearlyLimit,
            /// <summary>
            /// The no limit
            /// </summary>
            NoLimit
        }

        /// <summary>
        /// Enum WorkerType
        /// </summary>
        public enum WorkerType
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The permanent
            /// </summary>
            Permanent,
            /// <summary>
            /// The contract
            /// </summary>
            Contract
        }

        /// <summary>
        /// Enum TimeType
        /// </summary>
        public enum TimeType
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The full time
            /// </summary>
            FullTime,
            /// <summary>
            /// The part time
            /// </summary>
            PartTime
        }

        /// <summary>
        /// Enum TerminationType
        /// </summary>
        public enum TerminationType
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The employee resignation
            /// </summary>
            EmployeeResignation,
            /// <summary>
            /// The retirement
            /// </summary>
            Retirement,
            /// <summary>
            /// The involuntary
            /// </summary>
            Involuntary,
            /// <summary>
            /// The end of contract
            /// </summary>
            EndOfContract,
            /// <summary>
            /// The death
            /// </summary>
            Death,
            /// <summary>
            /// The abandonment
            /// </summary>
            Abandonment
        }

        /// <summary>
        /// Enum ExitStatus
        /// </summary>
        public enum ExitStatus
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The initiated
            /// </summary>
            Initiated,
            /// <summary>
            /// The completed
            /// </summary>
            Completed
        }

        /// <summary>
        /// Enum EmploymentStatus
        /// </summary>
        public enum EmploymentStatus
        {
            /// <summary>
            /// The working
            /// </summary>
            Working,
            /// <summary>
            /// The relieved
            /// </summary>
            Relieved
        }

        /// <summary>
        /// Enum Remote Clock-in Approval Type
        /// </summary>
        public enum RemoteClockInApprovalType
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The approval required
            /// </summary>
            ApprovalRequired,
            /// <summary>
            /// The approval not required
            /// </summary>
            ApprovalNotRequired,
            /// <summary>
            /// The require notify
            /// </summary>
            RequireNotify
        }



        /// <summary>
        /// MesureMent
        /// </summary>
        public enum MesureMent
        {
            /// <summary>
            /// The miles
            /// </summary>
            Miles = 0,
            /// <summary>
            /// </summary>
            Kms = 1
        }

        /// <summary>
        /// NatureOfExpense
        /// </summary>
        public enum NatureOfExpense
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The general
            /// </summary>
            General = 1,
            /// <summary>
            /// The mileage
            /// </summary>
            Mileage = 2,

            /// <summary>
            /// The per diem
            /// </summary>
            PerDiem = 3
        }

        /// <summary>
        /// Mileage Unit
        /// </summary>
        public enum MileageUnit
        {
            [Description(Title = "KM")]
            KM = 0,
            [Description(Title = "Mile")]
            Mi = 1
        }

        /// <summary>
        /// ExpenseStatus
        /// </summary>
        public enum ExpenseStatus
        {
            /// <summary>
            /// The not submitted
            /// </summary>
            NotSubmitted = 0,
            /// <summary>
            /// The submitted
            /// </summary>
            Submitted = 1,
            /// <summary>
            /// The approved
            /// </summary>
            Approved = 2,
            /// <summary>
            /// The rejected
            /// </summary>
            Rejected = 3,
            /// <summary>
            /// The none
            /// </summary>
            None = 4
        }

        /// <summary>
        /// ReportStatus
        /// </summary>
        public enum ReportStatus
        {
            /// <summary>
            /// The open
            /// </summary>
            Open = 0,
            /// <summary>
            /// The submitted
            /// </summary>
            Submitted = 1,
            /// <summary>
            /// The closed
            /// </summary>
            Closed = 2
        }

        /// <summary>
        /// Employee claim status
        /// </summary>
        public enum ExpenseClaimStatus
        {
            /// <summary>
            /// The none
            /// </summary>
            [Description(Title = "None")]
            None = 0,
            /// <summary>
            /// The pending
            /// </summary>
            [Description(Title = "Not Submitted")]
            Pending = 1,
            /// <summary>
            /// The submitted
            /// </summary>
            [Description(Title = "Waiting for Approval")]
            Submitted = 2,
            /// <summary>
            /// The approved
            /// </summary>
            [Description(Title = "Approved")]
            Approved = 3,
            /// <summary>
            /// The rejected
            /// </summary>
            [Description(Title = "Rejected")]
            Rejected = 4,
            /// <summary>
            /// The paid
            /// </summary>
            [Description(Title = "Paid")]
            Paid = 5
        }

        /// <summary>
        /// Enum BlobContainers
        /// </summary>
        public enum BlobContainers
        {
            /// <summary>
            /// The profile image
            /// </summary>
            ProfileImage = 0,
            /// <summary>
            /// The documents
            /// </summary>
            Documents,
            /// <summary>
            /// The excel uploads
            /// </summary>
            ExcelUploads,
            /// <summary>
            /// The tax bills
            /// </summary>
            TaxBills,
            /// <summary>
            /// The engage
            /// </summary>
            Engage,
            /// <summary>
            /// The org logo
            /// </summary>
            OrgLogo,
            /// <summary>
            /// The expense receipts
            /// </summary>
            ExpenseReceipts
        }

        /// <summary>
        /// Enum menu icon
        /// </summary>
        public enum MenuIcon
        {
            /// <summary>
            /// Home
            /// </summary>
            ic_home_white,
            /// <summary>
            /// Clock Time
            /// </summary>
            clock_2x,
            /// <summary>
            /// Leave Balance
            /// </summary>
            ic_LeaveRequests,
            /// <summary>
            /// Leave Calendar
            /// </summary>
            ic_Holiday,
            /// <summary>
            /// EmployeeDirectory
            /// </summary>
            ic_dashboard_Apporvals,
            /// <summary>
            /// logout
            /// </summary>
            menu_logout
        }

        /// <summary>
        /// field permission roles
        /// </summary>
        public enum FieldPermissionRoles
        {
            None = 0,
            Self = 1,
            ReportingManagerAndUp = 2,
            EveryOne = 3
        }

        /// <summary>
        /// Field visibility
        /// </summary>
        public enum FieldVisibility
        {
            Read = 0,
            Write,
            Hidden
        }

        /// <summary>
        /// Field approval 
        /// </summary>
        public enum FieldApproval
        {
            NotNeeded = 0,
            FromReportingManager,
            FromReportingManagerOrHRAdmin,
            FromHRAdmin,
        }

        /// <summary>
        /// Field request status
        /// </summary>
        public enum FieldRequestStatus
        {
            None = 0,
            Pending,
            PartiallyApproved,
            Approved,
            Rejected
        }

        /// <summary>
        /// Supported form fields.
        /// </summary>
        public enum FormFieldTypes
        {
            None = 0,
            TextBox = 1,
            TextArea = 2,
            Radio = 3,
            Checkbox = 4,
            Dropdown = 5,
            Currency = 6,
            Date = 7,
            Numeric = 8,
            MultiDropdown = 9,
            Picture = 10,
            Toggle = 11,
            SingleCheckbox = 12,
            Email = 13,
            Time = 14,
            Percentage = 15,
            Folder = 16,
            File = 17,
            Url = 18,
            Attachment = 19,
            Editor = 20,
            DateTime = 21,
        }

        /// <summary>
        /// Supported field types.
        /// </summary>
        public enum FieldTypes
        {
            None = 0,
            Integer = 1,
            Decimal = 2,
            String = 3,
            Boolean = 4,
            Enum = 5,
            DateTime = 6,
            Complex = 50
        }

        /// <summary>
        /// BankAccountType
        /// </summary>
        public enum BankAccountType
        {
            None = 0,
            Current,
            Savings
        }

        /// <summary>
        /// SalaryPaymentMode
        /// </summary>
        public enum SalaryPaymentMode
        {
            None = 0,
            [Description(Title = "Bank Transfer")]
            BankTransfer,
            Cheque,
            Cash
        }

        /// <summary>
        /// PFLeavingReasonType
        /// </summary>
        public enum PFLeavingReasonType
        {
            None = 0,
            Cessation,
            Superannuation,
            Retirement,
            DeathInService,
            PermanentDisablement
        }

        /// <summary>
        /// CompanyType
        /// </summary>
        public enum CompanyType
        {
            publicSector = 0,
            privateLimited,
            LimitedLiability
        }

        /// <summary>
        /// DeductionStatus
        /// </summary>
        public enum DeductionStatus
        {
            None = 0,
            [Description(Title = "Not Submitted")]
            NotSubmitted,
            [Description(Title = "To Be Reviewed")]
            Submitted,
            [Description(Title = "Accepted")]
            Accepted,
            [Description(Title = "Rejected")]
            Rejected,
            [Description(Title = "Auto Accepted")]
            AutoAccepted
        }

        /// <summary>
        /// HouseLoanType
        /// </summary>
        public enum HouseLoanType
        {
            None = 0,
            ConstructionOrPurchase,
            Repair
        }

        /// <summary>
        /// Enum House Loan Type
        /// </summary>
        public enum HouseLoanFor
        {
            None = 0,
            SelfOccupiedProperty,
            LetOutProperty
        }

        /// <summary>
        /// GenerationSource
        /// </summary>
        public enum GenerationSource
        {
            None = 0,
            InsideKeka,
            CurrentEmploymentImport,
            Projected,
            PreviousEmployment,
        }

        /// <summary>
        /// Enum DayType
        /// </summary>
        public enum DayType
        {
            WorkingDay = 0,
            Holiday = 1,
            FullDayWeeklyOff = 2,
            FirstHalfWeeklyOff = 3,
            SecondHalfWeeklyOff = 4,
        }

        /// <summary>
        /// Enum Time entry invoice status
        /// </summary>
        public enum TimeEntryInvoiceStatus
        {
            NotInvoiced = 0,
            Invoiced
        }

        /// <summary>
        /// How often the payroll runs.
        /// </summary>
        public enum PayrollRunFrequency
        {
            None = 0,
            Monthly = 1,
            BiWeekly = 2,
            Weekly = 3
        }

        /// <summary>
        /// Run status of a cycle.
        /// </summary>
        public enum PayrollRunStatus
        {
            NotApplicable = -1, // for cycles before the keka started
            Pending = 0,
            Locked = 1,
            Closed = 2
        }

        /// <summary>
        /// Enum TaskBillingType
        /// </summary>
        public enum TaskBillingType
        {
            [Description(Title = "Non-Billable")]
            NonBillable = 0,
            [Description(Title = "Billable")]
            Billable = 1,
            [Description(Title = "Any")]
            Any = 2
        }

        #region App Side Enums

        /// <summary>
        /// ClockIn Button Status based on Clock In Enabled and Disabled
        /// for ui custom binding
        /// </summary>
        public enum ClockInButtonStatus
        {
            Disabled = 0,
            ClockIn,
            ClockOut
        }

        /// <summary>
        /// PaymentStatus
        /// </summary>
        public enum PaymentStatus
        {
            [Description(Title = "Yet to be paid")]
            YetToBePaid = 0,
            [Description(Title = "Paid Already")]
            PaidAlready
        }
        #endregion
    }
    public class DescriptionAttribute : Attribute
    {
        public string Title { get; set; }
    }

}