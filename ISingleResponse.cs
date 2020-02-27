using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Response
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
