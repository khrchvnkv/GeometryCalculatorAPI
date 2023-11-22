using GeometryCalculator.Entities.Figures;
using GeometryCalculator.Services.FigureFactory;
using Microsoft.AspNetCore.Mvc;

namespace GeometryCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaCalculator : ControllerBase
    {
        private readonly IFiguresFactory _figuresFactory;

        public AreaCalculator(IFiguresFactory figuresFactory) => _figuresFactory = figuresFactory;

        [HttpGet]
        public IActionResult GetArea([FromQuery] float[] figureParams)
        {
            try
            {
                var figure = _figuresFactory.GetFigureWithParams(figureParams);
                return Ok(new
                {
                    FigureType = Enum.GetName(typeof(IFigure.FigureTypes), figure.FigureType),
                    AreaValue = figure.GetAreaValue(),
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}