using InfraStructure.GenericRepository;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Repository
{
    public class BankRepository : GenericRepository<Models.DomainModels.Bank>
    {
        private readonly EBankingContext _context;
        public BankRepository(EBankingContext context) : base(context)
        {
            _context = context;
        }
    }
}
