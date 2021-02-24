using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SampleApp.DAL;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IConfiguration _config;
        private string secret3APIKey = "AIzaSyCuEKyaBjjAkbWkhwhrs9Sg1574nOs8QRM";

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var db = new DbAccess();

            string dbConn = _config.GetConnectionString("conn");
            db.TriggerSecurityWarning(dbConn, Customer.Name, Customer.Password);

            //string name = Request.Form["product_name"];
            //using (SqlConnection connection = new SqlConnection(dbConn))
            //{
            //    SqlCommand sqlCommand = new SqlCommand()
            //    {
            //        CommandText = "SELECT ProductId FROM Products WHERE ProductName = '" + name + "'",
            //        CommandType = CommandType.Text,
            //    };

            //    SqlDataReader reader = sqlCommand.ExecuteReader();
            //}

            return RedirectToPage("./Index");
        }
    }
}
