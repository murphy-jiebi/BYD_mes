using HPSocketCS;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Formatter;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF.Common;
using static ModbusToMQTT.MesMsg;
using static ModbusToMQTT.ModbusTCPClass;

namespace ModbusToMQTT
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();

            try
            {

                #region 事件listbox属性   该Listbox用于运行日志界面

                pnlList.Controls.Add(EventMsgListBox);//listbox属性
                EventMsgListBox.Dock = DockStyle.Fill;
                EventMsgListBox.BackColor = Color.White;
                EventMsgListBox.Font = new Font("微软雅黑", 12, FontStyle.Regular);

                #endregion

                #region 从配置文件中读取参数

                //lblMainTitle.Text = gIni.ReadString("Params", "MainTitleText", "");
                //this.Text = gIni.ReadString("Params", "MainTitleText", "");

                txtMQTTSvrIP.Text = gIni.ReadString("MQTTParams", "MqttServerIP", "");
                gMQTTSvrIP = gIni.ReadString("MQTTParams", "MqttServerIP", "");
                txtMQTTSvrPort.Text = gIni.ReadString("MQTTParams", "MqttServerPort", "");
                gMQTTSvrPort = ushort.Parse(gIni.ReadString("MQTTParams", "MqttServerPort", ""));
                txtMQTTUsername.Text = gIni.ReadString("MQTTParams", "MQTTUsername", "");
                gMQTTUsername = gIni.ReadString("MQTTParams", "MQTTUsername", "");
                txtMQTTPwd.Text = gIni.ReadString("MQTTParams", "MQTTPwd", "");
                gMQTTPwd = gIni.ReadString("MQTTParams", "MQTTPwd", "");



                txtModbusSvrIP.Text = gIni.ReadString("ModbusTCPParams", "ModbusSvrIP", "");
                gModbusSvrIP = gIni.ReadString("ModbusTCPParams", "ModbusSvrIP", "");
                textBox2.Text = gIni.ReadString("ModbusTCPParams", "ModbusSvrPort", "");
                gModbusSvrPort = ushort.Parse(gIni.ReadString("ModbusTCPParams", "ModbusSvrPort", ""));
                textBox1.Text = gIni.ReadString("ModbusTCPParams", "SlaveID", "");
                gModbusSlaveID = Convert.ToInt32(gIni.ReadString("ModbusTCPParams", "SlaveID", ""));
                txtModbusStartAddress.Text = gIni.ReadString("ModbusTCPParams", "ModbusStartAdd", "");
                gModbusStartAdd = Convert.ToInt32(gIni.ReadString("ModbusTCPParams", "ModbusStartAdd", ""));
                txtModbusReadCount.Text = gIni.ReadString("ModbusTCPParams", "ModbusReadCount", "");
                gModbusReadCount = Convert.ToInt32(gIni.ReadString("ModbusTCPParams", "ModbusReadCount", ""));

                if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "1")
                {
                    gModbusCmd = 1;
                    cbxModbusCmd.SelectedIndex = 0;
                }
                else if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "2")
                {
                    gModbusCmd = 2;
                    cbxModbusCmd.SelectedIndex = 1;
                }
                else if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "3")
                {
                    gModbusCmd = 3;
                    cbxModbusCmd.SelectedIndex = 2;
                }
                else if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "4")
                {
                    gModbusCmd = 4;
                    cbxModbusCmd.SelectedIndex = 3;
                }
                else
                {
                    gModbusCmd = 3;
                    cbxModbusCmd.SelectedIndex = 2;
                }

                #endregion

                #region Modbus TCP 客户端事件绑定

                gTCPClient_Modbus.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);
                gTCPClient_Modbus.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);
                gTCPClient_Modbus.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);
                gTCPClient_Modbus.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);
                gTCPClient_Modbus.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);

                #endregion

                //根据需要制定日志列数，此处示例为两列
                gDtLogInfo.Columns.Add("Cycle Counter");
                gDtLogInfo.Columns[0].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Energy\n(J)");
                gDtLogInfo.Columns[1].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Trigger Pressure\n(mBar)");
                gDtLogInfo.Columns[2].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Weld Pressure\n(mBar)");
                gDtLogInfo.Columns[3].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Amplitude\n(μm)");
                gDtLogInfo.Columns[4].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Weld Time\n(ms)");
                gDtLogInfo.Columns[5].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Peak Power\n(W)");
                gDtLogInfo.Columns[6].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Preheight\n(μm)");
                gDtLogInfo.Columns[7].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Post Height\n(μm)");
                gDtLogInfo.Columns[8].DataType = Type.GetType("System.Int32");
                gDtLogInfo.Columns.Add("Error");
                gDtLogInfo.Columns[9].DataType = Type.GetType("System.String");
                gDtLogInfo.Columns.Add("Result");
                gDtLogInfo.Columns[10].DataType = Type.GetType("System.String");
                gDtLogInfo.Columns.Add("Repeat Cycle");
                gDtLogInfo.Columns[11].DataType = Type.GetType("System.Int32");
                //将数据源绑定，这样更新gDtLogInfo即可
                grdHisLog.DataSource = gDtLogInfo;

                //根据需要制定日志列数，此处示例为两列

                gDtLogInfoA.Columns.Add("Index");
                gDtLogInfoA.Columns[0].DataType = Type.GetType("System.Int32");
                gDtLogInfoA.Columns.Add("Item Description"); 
                gDtLogInfoA.Columns[1].DataType = Type.GetType("System.String");
                gDtLogInfoA.Columns.Add("From MQTT");
                gDtLogInfoA.Columns[2].DataType = Type.GetType("System.String");
                gDtLogInfoA.Columns.Add("From Modbus");
                gDtLogInfoA.Columns[3].DataType = Type.GetType("System.String");


                //将数据源绑定，这样更新gDtLogInfo即可
                grdDataLogA.DataSource = gDtLogInfoA;

                InitRecipeTable();

            }
            catch (Exception ex)
            {
                WriteSysLog("窗体加载报错：" + ex.ToString().Trim());
            }
        }

        #region 全局变量

        int[] jobCnt = new int[3]; // 0:良品数； 1：追加任务良品数； 2：不良数；
        int weldCnt = 0;            //焊接计数
        string jobKeyStr = string.Empty;
        int jobState = 0;

        ModbusTCPClass.WeldData weldData;

        string[] deviceStateStr =
        {
            "Running",
            "Alarming",
            "Learning",
            "Paused",
            "Ready",
            "Debugging",
            "Other",
        };

        string[] deviceStateCnStr =
        {
            "生产中",
            "报警故障中",
            "调试学习中",
            "生产暂停中",
            "设备待机中",
            "设备调试中",
            "其它",
        };

        string[] jobStateStr =
        {
            "InWork",
            "Pending",
            "Suspended",
            "Rejected",
            "Done",
        };

        int deviceState = 0;

        struct MQTTTopic
        {
            public const string JobReport = "V1/Publish/IoT/State/JobReport";
            public const string UnitQuality = "V1/Publish/IoT/Process/UnitQuality";
            public const string Alarm = "V1/Publish/IoT/State/Alarm";
            public const string Configuration = "V1/Publish/IoT/State/Configuration";
            public const string Heartbeat = "V1/Publish/IoT/State/Heartbeat";
            public const string DeviceVersion = "V1/Publish/IoT/State/DeviceVersion";
            public const string LearnRecord = "V1/Publish/IoT/Process/LearnRecord";
            public const string EnergyConsumption = "V1/Publish/IoT/Consumption/Energy";
            public const string Log = "V1/Publish/IoT/Log";
            public const string RequestArticles = "V1/Request/Application/Specification/Articles";
            public const string FeedbackArticles = "V1/Feedback/Application/Specification/Articles";
            public const string RequestJobs = "V1/Request/Application/Production/Jobs";
            public const string FeedbackJobs = "V1/Feedback/Application/Production/Jobs";
        }


        Queue<KeyValuePair<string, string>> mqttMsgQueue = new Queue<KeyValuePair<string, string>>();
        Queue<string> mqttMsgIdQueue = new Queue<string>();

        #region ListBox内容添加事件

        DoubleBufferListBox EventMsgListBox = new DoubleBufferListBox();                                       //实例化 ListBox
        private delegate void ShowEventMsg(string eventMsg);
        private ShowEventMsg AddMsgDelegate;

        #endregion

        #region MQTT相关变量

        IMqttClient mqttClient;                                                                                 //MQTT客户端
        MqttClientOptions mqttClientOptions;

        #endregion

        IniFilesClass gIni = new IniFilesClass("" + System.Windows.Forms.Application.StartupPath + "\\Config.ini");       //读取ini配置文件类实例
        ModbusTCPClass gModbusTCPClass = new ModbusTCPClass();                                                            //ModbusTCP类实例
        MesMsg  mesMsg = new MesMsg();

        //MQTT参数声明
        string gMQTTSvrIP = "127.0.0.1";
        ushort gMQTTSvrPort = 1885;
        string gMQTTUsername = "admin";
        string gMQTTPwd = "123456";
        int gMQTTPubTime = 5;

        //Modbus参数声明
        string gModbusSvrIP = "127.0.0.1";
        ushort gModbusSvrPort = 502;
        int gModbusSlaveID = 1;
        int gModbusCmd = 3;
        int gModbusStartAdd = 6800;
        int gModbusReadCount = 100;

        int gClearMemoryCount = 0;                                                                            //清理内存计时计数

        TcpClient gTCPClient_Modbus = new TcpClient();                                                        //ModbusTCP客户端

        Thread ThrdSendCmd;                                                                                   //发送Modbus命令获取数据的线程

        Thread ThrdMqttSend;

        Thread ThrdStateMachine;

        JsonMQTT_Publish gPublishJsonData = new JsonMQTT_Publish();                                           //通过MQTT发布的数据JSON类实例

        DataTable gDtLogInfo = new DataTable();                                                               //首页History Log 表格绑定的数据表

        DataTable gDtLogInfoA = new DataTable();                                                               //首页History Log 表格绑定的数据表

        DataTable gDtLogInfoB = new DataTable();                                                               //首页History Log 表格绑定的数据表

        DataRow[] drA = new DataRow[13];
        #endregion
        private void fmMain_Load(object sender, EventArgs e)
        {
            try
            {
                tabMain.SelectedIndex = 0;

                //软件运行日志委托声明,用于跨线程操作
                AddMsgDelegate = new ShowEventMsg(AddMsg);

                //MQTT启动
                Task.Run(async () => { await ConnectMqttServerAsync(); });

                //Modbus客户端连接
                gTCPClient_Modbus.Connect(gModbusSvrIP, gModbusSvrPort, true);

                //日期timer和MQTT Timer启动
                tmrMQTT.Interval = gMQTTPubTime * 1000;

                tmrDateTime.Enabled = true;
                tmrMQTT.Enabled = true;

                //取数命令线程启动
                ThrdSendCmd = new Thread(SendModbusCmd);
                ThrdSendCmd.IsBackground = true;
                ThrdSendCmd.Start();

                ThrdMqttSend = new Thread(MqttPublish);
                ThrdMqttSend.IsBackground = true;
                ThrdMqttSend.Start();

                ThrdStateMachine = new Thread(StateMachine);
                ThrdStateMachine.IsBackground = true;
                ThrdStateMachine.Start();

                label2.Text = deviceStateCnStr[deviceState];

                
            }
            catch (Exception ex)
            {
                WriteSysLog("窗体加载事件报错：" + ex.ToString().Trim());
            }
        }

        #region 参数设置界面

        /// <summary>
        /// 参数设置界面确认修改按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommParamsSet1_Click(object sender, EventArgs e)
        {

            gIni.WriteString("MQTTParams", "MqttServerIP", txtMQTTSvrIP.Text.Trim());
            gIni.WriteString("MQTTParams", "MqttServerPort", txtMQTTSvrPort.Text.Trim());
            gIni.WriteString("MQTTParams", "MQTTUsername", txtMQTTUsername.Text.Trim());
            gIni.WriteString("MQTTParams", "MQTTPwd", txtMQTTPwd.Text.Trim());


            gIni.WriteString("ModbusTCPParams", "ModbusSvrIP", txtModbusSvrIP.Text.Trim());
            gIni.WriteString("ModbusTCPParams", "ModbusSvrPort", textBox2.Text.Trim());
            gIni.WriteString("ModbusTCPParams", "SlaveID", textBox1.Text.Trim());
            gIni.WriteString("ModbusTCPParams", "ModbusStartAdd", txtModbusStartAddress.Text.Trim());
            gIni.WriteString("ModbusTCPParams", "ModbusReadCount", txtModbusReadCount.Text.Trim());
            gIni.WriteString("ModbusTCPParams", "ModbusCmd", (cbxModbusCmd.SelectedIndex + 1).ToString().Trim());

            MessageBox.Show("参数修改成功！");

            gMQTTSvrIP = gIni.ReadString("MQTTParams", "MqttServerIP", "");
            gMQTTSvrPort = ushort.Parse(gIni.ReadString("MQTTParams", "MqttServerPort", ""));
            gMQTTUsername = gIni.ReadString("MQTTParams", "MQTTUsername", "");
            gMQTTPwd = gIni.ReadString("MQTTParams", "MQTTPwd", "");
            gMQTTPubTime = Convert.ToInt32(gIni.ReadString("MQTTParams", "MQTTPubTime", ""));

            gModbusSvrIP = gIni.ReadString("ModbusTCPParams", "ModbusSvrIP", "");
            gModbusSvrPort = ushort.Parse(gIni.ReadString("ModbusTCPParams", "ModbusSvrPort", ""));
            gModbusSlaveID = Convert.ToInt32(gIni.ReadString("ModbusTCPParams", "SlaveID", ""));
            gModbusStartAdd = Convert.ToInt32(gIni.ReadString("ModbusTCPParams", "ModbusStartAdd", ""));
            gModbusReadCount = Convert.ToInt32(gIni.ReadString("ModbusTCPParams", "ModbusReadCount", ""));

            if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "1")
            {
                gModbusCmd = 1;
            }
            else if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "2")
            {
                gModbusCmd = 2;
            }
            else if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "3")
            {
                gModbusCmd = 3;
            }
            else if (gIni.ReadString("ModbusTCPParams", "ModbusCmd", "") == "4")
            {
                gModbusCmd = 4;
            }
            else
            {
                gModbusCmd = 3;
            }

        }

        /// <summary>
        /// 参数设置界面重启通讯按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestartServer1_Click(object sender, EventArgs e)
        {
            gTCPClient_Modbus.Stop();
            mqttClient.DisconnectAsync();
        }

        #endregion

        #region 运行日志界面

        /// <summary>
        /// 清空日志按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            EventMsgListBox.Items.Clear();
        }

        #endregion

        #region Timer事件

        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            try
            {
                #region 首页日志表格的示例

                // 声明一个数据行，是这个DataTable中的行格式
                DataRow dr = gDtLogInfo.NewRow();

                //因为最初定义了两列，所以给两列按定义的格式赋值，此处第一列为时间，第二列为秒的字符串格式
                dr[0] = DateTime.Now.Second;
                dr[1] = DateTime.Now.Hour.ToString();
                dr[2] = DateTime.Now.Minute.ToString();
                dr[3] = DateTime.Now.Second.ToString();

                //然后将这个数据行加入到这个DataTable中
                gDtLogInfo.Rows.InsertAt(dr,0);

                if (gDtLogInfo.Rows.Count > 1000)
                {
                    //保持最新的1000行
                    gDtLogInfo.Rows.RemoveAt(0);
                }
                else
                {

                }

                //保证表格一直显示在最新一行
                grdHisLog.FirstDisplayedScrollingRowIndex = gDtLogInfo.Rows.Count;

                #endregion

                #region 首页日志表格的示例 -A

                // 声明一个数据行，是这个DataTable中的行格式
                

                //保证表格一直显示在最新一行
                //grdDataLogA.FirstDisplayedScrollingRowIndex = gDtLogInfoA.Rows.Count;

                #endregion

                lblDate.Text = System.DateTime.Now.ToLongDateString();
                lblTime.Text = System.DateTime.Now.ToLongTimeString();

                gClearMemoryCount++;
                if (gClearMemoryCount > 86400)
                {
                    //每天清理一次内存
                    ClearMemory();
                    gClearMemoryCount = 0;

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                WriteSysLog("日期timer事件异常：" + ex.ToString().Trim());

            }
        }

        private void tmrMQTT_Tick(object sender, EventArgs e)
        {
            
            string val = mesMsg.PackMsgHeartbeat(deviceStateStr[deviceState]);

            KeyValuePair<string, string> mqttMsg = new KeyValuePair<string, string>(MQTTTopic.Heartbeat, val);

            mqttMsgQueue.Enqueue(mqttMsg);
            //try
            //{
            //    if (!mqttClient.IsConnected)
            //    {
            //        AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 客户端已与服务端断开，尝试重连！]"));
            //        mqttClient.ConnectAsync(mqttClientOptions);
            //    }
            //    else
            //    {
            //        //Publish(gMQTTPubTopic, JsonConvert.SerializeObject(gPublishJsonData));
            //        AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 发布数据] -> 发布主题:{0} 数据长度:{1}", gMQTTPubTopic, JsonConvert.SerializeObject(gPublishJsonData).Length));
            //    }
            //}
            //catch (Exception ex)
            //{

            //    WriteSysLog("实时数据发布Timer异常：" + ex.ToString().Trim());

            //}
        }

        #endregion

        #region 优化后的不闪烁的ListBox

        public class DoubleBufferListBox : ListBox//不闪烁的ListBox
        {
            public DoubleBufferListBox()
            {
                SetStyle(ControlStyles.DoubleBuffer |
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
            }
        }

        #endregion

        #region ListBox添加内容的方法
        void AddMsg(string msg)
        {
            if (this.EventMsgListBox.InvokeRequired)
            {
                //调用自己
                this.EventMsgListBox.Invoke(AddMsgDelegate, msg);
            }
            else
            {
                if (this.EventMsgListBox.Items.Count > 300)
                {
                    this.EventMsgListBox.Items.RemoveAt(0);
                }
                this.EventMsgListBox.Items.Add(msg);
                this.EventMsgListBox.TopIndex = this.EventMsgListBox.Items.Count - (int)(this.EventMsgListBox.Height / this.EventMsgListBox.ItemHeight);
            }
        }

        #endregion

        #region MQTT客户端

        private async Task ConnectMqttServerAsync()
        {
            try
            {
                mqttClient = new MqttFactory().CreateMqttClient();
                mqttClientOptions = new MqttClientOptionsBuilder()
                .WithClientId("ModbusToMQTT" + DateTime.Now.ToString("yyyyMMddHHmmss").Trim())
                .WithTcpServer(gMQTTSvrIP, gMQTTSvrPort)
                .WithCredentials(gMQTTUsername, gMQTTPwd)
                .WithCleanSession(true)
                .WithProtocolVersion(MqttProtocolVersion.V311)
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(2))
                .Build();

                mqttClient.ConnectedAsync += _mqttClient_ConnectedAsync;
                mqttClient.DisconnectedAsync += _mqttClient_DisconnectedAsync;
                mqttClient.ApplicationMessageReceivedAsync += _mqttClient_ApplicationMessageReceivedAsync;

                await mqttClient.ConnectAsync(mqttClientOptions);
            }
            catch (Exception ex)
            {

                AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 客户端与服务端建立链接失败]"));

                WriteSysLog("MQTT客户端建立链接异常" + ex.ToString());

            }

            //Subscribe("topic2");
        }

        /// <summary>
        /// 客户端连接关闭事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task _mqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {

            AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 客户端已断开与服务端的链接]"));

            return Task.CompletedTask;
        }

        /// <summary>
        /// 客户端连接成功事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task _mqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            //Console.WriteLine($"客户端已连接服务端……");

            // 订阅消息主题
            // MqttQualityOfServiceLevel: （QoS）:  0 最多一次，接收者不确认收到消息，并且消息不被发送者存储和重新发送提供与底层 TCP 协议相同的保证。
            // 1: 保证一条消息至少有一次会传递给接收方。发送方存储消息，直到它从接收方收到确认收到消息的数据包。一条消息可以多次发送或传递。
            // 2: 保证每条消息仅由预期的收件人接收一次。级别2是最安全和最慢的服务质量级别，保证由发送方和接收方之间的至少两个请求/响应（四次握手）。

            //mqttClient.SubscribeAsync("RadMonitor/ThrdSearch", MqttQualityOfServiceLevel.AtLeastOnce);                          //订阅查询阈值信息

            AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 客户端已与服务端建立链接]"));

            mqttClient.SubscribeAsync(MQTTTopic.RequestArticles, MqttQualityOfServiceLevel.ExactlyOnce);
            mqttClient.SubscribeAsync(MQTTTopic.RequestJobs, MqttQualityOfServiceLevel.ExactlyOnce);


            return Task.CompletedTask;
        }

        /// <summary>
        /// 收到消息事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task _mqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            string val = string.Empty;
            try
            {
                //Console.WriteLine($"ApplicationMessageReceivedAsync：客户端ID=【{arg.ClientId}】接收到消息。 Topic主题=【{arg.ApplicationMessage.Topic}】 消息=【{Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}】 qos等级=【{arg.ApplicationMessage.QualityOfServiceLevel}】");

                AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 接收订阅数据：{0}] -> 客户端ID:{1} 数据长度:{2}", arg.ApplicationMessage.Topic, arg.ClientId, arg.ApplicationMessage.Payload.Length));

                switch (arg.ApplicationMessage.Topic)
                {
                    case MQTTTopic.RequestArticles:
                        mesMsg.ParseMsgRequestArticle(Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
                        val = mesMsg.PackMsgFeedbackSpecArticle();
                        KeyValuePair<string, string> pair1 = new KeyValuePair<string, string>(MQTTTopic.FeedbackArticles, val);
                        mqttMsgQueue.Enqueue(pair1);
                        break;
                    case  MQTTTopic.RequestJobs:
                        mesMsg.ParseMsgRequestJob(Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
                        val = mesMsg.PackMsgFeedbackSpecArticle();
                        KeyValuePair<string, string> pair2 = new KeyValuePair<string, string>(MQTTTopic.FeedbackJobs, val);
                        mqttMsgQueue.Enqueue(pair2);
                        break;
                    default:

                        break;
                }
                
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                WriteSysLog("订阅接收命令代码块错误" + ex.ToString());

                return Task.CompletedTask;
            }
        }
        /// <summary>
        /// 数据发布
        /// </summary>
        /// <param name="data">要发布的数据</param>
        public void Publish(string topic, string data)
        {


            var message = new MqttApplicationMessage
            {
                Topic = topic,
                Payload = Encoding.UTF8.GetBytes(data),
                QualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce,
                Retain = false, // 服务端是否保留消息。true为保留，如果有新的订阅者连接，就会立马收到该消息。
                UserProperties = new List<MqttUserProperty>()
                {
                    new MqttUserProperty("DateTime", DateTime.Now.ToString("O").Trim()),
                 }
            };

            if(topic == MQTTTopic.FeedbackArticles || topic == MQTTTopic.FeedbackJobs)
            {
                message.UserProperties.Add(new MqttUserProperty("MessageId", mqttMsgIdQueue.Dequeue()));
            }
            
            mqttClient.PublishAsync(message);
        }

        public void Subscribe(string topic)                 //订阅
        {
            MqttClientSubscribeOptions subOptions = new MqttClientSubscribeOptions();

            subOptions.TopicFilters = new List<MQTTnet.Packets.MqttTopicFilter>();
            {
                new MQTTnet.Packets.MqttTopicFilter()
                {
                    Topic = topic,
                    QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce
                };
            }

            mqttClient.SubscribeAsync(subOptions);
        }



        #endregion

        #region MQTT发布数据的JSON类

        public class JsonMQTT_Publish
        {
            /// <summary>
            /// 要发送的数据1
            /// </summary>
            public float Value1 { get; set; }
            /// <summary>
            /// 要发送的数据2
            /// </summary>
            public float Value2 { get; set; }
        }

        #endregion

        #region 发送Modbus取数命令线程

        void SendModbusCmd()
        {

            while (true)
            {

                byte[] sendCmdByteArray = gModbusTCPClass.GetModbusTCPSendCmd((byte)gModbusSlaveID, (byte)gModbusCmd, (ushort)gModbusStartAdd, (ushort)gModbusReadCount);

                if (gTCPClient_Modbus.Send(sendCmdByteArray, sendCmdByteArray.Length))
                {
                    AddMsg(string.Format("" + DateTime.Now.ToString() + " > [Modbus-TCP -> 发送数据] ->  数据长度:{0}", sendCmdByteArray.Length));
                }
                else
                {
                    AddMsg(string.Format("" + DateTime.Now.ToString() + " > [Modbus-TCP -> 通讯信息] ->  发送数据失败，尝试重连！"));
                    gTCPClient_Modbus.Connect(gModbusSvrIP, gModbusSvrPort, true);
                }

                Thread.Sleep(1000);
            }
        }

        #endregion

        #region Modbus-TCP TCPClient事件

        HandleResult OnPrepareConnect(TcpClient sender, IntPtr socket)
        {
            return HandleResult.Ok;
        }

        HandleResult OnConnect(TcpClient sender)
        {
            // 已连接 到达一次

            // 如果是异步联接,更新界面状态
            AddMsg(string.Format("" + DateTime.Now.ToString() + " > [Modbus-TCP -> 通讯信息] ->  客户端连接成功！"));

            return HandleResult.Ok;
        }

        HandleResult OnSend(TcpClient sender, byte[] bytes)
        {
            // 客户端发数据了

            return HandleResult.Ok;
        }

        HandleResult OnReceive(TcpClient sender, byte[] bytes)
        {
            try
            {
                AddMsg(string.Format("" + DateTime.Now.ToString() + " > [Modbus-TCP -> 接收数据] ->  数据长度:{0}", bytes.Length));

                weldData = WeldData.FromBytes(bytes);

                ////解析接收到的数据，已封装好，可查看ModbusTCPClass.JsonModbusTCPRevData_Master中每个项的定义，按需使用即可
                //ModbusTCPClass.JsonModbusTCPRevData_Master receiveDataJson = gModbusTCPClass.GetModbusTCPRevData_Master(bytes);

                ////此处为示意，更新要发布的数据
                //gPublishJsonData.Value1 = receiveDataJson.AnalysisData03[0];
                //gPublishJsonData.Value2 = receiveDataJson.AnalysisData03[1];
            }
            catch (Exception ex)
            {
                WriteSysLog("Modbus客户端数据解析异常：" + ex.ToString().Trim());
            }

            return HandleResult.Ok;
        }

        HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            AddMsg(string.Format("" + DateTime.Now.ToString() + " > [Modbus-TCP -> 通讯信息] ->  客户端断开连接！"));

            return HandleResult.Ok;
        }


        #endregion

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }


        #endregion

        #region 记录日志方法
        /// <summary>
        /// 写异常日志
        /// </summary>
        /// <param name="logStr">日志内容</param>
        public void WriteSysLog(string logStr)
        {
            string logPath = "" + System.Windows.Forms.Application.StartupPath + "\\SysLog\\" + DateTime.Now.Year.ToString().Trim() + "年\\" + DateTime.Now.Month.ToString().Trim() + "月\\" + DateTime.Now.Day.ToString().Trim() + "日";

            //先判断路径文件夹是否存在，不存在新建文件夹
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            //日志全路径
            string fname = logPath + "\\SysLog.txt";

            //定义文件信息对象
            FileInfo finfo = new FileInfo(fname);

            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
            }


            if (IsFileLocked(fname))
            {

                //如果被占用则不进行操作
            }
            else
            {
                if (finfo.Length > 104857600)
                {
                    string logNameDTStr = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
                    //文件超过100MB则重命名
                    File.Move(fname, logPath + "\\SysLog" + logNameDTStr + ".txt");
                }

                //创建只写文件流
                using (FileStream fs = finfo.OpenWrite())
                {
                    //根据上面创建的文件流创建写数据流
                    StreamWriter w = new StreamWriter(fs);

                    //设置写数据流的起始位置为文件流的末尾
                    w.BaseStream.Seek(0, SeekOrigin.End);

                    //写入当前系统时间并换行
                    w.Write("[NowTime->" + DateTime.Now.ToString() + "] Log:");

                    //写入日志内容并换行
                    w.Write(logStr + "\r\n");

                    //清空缓冲区内容，并把缓冲区内容写入基础流
                    w.Flush();

                    //关闭写数据流
                    w.Close();
                }
            }

        }
        /// <summary>
        /// 写运行日志
        /// </summary>
        /// <param name="logStr">日志内容</param>
        public void WriteRunLog(string logStr)
        {
            string logPath = "" + System.Windows.Forms.Application.StartupPath + "\\RunLog\\" + DateTime.Now.Year.ToString().Trim() + "年\\" + DateTime.Now.Month.ToString().Trim() + "月";

            //先判断路径文件夹是否存在，不存在新建文件夹
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            //日志全路径
            string fname = logPath + "\\RunLog.txt";

            //定义文件信息对象
            FileInfo finfo = new FileInfo(fname);

            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
            }


            if (IsFileLocked(fname))
            {

                //如果被占用则不进行操作
                //WriteSysLog("被占用：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
            else
            {
                if (finfo.Length > 104857600)
                {
                    string logNameDTStr = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
                    //文件超过100MB则重命名
                    File.Move(fname, logPath + "\\RunLog" + logNameDTStr + ".txt");
                }

                //创建只写文件流
                using (FileStream fs = finfo.OpenWrite())
                {
                    //根据上面创建的文件流创建写数据流
                    StreamWriter w = new StreamWriter(fs);

                    //设置写数据流的起始位置为文件流的末尾
                    w.BaseStream.Seek(0, SeekOrigin.End);

                    //写入当前系统时间并换行
                    w.Write("[NowTime->" + DateTime.Now.ToString() + "] Log:");

                    //写入日志内容并换行
                    w.Write(logStr + "\r\n");

                    //清空缓冲区内容，并把缓冲区内容写入基础流
                    w.Flush();

                    //关闭写数据流
                    w.Close();
                }
            }

        }
        /// <summary>
        /// 文件是否被占用
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }




        #endregion

        /// <summary>
        /// 将日志表格中数据导出至文本
        /// </summary>
        /// <param name="dtLog">日志表格绑定的DataTable，即本文中的gDtLogInfo</param>
        public void ExportLogToTxt(DataTable dtLog)
        {
            for (int i = 0; i < dtLog.Rows.Count; i++)
            {
                //将每行日志，用逗号分割后，写入RunLog文件夹中文本
                string str = dtLog.Rows[i][0].ToString().Trim() + "," + dtLog.Rows[i][1].ToString().Trim();
                //若需修改路径，请去WriteRunLog中修改
                WriteRunLog(str);
            }
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        void MqttPublish()
        {
            while (true)
            {
                if (mqttMsgQueue.Count > 0)
                {
                    KeyValuePair<string, string> mqttMsg = mqttMsgQueue.Dequeue();

                    if (mqttClient.IsConnected)
                    {
                        Publish(mqttMsg.Key, mqttMsg.Value);
                        AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 发布数据] -> 发布主题:{0} 数据长度:{1}", mqttMsg.Key, mqttMsg.Value));
                    }
                    else
                    {
                        AddMsg(string.Format("" + DateTime.Now.ToString() + " > [MQTT -> 客户端已与服务端断开，尝试重连！]"));
                        mqttClient.ConnectAsync(mqttClientOptions);
                    }
                    Thread.Sleep(gMQTTPubTime * 1000);
                }
                Thread.Sleep(20);
            }
        }

        void StateMachine()
        {
            
            while (true)
            {
                if(weldData.Counter != weldCnt)
                {
                    weldCnt = weldData.Counter;
                   

                    if (weldData.WeldErrorCode != 0)
                    {
                        jobCnt[2]++;


                    }
                    else
                    {
                        jobCnt[0]++;
                    }

                    string val = mesMsg.PackMsgJobReport(jobKeyStr, jobStateStr[jobState], jobCnt);
                    KeyValuePair<string, string> msg = new KeyValuePair<string, string>(MQTTTopic.JobReport, val);
                    mqttMsgQueue.Enqueue(msg);



                    DataRow dr = gDtLogInfo.NewRow();

                    dr[0] = weldData.Counter;
                    dr[1] = weldData.Barcode1;
                    dr[2] = weldData.WeldErrorCode;
                    dr[3] = "OK";

                    gDtLogInfo.Rows.Add(dr);

                    if (gDtLogInfo.Rows.Count > 1000)
                    {
                        //保持最新的1000行
                        gDtLogInfo.Rows.RemoveAt(0);
                    }
                    else
                    {

                    }

                    //保证表格一直显示在最新一行
                    grdHisLog.FirstDisplayedScrollingRowIndex = gDtLogInfo.Rows.Count;

                }

                Thread.Sleep(100);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = deviceStateCnStr[deviceState];
        }

        public void InitRecipeTable()
        {
            string[] str =
            {
                "Recipe Name",
                "Weld Pressure(mBar)",
                "Amplitude(μm)",
                "Energy(J)",
                "Preheight+(μm)",
                "Preheight-(μm)",
                "Weld Time+(ms)",
                "Weld Time-(ms)",
                "Weld Power+(W)",
                "Weld Power-(W)",
                "Post Height+(μm)",
                "Post Height-(μm)",
                "Trigger Pressure(mBar)",
            };
            //因为最初定义了两列，所以给两列按定义的格式赋值，此处第一列为时间，第二列为秒的字符串格式
            for(int i = 0;i<13;i++)
            {
                drA[i] = gDtLogInfoA.NewRow();
                drA[i][0] = i + 1;
                drA[i][1] = str[i];
                drA[i][2] = "NA";
                drA[i][3] = "NA";
                gDtLogInfoA.Rows.Add(drA[i]);
            }
        }

        public void UpdateRecipeTable()
        {


        }
    }
}
