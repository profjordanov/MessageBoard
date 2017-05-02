using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
    public class BlogController : Controller
    {

        private BlogService service;

        public BlogController()
        {
            this.service = new BlogService();
        }

        public ActionResult Index()
        {
            IEnumerable<BlogTopicVM> vms = this.service.GetAllTopicVms();
            return View(vms);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        public ActionResult Add([Bind(Include = "Title, ImageThumbnail, Description, Date")] BlogTopicBM bind)
        {
            this.service.AddTopic(bind);
            return this.RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            BlogTopicVM topicvm = this.service.GetTopic(id);
            return this.View(topicvm);
        }

    }
}
