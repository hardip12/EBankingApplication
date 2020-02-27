
using Models.DomainModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomain.Interface
{
    public interface ICustomerDetails
    {
        bool ValidateEmailId(string enterpriseId);
        bool ValidateExistingEmailId(string enterpriseId);
        
        Task<bool> SaveCustomerDetails(CustomerViewModel data);
    }
}
