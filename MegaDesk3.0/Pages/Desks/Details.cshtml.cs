﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk3._0.Data;
using MegaDesk3._0.Models;

namespace MegaDesk3._0.Pages.Desks
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDesk3._0.Data.MegaDesk3_0Context _context;

        public DetailsModel(MegaDesk3._0.Data.MegaDesk3_0Context context)
        {
            _context = context;
        }

        public Desk Desk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desk = await _context.Desk.FirstOrDefaultAsync(m => m.Id == id);
            if (desk == null)
            {
                return NotFound();
            }
            else
            {
                Desk = desk;
            }
            return Page();
        }
    }
}
