using ReferralSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.Services;
using System.IO;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ReferralSystem.ServiceContracts;

namespace ReferralSystem.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        ReportService reports = new ReportService();
        [ReferralSystemAuthorize("HR")]
        public ActionResult Employees()
        {
            return View(reports.EmployeeReport());
        }

        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created   
            string strPDFFileName = string.Format("EmployeeDetails" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(9);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table  

            //file will created in this path  
            string strAttachment = Server.MapPath("~/ReportDownloads/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF(tableLayout));

            // Closing the document  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 30, 30, 30, 30, 30, 50, 30, 30, 30 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            List<EmployeeReportViewModel> employees = reports.EmployeeReport();



            tableLayout.AddCell(new PdfPCell(new Phrase("Employees List", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) {
                Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER
            });


            ////Add header  
            AddCellToHeader(tableLayout, "FirstName");
            AddCellToHeader(tableLayout, "MiddleName");
            AddCellToHeader(tableLayout, "LastName");
            AddCellToHeader(tableLayout, "Designation");
            AddCellToHeader(tableLayout, "DOB");
            AddCellToHeader(tableLayout, "Email");
            AddCellToHeader(tableLayout, "PhoneNumber");
            AddCellToHeader(tableLayout, "ReferralBonus");
            AddCellToHeader(tableLayout, "ReferralsConverted");

            ////Add body  

            foreach (var emp in employees)
            {

                AddCellToBody(tableLayout, emp.FirstName);
                AddCellToBody(tableLayout, emp.MiddleName);
                AddCellToBody(tableLayout, emp.LastName);
                AddCellToBody(tableLayout, emp.Designation);
                AddCellToBody(tableLayout, emp.DOB.ToString());
                AddCellToBody(tableLayout, emp.Email);
                AddCellToBody(tableLayout, emp.PhoneNumber);
                AddCellToBody(tableLayout, emp.ReferralBonus.ToString());
                AddCellToBody(tableLayout, emp.ReferralsConverted.ToString());

            }

            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.WHITE)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(60, 60, 60)
    });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
             {
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
    });
        }
    }
}