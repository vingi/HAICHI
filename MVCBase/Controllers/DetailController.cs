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
    public class DetailController : Controller
    {
        //
        // GET: /Detail/

        public ActionResult News(int? id)
        {
            News dal = new News();
            Ba_News model = dal.GetSingleNewsById(id.HasValue ? (int)id : 1);

            return View(model);
        }

        public ActionResult Medium(int? id)
        {
            Medium dal = new Medium();
            Ba_Medium model = dal.GetSinglemediumById(id.HasValue ? (int)id : 1);

            return View(model);
        }

    }
}
