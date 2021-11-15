using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GameLib;
using Dapper;
using System.Data.SqlClient;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        // GameLib.Database db = new();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        // public static Dictionary<int, string> GetAllItems()
        // {
        //     foreach (var item in db)
        //     {
                
        //     }
        // }
    }
}
