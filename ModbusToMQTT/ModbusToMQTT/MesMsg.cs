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
