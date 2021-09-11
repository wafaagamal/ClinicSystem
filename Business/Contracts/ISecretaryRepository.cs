using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface ISecretaryRepository :IRepository<Secretary>
    {
        void ResgisterSecretary(Secretary secretary);
        Secretary LoginSecretary(string email, string password);
        Secretary getByEmail(string email);
    }
}
