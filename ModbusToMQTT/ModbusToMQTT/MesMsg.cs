using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModbusToMQTT.ModbusTCPClass;
using static ModbusToMQTT.ModbusTCPClass.WeldData;

namespace ModbusToMQTT
{
    class MesMsg
    {
        //JObject jsonObject = new JObject
        //{
        //    { "id", 0},
        //    { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
        //    { "data", new JObject()},
        //};

        public string PackMsgJobReport(string jobKey, string jobState, int[] cnt)
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

        public string PackMsgUnitQuality(int Number, string Result)
        {
            var reprot = new
            {
                Number,
                Result
            };

            return JsonConvert.SerializeObject(reprot);
        }

        public string PackMsgAlarm(string type, string msg)
        {
            var report = new
            {
                AlarmType = type,
                AlarmMessage = msg
            };

            return JsonConvert.SerializeObject(report);
        }

        public string PackMsgCfg(Decimal[] cfg)
        {
            if(cfg.Length < 7)
            {
                return null;
            }

            var report = new
            {
                Amplitude = cfg[0],
                Energy = cfg[1],
                Pressure = cfg[2],
                Height = cfg[3],
                SumOfWireDiameter = cfg[4],
                WireDiameter = cfg[5],
                WeldingTime = cfg[6],
            };

            return JsonConvert.SerializeObject(report);
        }

        public string PackMsgHeartbeat(string state)
        {
            var report = new
            {
                DeviceState = state,
            };

            return JsonConvert.SerializeObject(report); 
        }

        // 详细伪代码：
        // 1. 如果输入 msg 为空或空白，返回错误码 -1。
        // 2. 尝试用 JObject.Parse 直接解析 msg。
        //    a. 解析成功 -> 继续。
        //    b. 解析失败（可能因为使用单引号或未转义的引号） -> 将单引号替换为双引号后再次解析。
        // 3. 从 JObject 中安全读取各字段，使用 jo.Value<T?> 提供默认值（如果字段缺失则使用 0 或 null）。
        // 4. （可选）将解析到的值赋给类字段或配置处，这里保留 TODO 注释供后续使用。
        // 5. 解析成功返回 0，出错返回 -1。
        // 备注：避免在方法中保留未使用的硬编码 JSON 字符串，修复原先导致的字符串字面量语法错误。

        public ModbusTCPClass.ArticleData ParseMsgRequestArticle(string msg)
        {
            ModbusTCPClass.ArticleData articleData = JsonConvert.DeserializeObject<ModbusTCPClass.ArticleData>(msg);

            return articleData;
        }

        public ModbusTCPClass.JobData ParseMsgRequestJob(string msg)
        {
            ModbusTCPClass.JobData jobData =JsonConvert.DeserializeObject<ModbusTCPClass.JobData>(msg);

            return jobData; 
        }

        public string PackMsgFeedbackSpecArticle()
        {
            var report = new
            {
                StatusCode = "OK",
                ReasonPhrase = "OK",
            };
            return JsonConvert.SerializeObject(report);
        }

        public string PackMsgFeedbackProductionJob()
        {
            var report = new
            {
                StatusCode = "OK",
                ReasonPhrase = "OK",
            };
            return JsonConvert.SerializeObject(report);
        }
    }
}
