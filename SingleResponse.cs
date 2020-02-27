using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Response
{
    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public SingleResponse()
        {
            IsValid = true;
        }
        public string Message { get; set; }

        public bool DidError { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
