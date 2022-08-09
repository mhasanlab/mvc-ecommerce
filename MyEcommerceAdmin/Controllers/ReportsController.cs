using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEcommerceAdmin.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StocksReport()
        {
            try
            {
                string str = @"Data Source=.;Initial Catalog=R49_MyEcommerceDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter ada = new SqlDataAdapter();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "Select * from Products p inner join Categories c on c.CategoryID=p.CategoryID inner join Suppliers s on s.SupplierID=p.SupplierID";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "Products");
                ReportDocument rd = new ReportDocument();
                string rptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Stocks.rpt");
                rd.Load(rptPath);
                rd.SetDataSource(ds);
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Flush();
                rd.Close();
                rd.Dispose();
                return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);
            }
            catch (Exception ex)
            {
                return Content("<h2>Error:" + ex.Message + "</h2>", "text/html");
            }
        }

        public ActionResult CustomersReport()
        {
            try
            {
                string str = @"Data Source=.;Initial Catalog=R49_MyEcommerceDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter ada = new SqlDataAdapter();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "Select * from Customers";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "Customers");
                ReportDocument rd = new ReportDocument();
                string rptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Customers.rpt");
                rd.Load(rptPath);
                rd.SetDataSource(ds);
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Flush();
                rd.Close();
                rd.Dispose();
                return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);
            }
            catch (Exception ex)
            {
                return Content("<h2>Error:" + ex.Message + "</h2>", "text/html");
            }
        }

        public ActionResult SalesReport()
        {
            try
            {
                string str = @"Data Source=.;Initial Catalog=R49_MyEcommerceDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter ada = new SqlDataAdapter();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM OrderDetails od inner join Orders o on o.OrderID = od.OrderID inner join Products p on p.ProductID = od.ProductID";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "OrderDetails");
                ReportDocument rd = new ReportDocument();
                string rptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Sales.rpt");
                rd.Load(rptPath);
                rd.SetDataSource(ds);
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Flush();
                rd.Close();
                rd.Dispose();
                return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);
            }
            catch (Exception ex)
            {
                return Content("<h2>Error:" + ex.Message + "</h2>", "text/html");
            }
        }




    }
}