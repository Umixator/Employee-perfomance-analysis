using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using EPA.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using EPA.Services;

namespace EPA.Controllers
{
    public class ParameterController : Controller
    {
        public GradingTable _gt = new GradingTable();
        private readonly GradingService _service;
        private readonly EpaDbContext _context;
        public ParameterController(EpaDbContext context, GradingService service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet]
        public ActionResult ParameterTable()
        {
            _gt.Parameters = _service.GetParameterList();
            _gt.MarkDescriptions = _service.GetMarkDescriptionList();
            return View(_gt);
        }
        public ActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateParameter(GradingTable g)
        {
            await _service.CreateParameter(g.Parameter, g.MarkDescriptions);
            return RedirectToAction("ParameterTable");
        }
    }
}
