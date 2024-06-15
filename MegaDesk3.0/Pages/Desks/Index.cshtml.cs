using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk3._0.Data;
using MegaDesk3._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace MegaDesk3._0.Pages.Desks
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk3._0.Data.MegaDesk3_0Context _context;

        public IndexModel(MegaDesk3._0.Data.MegaDesk3_0Context context)
        {
            _context = context;
        }

        public IList<Desk> Desk { get;set; } = default!;

        //Adding search for customer name
        [BindProperty(SupportsGet = true)]
        public string? SearchName { get; set; }

        //For sorting
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        

        public async Task OnGetAsync(string sortOrder)
        {
            // Adding sorting
            CurrentSort = sortOrder;
            NameSort = sortOrder == "name" ? "name_desc" : "name";
            DateSort = sortOrder == "date" ? "date_desc" : "date";
            // 


            var desks = from d in _context.Desk
                         select d;

            // Adding sorting
            switch (sortOrder)
            {
                case "name_desc":
                    desks = desks.OrderByDescending(d => d.Name);
                    break;
                case "name":
                    desks = desks.OrderBy(d => d.Name);
                    break;
                case "date_desc":
                    desks = desks.OrderByDescending(d => d.Date);
                    break;
                case "date":
                default:
                    desks = desks.OrderBy(d => d.Date);
                    break;
            }
            //


            if (!string.IsNullOrEmpty(SearchName))
            {
                desks = desks.Where(d => d.Name.Contains(SearchName));
            }

            Desk = await desks.ToListAsync();
        }
    }
}
