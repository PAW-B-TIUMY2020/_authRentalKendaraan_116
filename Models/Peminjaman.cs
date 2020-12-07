using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_116.Models
{
    public partial class Peminjaman
    {
        public Peminjaman()
        {
            Pengembalian = new HashSet<Pengembalian>();
        }
        [DisplayName("ID")]
        public int IdPeminjaman { get; set; }
        [Required(ErrorMessage = "Tanggal harus di isi")]
        [DisplayName("Tanggal Peminjaman")]
        public DateTime? TglPeminjaman { get; set; }
        [DisplayName("Kendaraan")]
        public int? IdKendaraan { get; set; }
        [DisplayName("Costumer")]
        public int? IdCostumer { get; set; }
        [DisplayName("Jaminan")]
        public int? IdJaminan { get; set; }
        [DisplayName("Biaya")]
        public int? Biaya { get; set; }

        [DisplayName("Costumer")]
        public Costumer IdCostumerNavigation { get; set; }
        [DisplayName("Jaminan")]
        public Jaminan IdJaminanNavigation { get; set; }
        [DisplayName("Kendaraan")]
        public Kendaraan IdKendaraanNavigation { get; set; }
        public ICollection<Pengembalian> Pengembalian { get; set; }
        public object IdCustomerNavigation { get; internal set; }
    }
}
