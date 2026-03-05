using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.Common;

namespace ModbusToMQTT
{
    class ModbusTCPClass
    {

        /// <summary>
        /// 获取ModbusTCP的发送命令，支持01,03,05,06,15,16六个命令。
        /// </summary>
        /// <param name="addressID">从机地址</param>
        /// <param name="funcNum">命令功能码</param>
        /// <param name="registerStart">起始寄存器地址</param>
        /// <param name="resgisterCount">读取或写入的寄存器个数</param>
        /// <param name="writeContentArray">要写入的数据内容，仅写入功能码时生效</param>
        /// <returns>符合条件的字节数组，回复若为一个字节的数组，含义如下f0为功能码无效，f1为写入数据为空，f2为写入寄存器个数超过协议限制，f3为写入寄存器个数与内容不匹配</returns>
        public byte[] GetModbusTCPSendCmd(byte addressID, byte funcNum, ushort registerStart, ushort registerCount, byte[] writeContentArray = null)
        {
            if (funcNum == 0x01)
            {
                #region 01命令 读线圈状态

                if (registerCount <= 2000)
                {
                    byte[] resultArray = new byte[12];

                    resultArray[0] = 0x00;
                    resultArray[1] = 0x01;
                    resultArray[2] = 0x00;
                    resultArray[3] = 0x00;
                    resultArray[4] = 0x00;
                    resultArray[5] = 0x06;                      //后面的长度
                    resultArray[6] = addressID;
                    resultArray[7] = funcNum;
                    resultArray[8] = BitConverter.GetBytes(registerStart)[1];
                    resultArray[9] = BitConverter.GetBytes(registerStart)[0];
                    resultArray[10] = BitConverter.GetBytes(registerCount)[1];
                    resultArray[11] = BitConverter.GetBytes(registerCount)[0];

                    return resultArray;
                }
                else
                {
                    //要读的线圈数超过2000
                    return new byte[1] { 0xf2 };
                }

                #endregion
            }
            else if (funcNum == 0x03)
            {
                #region 03命令 读寄存器数据

                if (registerCount <= 125)
                {
                    byte[] resultArray = new byte[12];

                    resultArray[0] = 0x00;
                    resultArray[1] = 0x01;
                    resultArray[2] = 0x00;
                    resultArray[3] = 0x00;
                    resultArray[4] = 0x00;
                    resultArray[5] = 0x06;                      //后面的长度
                    resultArray[6] = addressID;
                    resultArray[7] = funcNum;
                    resultArray[8] = BitConverter.GetBytes(registerStart)[1];
                    resultArray[9] = BitConverter.GetBytes(registerStart)[0];
                    resultArray[10] = BitConverter.GetBytes(registerCount)[1];
                    resultArray[11] = BitConverter.GetBytes(registerCount)[0];

                    return resultArray;
                }
                else
                {
                    //要读的寄存器数超过125
                    return new byte[1] { 0xf2 };
                }

                #endregion
            }
            else if (funcNum == 0x05)
            {
                #region 05命令 写单个线圈

                if (writeContentArray != null)
                {
                    if (writeContentArray.Length == 2)
                    {
                        byte[] resultArray = new byte[12];

                        resultArray[0] = 0x00;
                        resultArray[1] = 0x01;
                        resultArray[2] = 0x00;
                        resultArray[3] = 0x00;
                        resultArray[4] = 0x00;
                        resultArray[5] = 0x06;                      //后面的长度
                        resultArray[6] = addressID;
                        resultArray[7] = funcNum;
                        resultArray[8] = BitConverter.GetBytes(registerStart)[1];
                        resultArray[9] = BitConverter.GetBytes(registerStart)[0];
                        resultArray[10] = writeContentArray[0];
                        resultArray[11] = writeContentArray[1];

                        return resultArray;
                    }
                    else
                    {
                        //写单个线圈时，数据内容数组长度不够
                        return new byte[1] { 0xf3 };
                    }
                }
                else
                {
                    // 要写数据内容为空
                    return new byte[1] { 0xf1 };
                }

                #endregion
            }
            else if (funcNum == 0x06)
            {
                #region 06命令 写单个寄存器

                if (writeContentArray != null)
                {
                    if (writeContentArray.Length == 2)
                    {
                        byte[] resultArray = new byte[12];

                        resultArray[0] = 0x00;
                        resultArray[1] = 0x01;
                        resultArray[2] = 0x00;
                        resultArray[3] = 0x00;
                        resultArray[4] = 0x00;
                        resultArray[5] = 0x06;                      //后面的长度
                        resultArray[6] = addressID;
                        resultArray[7] = funcNum;
                        resultArray[8] = BitConverter.GetBytes(registerStart)[1];
                        resultArray[9] = BitConverter.GetBytes(registerStart)[0];
                        resultArray[10] = writeContentArray[0];
                        resultArray[11] = writeContentArray[1];

                        return resultArray;
                    }
                    else
                    {
                        //写单个寄存器时，数据内容数组长度不够
                        return new byte[1] { 0xf3 };
                    }
                }
                else
                {
                    // 要写数据内容为空
                    return new byte[1] { 0xf1 };
                }

                #endregion
            }
            else if (funcNum == 0x0F)
            {
                #region 15命令 写多个线圈

                if (writeContentArray != null)
                {
                    if (registerCount <= 2000)
                    {
                        if (((registerCount - 1) / 8) + 1 == writeContentArray.Length)
                        {
                            byte[] resultArray = new byte[13 + writeContentArray.Length];

                            resultArray[0] = 0x00;
                            resultArray[1] = 0x01;
                            resultArray[2] = 0x00;
                            resultArray[3] = 0x00;
                            resultArray[4] = BitConverter.GetBytes((resultArray.Length - 6))[1];
                            resultArray[5] = BitConverter.GetBytes((resultArray.Length - 6))[0];                    //后面的长度
                            resultArray[6] = addressID;
                            resultArray[7] = funcNum;
                            resultArray[8] = BitConverter.GetBytes(registerStart)[1];
                            resultArray[9] = BitConverter.GetBytes(registerStart)[0];
                            resultArray[10] = BitConverter.GetBytes(registerCount)[1];
                            resultArray[11] = BitConverter.GetBytes(registerCount)[0];
                            resultArray[12] = (byte)writeContentArray.Length;
                            writeContentArray.CopyTo(resultArray, 13);

                            return resultArray;
                        }
                        else
                        {
                            //要写的线圈数与数据内容不符
                            return new byte[1] { 0xf3 };
                        }
                    }
                    else
                    {
                        //要写的线圈数超过2000
                        return new byte[1] { 0xf2 };
                    }
                }
                else
                {
                    //要写数据内容为空
                    return new byte[1] { 0xf1 };
                }

                #endregion
            }
            else if (funcNum == 0x10)
            {
                #region 16命令 写多个寄存器

                if (writeContentArray != null)
                {
                    if (registerCount <= 125)
                    {
                        if (registerCount * 2 == writeContentArray.Length)
                        {
                            byte[] resultArray = new byte[13 + writeContentArray.Length];

                            resultArray[0] = 0x00;
                            resultArray[1] = 0x01;
                            resultArray[2] = 0x00;
                            resultArray[3] = 0x00;
                            resultArray[4] = BitConverter.GetBytes((resultArray.Length - 6))[1];
                            resultArray[5] = BitConverter.GetBytes((resultArray.Length - 6))[0];
                            resultArray[6] = addressID;
                            resultArray[7] = funcNum;
                            resultArray[8] = BitConverter.GetBytes(registerStart)[1];
                            resultArray[9] = BitConverter.GetBytes(registerStart)[0];
                            resultArray[10] = BitConverter.GetBytes(registerCount)[1];
                            resultArray[11] = BitConverter.GetBytes(registerCount)[0];
                            resultArray[12] = (byte)writeContentArray.Length;
                            writeContentArray.CopyTo(resultArray, 13);

                            return resultArray;
                        }
                        else
                        {
                            //要写的寄存器数与数据内容不符
                            return new byte[1] { 0xf3 };
                        }
                    }
                    else
                    {
                        //要写的寄存器数超过125
                        return new byte[1] { 0xf2 };
                    }
                }
                else
                {
                    //要写数据内容为空
                    return new byte[1] { 0xf1 };
                }

                #endregion
            }
            else
            {
                //不支持的功能码
                return new byte[1] { 0xf0 };
            }
        }

