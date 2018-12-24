using Microsoft.AspNetCore.Mvc;
using Service;
using Model;

namespace api.Controllers
{
    [Route("[controller]")]
    public class FigureController : Controller
    {
        private readonly IFigureService _figureService;

        public FigureController(IFigureService figureService)
        {
            _figureService = figureService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _figureService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _figureService.Get(id)
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Figure model)
        {
            return Ok(
                _figureService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Figure model)
        {
            return Ok(
                _figureService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _figureService.Delete(id)
            );
        }
    }
}
