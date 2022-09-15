using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace PingResult
{
    #region Directer
    /// <summary>
    /// Directed by 王钦奕
    /// Build Time 2021年12月9日
    /// </summary>
    #endregion
    public partial class Ping_Main : Form
    {
        #region 定义全局的数据展示表格，用来赋值给datagridview
        DataTable datatable = new DataTable();
        #endregion

        public Ping_Main()
        {
            InitializeComponent();
            #region 初始化展示表格
            datatable.Columns.Add("IP");
            datatable.Columns.Add("NetConnect");
            datatable.Columns.Add("DNS");
            datatable.Columns.Add("MAC");
            #endregion
        }

        #region 点击ping测试加载计时器，设定600秒一次推送
        private void Begin_Click(object sender, EventArgs e)
        {
            datatable.Clear();
            var pingtimer = new System.Timers.Timer();
            pingtimer.Interval = 600000;
            pingtimer.AutoReset = true;
            pingtimer.Enabled = true;
            #region 计时器计时（暂未启用）
            /*
            var timernumber = 0;
            try 
            {
                for (int i = 0; i < ping; i++)
                {

                }
            }

            catch
            {

            }*/
            #endregion
            pingtimer.Elapsed += Pingtimer_Elapsed;

            #region 跳过对windows窗体控件线程安全调用，并不解决根本问题。
            //对 Windows 窗体控件的非线程安全调用方式是从辅助线程直接调用。
            //调用应用程序时，调试器会引发一个 InvalidOperationException，警告对控件的调用不是线程安全的。
            #endregion
            CheckForIllegalCrossThreadCalls = false;

            #region 暂时不用代码，仅做if条件参考判断
            /*var PingLinesCount = Pinglist.Lines.Count();
            try
            {

                for (int i = 0; i < PingLinesCount; i++)
                {
                    if (Pinglist.Text != null)
                    {
                        var NetSefment = Pinglist.Lines[i];
                        string[] NetSefmentArray = NetSefment.Split('-', ',', ' ', '。', '~',':');
                        var BeginNetSegment = NetSefmentArray[0];
                        var EndNetSegment = NetSefmentArray[1];
                        if (IPAddress.TryParse(BeginNetSegment, out var BeginNetSegmentIP)
                            && IPAddress.TryParse(EndNetSegment, out var EndNetSegmentIP)
                            && BitConverter.ToInt32(BeginNetSegmentIP.GetAddressBytes(),0)
                            >= BitConverter.ToInt32(EndNetSegmentIP.GetAddressBytes(),0))
                        {
                            
                            //Dns.GetHostName
                        }
                        else
                        {
                            MessageBox.Show("无效IP地址，请检查后重新输入。");
                        }
                    }
                    else break;
                }
            }
            catch
            {
                MessageBox.Show("程序发生未知错误。");
             }*/
            #endregion
        }
        #endregion

        #region 计时器到点事件
        /// <summary>
        /// 计时器每隔10分钟运行一次代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pingtimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            datatable.Clear();
            var pinglinescount = pingrichtextbox.Lines.Count();
            try
            {
                for (int i = 0; i < pinglinescount; i++)
                {
                    if (pingrichtextbox.Text != null)
                    {
                        var netsefment = pingrichtextbox.Lines[i];
                        string[] netsefmentarray = netsefment.Split('-', ',', ' ', '。', '~', ':', '.');
                        var beginnetsegment = netsefmentarray[3];
                        var endnetsegment = netsefmentarray[7];
                        if (netsefmentarray[0] == netsefmentarray[4]
                            && netsefmentarray[1] == netsefmentarray[5]
                            && netsefmentarray[2] == netsefmentarray[6]
                            && Convert.ToInt32(beginnetsegment) <= Convert.ToInt32(endnetsegment)
                            && IPAddress.TryParse(beginnetsegment, out var BeginNetSegmentIP)
                            && IPAddress.TryParse(endnetsegment, out var EndNetSegmentIP)
                            )
                        {
                            for (var IP = Convert.ToInt32(beginnetsegment); IP <= Convert.ToInt32(endnetsegment); IP++)
                            {
                                Ping ping = new Ping();
                                var scanIP_string = netsefmentarray[0] + "." + netsefmentarray[1] + "." + netsefmentarray[2] + "." + Convert.ToString(IP);
                                PingReply reply = ping.Send(scanIP_string, 1);
                                DataRow dataRow = datatable.NewRow();
                                if (showiponly.Checked == true)
                                {
                                    if (reply.Status == IPStatus.Success)
                                    {

                                    }
                                    else
                                    {
                                        dataRow["IP"] = scanIP_string;
                                        dataRow["NetConnect"] = "unconnect";
                                        datatable.Rows.Add(dataRow);
                                    }
                                }
                                else
                                {
                                    if (reply.Status == IPStatus.Success)
                                    {
                                        dataRow["IP"] = scanIP_string;
                                        dataRow["NetConnect"] = "connect";
                                        datatable.Rows.Add(dataRow);
                                    }
                                    else
                                    {
                                        dataRow["IP"] = scanIP_string;
                                        dataRow["NetConnect"] = "unconnect";
                                        datatable.Rows.Add(dataRow);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("无效IP地址，请检查后重新输入。");
                        }
                    }
                    else break;
                }
            }
            catch
            {
                MessageBox.Show("程序发生未知错误。");
            }
            datagridview.DataSource = datatable;
            var data = ConvertDataTableToString(datatable);
            var info = HttpGet(data);
            try
            {
                if (datatable.Rows.Count == 0)
                {
                    datatable.Rows.Add("无掉线情况");
                }
                else
                {
                    datagridview.Show();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("转换datatable显示出错。");
            }
        }
        #endregion

        #region 窗体加载事件
        private void Ping_Main_Load(object sender, EventArgs e)
        {
            pingrichtextbox.Text = "请在此输入需要扫描的IP段，格式为一行一个IP段。例：192.168.0.1-192.168.0.254。";
            pingrichtextbox.HideSelection = false;
            pingrichtextbox.SelectAll();
        }
        #endregion

        #region 未启用checkbox点击事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void showiponly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (datatable.Rows.Count == 0)
                {

                }
                if (showIpOnly.Checked == true)
                {
                    DataRow[] dataRow;
                    dataRow = datatable.Select("NetConnect=unconnect");
                    foreach (DataRow row in dataRow)
                    {
                        datatable.Rows.Remove(row);
                    }
                    dataGridView.DataSource = datatable;
                    dataGridView.Show();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("显示可连接IP出错。");
            }

        }*/
        #endregion

        #region 刷新按钮点击事件
        private void refresh_click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 转换datatable为string
        public static string ConvertDataTableToString(DataTable dataTable)
        {
            string data = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    data += row[j];
                    if (j == dataTable.Columns.Count - 1)
                    {
                        if (i != (dataTable.Rows.Count - 1))
                            data += @"";
                    }
                    else
                        data += @"|";
                }
            }
            return data;
        }
        #endregion

        #region 模拟http发送get请求
        public string HttpGet(string postDataStr)
        {
            //发送到VX的pushplus
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://pushplus.hxtrip.com/send?token=5718f2394c8f4b4dae5f4f996bdd3b9f&content=" + postDataStr);
            #region 未启用服务
            //机器人发送到QQ群
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://138.2.123.114:5701/send_group_msg?group_id=539726277&message=" + postDataStr);
            //机器人发送到QQ
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://138.2.123.114:5701/send_private_msg?user_id=125939224&message=" + postDataStr);
            //发送到server酱
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://sctapi.ftqq.com/SCT66995TOkM9qjVjUYcNfwClRyAajnDs.send?desp=" + postDataStr);
            #endregion
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        #endregion

        #region 模拟http发送post请求(未启用)
        /*
        private string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString; 
        }
        */
        #endregion

    }
}
