using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LigaProEcuador.Models;

    public class DBSqlServerLigaPro : DbContext
    {
        public DBSqlServerLigaPro (DbContextOptions<DBSqlServerLigaPro> options)
            : base(options)
        {
        }

        public DbSet<LigaProEcuador.Models.Equipo> Equipo { get; set; } = default!;

public DbSet<LigaProEcuador.Models.Jugador> Jugador { get; set; } = default!;

public DbSet<LigaProEcuador.Models.Posicion> Posicion { get; set; } = default!;

public DbSet<LigaProEcuador.Models.Puntaje> Puntaje { get; set; } = default!;
    }
