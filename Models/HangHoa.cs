using System.ComponentModel.DataAnnotations;

namespace Ktrgk2.Models
{
    public class HangHoa
    {
        [Key]
        public string MaHangHoa { get; set; } = string.Empty;
        public string TenHangHoa { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public string? GhiChu { get; set; }
    }
}