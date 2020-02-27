using BusinessDomain.Interface;
using InfraStructure.EBankingUnitOfWork;
using Models.DomainModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomain.Concrete
{
    public class CustomerDetailsConcrete :ICustomerDetails
    {
        private EbankingUnitOfWork _canUnitOfWork;
        public CustomerDetailsConcrete(EbankingUnitOfWork ebankingUnitOfWork)
        {
            _canUnitOfWork = ebankingUnitOfWork;
        }
        public bool ValidateEmailId(string enterpriseId)
        {
            bool NotUnique = _canUnitOfWork.CustomerRepo.Get(x => x.EmailId == enterpriseId).Select(x => x.EmailId).Count() > 0;
            
            if (!NotUnique)
            {
                return false;
            }
                                        
            return NotUnique;
        }
        public bool ValidateExistingEmailId(string enterpriseId)
        {
            bool Unique = _canUnitOfWork.CustomerRepo.Get(x => x.EmailId == enterpriseId).Select(x => x.EmailId).Count() > 0;

            if (!Unique)
            {
                return true;
            }

            return false;
        }
        
        public async Task<bool> SaveCustomerDetails(CustomerViewModel data)
        {
            DateTime currentDate = DateTime.UtcNow;
            //var emailid = _canUnitOfWork.CustomerRepo.Get(x => x.EmailId.Equals(data.email)).Select(x => x.EmailId).ToString();
            //var password = _canUnitOfWork.CustomerRepo.Get(x => x.Password.Equals(data.password)).Select(x => x.Password).ToString();
            Customer c = new Customer();
            c.CreatedOn = currentDate;
            c.EmailId = data.email;
            c.Password = data.password;
            c.ModifiedOn = currentDate;
            _canUnitOfWork.CustomerRepo.Insert(c);
            return _canUnitOfWork.SaveChanges();
        }
    }
}
