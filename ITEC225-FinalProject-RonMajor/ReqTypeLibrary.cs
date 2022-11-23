using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    [Serializable]
    internal static class FormTemplate
    {

        #region Static
        public static List<Request> requests = new List<Request>();
        public static List<Candidate> candidates = new List<Candidate>(); //all static lists which persist across whole app.
        public static List<Position> positions = new List<Position>();
        public static List<User> users = new List<User>();

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

    internal class Request : IRequestForm
    {
        public string? FormName { get; set; }
        public string? DelegateLabel { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int OrderNumber { get; set; }

        public Request()
        {

        }
    }

    internal class SLERequest : Request //SLERequest inherits from Request.
    {
        //sle stuff.
    }

    internal class PriorityClearanceRequest : Request //PC inherits from Request.
    {
        //psc stuff.
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

        public Candidate()
        {

            ICandidate.Candidates = new();
            VisLevel = VisibilityLevel.Manager;

        }
    }

    internal class Position : IPosition
    {
        public int PosNum { get; set; } //implement bits of the interface.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VisibilityLevel VisLevel { get; set; }
        public PositionType PositionType { get; set; }
        public SubType SubType { get; set; }


        public Position()
        {

        }
    }

}
