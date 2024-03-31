using AppData.Context;
using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {

        IAllRepos<ChucVu> irepos;
        //tao 1 dbcontext de khong bi null
        NhanVienContext context = new NhanVienContext();

        public ChucVuController()
        {
            //tao 1 allrepos de gan cho IAllrepos
            AllRepos<ChucVu> repos = new AllRepos<ChucVu>(context, context.ChucVus);
            irepos = repos;

        }
        [HttpGet("get-all-ChucVu")]
        public IEnumerable<ChucVu> GetAll()
        {
            return irepos.GetAllItems();
        }

        [HttpGet("getByid-ChucVu/{id}")]
        public IActionResult GetById(Guid id)
        {
            var nhanvien = irepos.GetByID(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return Ok(nhanvien);
        }

        [HttpPost("crate-ChucVu")]
        public bool CreateChucVu(string ten, bool trangthai)
        {
            ChucVu cv = new ChucVu();
            cv.ID = Guid.NewGuid();
            cv.Ten = ten;
            cv.TrangThai = trangthai;

            return irepos.CreateItem(cv);
        }

        [HttpPut("update-ChucVu")]
        public bool UpdateChucVu(Guid id, string ten, bool trangthai)
        {
            ChucVu cv = new ChucVu();
            cv.ID = id;
            cv.Ten = ten;
            cv.TrangThai = trangthai;

            return irepos.UpdateItem(cv);
        }

        [HttpDelete("delete-ChucVu")]
        public bool DeleteChucVu(Guid id)
        {
            ChucVu cv = new ChucVu();
            cv.ID = id;
            return irepos.DeleteItem(cv);
        }

    }
}
