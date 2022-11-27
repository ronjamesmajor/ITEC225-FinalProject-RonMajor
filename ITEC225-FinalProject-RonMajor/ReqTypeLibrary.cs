using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ITEC225_FinalProject_RonMajor.IRequest;

namespace ITEC225_FinalProject_RonMajor
{
    [Serializable]
    internal static class FormTemplate
    {

        #region Static
        public static List<Request> requests = new();
        public static List<Candidate> candidates = new(); //all static lists which persist across whole app.
        public static List<Position> positions = new();
        public static List<User> users = new();
        public static List<Administrator> administrators = new();
        public static List<Manager> managers = new();
        public static List<HR> hRs = new();
        public static List<Client> clients = new();

        #endregion
        #region Fields

        #endregion
        #region Properties

        #endregion
        #region Constructors

        #endregion
        #region Methods

        //SaveRequest()
        //SaveCandidates()
        //SavePositions()
        #endregion

    }

    public class ReqTypeLibrary
    {
    }

    internal class Request : IRequest
    {
        public string RequestID { get; set; }
        public string? FormName { get; set; }
        public string? DelegateLabel { get; set; }
        public ApprovalOrder approval { get; set; }
        public VisibilityLevel visLevel { get; set; }

        public Request(Candidate candidate, Position position)
        {
            approval = ApprovalOrder.Draft;
            visLevel = VisibilityLevel.HR; //HR and up can see requests.
        }
    }

    internal class SLERequest : Request //SLERequest inherits from Request.
    {
        //sle stuff.
        public SLERequest(Candidate candidate, Position position) : base(candidate,position)
        {
            //go!
        }
    }

    internal class PriorityClearanceRequest : Request //PC inherits from Request.
    {
        //psc stuff.
        public PriorityClearanceRequest(Candidate candidate, Position position) : base(candidate, position)
        {
            //go!
        }
    }

    public class Candidate : ICandidate
    {
        #region Properties
        public int EmployeeNum { get; set; } //Use all properties of interface.
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string OfficeLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public VisibilityLevel VisLevel { get; set; }
        #endregion

        public Candidate(int emplNum, string last, string first)
        {
            EmployeeNum = emplNum; //feed data into the Candidate.
            LastName = last;
            FirstName = first;
            ICandidate.Candidates = new();
            VisLevel = VisibilityLevel.Manager;
            FormTemplate.candidates.Add(this); //add this to candidates list.
        }
    }

    public class Position : IPosition
    {
        public int PosNum { get; set; } //implement bits of the interface.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VisibilityLevel VisLevel { get; set; }
        public PositionType PositionType { get; set; }
        public SubType SubType { get; set; }
        public string Directorate { get; set; }
        public string OfficeLocation { get; set; }
        public VisibilityLevel visLevel { get; set; }


        public Position(int posiNum, DateTime startDate)
        {
            PosNum = posiNum;
            StartDate = startDate;
            //position control receives position, and therefore it's properties.
            FormTemplate.positions.Add(this);
            visLevel = VisibilityLevel.Client; //anyone can see positions.
        }
    }

}
