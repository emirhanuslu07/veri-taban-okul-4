using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_EF_iliskiliTablolar.Modeller;

namespace WinFormsApp_EF_iliskiliTablolar
{
    public class Veritabani : DbContext
    {
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Okul;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }
}
