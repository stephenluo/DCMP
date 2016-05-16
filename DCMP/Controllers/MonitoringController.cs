using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;

namespace DCMP.Controllers
{
    public class MonitoringController : Controller
    {
        // GET: Monitoring
        public ActionResult Index()
        {
            return View();
        }

        // GET: MonitoringOverview
        //api/MonitoringOverview
        public ContentResult MonitoringOverview()
        {
            string qSql = "select MChannelCategories,MChannelSubclasses,MAcquisitionMode,MDataCategories,MState,MAmountOfData,MPastMonthUpdateAmount from [TB_MonitoringOverview] order by [MIndex]";
            DataSet ds = SimpleDataHelper.Query(SimpleDataHelper.MSConnectionString, qSql);

            JArray array = new JArray();
            JObject o;
            JArray values = new JArray();

            //object[] array;
            //object o;
            //object[] values;

            string LastChannelCategories = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string MChannelCategories = ds.Tables[0].Rows[i][0].ToString();
                string MChannelSubclasses = ds.Tables[0].Rows[i][1].ToString();
                string MAcquisitionMode = ds.Tables[0].Rows[i][2].ToString();
                string MDataCategories = ds.Tables[0].Rows[i][3].ToString();
                string MState = ds.Tables[0].Rows[i][4].ToString();
                string MAmountOfData = ds.Tables[0].Rows[i][5].ToString();
                string MPastMonthUpdateAmount = ds.Tables[0].Rows[i][6].ToString();

                if (!LastChannelCategories.Equals(MChannelCategories))
                {
                    LastChannelCategories = MChannelCategories;

                    o = new JObject();
                    o["ChannelCategories"] = MChannelCategories;
                    values = new JArray();
                    o["Values"] = values;
                    array.Add(o);

                }

                JObject o2 = new JObject();
                o2["ChannelSubclasses"] = MChannelSubclasses;
                o2["AcquisitionMode"] = MAcquisitionMode;
                o2["DataCategories"] = MDataCategories;
                o2["State"] = MState;
                o2["AmountOfData"] = MAmountOfData;
                o2["PastMonthUpdateAmount"] = MPastMonthUpdateAmount;

                values.Add(o2);
            }

            return Content(array.ToString());
        }

    }
}