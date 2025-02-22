using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Email.Domain.Entities;


namespace Epam.Email.Domain.Repositories
{

    public interface IEmailRepository
    {
        Task<List<Epam.Email.Domain.Entities.Email>> GetAllRegisteredEmailsAsync();
    }
}
