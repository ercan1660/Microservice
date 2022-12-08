using Microsoft.AspNetCore.Mvc;
using P_CRUD_MS.Entity;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace P_CRUD_MS.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly Context _context;
        public PhoneController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        //datayı post ile alıyoruz.(APİ KISMI)
        public async Task<IActionResult> AddPhone([FromBody] Phone phone)
        {
            _context.Add(phone);
            _context.SaveChanges();
            //verileri kaydediyoruz.

            ///api/PhoneReport endpointine rest çağrısı atıyoruz.
            using (var httpClient = new HttpClient())
            {

                //post methodunun body kısmını method olarak aldık.
                var tmpPhone = new
                {
                    phone = phone.PhoneNumber
                };


                //model jsona converter oluyor
                var content = new StringContent(JsonConvert.SerializeObject(tmpPhone), Encoding.UTF8, "application/json");

                //Reguest yaptığımız Report
                var response = await httpClient.PostAsync("https://localhost:44372/api/PhoneReport", content);

                //hata durumuna göre kontrol ediyor veya devam ediyor.
                if (!response.IsSuccessStatusCode)
                {
                    throw new System.Exception("Hata Olustu");
                }
            }
            return Ok("Index");
        }
    }
}
