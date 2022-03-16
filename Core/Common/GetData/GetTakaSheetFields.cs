using KarKhanaBook.Model.Common;
using KarkhanaBookContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static KarKhanaBook.Model.Common.Result;

namespace KarKhanaBook.Core.Common.GetData
{
    public class GetTakaSheetFields
    {
        public Result Get() 
        {
            using (KarkhanaBookDataContext context = new KarkhanaBookDataContext()) 
            {
                List<Model.Common.IntegerNullString> integerNullStrings = new List<IntegerNullString>();
                var qs = (from obj in context.Lookups
                          where obj.NameID == 3
                          select new IntegerNullString()
                          {
                              ID=obj.ValueID,
                              Text=obj.Value,
                          }).ToList();
                return new Result()
                {
                    Message = "Takasheet field get Successfully",
                    Status = ((ResultStatus)(Enum.Parse(typeof(ResultStatus), ResultStatus.success.ToString()
                    , true))).ToString(),
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = qs,
                };
            }
        
        }
    }
}
