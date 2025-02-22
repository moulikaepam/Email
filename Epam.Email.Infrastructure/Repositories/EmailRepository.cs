using Microsoft.EntityFrameworkCore;
using Epam.Email.Domain.Entities;
using Epam.Email.Domain.Repositories;
using Epam.Email.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Epam.Email.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _context;

        public EmailRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Epam.Email.Domain.Entities.Email>> GetAllRegisteredEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }
    }
}
