using Microsoft.AspNetCore.Mvc;
using NLog;
using SitNSleep.Services.Dtos;
using SitNSleep.Services.Interfaces;
using SitNSleep.Web.Models;
using AutoMapper;

namespace SitNSleep.Web.Controllers
{
    public class SalesPersonController : Controller
    {
        #region Field(s)

        private readonly Logger _logger;
        private readonly ISalesPersonService _salespersonService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public SalesPersonController(ISalesPersonService salespersonService, IMapper mapper)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _salespersonService = salespersonService;
            _mapper = mapper;
        }

        #endregion

        #region Action Method(s)

        public IActionResult Index()
        {
            _logger.Info($"In SalesPerson Controller Index Action.");
            return View();
        }


        [HttpGet]
        [Route("~/SalesPerson/SalesPersonList")]
        public async Task<ActionResult<IEnumerable<SalesPersonModel>>> SalesPersonList()
        {
            var list = await _salespersonService.GetSalesPersonList();

            //return Ok(list);
            return Json(new
            {
                message = list
            });
        }

        [HttpPost]
        [Route("~/SalesPerson/AddSalesPerson")]
        public async Task<ActionResult> AddSalesPerson(SalesPersonModel model)
        {
            var request = _mapper.Map<SalesPersonDto>(model);
            var salesperson = await _salespersonService.AddSalesPerson(request);

            return Json(new
            {
                message = salesperson
            });
        }

        #endregion
    }
}
