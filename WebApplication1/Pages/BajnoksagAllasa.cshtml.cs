using FociWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLitePCL;

namespace FociWebApp.Pages
{
    public class BajnoksagAllasaModel : PageModel
    {private readonly FociDbContext _context;
        public BajnoksagAllasaModel(FociDbContext context)
        {
            _context = context;
        }
        public List<Meccs> meccsek;
        public List<CsapatEredmenyei> csapatEredmenyei;
        public void OnGet()
        {

            meccsek = _context.Meccsek.ToList();
            csapatEredmenyei = new List<CsapatEredmenyei>();
            foreach (var cs in meccsek.Select(x => x.HazaiCsapat).Distinct())
            {
                CsapatEredmenyei ujcsapat = new CsapatEredmenyei();
                ujcsapat.CsapatNev = cs;
                csapatEredmenyei.Add(ujcsapat);
            }
            foreach (var cs in csapatEredmenyei)
            {
                cs.GyozelmekSzama = meccsek.Where(x => x.GyoztesCsapatNeve() == cs.CsapatNev).Count();
                cs.GyozelmekSzama = meccsek.Where(x => (x.HazaiCsapat == cs.CsapatNev || x.VendegCsapat == cs.CsapatNev) && x.GyoztesCsapatNeve() != "").Count();
            }
        }
    }
}
