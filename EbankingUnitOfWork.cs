using InfraStructure.Repository;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.EBankingUnitOfWork
{
    public class EbankingUnitOfWork :UnitOfWork
    {
        public EbankingUnitOfWork(EBankingContext context) : base(context)
        {
        }
        public CustomerDetailsRepository CustomerDetailsRepo
        {
            get
            {
                return new CustomerDetailsRepository(_context);
            }
        }
        public CustomerRepository CustomerRepo
        {
            get
            {
                return new CustomerRepository(_context);
            }
        }
    }
}
