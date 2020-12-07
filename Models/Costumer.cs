using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_116.Models
{
    public partial class Costumer
    {
        public Costumer()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdCostumer { get; set; }
        [Required(ErrorMessage = "Nama Customer Tidak boleh kosong")]
        public string NamaCostumer { get; set; }
        [Required(ErrorMessage = "NIK Customer Tidak boleh kosong")]
        [RegularExpression("^[0-9]*&",ErrorMessage ="Hanya boleh diisi oleh angka")]
        public string Nik { get; set; }
        [Required(ErrorMessage = "Alamat Customer Tidak boleh kosong")]
        public string Alamat { get; set; }
        [Required(ErrorMessage = "No Hp Customer Tidak boleh kosong")]
        [MinLength(10,ErrorMessage ="No Hp Minimal 10 angka")]
        [MaxLength(13, ErrorMessage = "No Hp Minimal 13 angka")]
        public string NoHp { get; set; }
        public int? IdGender { get; set; }

        [DisplayName("Gender")]
        public Gender IdGenderNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
