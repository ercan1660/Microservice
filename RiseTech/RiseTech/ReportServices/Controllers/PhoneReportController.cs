using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportServices.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace ReportServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneReportController : ControllerBase
    {

        //Context bağlantısı
        private readonly Context _context;
        public PhoneReportController(Context context)
        {
            _context = context;
        }


        //post atılıyor. crud daki form alanı veya apiden string kayıt alanı
        //telefon 212 ile başlarsa istanbul ,224 ile başlarsa bursa deyip count 1 artırıldı
        //diğer ise diger diye artırıldı.
        [HttpPost]
        public async Task<IActionResult> AddPhone(ReportDTO reportDTO)
        {
            
            if(reportDTO.Phone.StartsWith("212"))
            {
                AddOrUpdate("istanbul");
            }
            else if(reportDTO.Phone.StartsWith("224"))
            {
                AddOrUpdate("bursa");
            }
            else
            {
                AddOrUpdate("diger");
            }
            return Ok("saved");
        }

        //get olarak çağırıyor listeliyor
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(_context.PhoneReports.ToList());
        }

        //veritabanında var ise 1 artıtıp güncelliyor yok ise insert atıyor.
        private void AddOrUpdate(string key)
        {
            var report = _context.PhoneReports.FirstOrDefault(f => f.Name == key);
            if (report != null)
            {
                report.Count++;
                _context.Update(report);

            }
            else
            {
                _context.Add(new PhoneReport
                {
                    Name = key,
                    Count = 1
                });
            }

            //kaydediyor 
            _context.SaveChanges();
        }
    }
}
