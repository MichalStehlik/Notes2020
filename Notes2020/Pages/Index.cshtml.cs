using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Notes2020.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string UserName { get; set; }
        public string UserId { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            UserName = User.Identity.Name;
            var UserData = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            UserId = UserData.Value;
        }
    }
}
