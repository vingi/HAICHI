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
    public class MediumOperateController : Controller
    {
        //
        // GET: /SuperAdmin/MediumOperate/

        public ActionResult Index(int? id)
        {
            ViewBag.jsInit = Public.SuperAdminCommon.JSInit("MediumManage", "MediumOperate");
            var model = new Ba_Medium();
            if (id != null)
            {
                Medium dal = new Medium();
                model = dal.GetSinglemediumById((int)id);
            }
            if (model == null)
                model = new Ba_Medium();

            ViewBag.model = model;

            if (model.Ns_ID.Equals(0))
                ViewBag.Title = "新增媒體報道";
            else
                ViewBag.Title = "更新媒體報道";

            return View();
        }

        [HttpPost,ValidateInput(false)]
        public string Submit(MediumOperate_Form form)
        {
            string result = string.Empty;
            Medium dal = new Medium();
            var model = dal.GetSinglemediumById(form.medium_id);
            if (model == null)
                model = new Ba_Medium();
            model.Ns_Title = form.medium_title;
            model.Ns_SubTitle = form.medium_subtitle;
            model.Ns_Content = form.medium_description;
            model.Ns_BuildTime = DateTime.Now;
            model.Ns_State = true;
            try
            {
                dal.SaveOrUpdate(model);
                result = "1";
            }
            catch (System.Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        public string Delete(int id)
        {
            string result = "0";
            Medium dal = new Medium();
            var model = dal.GetSinglemediumById(id);
            if (model != null)
            {
                model.Ns_State = false;
                dal.Update(model);
                result = "1";
            }

            return result;
        }

    }

    public class MediumOperate_Form
    {
        public int medium_id { get; set; }
        public string medium_title { get; set; }
        public string medium_subtitle { get; set; }
        public string medium_description { get; set; }
    }
}
