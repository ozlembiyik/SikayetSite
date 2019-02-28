using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SikayetSitesiMvc.Enums.Enums;

namespace SikayetSitesiMvc.Models
{
    public class Complaint
    {
        [Key]
        public int ComplaintID { get; set; }

        [Display(Name = "Şikayet Başlığı")]
        public string Title { get; set; }

        [Display(Name = "Şikayet İçeriği")]
        public string Content { get; set; }

        [Display(Name = "Varsa şikayetinize ait fotoğraf/video")]
        public string Photo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Şikayet Tarihi")]
        public DateTime? Date { get; set; }

        [Display(Name = "Taşıt Türü")]
        public TasıtTuru TasitTuru { get; set; } 

        [Display(Name = "Durak Adı(Taksinin bağlı olduğu)")]
        public string CabStand { get; set; }

        [Display(Name = "Hat No")]
        public string LineNumber { get; set; }

        [Display(Name = "Plaka No")]
        public string PlateNo { get; set; }

    }
}