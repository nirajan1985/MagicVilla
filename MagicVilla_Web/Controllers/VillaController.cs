using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly VillaService _villaService;

        public VillaController(IMapper mapper, VillaService villaService)
        {
            _mapper = mapper;
            _villaService = villaService;
        }
    
        public async Task< IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var response = await _villaService.GetAllAsync<APIResponse>();
            if(response !=null && response.IsSuccess)
            {
                list=JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));  

            }
            return View(list);
        }
    }
}
