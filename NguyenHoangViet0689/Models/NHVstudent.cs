using System.ComponentModel.DataAnnotations;
namespace NguyenHoangViet0689.Models
{
    public class NHVstudent
    {
        [Key]
        public int NHVMaSV { get; set; }
        public string NHVTenSV { get; set; }
        public float NHVsdt { get; set; }
    }
}