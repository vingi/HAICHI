using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBase.Domain.Entity;
using MVCBase.DAL;
using NHibernate;

namespace MVCBase.Areas.SuperAdmin.Controllers
{
    public class MediumListController : Controller
    {
        //
        // GET: /SuperAdmin/MediumList/

        public ActionResult Index()
        {
            ViewBag.jsInit = Public.SuperAdminCommon.JSInit("MediumManage", "MediumList");

            Medium dal = new Medium();
            IList<Ba_Medium> medium = dal.Getmedium();

            return View(medium);
        }

    }
}
