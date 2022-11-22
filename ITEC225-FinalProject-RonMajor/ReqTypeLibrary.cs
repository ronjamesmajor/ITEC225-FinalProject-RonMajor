using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal static class FormTemplate
    {

        #region Static
        public static List<Request> requests = new List<Request>();
        public static List<Candidate> candidates = new List<Candidate>(); //all static lists which persist across whole app.
        public static List<Position> positions = new List<Position>();

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
}
