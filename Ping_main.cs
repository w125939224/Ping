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

namespace PingResult
{
    public partial class Ping_main : Form
    {
        public Ping_main()
        {
            InitializeComponent();
        }
        private void begin_Click(object sender, EventArgs e)
        {
            var PingLinesCount = Pinglist.Lines.Count();
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
            }
        }
        private void Ping_main_Load(object sender, EventArgs e)
        {
            Pinglist.Text = "请在此输入需要扫描的IP段，格式为一行一个IP段。例：192.168.0.1-192.168.0.254。";
            Pinglist.HideSelection = false;
            Pinglist.SelectAll();
        }
    }
}
