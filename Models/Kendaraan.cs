using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_116.Models
{
    public partial class Kendaraan
    {
        public Kendaraan()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdKendaraan { get; set; }
        [Required(ErrorMessage = "Nama Kendaraan Tidak boleh kosong")]
        public string NamaKendaraan { get; set; }
        [Required(ErrorMessage = "No Polisi Tidak boleh kosong")]
        public string NoPolisi { get; set; }
        [Required(ErrorMessage = "No STNK Tidak boleh kosong")]
        [MinLength(8, ErrorMessage = "No Hp Minimal 8 angka")]
        [MaxLength(8, ErrorMessage = "No Hp Minimal 8 angka")]
        public string NoStnk { get; set; }
        public int? IdJenisKendaraan { get; set; }
        public string Ketersediaan { get; set; }

        public JenisKendaraan IdJenisKendaraanNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
