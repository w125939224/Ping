using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;

namespace PingResult
{
    /// <summary>
    /// Directed by 王钦奕
    /// Build Time 2021年12月9日
    /// </summary>
    public partial class Ping_main : Form
    {
        /// <summary>
        /// 全局变量声明，仅用做输出时传参
        /// </summary>
        public static List<string> PingList = new List<string>();
        public Ping_main()
        {
            InitializeComponent();
        }
        private void begin_Click(object sender, EventArgs e)
        {
            var PingLinesCount = PingRichTextBox.Lines.Count();
            try
            {

                for (int i = 0; i < PingLinesCount; i++)
                {
                    if (PingRichTextBox.Text != null)
                    {
                        var NetSefment = PingRichTextBox.Lines[i];
                        string[] NetSefmentArray = NetSefment.Split('-', ',', ' ', '。', '~', ':', '.');
                        var BeginNetSegment = NetSefmentArray[3];
                        var EndNetSegment = NetSefmentArray[7];
                        if (NetSefmentArray[0] == NetSefmentArray[4]
                            && NetSefmentArray[1] == NetSefmentArray[5]
                            && NetSefmentArray[2] == NetSefmentArray[6]
                            && Convert.ToInt32(BeginNetSegment) <= Convert.ToInt32(EndNetSegment)
                            && IPAddress.TryParse(BeginNetSegment, out var BeginNetSegmentIP)
                            && IPAddress.TryParse(EndNetSegment, out var EndNetSegmentIP)
                            )
                        {
                            for (var IP = Convert.ToInt32(BeginNetSegment); IP < Convert.ToInt32(EndNetSegment); IP++)
                            {
                                
                                DataGridView.DataSource = PingList;
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
        }
        private void Ping_main_Load(object sender, EventArgs e)
        {
            PingRichTextBox.Text = "请在此输入需要扫描的IP段，格式为一行一个IP段。例：192.168.0.1-192.168.0.254。";
            PingRichTextBox.HideSelection = false;
            PingRichTextBox.SelectAll();
        }
        /// <summary>
        /// 扫描IP获得DNS和主机名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status == IPStatus.Success)
            {
                PingList.Add(e.Reply.Address.ToString() + "|" + Dns.GetHostEntry(IPAddress.Parse(e.Reply.Address.ToString())).HostName);
            }
        }
    }
}
