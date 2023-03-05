using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Services
{
    internal sealed class SqlServerPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public SqlServerPackingListReadService(ReadDbContext context)
            => _packingList = context.PackingLists;

        public Task<bool> ExistsByNameAsync(string name)
            => _packingList.AnyAsync(pl => pl.Name == name);
    }
}
