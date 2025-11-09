using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class RolFormPermissionRepository : DataGeneric<RolFormPermission>, IRolFormPermissionRepository
    {
        public RolFormPermissionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<RolFormPermission>> GetAllAsync()
        {
            return await _context.Set<RolFormPermission>()
                        .Include(rfp => rfp.Rol)
                        .Include(rfp => rfp.Form)
                        .Include(rfp => rfp.Permission)
                        .Where(rfp => rfp.IsDeleted == false)

                        .ToListAsync();
        }

        public override async Task<IEnumerable<RolFormPermission>> GetDeletes()
        {
            return await _context.Set<RolFormPermission>()
                        .Include(rfp => rfp.Rol)
                        .Include(rfp => rfp.Form)
                        .Include(rfp => rfp.Permission)
                        .Where(rfp => rfp.IsDeleted == true)
                        .ToListAsync();
        }

        public override async Task<RolFormPermission?> GetByIdAsync(int id)
        {
            return await _context.Set<RolFormPermission>()
                      .Include(rfp => rfp.Rol)
                      .Include(rfp => rfp.Form)
                      .Include(rfp => rfp.Permission)
                      .FirstOrDefaultAsync(rfp => rfp.Id == id);

        }
    }
}
