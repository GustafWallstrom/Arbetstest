using Core;
using Core.Base;
using Core.Base.Interfaces;
using Core.Controls;
using DeveloperTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeveloperTest.Controls
{
    [DUserControl("/Controls/AllLogItems.ascx", "Alla loggar", Icon = "plus-square-o", IconColor = "#f1592a", Description = "Alla loggar")]
    [RibbonTab(Title = "En lista med alla loggar", IsPrimary = true, Name = "tab")]
    [RibbonGroup(Tab = "tab", Title = "General", Name = "gen")]
    [RibbonGroup(Tab = "tab", Title = "Layout", Name = "layout")]
    public partial class AllLogItems : UserControlExtender, IDynamicUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var years = new HashSet<string>();
                var logItems = LogItemHelper.AllLogs.OrderByDescending(item => item.Id);

                foreach (var conf in logItems)
                {
                    var year = conf.Date.ToString("yyyy");
                    if (!years.Contains(year))
                        years.Add(year);
                }

                exyearsel.DataSource = years;
                exyearsel.DataBind();
                exyearsel.Items.Insert(0, new ListItem("-- Välj år--", "0"));

                exItems.DataSource = logItems;
                exItems.DataBind();
            }
        }

        protected void exportAll_Click(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;

            try
            {
                var logItems = LogItemHelper.AllLogs.OrderByDescending(item => item.Id).ToList();
                var now = DateTime.Now.ToString("yyyy-MM-dd_hh:mm");

                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", $"filename=\"Logg_{now}.xls\"");

                logItems.ToExcelStream(response.OutputStream);
            }
            catch (Exception ex)
            {
                Logger.Instance.AddLine("excel.txt", ex);
                throw;
            }
            finally
            {
                response.End();
            }
        }

        protected void exyearsel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            var items = exyearsel.SelectedValue == "0" 
                ? LogItemHelper.AllLogs.OrderByDescending(item => item.Id) 
                : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderByDescending(p => p.Id);

            exItems.DataSource = items;
            exItems.DataBind();
        }

        protected void sortvalue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            int sortChoise = Int32.Parse(sortvalue.SelectedValue);
            String sortType = sorttype.SelectedValue;
            var items = LogItemHelper.AllLogs.OrderByDescending(item => item.Id);

            switch (sortChoise)
            {
                case 0:
                    if (sortType == "0")
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderByDescending(item => item.Id)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderByDescending(p => p.Id);
                    }
                    else
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderBy(item => item.Id)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderBy(p => p.Id);
                    }
                    break;

                case 1:

                    if (sortType == "0")
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderByDescending(item => item.Question)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderByDescending(p => p.Question);
                    }
                    else
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderBy(item => item.Question)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderBy(p => p.Question);
                    }
                    break;

                case 2:
                    if (sortType == "0")
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderByDescending(item => item.UniqueId)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderByDescending(p => p.UniqueId);
                    }
                    else
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderBy(item => item.UniqueId)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderBy(p => p.UniqueId);
                    }
                    break;

                case 3:

                    if (sortType == "0")
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderByDescending(item => item.Date)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderByDescending(p => p.Date);
                    }
                    else
                    {
                        items = exyearsel.SelectedValue == "0"
                        ? LogItemHelper.AllLogs.OrderBy(item => item.Date)
                        : LogItemHelper.AllLogs.Where(x => x.Date.ToString("yyyy") == exyearsel.SelectedValue).OrderBy(p => p.Date);
                    }
                    break;

            }

            exItems.DataSource = items;
            exItems.DataBind();
        }
    }
}