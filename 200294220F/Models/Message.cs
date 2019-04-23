using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


//GIT URL IS: https://github.com/luluwheelan/200294220F.git

namespace _200294220F.Models
{
    public class Message
    {

        private DateTime _date = DateTime.Now;
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "What is your name?")]
        [StringLength(10, MinimumLength = 2)]
        [DisplayName("Name")]
        public virtual string User { get; set; }

        [Required(ErrorMessage = "What do you want to tell us?")]
        [StringLength(500, MinimumLength = 5)]
        [DisplayName("Message")]
        public virtual string Info { get; set; }

        //Set PostTime dafault value.
        [DisplayName("Posted At")]
        public virtual DateTime PostTime
        {
            get { return _date; }
            set { _date = value; }
        }

    }
}