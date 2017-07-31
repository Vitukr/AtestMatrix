using AtestMatrixData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtestMatrix.Controllers
{
    public class HomeController : Controller
    {
        IAmatrix amatrix;

        public HomeController(IAmatrix m)
        {
            amatrix = m;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadMatrix(HttpPostedFileBase file = null)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/App_Data"), _FileName);
                        file.SaveAs(_path);

                        var textLines = System.IO.File.ReadAllLines(_path).ToArray();

                        amatrix.ReadMatrix(textLines);
                        return View("Index", new Tuple<int[][], int>(amatrix.Matrix, amatrix.Number));
                    }
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult GenerateMatrix(int number = 0)
        {
            try
            {
                if (number > 0)
                {
                    amatrix.GenerateMatrix(number);
                    return View("Index", new Tuple<int[][], int>(amatrix.Matrix, number));
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult RotateMatrix()
        {
            try
            {
                if (amatrix.Matrix != null)
                {
                    amatrix.RotateMatrix();
                    return View("Index", new Tuple<int[][], int>(amatrix.Matrix, amatrix.Number));
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        public FileContentResult DownloadCSV(string fileName)
        {
            try
            {
                if(fileName == "")
                {
                    fileName = "Matrix";
                }
                
                string csv = "";
                for (int i = 0; i < amatrix.Number; ++i)
                {
                    csv += string.Join(";", amatrix.Matrix[i]) + Environment.NewLine;
                }
                return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", fileName + ".csv");
            }
            catch
            {
                return File(new byte[0], "text/csv", "EmptyFile.csv");
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}