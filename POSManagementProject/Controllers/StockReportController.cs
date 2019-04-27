using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.DAL;
using POSManagementProject.Models.ViewModels;
using POSManagementProject.Report;

namespace POSManagementProject.Controllers
{
    public class StockReportController : Controller
    {
        StockReportVM stockReportVm = new StockReportVM();
        StockReportDAL stockReportDal = new StockReportDAL();

        // GET: StockReport
        public ActionResult Index()
        {
            
            stockReportVm.SelectListBranch = stockReportDal.GetBranchSelectList();
            stockReportVm.StockList = stockReportDal.GetStockList();
            return View(stockReportVm);
        }

        [HttpPost]
        public ActionResult Index(long branchId)
        {
            stockReportVm.SelectListBranch = stockReportDal.GetBranchSelectList();
            stockReportVm.StockList = stockReportDal.GetStockList(branchId);
            return View(stockReportVm);
        }


        public ActionResult ExportAllInfoToPdf(long branchId)
        {
            StockInfoExportToFile exPdf = new StockInfoExportToFile();
            exPdf.ExportAllInfoToPdf(stockReportDal.GetStockList(branchId));
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}