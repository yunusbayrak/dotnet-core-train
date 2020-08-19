using Business.Models;
using Business.Models.Filters;
using Business.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Kullanici")]
    public class IhbarController : ControllerBase
    {
        private readonly IIhbarService _ihbarService;

        public IhbarController(IIhbarService ihbarService)
        {
            _ihbarService = ihbarService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var ihbarlar = _ihbarService.GetIhbarlar(new IhbarFilterModel());
            if (ihbarlar != null)
                return Ok(ihbarlar);
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ihbar = _ihbarService.GetIhbar(id);
            if (ihbar != null)
                return Ok(ihbar);
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(IhbarModel ihbar)
        {
            var result = _ihbarService.AddIhbar(ihbar);
            if (result)
                return Ok(ihbar);
            return BadRequest("İhbar eklenirken hata meydana geldi!");
        }

        [HttpPut]
        public IActionResult Put(IhbarModel ihbar)
        {
            var result = _ihbarService.UpdateIhbar(ihbar);
            if (result)
                return Ok(ihbar);
            return BadRequest("İhbar güncellenirken hata meydana geldi!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _ihbarService.DeleteIhbar(id);
            if (result)
                return Ok();
            return BadRequest("İhbar silinirken hata meydana geldi!");
        }
    }
}