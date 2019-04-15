using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _200294220F.Models
{
    public class ContextInitializer : DropCreateDatabaseAlways<_200294220FContext>
    {
        protected override void Seed(_200294220FContext context)
        {
            Message m1 = new Message
            {
                User = "Lulu",
                message = "It was a good semester",
                PostTime = DateTime.Now.Date.AddHours(12).AddMinutes(30)
            };

            Message m2 = new Message
            {
                User = "Lulu",
                message = "Thanks for teaching me.",
                PostTime = DateTime.Now.Date.AddHours(2).AddMinutes(30)
            };

            Message m3 = new Message
            {
                User = "Lulu",
                message = "See you around on campus :)",
            };

            context.Messages.Add(m1);
            context.Messages.Add(m2);
            context.Messages.Add(m3);
            base.Seed(context);
        }
    }
}