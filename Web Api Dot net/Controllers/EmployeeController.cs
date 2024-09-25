using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Dot_net.Models;

namespace Web_Api_Dot_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        WebApiContext db = new WebApiContext();

        [HttpGet]
        public IActionResult AllEmployee()
        {
            var employee = db.Tables.ToList();
            return Ok(employee);
        }

        [HttpPost]

        public IActionResult Store(Table table)
        {
            try
            {
                db.Tables.Add(table);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet ("{id}")]
        public IActionResult edit (int id)
        {
            try
            {
                
                var data = db.Tables.Find(id);
                if (data == null)
                {
                    return NotFound(new { message = "Employee not found." });
                }
                return Ok(data);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, Table table)
        {
            // Check if the table with the specified id exists
            var data = db.Tables.Find(id);
            if (data == null)
            {
                return NotFound(new { message = "Record not found." });
            }
            data.Name = table.Name;
            data.RolNumber = table.RolNumber;
            data.Company = table.Company;
            db.Tables.Update(data);
            db.SaveChanges();
            return Ok(data);

        }

        [HttpDelete ("{id}")]
        public IActionResult delete(int id)
        {
            var data = db.Tables.Find(id);
            if (data == null)
            {
                return NotFound(new { message = "Record not found." });
            }
            db.Tables.Remove(data);
            db.SaveChanges();
            return Ok(new { message = "Record Delete SuccessFully." });

        }


        }
}
