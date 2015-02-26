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

            IList<Ba_News> allmodel = dal.GetNews();
            int pagenum = 1;
            if (allmodel.Count % 3 == 0)
                pagenum = allmodel.Count / 3;
            else
                pagenum = allmodel.Count / 3 + 1;
            int currentpage = id.HasValue ? (int)id : 1;
            Common.HtmlPagerControl page = new Common.HtmlPagerControl(pagenum, 3, 7);
            page.CurrentPage = currentpage;
            ViewBag.currentpage = currentpage;
            page.ClickEvent = "onclick=\"topage(this);\"";
            ViewBag.pageinfo = page.Render();

            return View(model);
        }

        public ActionResult Medium(int? id)
        {
            Medium dal = new Medium();
            IList<Ba_Medium> model = dal.Getmedium(id.HasValue ? (int)id : 1);

            IList<Ba_Medium> allmodel = dal.Getmedium();
            int pagenum = 1;
            if (allmodel.Count % 3 == 0)
                pagenum = allmodel.Count / 3;
            else
                pagenum = allmodel.Count / 3 + 1;
            int currentpage = id.HasValue ? (int)id : 1;
            Common.HtmlPagerControl page = new Common.HtmlPagerControl(pagenum, 3, 7);
            page.CurrentPage = currentpage;
            ViewBag.currentpage = currentpage;
            page.ClickEvent = "onclick=\"topage(this);\"";
            ViewBag.pageinfo = page.Render();

            return View(model);
        }

    }
}
