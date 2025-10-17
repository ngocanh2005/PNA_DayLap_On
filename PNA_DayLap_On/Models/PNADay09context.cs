using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
namespace PNA_DayLap_On.Models
{
    public class PNADay09context : DbContext
    {
        public PNADay09context(DbContextOptions<PNADay09context> options) : base(options)
        {
        }
        public DbSet<pna_LoaiSanPham> pna_LoaiSanPhams { get; set; }
        public DbSet<pna_SanPham> pna_SanPhams { get; set; }

    }
}
