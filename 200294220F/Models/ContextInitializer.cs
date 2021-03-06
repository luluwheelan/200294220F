﻿using System;
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
                Info = "Hey, this is going to be a good one",
                PostTime = DateTime.Now.Date.AddHours(24).AddMinutes(30)
            };

            Message m2 = new Message
            {
                User = "Lulu",
                Info = "Seeded message from initializer.",
                PostTime = DateTime.Now.Date.AddHours(48).AddMinutes(30)
            };

            Message m3 = new Message
            {
                User = "Lulu",
                Info = "What happens next?",
            };

            context.Messages.Add(m1);
            context.Messages.Add(m2);
            context.Messages.Add(m3);
            base.Seed(context);
        }
    }
}