using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Assets.CSScripts
{
    class NetPlayer
    {
        TcpClient client = null;
        StreamReader sr;
        StreamWriter sw;
        //public static NetPlayer instance;

        public NetPlayer()
        {
            //instance = this;
        }
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="ip">服务器的IP</param>
        /// <returns>是否连接成功</returns>
        public bool connectNet(string ip)
        {
            bool flag = false;
            try
            {
                client = new TcpClient();
                //连接服务器
                client.Connect(IPAddress.Parse("115.159.52.43"), 5010);
                //client.Connect(IPAddress.Parse("127.0.0.1"), 5010);
                //获取本地的IP
                string clientIP = client.Client.LocalEndPoint.ToString();
                sendLoaclIP(clientIP);
                return flag = true;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return flag;
            }
        }
        /// <summary>
        /// 发送本地IP
        /// </summary>
        /// <param name="localIP">本地的IP</param>
        private void sendLoaclIP(string localIP)
        {
            NetworkStream ns = client.GetStream();
            sw = new StreamWriter(ns, Encoding.UTF8);
            //发送方法
            SWsend(sw, "LocalIP:" + localIP);
        }
        /// <summary>
        /// 发送的数据
        /// </summary>
        /// <param name="p_x">坐标x</param>
        /// <param name="p_y">坐标y</param>
        /// <param name="p_z">坐标z</param>
        /// <param name="r_x">旋转x</param>
        /// <param name="r_y">旋转y</param>
        /// <param name="r_z">旋转z</param>
        /// <param name="mouse_x">鼠标旋转</param>
        /// <param name="mouse_y">鼠标旋转</param>
        /// <param name="shoot">是否射击:0:false,1:true</param>
        /// <param name="dead">是否死亡:0:false,1:true</param>
        public void sendSomeData(string msg = "NULL")
        {
            //将要发送的数据存入data
            NetworkStream ns = client.GetStream();
            sw = new StreamWriter(ns, Encoding.UTF8);
            SWsend(sw, msg);
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <returns>返回float的集合保存了position,rotation,shoot,dead</returns>
        public Dictionary<string, float> reciveSomeData()
        {
            Dictionary<string, float> diction = new Dictionary<string, float>();
            try
            {
                NetworkStream ns = client.GetStream();
                sr = new StreamReader(ns, Encoding.UTF8);
                if (client.Available > 0)
                {
                    string data = sr.ReadLine();
                    if (data == "NULL")
                    {
                        diction.Add("Error", -1);
                        return diction;
                    }
                    string[] dataSplit = data.Split(':');
                    string one = dataSplit[0];
                    switch (one)
                    {
                        case "LocalIP":
                            diction.Add("What", 0);
                            break;
                        case "Position":
                            diction.Add("What", 1);
                            diction.Add("p_x", (float)Convert.ToDouble(dataSplit[1].Split(',')[0].Trim()));
                            diction.Add("p_y", (float)Convert.ToDouble(dataSplit[1].Split(',')[1].Trim()));
                            diction.Add("p_z", (float)Convert.ToDouble(dataSplit[1].Split(',')[2].Trim()));
                            break;
                        case "Rotation":
                            diction.Add("What", 2);
                            diction.Add("mouse_y", (float)Convert.ToDouble(dataSplit[1].Split('.')[0].Trim()));
                            diction.Add("mouse_x", (float)Convert.ToDouble(dataSplit[1].Split('.')[1].Trim()));
                            break;
                        case "Shoot":
                            diction.Add("What", 3);
                            break;
                        case "Dead":
                            diction.Add("What", 4);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                diction.Add("Error", -1);
            }

            return diction;
        }
        /// <summary>
        /// 发送函数
        /// </summary>
        /// <param name="sws">发送对象</param>
        /// <param name="msg">发送数据</param>
        private void SWsend(StreamWriter sws, string msg)
        {
            try
            {
                if (!client.Client.Connected)
                    connectNet("hace");
                sws.Flush();
                sws.WriteLine(msg);
                sws.Flush();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
        }
    }
}
