﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IES9012.Core.Modelos;
using IES9012.UI.Data;

namespace IES9012.UI.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly IES9012.UI.Data.IES9012Context _context;

        public EditModel(IES9012.UI.Data.IES9012Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiantes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiantes =  await _context.Estudiantes.FirstOrDefaultAsync(m => m.EstudianteId == id);
            if (estudiantes == null)
            {
                return NotFound();
            }
            Estudiantes = estudiantes;
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

            _context.Attach(Estudiantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudiantesExists(Estudiantes.EstudianteId))
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

        private bool EstudiantesExists(int id)
        {
          return (_context.Estudiantes?.Any(e => e.EstudianteId == id)).GetValueOrDefault();
        }
    }
}