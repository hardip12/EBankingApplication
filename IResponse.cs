using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Response
{
    public interface IResponse
    {
        string Message { get; set; }
        bool DidError { get; set; }

        bool IsValid { get; set; }
        string ErrorMessage { get; set; }
    }
}
