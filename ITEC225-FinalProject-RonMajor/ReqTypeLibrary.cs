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

    public class Request : IRequest
    {
        Random rand = new Random();
        public int ReferenceNumber { get; set; }
        public bool ApprovalRequired { get; set; }
        public string? BilingualPosition { get; set; }
        public string? LanguageProfile { get; set; }
        public string? DelegateLabel { get; set; }
        public ApprovalOrder approval { get; set; }
        public VisibilityLevel visLevel { get; set; }
        public Candidate Candidate { get; set; }
        public Position Position { get; set; }

        public Request() { }

        public Request(Candidate candidate, Position position)
        {
            ReferenceNumber = rand.Next(000000, 999999);
            this.Candidate = candidate;
            this.Position = position;
            approval = ApprovalOrder.Draft;
            visLevel = VisibilityLevel.HR; //HR and up can see requests.
            FormTemplate.requests.Add(this); //add this request to requests.
        }
    }

    public class SLERequest : Request //SLERequest inherits from Request.
    {
        //sle stuff.
        public int EquivalencyNumber { get; set; }
        public string Equivalency { get; set; }

        public SLERequest(Candidate candidate, Position position, int equivalencyNumber, string equivalency) : base(candidate, position)
        {
            EquivalencyNumber = equivalencyNumber;
            Equivalency = equivalency;
        }
    }

    public class PriorityClearanceRequest : Request //PC inherits from Request.
    {
        //psc stuff.
        public string PriorityRationale { get; set; }
        public int PriorityNumber { get; set; }

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
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string OfficeLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public VisibilityLevel VisLevel { get; set; }
        #endregion

        public Candidate() { } //parameterless constructor required by JSON serializer.

        public Candidate(int emplNum, string last, string first)
        {
            EmployeeNum = emplNum; //feed data into the Candidate.
            LastName = last;
            FirstName = first;
            DisplayName = $"{last}, {first}";
            VisLevel = VisibilityLevel.Manager;
            FormTemplate.candidates.Add(this); //add this to candidates list.
        }
    }

    public class Position : IPosition
    {
        public int PosNum { get; set; } //implement bits of the interface.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DisplayName { get; set; }
        public VisibilityLevel VisLevel { get; set; }
        public PositionType PositionType { get; set; }
        public SubType SubType { get; set; }
        public string Directorate { get; set; }
        public string OfficeLocation { get; set; }

        public Position() { }

        public Position(int posiNum, DateTime startDate)
        {
            PosNum = posiNum;
            StartDate = startDate;
            DisplayName = $"{posiNum} - {PositionType}";
            //position control receives position, and therefore it's properties.
            VisLevel = VisibilityLevel.Client; //anyone can see positions.
            FormTemplate.positions.Add(this);
        }
    }

}
