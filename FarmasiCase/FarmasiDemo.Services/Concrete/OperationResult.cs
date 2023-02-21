using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Services.Concrete
{
    public enum OperationResultType
    {
        ERROR = 0,
        SUCCESS = 1,
        WARNING = 2,
        INFO = 3
    }

    public class OperationResult
    {
        public OperationResultType ResultType { get; set; }
        public string ResultTitle { get; set; }
        public string ResultText { get; set; }
        public OperationResult(OperationResultType resultType)
        {
            ResultType = resultType;
        }
        public OperationResult(OperationResultType resultType, string resultText, string resultTitle)
        {
            ResultType = resultType;
            ResultText = resultText;
            ResultTitle = resultTitle;
        }
    }

    public class OperationResult<TDto> : OperationResult
    {
        public OperationResult(OperationResultType resultType) : base(resultType) { }
        public OperationResult(OperationResultType resultType, string resultText, string resultTitle) : base(resultType, resultText, resultTitle) { }
        public TDto EntityDto { get; set; }
        public List<TDto> EntityListDto { get; set; }
    }
}
