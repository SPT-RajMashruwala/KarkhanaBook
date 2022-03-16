using KarKhanaBook.Core.Common.GetData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarKhanaBook.Controllers.Common
{
    
    [ApiController]
    public class GetTakaSheetFieldController : ControllerBase
    {
        [HttpGet]
        [Route("GetTakaSheetField")]
        public IActionResult Get() 
        {
            return Ok(new GetTakaSheetFields().Get());
        }

    }
}
