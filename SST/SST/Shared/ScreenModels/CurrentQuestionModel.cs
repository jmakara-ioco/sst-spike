using System;
using System.Collections.Generic;
using System.Text;

namespace SST.Shared
{
    public class CurrentQuestionModel
    {
        public Guid ContractTypeID { get; set; }
        public Guid? NextQuestionID { get; set; }
        public Guid? QuestionID { get; set; }
        public Guid FirmID { get; set; }
    }
}
