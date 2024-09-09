using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public string ApellidoPaterno { get; set; } = null!;

    public string? Curp { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public string? Telefono { get; set; }
}
