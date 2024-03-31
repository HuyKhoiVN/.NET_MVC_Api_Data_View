using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class NhanVien
    {
        [Key]
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public Guid IDChucVu { get; set; }
        public string Email { get; set; }
        public int Luong { get; set; }
        public bool TrangThai { get; set; }

        public virtual ChucVu chucVu { get; set; }

        /*public virtual ChucVu ChucVu { get; set; }
        [ForeignKey(nameof(IDChucVuNav))]
        [InverseProperty(nameof(ChucVu.NhanViens))]
        public virtual ChucVu IDChucVuNav { get; set; }*/
    }
}
