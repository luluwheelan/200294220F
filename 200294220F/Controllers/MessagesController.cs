using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _200294220F.Models;

namespace _200294220F.Controllers
{
    public class MessagesController : Controller
    {
        private _200294220FContext db = new _200294220FContext();

        // GET: Messages
        [Route("")]
        [Route("Chat")]
        public ActionResult Index()
        {
            MessageViewModel vm = new MessageViewModel()
            {
                Messages = db.Messages.ToList()
            };
            vm.Messages = vm.Messages.OrderByDescending(p => p.PostTime.Date).ThenBy(p => p.PostTime.TimeOfDay).ToList();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("")]
        [Route("Chat")]
        public ActionResult Index([Bind(Include = "User,Info")]Message newMessage)
        {
            MessageViewModel vm;
            if (ModelState.IsValid)
            {

                db.Messages.Add(newMessage);
                db.SaveChanges();
                ModelState.Clear();
                vm = new MessageViewModel()
                {
                    Messages = db.Messages.ToList()
                };
                vm.Messages = vm.Messages.OrderByDescending(p => p.PostTime.Date).ThenBy(p => p.PostTime.TimeOfDay).ToList();
                return PartialView("Index", vm);
            }

            vm = new MessageViewModel()
            {
                Messages = db.Messages.ToList(),
                newMessage = newMessage
            };
            vm.Messages = vm.Messages.OrderByDescending(p => p.PostTime.Date).ThenBy(p => p.PostTime.TimeOfDay).ToList();
            return PartialView("Index", vm);

        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User,Info")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
