using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal interface IRequest
    {
        //enum for approval order for requests.
        enum ApprovalOrder {Draft, AwaitingManager, AwaitingAdmin, Complete, Deleted}

        #region Properties
        public bool ApprovalRequired { get; set; }
        public ApprovalOrder approval { get; set; }
        public string BilingualPosition { get; set; }
        public string LanguageProfile { get; set; }
       
        #endregion

    }
}
