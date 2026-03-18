using Microsoft.EntityFrameworkCore;
using Techno_uus.Models;

namespace Techno_uus.Data
{
    //Andmebaasi genereerimise jaoks infot sisaldav  context class
    public class SchoolContext : DbContext //SchoolContext omab pärilust paketist Microsoft.EntityFrameworkCore;
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { } //Constructor kus vaikeväärtusena on andmebaasi seadistus põhinedes paketil olenevatest vaikeväärtustest
        public DbSet<Pupil> Pupils { get; set; } //Model
        public DbSet<StudyGroup> StudyGroups { get; set; } //Model

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Paketis olev meetod mille abil tekitame andmebaasi tabelid
        {
            modelBuilder.Entity<Pupil>().ToTable("Pupil"); // ModelBuilderis on nüüd Pupil mudeliga tabel mida meetod ToTable seab pärast päris andmebaasi "Pupil" nimelise tabelina
            modelBuilder.Entity<StudyGroup>().ToTable("StudyGroup"); //ModelBuilderis on nüüd StudyGroup mudeliga tabel mida meetod ToTable seab pärast päris andmebaasi "StudyGroup" nimelise tabelina
        }
    }
}
