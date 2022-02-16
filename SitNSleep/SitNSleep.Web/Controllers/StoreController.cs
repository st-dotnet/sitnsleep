using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
using SitNSleep.Services.Dtos;
using SitNSleep.Services.Interfaces;
using SitNSleep.Web.Models;

namespace SitNSleep.Apis.Controllers
{
    public class StoreController : Controller
    {
        #region Field(s)

        private readonly Logger _logger;
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        
        #endregion

        #region Constructor

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _storeService = storeService;
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
            _logger.Info($"In Store Controller Index Action.");
            return View();
        }

        /// <summary>
        /// Get Store By Storeid
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/Store/GetStore/{storeId}")]
        public async Task<ActionResult<IEnumerable<StoreModel>>> GetStore(int storeId)
        {
            _logger.Info($"In Store Controller GetStore Action.");
            try
            {
                var store = await _storeService.GetStore(storeId);

                return Json(new
                {
                    message = store
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"An unhandelled error occured. {ex}" });
            }
        }

        /// <summary>
        /// Get All Store
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/Store/StoreList")]
        public async Task<ActionResult<IEnumerable<StoreModel>>> StoreList()
        {
            _logger.Info($"In Store Controller StoreList Action.");
            try
            {
                var list = await _storeService.GetStoreList();

                return Json(new
                {
                    message = list
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"An unhandelled error occured. {ex}" });
            }
        }

        /// <summary>
        /// Add Store
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/Store/AddStore")]
        public async Task<ActionResult> AddStore([FromBody] StoreModel model)
        {
            _logger.Info($"In Store Controller AddStore Action.");
            try
            {
                var request = _mapper.Map<StoreDto>(model);
                var store = await _storeService.AddStore(request);

                return Json(new
                {
                    message = store
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"An unhandelled error occured. {ex}" });
            }
        }

        /// <summary>
        /// Update Store
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/Store/UpdateStore")]
        public async Task<ActionResult> UpdateStore([FromBody] StoreModel model)
        {
            _logger.Info($"In Store Controller UpdateStore Action.");
            try
            {
                var request = _mapper.Map<StoreDto>(model);
                var store = await _storeService.UpdateStore(request);

                return Json(new
                {
                    message = store
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"An unhandelled error occured. {ex}" });
            }
        }

        /// <summary>
        /// Delete Store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/Store/DeleteStore/{storeId}")]
        public async Task<bool> DeleteStore(int storeId)
        {
            _logger.Info($"In Store Controller DeleteStore Action.");
            try
            {
                var salesperson = await _storeService.DeleteStore(storeId);

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
