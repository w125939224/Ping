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
    /// <summary>
    /// Directed by 王钦奕
    /// Build Time 2021年12月9日
    /// </summary>
    public partial class ping_Main : Form
    {
        ///定义全局的数据展示表格，用来赋值给datagridview
        DataTable datatable = new DataTable();
        public ping_Main()
        {
            InitializeComponent();
            datatable.Columns.Add("IP");
            datatable.Columns.Add("NetConnect");
            datatable.Columns.Add("DNS");
            datatable.Columns.Add("MAC");
        }
        private void begin_Click(object sender, EventArgs e)
        {
            datatable.Clear();
            var pingLinesCount = pingRichTextBox.Lines.Count();

            try
            {
                for (int i = 0; i < pingLinesCount; i++)
                {
                    if (pingRichTextBox.Text != null)
                    {
                        var netSefment = pingRichTextBox.Lines[i];
                        string[] netSefmentArray = netSefment.Split('-', ',', ' ', '。', '~', ':', '.');
                        var beginNetSegment = netSefmentArray[3];
                        var endNetSegment = netSefmentArray[7];
                        if (netSefmentArray[0] == netSefmentArray[4]
                            && netSefmentArray[1] == netSefmentArray[5]
                            && netSefmentArray[2] == netSefmentArray[6]
                            && Convert.ToInt32(beginNetSegment) <= Convert.ToInt32(endNetSegment)
                            && IPAddress.TryParse(beginNetSegment, out var BeginNetSegmentIP)
                            && IPAddress.TryParse(endNetSegment, out var EndNetSegmentIP)
                            )
                        {
                            for (var IP = Convert.ToInt32(beginNetSegment); IP <= Convert.ToInt32(endNetSegment); IP++)
                            {
                                Ping ping = new Ping();

                                var scanIP_String = netSefmentArray[0] + "." + netSefmentArray[1] + "." + netSefmentArray[2] + "." + Convert.ToString(IP);
                                PingReply reply = ping.Send(scanIP_String, 1);
                                DataRow dataRow = datatable.NewRow();
                                if (showIpOnly.Checked == true)
                                {
                                    if (reply.Status == IPStatus.Success)
                                    {
                                        dataRow["IP"] = scanIP_String;
                                        dataRow["NetConnect"] = "connect";
                                        datatable.Rows.Add(dataRow);
                                    }
                                }
                                else
                                {
                                    if (reply.Status == IPStatus.Success)
                                    {
                                        dataRow["IP"] = scanIP_String;
                                        dataRow["NetConnect"] = "connect";
                                        datatable.Rows.Add(dataRow);
                                    }
                                    else
                                    {
                                        dataRow["IP"] = scanIP_String;
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
            dataGridView.DataSource = datatable;
            var data = convertDataTableToString(datatable);
            var info = HttpGet(data);
            dataGridView.Show();

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
        private void ping_Main_Load(object sender, EventArgs e)
        {
            pingRichTextBox.Text = "请在此输入需要扫描的IP段，格式为一行一个IP段。例：192.168.0.1-192.168.0.254。";
            pingRichTextBox.HideSelection = false;
            pingRichTextBox.SelectAll();
        }

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
        private void reFresh_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 转换datatable为string
        public static string convertDataTableToString(DataTable dataTable)
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
                            data += "\r\n";
                    }
                    else
                        data += "|";
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
            //机器人发送到QQ
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://195.15.242.242:5700/send_group_msg?user_id=539726277&message=" + postDataStr);
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
