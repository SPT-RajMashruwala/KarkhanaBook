using KarKhanaBook.Model.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static KarKhanaBook.Model.Common.Result;

namespace KarKhanaBook.Core
{
    public class Testing
    {
        public Result Test(DataTable table) 
        {
            List<Model.Search.SearchTakaSheet> takaSheet = new List<Model.Search.SearchTakaSheet>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];


                takaSheet.Add(new Model.Search.SearchTakaSheet()
                {
                    TakaSheetIndex = Int16.Parse(dr["TakaSheetIndex"].ToString()),
                    SloatNumber = Int16.Parse(dr["SlotNumber"].ToString()),
                    Date = Convert.ToDateTime(dr["Date"].ToString()),
                    TakaID = Int16.Parse(dr["TakaID"].ToString()),
                    MachineNumber = Int16.Parse(dr["MachineNumber"].ToString()),
                    Meter = float.Parse(dr["Meter"].ToString()),
                    Weight = float.Parse(dr["Weight"].ToString()),

                });
            }

            return new Result()
            {
                Message = "TakaSheet Added Successfully",
                Status = ((ResultStatus)(Enum.Parse(typeof(ResultStatus), ResultStatus.success.ToString()
                    , true))).ToString(),
                StatusCode = (int)System.Net.HttpStatusCode.OK,
                Data = takaSheet,
            };

        }
    }
}
