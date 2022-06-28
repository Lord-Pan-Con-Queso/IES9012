using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IES9012.Core.Modelos;
using IES9012.UI.Data;

namespace IES9012.UI.Pages.Estudiantes
{
    public class IndexModel : PageModel
{
    private readonly IES9012.UI.Data.IES9012Context _context;

    public IndexModel(IES9012.UI.Data.IES9012Context context)
    {
        _context = context;
    }
    //Acepta valores null porque la primera vez que abra la pagina no va a haber ninguna propiedad activa.
    public string? OrdenNombre { get; set; }
    public string? OrdenFecha { get; set; }
    public string? OrdenActual { get; set; }
    public string? FiltroActual { get; set; }

    public IList<Estudiante> Estudiantes { get; set; } = default!;

    public async Task OnGetAsync(string clasificarOrden)
    {
        OrdenNombre = String.IsNullOrEmpty(clasificarOrden) ? "Apellido_desc" : "";
        //Se le asigna a OrdenFecha un valor dependiendo del valor de clasificarOrden.
        //Si clasificarOrden contiene FechaInscripcion, a OrdenFecha le asigna FechaInscripcion_desc,
        //Si clasificaOrden no contiene FechaInscripcion, a OrdenFecha le asigna FechaInscripcion.
        //El ? es como un if y el : es como un else, lo anterior es la condición.
        OrdenFecha = clasificarOrden == "FechaInscripcion" ? "FechaInscripcion_desc" : "FechaInscripcion";

        //IQueryable consulta almacenes de datos sin usar la memoria del cliente, mientras que 
        //IEnumerable consulta datos en memoria.
        //Para el enfoque IQueryable (from s in _context.Estudiantes select s;), el SQL traducido es:
        //Select * From Estudiantes as s;

        if (_context.Estudiantes != null)
        {
            IQueryable<Estudiante> estudiantesIQ = from s in _context.Estudiantes select s;

            switch (clasificarOrden)
            {
                case "Apellido_desc":
                    estudiantesIQ = estudiantesIQ.OrderByDescending(s => s.Apellido);
                    break;
                case "FechaInscripcion":
                    estudiantesIQ = estudiantesIQ.OrderBy(s => s.FechaInscripcion);
                    break;
                case "FechaInscripcion_desc":
                    estudiantesIQ = estudiantesIQ.OrderByDescending(s => s.FechaInscripcion);
                    break;
                default:
                    estudiantesIQ = estudiantesIQ.OrderBy(s => s.Apellido);
                    break;

            }
            Estudiantes = await estudiantesIQ.AsNoTracking().ToListAsync();
        }
    }
}
}