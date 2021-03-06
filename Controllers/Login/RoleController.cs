using KarKhanaBook.Core.Login;
using KarKhanaBook.Model.Login;

using Microsoft.AspNetCore.Mvc;


namespace KarKhanaBook.Controllers.Login
{
    [Route("")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        [HttpPost]
        [Route("Role/Add")]
        public IActionResult Add([FromBody] Role roleModel)
        {

            return Ok(new Roles().Add(roleModel));
        }

        [HttpGet]
        [Route("Role/View")]
        public IActionResult View()
        {

            return Ok(new Roles().View().Result);
        }

        [HttpGet]
        [Route("Role/View/{ID}")]
        public IActionResult ViewById([FromRoute] int ID)
        {

            return Ok(new Roles().ViewById(ID).Result);
        }

        [HttpPut]
        [Route("Role/Update/{ID}")]
        public IActionResult Update([FromBody] Role roleModel, [FromRoute] int ID)
        {

            return Ok(new Roles().Update(roleModel, ID));
        }

        [HttpDelete]
        [Route("Role/Delete/{ID}")]
        public IActionResult Delete([FromRoute] int ID)
        {

            return Ok(new Roles().Delete(ID));
        }
    }
}
