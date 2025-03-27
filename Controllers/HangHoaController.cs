using Ktrgk2.Data;
using Ktrgk2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ktrgk2.Controllers
{
    [Route("HangHoa")] // Định tuyến mặc định cho MVC
    public class HangHoaController : Controller
    {
        private readonly AppDbContext _context;

        public HangHoaController(AppDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách hàng hóa (View)
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var hangHoas = await _context.Goods.ToListAsync();
            return View(hangHoas);
        }

        // Hiển thị form chỉnh sửa (View)
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();
            return View(hangHoa);
        }

        // Xử lý cập nhật hàng hóa (View)
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, string maHangHoa, string tenHangHoa, int soLuong, string ghiChu)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();

            hangHoa.MaHangHoa = maHangHoa;
            hangHoa.TenHangHoa = tenHangHoa;
            hangHoa.SoLuong = soLuong;
            hangHoa.GhiChu = ghiChu;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // API: Lấy danh sách hàng hóa
        [HttpGet]
        [Route("api")]
        public async Task<ActionResult<IEnumerable<HangHoa>>> GetHangHoas()
        {
            return await _context.Goods.ToListAsync();
        }

        // API: Lấy hàng hóa theo ID
        [HttpGet]
        [Route("api/{id}")]
        public async Task<ActionResult<HangHoa>> GetHangHoa(string id)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();
            return hangHoa;
        }

        // API: Thêm hàng hóa mới
        [HttpPost]
        [Route("api")]
        public async Task<ActionResult<HangHoa>> PostHangHoa([FromBody] HangHoa hangHoa)
        {
            _context.Goods.Add(hangHoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHangHoa), new { id = hangHoa.MaHangHoa }, hangHoa);
        }

        // API: Cập nhật hàng hóa
        [HttpPut]
        [Route("api/{id}")]
        public async Task<IActionResult> PutHangHoa(string id, [FromBody] HangHoa hangHoa)
        {
            if (id != hangHoa.MaHangHoa) return BadRequest();

            _context.Entry(hangHoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // API: Xóa hàng hóa
        [HttpDelete]
        [Route("api/{id}")]
        public async Task<IActionResult> DeleteHangHoa(string id)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();

            _context.Goods.Remove(hangHoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // API: Cập nhật ghi chú
        [HttpPatch]
        [Route("api/update-ghi-chu/{id}")]
        public async Task<IActionResult> UpdateGhiChu(string id, [FromBody] string ghiChu)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();

            hangHoa.GhiChu = ghiChu;
            await _context.SaveChangesAsync();

            return Ok(hangHoa);
        }
    }
}