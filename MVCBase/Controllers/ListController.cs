using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBase.Domain.Entity;
using MVCBase.DAL;
using NHibernate;

namespace MVCBase.Controllers
{
    public class ListController : Controller
    {
        //
        // GET: /List/

        public ActionResult News(int? id)
        {
            News dal = new News();
            IList<Ba_News> model = dal.GetNews(id.HasValue ? (int)id : 1);

            return View(model);
        }

        public ActionResult Medium(int? id)
        {
            Medium dal = new Medium();
            IList<Ba_Medium> model = dal.Getmedium(id.HasValue ? (int)id : 1);

            return View(model);
        }

    }
}
