using System.ComponentModel.DataAnnotations;
namespace NguyenHoangViet0689.Models
{
    public class NHVstudent
    {
        [Key]
        public int NHVMaSV { get; set; }
        [Display(Name ="Mã sinh viên")]
        public string NHVTenSV { get; set; }
        public float NHVsdt { get; set; }
        public string NHVDiachi { get; set; }
    }
}