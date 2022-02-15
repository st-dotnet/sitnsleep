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

        /// <summary>
        /// Index Method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _logger.Info($"In SalesPerson Controller Index Action.");
            return View();
        }

        /// <summary>
        /// Get Salesperson By SalespersonId
        /// </summary>
        /// <param name="salespersonId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/SalesPerson/GetSalesPerson/{salespersonId}")]
        public async Task<ActionResult<IEnumerable<SalesPersonModel>>> GetSalesPerson(string salespersonId)
        {
            _logger.Info($"In SalesPerson Controller GetSalesPerson Action.");
            try
            {
                var salesperson = await _salespersonService.GetSalesPerson(salespersonId);

                //return Ok(list);
                return Json(new
                {
                    message = salesperson
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get All SalesPerson
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/SalesPerson/SalesPersonList")]
        public async Task<ActionResult<IEnumerable<SalesPersonModel>>> SalesPersonList()
        {
            _logger.Info($"In SalesPerson Controller SalesPersonList Action.");
            try
            {
                var list = await _salespersonService.GetSalesPersonList();

                return Json(new
                {
                    message = list
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add SalesPerson
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/SalesPerson/AddSalesPerson")]
        public async Task<ActionResult> AddSalesPerson([FromBody] SalesPersonModel model)
        {
            _logger.Info($"In SalesPerson Controller AddSalesPerson Action.");
            try
            {
                var request = _mapper.Map<SalesPersonDto>(model);
                var salesperson = await _salespersonService.AddSalesPerson(request);

                return Json(new
                {
                    message = salesperson
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update SalesPerson
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/SalesPerson/UpdateSalesPerson")]
        public async Task<ActionResult> UpdateSalesPerson([FromBody] SalesPersonModel model)
        {
            _logger.Info($"In SalesPerson Controller UpdateSalesPerson Action.");
            try
            {
                var request = _mapper.Map<SalesPersonDto>(model);
                var salesperson = await _salespersonService.UpdateSalesPerson(request);

                return Json(new
                {
                    message = salesperson
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete SalesPerson
        /// </summary>
        /// <param name="saleId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/SalesPerson/DeleteSalesPerson/{saleId}")]
        public async Task<bool> DeleteSalesPerson(int saleId)
        {
            _logger.Info($"In SalesPerson Controller DeleteSalesPersonAsync Action.");
            try
            {
                var salesperson = await _salespersonService.DeleteSalesPerson(saleId);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
