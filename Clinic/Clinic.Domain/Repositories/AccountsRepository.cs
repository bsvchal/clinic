using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;

namespace Clinic.Domain.Repositories;

public class AccountsRepository : BaseRepository<Account>, IAccountsRepository
{
    public AccountsRepository(ClinicDbContext clinicDbContext)
        : base(clinicDbContext)
    {
    }
}
