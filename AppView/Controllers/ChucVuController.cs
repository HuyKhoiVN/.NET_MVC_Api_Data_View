using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace AppView.Controllers
{
    public class ChucVuController : Controller
    {
        public ChucVuController()
        {
                
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            string apiUrl = "https://localhost:7119/api/ChucVu/get-all-ChucVu";
            //sau khi có api thực hiện lấy dữ liệu trả về từ nó
            var htppClient = new HttpClient(); // tao 1 httpClient de call api 
            var respone = await htppClient.GetAsync(apiUrl); //lay kq
                                                                                                                                        
            //doc ra string json
            string apiData = await respone.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ChucVu>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChucVu cv)
        {
            /*if(!ModelState.IsValid)
                return View(cv);*/

            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7119/api/ChucVu/crate-ChucVu?Ten={cv.Ten}&TrangThai={cv.TrangThai}";

            var json = JsonConvert.SerializeObject(cv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var respone = await httpClient.PostAsync(apiUrl, content);
            if (respone.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");
            return View(cv);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7119/api/ChucVu/getByid-ChucVu/{id}";
            var respone = await httpClient.GetAsync(apiUrl);
            string apiData = await respone.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChucVu> (apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(ChucVu cv)
        {
            if(ModelState.IsValid)
            {
                return View(cv);
            }

            var httpClient = new HttpClient();
            var apiUrl = $"https://localhost:7119/api/ChucVu/update-ChucVu?ID={cv.ID}&Ten={cv.Ten}&TrangThai={cv.TrangThai}";

            var json = JsonConvert.SerializeObject(cv);
            var content = new StringContent (json, Encoding.UTF8, "application/json");
            
            var respone = await httpClient.PutAsync(apiUrl, content);
            if(respone.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi");

            return View(cv);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7119/api/ChucVu/delete-ChucVu?id={id}";

            var respone = await httpClient.DeleteAsync(apiUrl);
            if(respone.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi, khong xoa duoc");
            return BadRequest();
        }
    }
}
