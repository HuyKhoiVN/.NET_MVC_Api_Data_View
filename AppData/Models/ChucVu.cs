using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class ChucVu
    {
        /*public ChucVu()
        {
            NhanViens = new HashSet<NhanVien>();
        }*/

        [Key]
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public bool TrangThai { get; set; }

        /*[InverseProperty(nameof(NhanVien.IDChucVu))]*/
        public  ICollection<NhanVien> NhanViens { get; set;}
        //public virtual ICollection<NhanVien> NhanViens { get; set;}
    }
}
