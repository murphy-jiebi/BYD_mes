using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModbusToMQTT
{
    class MesMsg
    {
        JObject jsonObject = new JObject
        {
            { "id", 0},
            { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
            { "data", new JObject()},
        };

        string PackMsgJobReport(string jobKey, string jobState, int[] cnt)
        {
            if (cnt == null || cnt.Length < 3)
            {
                return null; 
            }

            var report = new
            {
                jobKey,
                jobState,
                CounterReprot = new
                {
                    GoodPieces = cnt[0],
                    GoodPiecesAdditional = cnt[1],
                    BadFragmentsDeposit = cnt[2]
                }
            };

            return JsonConvert.SerializeObject(report);
        }


    }
}
