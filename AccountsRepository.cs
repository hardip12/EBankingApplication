
using InfraStructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;


namespace InfraStructure.Repository
{
    public class AccountsRepository: GenericRepository<Models.DomainModels.Accounts>
    {
        private readonly EBankingContext _context;
        public AccountsRepository(EBankingContext context) : base(context)
        {
            _context = context;
        }
    }
}
