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
    public class GradeController : Controller
    {
        public GradingTable _gt = new GradingTable();
        private readonly GradingService _service;
        private readonly EpaDbContext _context;
        public GradeController(EpaDbContext context, GradingService service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet]
        public ActionResult Index()
        {
            _gt.Selections = _service.GetSelectionList();
            _gt.Gradings = _service.GetGradingList();
            _gt.Departments = _service.GetDepartmentList();
            return View(_gt);
        }
    }
}
