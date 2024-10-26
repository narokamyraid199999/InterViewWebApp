using InterViewWebApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterViewWebApp.Controllers
{
    [Route("Unit")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        public UnitController(shopDbContext db)
        {
            _myDbContext = db;
        }

        private shopDbContext _myDbContext;

        [HttpGet]
        public IActionResult getAll()
        {
            var tempUnits = _myDbContext.Units.ToList();

            return Ok(tempUnits);
        }

        
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] Unit newUnit)
        {
            if (ModelState.IsValid)
            {

                var tempUnit = _myDbContext.Units.FirstOrDefault(y => y.unitNo == id);

                if (tempUnit == null)
                {
                    return BadRequest(new { error = "Invalid Unit Id :(" });

                }

                tempUnit.unitName = newUnit.unitName;

                _myDbContext.SaveChanges();

                return Ok(new { status = "Success" });
            }

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var tempUnit = _myDbContext.Units.FirstOrDefault(y => y.unitNo == id);

            if (tempUnit == null)
            {
                return BadRequest(new { error = "Invalid Unit Id :(" });
            }

            _myDbContext.Units.Remove(tempUnit);
            _myDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Unit newUnit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Unit newTempUnit = new Unit { unitName = newUnit.unitName };

                    _myDbContext.Units.Add(newTempUnit);
                    _myDbContext.SaveChanges();

                    return Ok(new { data = newTempUnit, status = "Success" });

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {ex.Message}");
                    return NoContent();
                }

            }

            return BadRequest(ModelState);

        }
        


    }
}
