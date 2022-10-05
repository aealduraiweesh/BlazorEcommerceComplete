using AspNetCore.Reporting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;

namespace BlazorEcommerce.Server.Controllers
{
    [Route(template:"api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ProductService productService;
        private readonly IProductService _productService;
        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        }

        [HttpGet]
        [Route(template:"GetReport")]
        public IActionResult GetReport(int reportType)
        {
         

            var dt = new DataTable();
            dt = _productService.GetProductsAsync();

            string mimeType = "";
            int extenstion = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";

            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("param","RDLC Report in Blazor Web Assembly");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource(dataSetName: "dsEmployee", dt);

            if(reportType == 1 )
            {

            }
        }
    }
}
