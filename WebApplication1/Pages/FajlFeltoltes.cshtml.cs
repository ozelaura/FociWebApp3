using FociWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FajlFeltolteseSzerverre.Pages
{
    public class FajlFeltoltesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly FociDbContext _context;
        [BindProperty]

        public IFormFile Feltoltes { get; set; }

        public FajlFeltoltesModel(IWebHostEnvironment env, FociDbContext context)
        {
            _env = env;
            _context = context;

        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Feltoltes == null || Feltoltes.Length == 0)
            {
                ModelState.AddModelError("Feltoltes", "Válassz ki egy állományt!");
                return Page();
            }
            var FeltoltesiKonyvtar = Path.Combine(_env.ContentRootPath, "uploads");
            var FeltoltendoAllomanyPath = Path.Combine(FeltoltesiKonyvtar, Feltoltes.FileName);

            using (var stream = new FileStream(FeltoltendoAllomanyPath, FileMode.Create))
            {
                await Feltoltes.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(FeltoltendoAllomanyPath);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var sor = sr.ReadLine();
                var elemek = sor.Split();
                Meccs ujMeccs = new Meccs();
                ujMeccs.Fordulo = int.Parse(elemek[0]);
                //...



                _context.Meccsek.Add(ujMeccs);
            }

            sr.Close();
            _context.SaveChanges();

            return Page();
        }
    }
}

