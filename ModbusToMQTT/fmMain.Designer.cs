
namespace ModbusToMQTT
{
    partial class fmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.tabMain = new DMSkin.Metro.Controls.MetroTabControl();
            this.tapLogShow = new DMSkin.Metro.Controls.MetroTabPage();
            this.grdHisLog = new System.Windows.Forms.DataGridView();
            this.picLogShowLogoWF = new System.Windows.Forms.PictureBox();
            this.lblLogShowCopyRightText = new System.Windows.Forms.Label();
            this.tapStatusShow1 = new DMSkin.Metro.Controls.MetroTabPage();
            this.pnlCommSettings = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.grpMQTTInfo = new System.Windows.Forms.GroupBox();
            this.txtPubTime = new System.Windows.Forms.TextBox();
            this.lblPubTimeTxt = new System.Windows.Forms.Label();
            this.txtMQTTPwd = new System.Windows.Forms.TextBox();
            this.txtPubTopic = new System.Windows.Forms.TextBox();
            this.lblPubTopicTxt = new System.Windows.Forms.Label();
            this.txtSubTopic = new System.Windows.Forms.TextBox();
            this.lblSubTopicTxt = new System.Windows.Forms.Label();
            this.lblMQTTPwdTxt = new System.Windows.Forms.Label();
            this.txtMQTTSvrIP = new System.Windows.Forms.TextBox();
            this.lblMQTTSvrIPTxt = new System.Windows.Forms.Label();
            this.txtMQTTSvrPort = new System.Windows.Forms.TextBox();
            this.lblMQTTSvrPortTxt = new System.Windows.Forms.Label();
            this.txtMQTTUsername = new System.Windows.Forms.TextBox();
            this.lblMQTTUsernameTxt = new System.Windows.Forms.Label();
            this.grpModbusTCPInfo = new System.Windows.Forms.GroupBox();
            this.txtModbusReadCount = new System.Windows.Forms.TextBox();
            this.lblModbusReadCountTxt = new System.Windows.Forms.Label();
            this.txtModbusStartAddress = new System.Windows.Forms.TextBox();
            this.lblModbusStartAddressTxt = new System.Windows.Forms.Label();
            this.lblModbusCmdTxt = new System.Windows.Forms.Label();
            this.cbxModbusCmd = new System.Windows.Forms.ComboBox();
            this.txtModbusSvrIP = new System.Windows.Forms.TextBox();
            this.lblModbusSvrIPTxt = new System.Windows.Forms.Label();
            this.txtModbusSvrPort = new System.Windows.Forms.TextBox();
            this.lblModbusSvrPortTxt = new System.Windows.Forms.Label();
            this.txtSlaveID = new System.Windows.Forms.TextBox();
            this.lblSlaveIDTxt = new System.Windows.Forms.Label();
            this.btnRestartServer1 = new System.Windows.Forms.Button();
            this.btnCommParamsSet1 = new System.Windows.Forms.Button();
            this.picStatusShowLogoWF1 = new System.Windows.Forms.PictureBox();
            this.lblStatusShowCopyRightText1 = new System.Windows.Forms.Label();
            this.tapSetting = new DMSkin.Metro.Controls.MetroTabPage();
            this.pnlLogShow = new System.Windows.Forms.Panel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.picSettingLogoWF = new System.Windows.Forms.PictureBox();
            this.lblSettingCopyRightText = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.tmrMQTT = new System.Windows.Forms.Timer(this.components);
            this.tmrDateTime = new System.Windows.Forms.Timer(this.components);
            this.tabMain.SuspendLayout();
            this.tapLogShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHisLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogShowLogoWF)).BeginInit();
            this.tapStatusShow1.SuspendLayout();
            this.pnlCommSettings.SuspendLayout();
            this.grpMQTTInfo.SuspendLayout();
            this.grpModbusTCPInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusShowLogoWF1)).BeginInit();
            this.tapSetting.SuspendLayout();
            this.pnlLogShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingLogoWF)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tapLogShow);
            this.tabMain.Controls.Add(this.tapStatusShow1);
            this.tabMain.Controls.Add(this.tapSetting);
            this.tabMain.DM_UseSelectable = true;
            this.tabMain.Location = new System.Drawing.Point(-5, 76);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(995, 565);
            this.tabMain.TabIndex = 6;
            // 
            // tapLogShow
            // 
            this.tapLogShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.tapLogShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tapLogShow.Controls.Add(this.grdHisLog);
            this.tapLogShow.Controls.Add(this.picLogShowLogoWF);
            this.tapLogShow.Controls.Add(this.lblLogShowCopyRightText);
            this.tapLogShow.DM_UseCustomBackColor = true;
            this.tapLogShow.DM_UseCustomForeColor = true;
            this.tapLogShow.DM_UseStyleColors = true;
            this.tapLogShow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tapLogShow.HorizontalScrollbarBarColor = true;
            this.tapLogShow.HorizontalScrollbarDM_HighlightOnWheel = false;
            this.tapLogShow.HorizontalScrollbarSize = 10;
            this.tapLogShow.Location = new System.Drawing.Point(4, 39);
            this.tapLogShow.Name = "tapLogShow";
            this.tapLogShow.Size = new System.Drawing.Size(987, 522);
            this.tapLogShow.TabIndex = 0;
            this.tapLogShow.Text = "          首页          ";
            this.tapLogShow.VerticalScrollbarBarColor = true;
            this.tapLogShow.VerticalScrollbarDM_HighlightOnWheel = false;
            this.tapLogShow.VerticalScrollbarSize = 10;
            // 
            // grdHisLog
            // 
            this.grdHisLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdHisLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdHisLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdHisLog.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdHisLog.Location = new System.Drawing.Point(22, 47);
            this.grdHisLog.Name = "grdHisLog";
            this.grdHisLog.ReadOnly = true;
            this.grdHisLog.RowTemplate.Height = 23;
            this.grdHisLog.Size = new System.Drawing.Size(951, 436);
            this.grdHisLog.TabIndex = 59;
            // 
            // picLogShowLogoWF
            // 
            this.picLogShowLogoWF.BackColor = System.Drawing.Color.Transparent;
            this.picLogShowLogoWF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLogShowLogoWF.Location = new System.Drawing.Point(648, 499);
            this.picLogShowLogoWF.Name = "picLogShowLogoWF";
            this.picLogShowLogoWF.Size = new System.Drawing.Size(24, 20);
            this.picLogShowLogoWF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogShowLogoWF.TabIndex = 58;
            this.picLogShowLogoWF.TabStop = false;
            // 
            // lblLogShowCopyRightText
            // 
            this.lblLogShowCopyRightText.BackColor = System.Drawing.Color.Transparent;
            this.lblLogShowCopyRightText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLogShowCopyRightText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(52)))), ((int)(((byte)(127)))));
            this.lblLogShowCopyRightText.Location = new System.Drawing.Point(670, 499);
            this.lblLogShowCopyRightText.Name = "lblLogShowCopyRightText";
            this.lblLogShowCopyRightText.Size = new System.Drawing.Size(314, 20);
            this.lblLogShowCopyRightText.TabIndex = 57;
            this.lblLogShowCopyRightText.Text = "CopyRight©XXXXXXXXXXXX INC.";
            this.lblLogShowCopyRightText.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tapStatusShow1
            // 
            this.tapStatusShow1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.tapStatusShow1.Controls.Add(this.pnlCommSettings);
            this.tapStatusShow1.Controls.Add(this.picStatusShowLogoWF1);
            this.tapStatusShow1.Controls.Add(this.lblStatusShowCopyRightText1);
            this.tapStatusShow1.DM_UseCustomBackColor = true;
            this.tapStatusShow1.DM_UseCustomForeColor = true;
            this.tapStatusShow1.DM_UseStyleColors = true;
            this.tapStatusShow1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tapStatusShow1.HorizontalScrollbarBarColor = true;
            this.tapStatusShow1.HorizontalScrollbarDM_HighlightOnWheel = false;
            this.tapStatusShow1.HorizontalScrollbarSize = 10;
            this.tapStatusShow1.Location = new System.Drawing.Point(4, 39);
            this.tapStatusShow1.Name = "tapStatusShow1";
            this.tapStatusShow1.Size = new System.Drawing.Size(987, 522);
            this.tapStatusShow1.TabIndex = 1;
            this.tapStatusShow1.Text = "         参数设置         ";
            this.tapStatusShow1.VerticalScrollbarBarColor = true;
            this.tapStatusShow1.VerticalScrollbarDM_HighlightOnWheel = false;
            this.tapStatusShow1.VerticalScrollbarSize = 10;
            // 
            // pnlCommSettings
            // 
            this.pnlCommSettings.BackColor = System.Drawing.Color.White;
            this.pnlCommSettings.Controls.Add(this.lblVersion);
            this.pnlCommSettings.Controls.Add(this.grpMQTTInfo);
            this.pnlCommSettings.Controls.Add(this.grpModbusTCPInfo);
            this.pnlCommSettings.Controls.Add(this.btnRestartServer1);
            this.pnlCommSettings.Controls.Add(this.btnCommParamsSet1);
            this.pnlCommSettings.Location = new System.Drawing.Point(13, 17);
            this.pnlCommSettings.Name = "pnlCommSettings";
            this.pnlCommSettings.Size = new System.Drawing.Size(960, 479);
            this.pnlCommSettings.TabIndex = 70;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVersion.Location = new System.Drawing.Point(799, 457);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(157, 20);
            this.lblVersion.TabIndex = 117;
            this.lblVersion.Text = "版本号：V1.0.00";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // grpMQTTInfo
            // 
            this.grpMQTTInfo.Controls.Add(this.txtPubTime);
            this.grpMQTTInfo.Controls.Add(this.lblPubTimeTxt);
            this.grpMQTTInfo.Controls.Add(this.txtMQTTPwd);
            this.grpMQTTInfo.Controls.Add(this.txtPubTopic);
            this.grpMQTTInfo.Controls.Add(this.lblPubTopicTxt);
            this.grpMQTTInfo.Controls.Add(this.txtSubTopic);
            this.grpMQTTInfo.Controls.Add(this.lblSubTopicTxt);
            this.grpMQTTInfo.Controls.Add(this.lblMQTTPwdTxt);
            this.grpMQTTInfo.Controls.Add(this.txtMQTTSvrIP);
            this.grpMQTTInfo.Controls.Add(this.lblMQTTSvrIPTxt);
            this.grpMQTTInfo.Controls.Add(this.txtMQTTSvrPort);
            this.grpMQTTInfo.Controls.Add(this.lblMQTTSvrPortTxt);
            this.grpMQTTInfo.Controls.Add(this.txtMQTTUsername);
            this.grpMQTTInfo.Controls.Add(this.lblMQTTUsernameTxt);
            this.grpMQTTInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grpMQTTInfo.Location = new System.Drawing.Point(12, 203);
            this.grpMQTTInfo.Name = "grpMQTTInfo";
            this.grpMQTTInfo.Size = new System.Drawing.Size(931, 189);
            this.grpMQTTInfo.TabIndex = 73;
            this.grpMQTTInfo.TabStop = false;
            this.grpMQTTInfo.Text = "MQTT参数设置";
            // 
            // txtPubTime
            // 
            this.txtPubTime.Location = new System.Drawing.Point(129, 143);
            this.txtPubTime.Name = "txtPubTime";
            this.txtPubTime.Size = new System.Drawing.Size(140, 26);
            this.txtPubTime.TabIndex = 90;
            // 
            // lblPubTimeTxt
            // 
            this.lblPubTimeTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPubTimeTxt.Location = new System.Drawing.Point(6, 142);
            this.lblPubTimeTxt.Name = "lblPubTimeTxt";
            this.lblPubTimeTxt.Size = new System.Drawing.Size(115, 29);
            this.lblPubTimeTxt.TabIndex = 89;
            this.lblPubTimeTxt.Text = "发布频率（s）：";
            this.lblPubTimeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMQTTPwd
            // 
            this.txtMQTTPwd.Location = new System.Drawing.Point(129, 95);
            this.txtMQTTPwd.Name = "txtMQTTPwd";
            this.txtMQTTPwd.Size = new System.Drawing.Size(140, 26);
            this.txtMQTTPwd.TabIndex = 88;
            // 
            // txtPubTopic
            // 
            this.txtPubTopic.Location = new System.Drawing.Point(766, 95);
            this.txtPubTopic.Name = "txtPubTopic";
            this.txtPubTopic.Size = new System.Drawing.Size(140, 26);
            this.txtPubTopic.TabIndex = 87;
            // 
            // lblPubTopicTxt
            // 
            this.lblPubTopicTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPubTopicTxt.Location = new System.Drawing.Point(653, 91);
            this.lblPubTopicTxt.Name = "lblPubTopicTxt";
            this.lblPubTopicTxt.Size = new System.Drawing.Size(107, 29);
            this.lblPubTopicTxt.TabIndex = 86;
            this.lblPubTopicTxt.Text = "发布主题：";
            this.lblPubTopicTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubTopic
            // 
            this.txtSubTopic.Location = new System.Drawing.Point(453, 95);
            this.txtSubTopic.Name = "txtSubTopic";
            this.txtSubTopic.Size = new System.Drawing.Size(140, 26);
            this.txtSubTopic.TabIndex = 85;
            // 
            // lblSubTopicTxt
            // 
            this.lblSubTopicTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubTopicTxt.Location = new System.Drawing.Point(346, 92);
            this.lblSubTopicTxt.Name = "lblSubTopicTxt";
            this.lblSubTopicTxt.Size = new System.Drawing.Size(99, 29);
            this.lblSubTopicTxt.TabIndex = 84;
            this.lblSubTopicTxt.Text = "订阅主题：";
            this.lblSubTopicTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMQTTPwdTxt
            // 
            this.lblMQTTPwdTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMQTTPwdTxt.Location = new System.Drawing.Point(22, 94);
            this.lblMQTTPwdTxt.Name = "lblMQTTPwdTxt";
            this.lblMQTTPwdTxt.Size = new System.Drawing.Size(99, 29);
            this.lblMQTTPwdTxt.TabIndex = 83;
            this.lblMQTTPwdTxt.Text = "密码：";
            this.lblMQTTPwdTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMQTTSvrIP
            // 
            this.txtMQTTSvrIP.Location = new System.Drawing.Point(129, 46);
            this.txtMQTTSvrIP.Name = "txtMQTTSvrIP";
            this.txtMQTTSvrIP.Size = new System.Drawing.Size(140, 26);
            this.txtMQTTSvrIP.TabIndex = 81;
            // 
            // lblMQTTSvrIPTxt
            // 
            this.lblMQTTSvrIPTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMQTTSvrIPTxt.Location = new System.Drawing.Point(22, 43);
            this.lblMQTTSvrIPTxt.Name = "lblMQTTSvrIPTxt";
            this.lblMQTTSvrIPTxt.Size = new System.Drawing.Size(99, 29);
            this.lblMQTTSvrIPTxt.TabIndex = 80;
            this.lblMQTTSvrIPTxt.Text = "服务器地址：";
            this.lblMQTTSvrIPTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMQTTSvrPort
            // 
            this.txtMQTTSvrPort.Location = new System.Drawing.Point(453, 46);
            this.txtMQTTSvrPort.Name = "txtMQTTSvrPort";
            this.txtMQTTSvrPort.Size = new System.Drawing.Size(140, 26);
            this.txtMQTTSvrPort.TabIndex = 79;
            // 
            // lblMQTTSvrPortTxt
            // 
            this.lblMQTTSvrPortTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMQTTSvrPortTxt.Location = new System.Drawing.Point(346, 43);
            this.lblMQTTSvrPortTxt.Name = "lblMQTTSvrPortTxt";
            this.lblMQTTSvrPortTxt.Size = new System.Drawing.Size(99, 29);
            this.lblMQTTSvrPortTxt.TabIndex = 78;
            this.lblMQTTSvrPortTxt.Text = "服务器端口：";
            this.lblMQTTSvrPortTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMQTTUsername
            // 
            this.txtMQTTUsername.Location = new System.Drawing.Point(766, 46);
            this.txtMQTTUsername.Name = "txtMQTTUsername";
            this.txtMQTTUsername.Size = new System.Drawing.Size(140, 26);
            this.txtMQTTUsername.TabIndex = 77;
            // 
            // lblMQTTUsernameTxt
            // 
            this.lblMQTTUsernameTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMQTTUsernameTxt.Location = new System.Drawing.Point(653, 42);
            this.lblMQTTUsernameTxt.Name = "lblMQTTUsernameTxt";
            this.lblMQTTUsernameTxt.Size = new System.Drawing.Size(107, 29);
            this.lblMQTTUsernameTxt.TabIndex = 76;
            this.lblMQTTUsernameTxt.Text = "用户名：";
            this.lblMQTTUsernameTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpModbusTCPInfo
            // 
            this.grpModbusTCPInfo.Controls.Add(this.txtModbusReadCount);
            this.grpModbusTCPInfo.Controls.Add(this.lblModbusReadCountTxt);
            this.grpModbusTCPInfo.Controls.Add(this.txtModbusStartAddress);
            this.grpModbusTCPInfo.Controls.Add(this.lblModbusStartAddressTxt);
            this.grpModbusTCPInfo.Controls.Add(this.lblModbusCmdTxt);
            this.grpModbusTCPInfo.Controls.Add(this.cbxModbusCmd);
            this.grpModbusTCPInfo.Controls.Add(this.txtModbusSvrIP);
            this.grpModbusTCPInfo.Controls.Add(this.lblModbusSvrIPTxt);
            this.grpModbusTCPInfo.Controls.Add(this.txtModbusSvrPort);
            this.grpModbusTCPInfo.Controls.Add(this.lblModbusSvrPortTxt);
            this.grpModbusTCPInfo.Controls.Add(this.txtSlaveID);
            this.grpModbusTCPInfo.Controls.Add(this.lblSlaveIDTxt);
            this.grpModbusTCPInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grpModbusTCPInfo.Location = new System.Drawing.Point(12, 20);
            this.grpModbusTCPInfo.Name = "grpModbusTCPInfo";
            this.grpModbusTCPInfo.Size = new System.Drawing.Size(931, 154);
            this.grpModbusTCPInfo.TabIndex = 72;
            this.grpModbusTCPInfo.TabStop = false;
            this.grpModbusTCPInfo.Text = "Modbus-TCP参数设置";
            // 
            // txtModbusReadCount
            // 
            this.txtModbusReadCount.Location = new System.Drawing.Point(766, 95);
            this.txtModbusReadCount.Name = "txtModbusReadCount";
            this.txtModbusReadCount.Size = new System.Drawing.Size(140, 26);
            this.txtModbusReadCount.TabIndex = 87;
            // 
            // lblModbusReadCountTxt
            // 
            this.lblModbusReadCountTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModbusReadCountTxt.Location = new System.Drawing.Point(653, 91);
            this.lblModbusReadCountTxt.Name = "lblModbusReadCountTxt";
            this.lblModbusReadCountTxt.Size = new System.Drawing.Size(107, 29);
            this.lblModbusReadCountTxt.TabIndex = 86;
            this.lblModbusReadCountTxt.Text = "读取个数：";
            this.lblModbusReadCountTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtModbusStartAddress
            // 
            this.txtModbusStartAddress.Location = new System.Drawing.Point(453, 95);
            this.txtModbusStartAddress.Name = "txtModbusStartAddress";
            this.txtModbusStartAddress.Size = new System.Drawing.Size(140, 26);
            this.txtModbusStartAddress.TabIndex = 85;
            // 
            // lblModbusStartAddressTxt
            // 
            this.lblModbusStartAddressTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModbusStartAddressTxt.Location = new System.Drawing.Point(346, 92);
            this.lblModbusStartAddressTxt.Name = "lblModbusStartAddressTxt";
            this.lblModbusStartAddressTxt.Size = new System.Drawing.Size(99, 29);
            this.lblModbusStartAddressTxt.TabIndex = 84;
            this.lblModbusStartAddressTxt.Text = "起始地址：";
            this.lblModbusStartAddressTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblModbusCmdTxt
            // 
            this.lblModbusCmdTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModbusCmdTxt.Location = new System.Drawing.Point(22, 94);
            this.lblModbusCmdTxt.Name = "lblModbusCmdTxt";
            this.lblModbusCmdTxt.Size = new System.Drawing.Size(99, 29);
            this.lblModbusCmdTxt.TabIndex = 83;
            this.lblModbusCmdTxt.Text = "读取命令：";
            this.lblModbusCmdTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxModbusCmd
            // 
            this.cbxModbusCmd.FormattingEnabled = true;
            this.cbxModbusCmd.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04"});
            this.cbxModbusCmd.Location = new System.Drawing.Point(129, 95);
            this.cbxModbusCmd.Name = "cbxModbusCmd";
            this.cbxModbusCmd.Size = new System.Drawing.Size(140, 28);
            this.cbxModbusCmd.TabIndex = 82;
            // 
            // txtModbusSvrIP
            // 
            this.txtModbusSvrIP.Location = new System.Drawing.Point(129, 46);
            this.txtModbusSvrIP.Name = "txtModbusSvrIP";
            this.txtModbusSvrIP.Size = new System.Drawing.Size(140, 26);
            this.txtModbusSvrIP.TabIndex = 81;
            // 
            // lblModbusSvrIPTxt
            // 
            this.lblModbusSvrIPTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModbusSvrIPTxt.Location = new System.Drawing.Point(22, 43);
            this.lblModbusSvrIPTxt.Name = "lblModbusSvrIPTxt";
            this.lblModbusSvrIPTxt.Size = new System.Drawing.Size(99, 29);
            this.lblModbusSvrIPTxt.TabIndex = 80;
            this.lblModbusSvrIPTxt.Text = "从站IP：";
            this.lblModbusSvrIPTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtModbusSvrPort
            // 
            this.txtModbusSvrPort.Location = new System.Drawing.Point(453, 46);
            this.txtModbusSvrPort.Name = "txtModbusSvrPort";
            this.txtModbusSvrPort.Size = new System.Drawing.Size(140, 26);
            this.txtModbusSvrPort.TabIndex = 79;
            // 
            // lblModbusSvrPortTxt
            // 
            this.lblModbusSvrPortTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModbusSvrPortTxt.Location = new System.Drawing.Point(346, 43);
            this.lblModbusSvrPortTxt.Name = "lblModbusSvrPortTxt";
            this.lblModbusSvrPortTxt.Size = new System.Drawing.Size(99, 29);
            this.lblModbusSvrPortTxt.TabIndex = 78;
            this.lblModbusSvrPortTxt.Text = "从站端口：";
            this.lblModbusSvrPortTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSlaveID
            // 
            this.txtSlaveID.Location = new System.Drawing.Point(766, 46);
            this.txtSlaveID.Name = "txtSlaveID";
            this.txtSlaveID.Size = new System.Drawing.Size(140, 26);
            this.txtSlaveID.TabIndex = 77;
            // 
            // lblSlaveIDTxt
            // 
            this.lblSlaveIDTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSlaveIDTxt.Location = new System.Drawing.Point(653, 42);
            this.lblSlaveIDTxt.Name = "lblSlaveIDTxt";
            this.lblSlaveIDTxt.Size = new System.Drawing.Size(107, 29);
            this.lblSlaveIDTxt.TabIndex = 76;
            this.lblSlaveIDTxt.Text = "从站地址号：";
            this.lblSlaveIDTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRestartServer1
            // 
            this.btnRestartServer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(178)))), ((int)(((byte)(115)))));
            this.btnRestartServer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestartServer1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnRestartServer1.ForeColor = System.Drawing.Color.White;
            this.btnRestartServer1.Location = new System.Drawing.Point(611, 431);
            this.btnRestartServer1.Name = "btnRestartServer1";
            this.btnRestartServer1.Size = new System.Drawing.Size(183, 34);
            this.btnRestartServer1.TabIndex = 69;
            this.btnRestartServer1.Text = "重启通讯";
            this.btnRestartServer1.UseVisualStyleBackColor = false;
            this.btnRestartServer1.Click += new System.EventHandler(this.btnRestartServer1_Click);
            // 
            // btnCommParamsSet1
            // 
            this.btnCommParamsSet1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(103)))), ((int)(((byte)(156)))));
            this.btnCommParamsSet1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommParamsSet1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCommParamsSet1.ForeColor = System.Drawing.Color.White;
            this.btnCommParamsSet1.Location = new System.Drawing.Point(208, 431);
            this.btnCommParamsSet1.Name = "btnCommParamsSet1";
            this.btnCommParamsSet1.Size = new System.Drawing.Size(183, 34);
            this.btnCommParamsSet1.TabIndex = 68;
            this.btnCommParamsSet1.Text = "确定修改";
            this.btnCommParamsSet1.UseVisualStyleBackColor = false;
            this.btnCommParamsSet1.Click += new System.EventHandler(this.btnCommParamsSet1_Click);
            // 
            // picStatusShowLogoWF1
            // 
            this.picStatusShowLogoWF1.BackColor = System.Drawing.Color.Transparent;
            this.picStatusShowLogoWF1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picStatusShowLogoWF1.Location = new System.Drawing.Point(648, 499);
            this.picStatusShowLogoWF1.Name = "picStatusShowLogoWF1";
            this.picStatusShowLogoWF1.Size = new System.Drawing.Size(24, 20);
            this.picStatusShowLogoWF1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picStatusShowLogoWF1.TabIndex = 60;
            this.picStatusShowLogoWF1.TabStop = false;
            // 
            // lblStatusShowCopyRightText1
            // 
            this.lblStatusShowCopyRightText1.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusShowCopyRightText1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatusShowCopyRightText1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(52)))), ((int)(((byte)(127)))));
            this.lblStatusShowCopyRightText1.Location = new System.Drawing.Point(670, 499);
            this.lblStatusShowCopyRightText1.Name = "lblStatusShowCopyRightText1";
            this.lblStatusShowCopyRightText1.Size = new System.Drawing.Size(314, 20);
            this.lblStatusShowCopyRightText1.TabIndex = 59;
            this.lblStatusShowCopyRightText1.Text = "CopyRight©XXXXXXXXXXXX INC.";
            this.lblStatusShowCopyRightText1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tapSetting
            // 
            this.tapSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.tapSetting.Controls.Add(this.pnlLogShow);
            this.tapSetting.Controls.Add(this.picSettingLogoWF);
            this.tapSetting.Controls.Add(this.lblSettingCopyRightText);
            this.tapSetting.DM_UseCustomBackColor = true;
            this.tapSetting.DM_UseCustomForeColor = true;
            this.tapSetting.DM_UseStyleColors = true;
            this.tapSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tapSetting.HorizontalScrollbarBarColor = true;
            this.tapSetting.HorizontalScrollbarDM_HighlightOnWheel = false;
            this.tapSetting.HorizontalScrollbarSize = 10;
            this.tapSetting.Location = new System.Drawing.Point(4, 39);
            this.tapSetting.Name = "tapSetting";
            this.tapSetting.Size = new System.Drawing.Size(987, 522);
            this.tapSetting.TabIndex = 2;
            this.tapSetting.Text = "         运行日志         ";
            this.tapSetting.VerticalScrollbarBarColor = true;
            this.tapSetting.VerticalScrollbarDM_HighlightOnWheel = false;
            this.tapSetting.VerticalScrollbarSize = 10;
            // 
            // pnlLogShow
            // 
            this.pnlLogShow.BackColor = System.Drawing.Color.White;
            this.pnlLogShow.Controls.Add(this.pnlList);
            this.pnlLogShow.Controls.Add(this.btnClearLog);
            this.pnlLogShow.Location = new System.Drawing.Point(13, 17);
            this.pnlLogShow.Name = "pnlLogShow";
            this.pnlLogShow.Size = new System.Drawing.Size(960, 470);
            this.pnlLogShow.TabIndex = 61;
            // 
            // pnlList
            // 
            this.pnlList.Location = new System.Drawing.Point(11, 8);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(941, 417);
            this.pnlList.TabIndex = 12;
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(153)))), ((int)(((byte)(252)))));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(11, 431);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(272, 31);
            this.btnClearLog.TabIndex = 10;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // picSettingLogoWF
            // 
            this.picSettingLogoWF.BackColor = System.Drawing.Color.Transparent;
            this.picSettingLogoWF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picSettingLogoWF.Location = new System.Drawing.Point(648, 499);
            this.picSettingLogoWF.Name = "picSettingLogoWF";
            this.picSettingLogoWF.Size = new System.Drawing.Size(24, 20);
            this.picSettingLogoWF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSettingLogoWF.TabIndex = 60;
            this.picSettingLogoWF.TabStop = false;
            // 
            // lblSettingCopyRightText
            // 
            this.lblSettingCopyRightText.BackColor = System.Drawing.Color.Transparent;
            this.lblSettingCopyRightText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSettingCopyRightText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(52)))), ((int)(((byte)(127)))));
            this.lblSettingCopyRightText.Location = new System.Drawing.Point(670, 499);
            this.lblSettingCopyRightText.Name = "lblSettingCopyRightText";
            this.lblSettingCopyRightText.Size = new System.Drawing.Size(314, 20);
            this.lblSettingCopyRightText.TabIndex = 59;
            this.lblSettingCopyRightText.Text = "CopyRight©XXXXXXXXXXXX INC.";
            this.lblSettingCopyRightText.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlTop.Controls.Add(this.lblMainTitle);
            this.pnlTop.Controls.Add(this.lblTime);
            this.pnlTop.Controls.Add(this.lblDate);
            this.pnlTop.Location = new System.Drawing.Point(-1, -4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(985, 80);
            this.pnlTop.TabIndex = 5;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(74)))), ((int)(((byte)(134)))));
            this.lblMainTitle.Location = new System.Drawing.Point(211, 16);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(515, 48);
            this.lblMainTitle.TabIndex = 8;
            this.lblMainTitle.Text = "XXXXXX软件";
            this.lblMainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(74)))), ((int)(((byte)(134)))));
            this.lblTime.Location = new System.Drawing.Point(822, 41);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(163, 23);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(74)))), ((int)(((byte)(134)))));
            this.lblDate.Location = new System.Drawing.Point(817, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(168, 23);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "2017-01-01";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrMQTT
            // 
            this.tmrMQTT.Interval = 5000;
            this.tmrMQTT.Tick += new System.EventHandler(this.tmrMQTT_Tick);
            // 
            // tmrDateTime
            // 
            this.tmrDateTime.Interval = 1000;
            this.tmrDateTime.Tick += new System.EventHandler(this.tmrDateTime_Tick);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 637);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tapLogShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHisLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogShowLogoWF)).EndInit();
            this.tapStatusShow1.ResumeLayout(false);
            this.pnlCommSettings.ResumeLayout(false);
            this.grpMQTTInfo.ResumeLayout(false);
            this.grpMQTTInfo.PerformLayout();
            this.grpModbusTCPInfo.ResumeLayout(false);
            this.grpModbusTCPInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusShowLogoWF1)).EndInit();
            this.tapSetting.ResumeLayout(false);
            this.pnlLogShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSettingLogoWF)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DMSkin.Metro.Controls.MetroTabControl tabMain;
        private DMSkin.Metro.Controls.MetroTabPage tapLogShow;
        private System.Windows.Forms.PictureBox picLogShowLogoWF;
        private System.Windows.Forms.Label lblLogShowCopyRightText;
        private DMSkin.Metro.Controls.MetroTabPage tapStatusShow1;
        private System.Windows.Forms.Panel pnlCommSettings;
        private System.Windows.Forms.GroupBox grpModbusTCPInfo;
        private System.Windows.Forms.TextBox txtModbusSvrPort;
        private System.Windows.Forms.Label lblModbusSvrPortTxt;
        private System.Windows.Forms.TextBox txtSlaveID;
        private System.Windows.Forms.Label lblSlaveIDTxt;
        private System.Windows.Forms.Button btnRestartServer1;
        private System.Windows.Forms.Button btnCommParamsSet1;
        private System.Windows.Forms.PictureBox picStatusShowLogoWF1;
        private System.Windows.Forms.Label lblStatusShowCopyRightText1;
        private DMSkin.Metro.Controls.MetroTabPage tapSetting;
        private System.Windows.Forms.PictureBox picSettingLogoWF;
        private System.Windows.Forms.Label lblSettingCopyRightText;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox grpMQTTInfo;
        private System.Windows.Forms.TextBox txtPubTime;
        private System.Windows.Forms.Label lblPubTimeTxt;
        private System.Windows.Forms.TextBox txtMQTTPwd;
        private System.Windows.Forms.TextBox txtPubTopic;
        private System.Windows.Forms.Label lblPubTopicTxt;
        private System.Windows.Forms.TextBox txtSubTopic;
        private System.Windows.Forms.Label lblSubTopicTxt;
        private System.Windows.Forms.Label lblMQTTPwdTxt;
        private System.Windows.Forms.TextBox txtMQTTSvrIP;
        private System.Windows.Forms.Label lblMQTTSvrIPTxt;
        private System.Windows.Forms.TextBox txtMQTTSvrPort;
        private System.Windows.Forms.Label lblMQTTSvrPortTxt;
        private System.Windows.Forms.TextBox txtMQTTUsername;
        private System.Windows.Forms.Label lblMQTTUsernameTxt;
        private System.Windows.Forms.TextBox txtModbusReadCount;
        private System.Windows.Forms.Label lblModbusReadCountTxt;
        private System.Windows.Forms.TextBox txtModbusStartAddress;
        private System.Windows.Forms.Label lblModbusStartAddressTxt;
        private System.Windows.Forms.Label lblModbusCmdTxt;
        private System.Windows.Forms.ComboBox cbxModbusCmd;
        private System.Windows.Forms.TextBox txtModbusSvrIP;
        private System.Windows.Forms.Label lblModbusSvrIPTxt;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlLogShow;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Timer tmrMQTT;
        private System.Windows.Forms.Timer tmrDateTime;
        private System.Windows.Forms.DataGridView grdHisLog;
    }
}

