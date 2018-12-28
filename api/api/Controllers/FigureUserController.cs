using Microsoft.AspNetCore.Mvc;
using Service;
using Model;

namespace api.Controllers
{
    [Route("[controller]")]
    public class FigureUserController : Controller
    {
        private readonly IFigureUserService _figureUserService;

        public FigureUserController(IFigureUserService figureUserService)
        {
            _figureUserService = figureUserService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _figureUserService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _figureUserService.Get(id)
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] FigureUser model)
        {
            return Ok(
                _figureUserService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] FigureUser model)
        {
            return Ok(
                _figureUserService.Update(model)
            );
        }
    }
}
