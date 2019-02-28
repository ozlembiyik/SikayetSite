using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SikayetSitesiMvc.Models
{
    public class User:ApplicationUser
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }

        //Bir kullanıcı birden fazla şikayet yapabilir.
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}