        /// <summary>
        /// 解析ModbusTCP返回命令（作为主站），支持01,03,05,06,15,16六个命令。
        /// </summary>
        /// <param name="receiveDataArray">接收到的数据</param>
        /// <param name="isAnalysis">是否进行默认解析，即线圈按bool值解析，寄存器按单精度浮点数解析</param>
        /// <param name="dataType">若按单精度浮点数解析，字节顺序是什么，默认为4（小端），1代表ABCD-大端 2代表BADC-大端反转 3代表CDAB-小端反转 4代表DCBA-小端</param>
        /// <returns>符合条件的Json结构体</returns>
        public JsonModbusTCPRevData_Master GetModbusTCPRevData_Master(byte[] receiveDataArray, bool isAnalysis = true, int dataType = 1)
        {
            JsonModbusTCPRevData_Master returnJson = new JsonModbusTCPRevData_Master();

            returnJson.AnalysisStatus = 0;
            returnJson.AddressID = 0x00;
            returnJson.FuncNum = 0x00;
            returnJson.ErrodCode = 0x00;
            returnJson.OriginalData = new byte[0];
            returnJson.AnalysisData01 = new List<bool>();
            returnJson.AnalysisData03 = new List<float>();
            returnJson.AddressStart = 0;
            returnJson.ModifyCount = 0;

            if (receiveDataArray.Length > 9)
            {
                if (receiveDataArray[7] == 0x01)
                {
                    #region 01命令回复 -- 读线圈

                    int dataPackageCount = receiveDataArray[8];

                    if (receiveDataArray.Length == 9 + dataPackageCount)
                    {

                        byte[] mBoolDataArray = CRC_16Class.SubByte(receiveDataArray, 9, dataPackageCount);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = mBoolDataArray;
                        if (isAnalysis)
                        {
                            returnJson.AnalysisData01 = GetBoolListFromDataArray(mBoolDataArray);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x03)
                {
                    #region 03命令回复 -- 读寄存器

                    int dataPackageCount = receiveDataArray[8];

                    if (receiveDataArray.Length == 9 + dataPackageCount)
                    {
                        byte[] floatDataArray = CRC_16Class.SubByte(receiveDataArray, 9, dataPackageCount);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = floatDataArray;
                        if (isAnalysis)
                        {
                            returnJson.AnalysisData03 = GetFloatListFromDataArray(floatDataArray, dataType);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x05)
                {
                    #region 05命令回复 -- 写单个线圈

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 10, 2);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x06)
                {
                    #region 06命令回复 -- 写单个寄存器

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 10, 2);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x0f)
                {
                    #region 15命令回复 -- 写多个线圈

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 8, 4);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ModifyCount = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 10, 2)[1], CRC_16Class.SubByte(receiveDataArray, 10, 2)[0] }, 0);
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x10)
                {
                    #region 16命令回复 -- 写多个寄存器

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 8, 4);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ModifyCount = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 10, 2)[1], CRC_16Class.SubByte(receiveDataArray, 10, 2)[0] }, 0);
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
            }
            else if (receiveDataArray.Length == 9)
            {
                #region 异常回复

                returnJson.AnalysisStatus = 0;
                returnJson.AddressID = receiveDataArray[6];
                returnJson.FuncNum = receiveDataArray[7];
                returnJson.ErrodCode = receiveDataArray[8];

                #endregion
            }
            else
            {

            }

            return returnJson;
        }

        /// <summary>
        /// 解析ModbusTCP返回命令（作为从站），支持01,03,05,06,15,16六个命令。
        /// </summary>
        /// <param name="receiveDataArray">接收到的数据</param>
        /// <param name="isAnalysis">是否进行默认解析，即线圈按bool值解析，寄存器按单精度浮点数解析</param>
        /// <param name="dataType">若按单精度浮点数解析，字节顺序是什么，默认为4（小端），1代表ABCD-大端 2代表BADC-大端反转 3代表CDAB-小端反转 4代表DCBA-小端</param>
        /// <returns>符合条件的Json结构体</returns>
        public JsonModbusTCPRevData_Slave GetModbusTCPRevData_Slave(byte[] receiveDataArray, bool isAnalysis = true, int dataType = 1)
        {
            JsonModbusTCPRevData_Slave returnJson = new JsonModbusTCPRevData_Slave();

            returnJson.AnalysisStatus = 0;
            returnJson.AddressID = 0x00;
            returnJson.FuncNum = 0x00;
            returnJson.ErrodCode = 0x00;
            returnJson.OriginalData = new byte[0];
            returnJson.AnalysisData15 = new List<bool>();
            returnJson.AnalysisData16 = new List<float>();
            returnJson.AnalysisData05 = false;
            returnJson.AddressStart = 0;
            returnJson.ModifyCount = 0;
            returnJson.ResponseCmd0506 = new byte[12];
            returnJson.ResponseCmd1516 = new byte[12];

            if (receiveDataArray.Length > 9)
            {
                if (receiveDataArray[7] == 0x01)
                {
                    #region 01命令回复 -- 读线圈回复

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 8, 4);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ModifyCount = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 10, 2)[1], CRC_16Class.SubByte(receiveDataArray, 10, 2)[0] }, 0);
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x03)
                {
                    #region 03命令回复 -- 读寄存器

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 8, 4);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ModifyCount = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 10, 2)[1], CRC_16Class.SubByte(receiveDataArray, 10, 2)[0] }, 0);
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x05)
                {
                    #region 05命令回复 -- 写单个线圈

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 10, 2);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ResponseCmd0506 = CRC_16Class.SubByte(receiveDataArray, 0, 12);

                        if (isAnalysis)
                        {
                            if (originalDataArray[0] == 0xff)
                            {
                                returnJson.AnalysisData05 = true;
                            }
                            else
                            {
                                returnJson.AnalysisData05 = false;
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x06)
                {
                    #region 06命令回复 -- 写单个寄存器

                    if (receiveDataArray.Length == 12)
                    {
                        byte[] originalDataArray = CRC_16Class.SubByte(receiveDataArray, 10, 2);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = originalDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ResponseCmd0506 = CRC_16Class.SubByte(receiveDataArray, 0, 12);
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x0f)
                {
                    #region 15命令回复 -- 写多个线圈

                    int dataPackageCount = receiveDataArray[12];

                    if (receiveDataArray.Length == 13 + dataPackageCount)
                    {

                        byte[] mBoolDataArray = CRC_16Class.SubByte(receiveDataArray, 13, dataPackageCount);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = mBoolDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ModifyCount = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 10, 2)[1], CRC_16Class.SubByte(receiveDataArray, 10, 2)[0] }, 0);
                        returnJson.ResponseCmd1516 = GetModbusTCPResponseByteArray1516(CRC_16Class.SubByte(receiveDataArray, 0, 12));

                        if (isAnalysis)
                        {
                            returnJson.AnalysisData15 = GetBoolListFromDataArray(mBoolDataArray);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
                else if (receiveDataArray[7] == 0x10)
                {
                    #region 16命令回复 -- 写多个寄存器

                    int dataPackageCount = receiveDataArray[12];

                    if (receiveDataArray.Length == 13 + dataPackageCount)
                    {

                        byte[] floatDataArray = CRC_16Class.SubByte(receiveDataArray, 13, dataPackageCount);

                        returnJson.AnalysisStatus = 1;
                        returnJson.AddressID = receiveDataArray[6];
                        returnJson.FuncNum = receiveDataArray[7];
                        returnJson.OriginalData = floatDataArray;
                        returnJson.AddressStart = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 8, 2)[1], CRC_16Class.SubByte(receiveDataArray, 8, 2)[0] }, 0);
                        returnJson.ModifyCount = BitConverter.ToUInt16(new byte[2] { CRC_16Class.SubByte(receiveDataArray, 10, 2)[1], CRC_16Class.SubByte(receiveDataArray, 10, 2)[0] }, 0);
                        returnJson.ResponseCmd1516 = GetModbusTCPResponseByteArray1516(CRC_16Class.SubByte(receiveDataArray, 0, 12));

                        if (isAnalysis)
                        {
                            returnJson.AnalysisData16 = GetFloatListFromDataArray(floatDataArray, dataType);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        returnJson.AnalysisStatus = 0;
                    }

                    #endregion
                }
            }
            else if (receiveDataArray.Length == 9)
            {
                #region 异常回复

                returnJson.AnalysisStatus = 0;
                returnJson.AddressID = receiveDataArray[6];
                returnJson.FuncNum = receiveDataArray[7];
                returnJson.ErrodCode = receiveDataArray[8];

                #endregion
            }
            else
            {

            }

            return returnJson;
        }

        /// <summary>
        /// 将字节数组按位解析成状态，布尔值
        /// </summary>
        /// <param name="dataArray">数据字节数组</param>
        /// <returns>符合条件的数据</returns>
        public List<bool> GetBoolListFromDataArray(byte[] dataArray)
        {

            List<bool> resultBoolList = new List<bool>();

            for (int byteIndex = 0; byteIndex < dataArray.Length; byteIndex++)
            {
                string mStr2Temp = Convert.ToString(dataArray[byteIndex], 2).PadLeft(8, '0');

                for (int strIndex = mStr2Temp.Length - 1; strIndex > -1; strIndex--)
                {
                    if (mStr2Temp[strIndex] == '1')
                    {
                        resultBoolList.Add(true);
                    }
                    else
                    {
                        resultBoolList.Add(false);
                    }
                }

            }

            return resultBoolList;
        }

        /// <summary>
        /// 将字节数组转换为单精度浮点数，若长度不为4的倍数，则转换能转换的最多的单精度浮点数
        /// </summary>
        /// <param name="dataArray">数据字节数组</param>
        /// <param name="dataType">默认为4（小端），1代表ABCD-大端 2代表BADC-大端反转 3代表CDAB-小端反转 4代表DCBA-小端</param>
        /// <returns>符合条件的数据</returns>
        public List<float> GetFloatListFromDataArray(byte[] dataArray, int dataType)
        {

            List<float> resultFloatList = new List<float>();

            for (int byteIndex = 0; byteIndex + 3 < dataArray.Length; byteIndex = byteIndex + 4)
            {
                byte[] floatArray = new byte[4];

                if (dataType == 1)
                {
                    floatArray[0] = dataArray[byteIndex + 3];
                    floatArray[1] = dataArray[byteIndex + 2];
                    floatArray[2] = dataArray[byteIndex + 1];
                    floatArray[3] = dataArray[byteIndex];
                }
                else if (dataType == 2)
                {
                    floatArray[0] = dataArray[byteIndex + 2];
                    floatArray[1] = dataArray[byteIndex + 3];
                    floatArray[2] = dataArray[byteIndex];
                    floatArray[3] = dataArray[byteIndex + 1];
                }
                else if (dataType == 3)
                {
                    floatArray[0] = dataArray[byteIndex + 1];
                    floatArray[1] = dataArray[byteIndex];
                    floatArray[2] = dataArray[byteIndex + 3];
                    floatArray[3] = dataArray[byteIndex + 2];
                }
                else
                {
                    floatArray[0] = dataArray[byteIndex];
                    floatArray[1] = dataArray[byteIndex + 1];
                    floatArray[2] = dataArray[byteIndex + 2];
                    floatArray[3] = dataArray[byteIndex + 3];
                }

                resultFloatList.Add(BitConverter.ToSingle(floatArray, 0));

            }

            return resultFloatList;
        }

        /// <summary>
        /// 将单精度浮点数按字节顺序要求，转换为对应字节数组
        /// </summary>
        /// <param name="floatList">单精度浮点数List</param>
        /// <param name="dataType">默认为4（小端），1代表ABCD-大端 2代表BADC-大端反转 3代表CDAB-小端反转 4代表DCBA-小端</param>
        /// <returns>符合条件的字节数组</returns>
        public byte[] GetByteArrayFromFloatList(List<float> floatList, int dataType)
        {
            if (floatList.Count > 0)
            {
                byte[] resultArray = new byte[floatList.Count * 4];

                for (int i = 0; i < floatList.Count; i++)
                {
                    if (dataType == 1)
                    {
                        byte[] tempArray = new byte[4];

                        byte[] tempArray1 = BitConverter.GetBytes(floatList[i]);

                        tempArray[0] = tempArray1[3];
                        tempArray[1] = tempArray1[2];
                        tempArray[2] = tempArray1[1];
                        tempArray[3] = tempArray1[0];

                        tempArray.CopyTo(resultArray, i * 4);
                    }
                    else if (dataType == 2)
                    {

                        byte[] tempArray = new byte[4];

                        byte[] tempArray1 = BitConverter.GetBytes(floatList[i]);

                        tempArray[0] = tempArray1[2];
                        tempArray[1] = tempArray1[3];
                        tempArray[2] = tempArray1[0];
                        tempArray[3] = tempArray1[1];

                        tempArray.CopyTo(resultArray, i * 4);
                    }
                    else if (dataType == 3)
                    {

                        byte[] tempArray = new byte[4];

                        byte[] tempArray1 = BitConverter.GetBytes(floatList[i]);

                        tempArray[0] = tempArray1[1];
                        tempArray[1] = tempArray1[0];
                        tempArray[2] = tempArray1[3];
                        tempArray[3] = tempArray1[2];

                        tempArray.CopyTo(resultArray, i * 4);
                    }
                    else
                    {
                        byte[] tempArray = BitConverter.GetBytes(floatList[i]);

                        tempArray.CopyTo(resultArray, i * 4);
                    }
                }

                return resultArray;
            }
            else
            {
                return new byte[1] { 0xff };
            }
        }

        /// <summary>
        /// 将二进制字符串转换为字节数组
        /// </summary>
        /// <param name="codeIIStr">二进制型字符串，仅包含0或1，增序状态，如000000001代表第九个线圈为ON</param>
        /// <returns>符合条件的字节数组</returns>
        public byte[] GetByteArrayFromIIStr(string codeIIStr)
        {

            byte[] resultArray = new byte[(int)Math.Ceiling(codeIIStr.Length / 8.0)];

            int byteCount = 0;

            for (int i = 0; i < codeIIStr.Length; i = i + 8)
            {

                string tempStr = "00000000";

                if (i + 7 < codeIIStr.Length)
                {
                    tempStr = codeIIStr.Substring(i, 8);

                    tempStr = new string(tempStr.Reverse().ToArray());

                }
                else
                {
                    tempStr = codeIIStr.Substring(i, codeIIStr.Length - i);

                    tempStr = new string(tempStr.Reverse().ToArray());

                    tempStr.PadLeft(8, '0');
                }

                byte tempByte = Convert.ToByte(tempStr, 2);

                resultArray[byteCount] = tempByte;

                byteCount++;

            }

            return resultArray;

        }
        /// <summary>
        /// 生成1516命令的返回命令
        /// </summary>
        /// <param name="revByteArray">截取的接收命令，仅长度需变化</param>
        /// <returns>符合要求的结果</returns>
        public byte[] GetModbusTCPResponseByteArray1516(byte[] revByteArray)
        {
            revByteArray[4] = BitConverter.GetBytes((UInt16)(revByteArray.Length - 6))[1];
            revByteArray[5] = BitConverter.GetBytes((UInt16)(revByteArray.Length - 6))[0];

            return revByteArray;
        }

        public class JsonModbusTCPRevData_Master
        {
            /// <summary>
            /// 本条命令的解析状态   0故障 1正常
            /// </summary>
            public int AnalysisStatus { get; set; }
            /// <summary>
            /// 回复命令的设备ID
            /// </summary>
            public byte AddressID { get; set; }
            /// <summary>
            /// 本条回复的功能码
            /// </summary>
            public byte FuncNum { get; set; }
            /// <summary>
            /// 错误代码
            /// </summary>
            public byte ErrodCode { get; set; }
            /// <summary>
            /// 原始数据，即解析前的数据部分的数据
            /// </summary>
            public byte[] OriginalData { get; set; }
            /// <summary>
            /// 解析后的03命令的数据 -- 读寄存器
            /// </summary>
            public List<float> AnalysisData03 { get; set; }
            /// <summary>
            /// 解析后的01命令的数据 -- 读线圈
            /// </summary>
            public List<bool> AnalysisData01 { get; set; }
            /// <summary>
            /// 15,16命令中回复的起始地址
            /// </summary>
            public ushort AddressStart { get; set; }
            /// <summary>
            /// 15,16命令中回复的修改个数
            /// </summary>
            public ushort ModifyCount { get; set; }

        }

        public class JsonModbusTCPRevData_Slave
        {
            /// <summary>
            /// 本条命令的解析状态   0故障 1正常
            /// </summary>
            public int AnalysisStatus { get; set; }
            /// <summary>
            /// 回复命令的设备ID
            /// </summary>
            public byte AddressID { get; set; }
            /// <summary>
            /// 本条回复的功能码
            /// </summary>
            public byte FuncNum { get; set; }
            /// <summary>
            /// 错误代码
            /// </summary>
            public byte ErrodCode { get; set; }
            /// <summary>
            /// 原始数据，即解析前的数据部分的数据
            /// </summary>
            public byte[] OriginalData { get; set; }
            /// <summary>
            /// 解析后的16命令的数据 -- 写多个寄存器
            /// </summary>
            public List<float> AnalysisData16 { get; set; }
            /// <summary>
            /// 解析后的15命令的数据 -- 写多个线圈
            /// </summary>
            public List<bool> AnalysisData15 { get; set; }
            /// <summary>
            /// 解析后的05命令的数据 -- 写单个线圈
            /// </summary>
            public bool AnalysisData05 { get; set; }
            /// <summary>
            /// 15,16命令中回复的起始地址
            /// </summary>
            public ushort AddressStart { get; set; }
            /// <summary>
            /// 15,16命令中回复的修改个数
            /// </summary>
            public ushort ModifyCount { get; set; }
            /// <summary>
            /// 05,06命令中成功解析后，要回复的字节数组
            /// </summary>
            public byte[] ResponseCmd0506 { get; set; }
            /// <summary>
            /// 15,16命令中成功解析后，要回复的字节数组
            /// </summary>
            public byte[] ResponseCmd1516 { get; set; }

        }
    }
}
