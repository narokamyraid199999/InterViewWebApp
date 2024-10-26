using InterViewWebApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterViewWebApp.Controllers
{
    [Route("InvoiceDetail")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        public InvoiceDetailController(shopDbContext db)
        {
            _myDbContext = db;
        }

        private shopDbContext _myDbContext;

        [HttpGet]
        public IActionResult getAll()
        {
            List<InvoiceDetails> invoiceDetails = _myDbContext.InvoiceDetails.ToList();

            return Ok(invoiceDetails);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody]InvoiceDetails newInvoice)
        {
            if (ModelState.IsValid)
            {
                var tempInvoice = _myDbContext.InvoiceDetails.FirstOrDefault(x => x.lineNo == id);

                var tempUnit = _myDbContext.Units.FirstOrDefault(y => y.unitNo == newInvoice.UnitNo);

                if (tempInvoice == null)
                {
                    return BadRequest(new { error = "Invalid Invoice Id :(" });
                }
                else if (tempUnit == null)
                {
                    return BadRequest(new { error = "Invalid Unit number :(" });

                }

                tempInvoice.price = newInvoice.price;
                tempInvoice.total = newInvoice.total;
                tempInvoice.quantity = newInvoice.quantity;
                tempInvoice.expiryDate = newInvoice.expiryDate;
                tempInvoice.productName = newInvoice.productName;
                tempInvoice.UnitNo = newInvoice.UnitNo;

                _myDbContext.SaveChanges();

                return Ok(new { status = "Success" });
            }

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var tempInvoice = _myDbContext.InvoiceDetails.FirstOrDefault(x => x.lineNo == id);

            if (tempInvoice == null)
            {
                return BadRequest(new { error = "Invalid Invoice Id :(" });
            }

            _myDbContext.InvoiceDetails.Remove(tempInvoice);
            _myDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(InvoiceDetails newInvoiceDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var tempUnit = _myDbContext.Units.FirstOrDefault(x => x.unitNo == newInvoiceDetails.UnitNo);
                    if ( tempUnit == null)
                    {
                        return BadRequest(new { error = "Invalid unit id" });
                    }

                    InvoiceDetails newTempInvoiceDetails = new InvoiceDetails {expiryDate=newInvoiceDetails.expiryDate, price=newInvoiceDetails.price, productName=newInvoiceDetails.productName, total=newInvoiceDetails.total, quantity=newInvoiceDetails.quantity, UnitNo=newInvoiceDetails.UnitNo };

                    _myDbContext.InvoiceDetails.Add(newTempInvoiceDetails);
                    _myDbContext.SaveChanges();

                    return Ok(new {data=newTempInvoiceDetails, status="Success"});

                }catch(Exception ex)
                {
                    Console.WriteLine($"Error {ex.Message}");
                    return NoContent();
                }

            }

            return BadRequest(ModelState);

        }


    }
}
