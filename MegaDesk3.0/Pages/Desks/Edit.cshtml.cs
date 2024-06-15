using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDesk3._0.Data;
using MegaDesk3._0.Models;

namespace MegaDesk3._0.Pages.Desks
{
    public class EditModel : PageModel
    {
        private readonly MegaDesk3._0.Data.MegaDesk3_0Context _context;

        public EditModel(MegaDesk3._0.Data.MegaDesk3_0Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Desk Desk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desk =  await _context.Desk.FirstOrDefaultAsync(m => m.Id == id);
            if (desk == null)
            {
                return NotFound();
            }
            Desk = desk;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Desk.Price = CalculatePrice(Desk.Width,Desk.Height,Desk.Drawers,Desk.Material,Desk.Rush);

            _context.Attach(Desk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskExists(Desk.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskExists(int id)
        {
            return _context.Desk.Any(e => e.Id == id);
        }

        private decimal CalculatePrice(int width, int height, int drawers, string material, int rush)
        {
            decimal price = 200;
            int surfaceArea = width * height;
            if (surfaceArea > 1000)
            {
                price += surfaceArea % 1000;
            }
            price += drawers * 50;
            switch (material)
            {
                case "Oak":
                    price += 200;
                    break;
                case "Laminate":
                    price += 100;
                    break;
                case "Pine":
                    price += 50;
                    break;
                case "Rosewood":
                    price += 300;
                    break;
                case "Veneer":
                    price += 125;
                    break;
            }
            switch (rush)
            {
                case 3:
                    if (surfaceArea < 1000)
                    {
                        price += 60;
                    }
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                    {
                        price += 70;
                    }
                    else
                    {
                        price += 80;
                    }
                    break;
                case 5:
                    if (surfaceArea < 1000)
                    {
                        price += 40;
                    }
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                    {
                        price += 50;
                    }
                    else
                    {
                        price += 60;
                    }
                    break;
                case 7:
                    if (surfaceArea < 1000)
                    {
                        price += 30;
                    }
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                    {
                        price += 35;
                    }
                    else
                    {
                        price += 40;
                    }
                    break;
            }
            return price;
        }
    }
}
