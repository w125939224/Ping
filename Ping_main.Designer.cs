
namespace PingResult
{
    partial class ping_Main
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
            this.begin = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.showIpOnly = new System.Windows.Forms.CheckBox();
            this.pingRichTextBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.reFresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // begin
            // 
            this.begin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.begin.AutoSize = true;
            this.begin.Location = new System.Drawing.Point(3, 16);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(87, 34);
            this.begin.TabIndex = 1;
            this.begin.Text = "开始ping测试";
            this.begin.UseVisualStyleBackColor = true;
            this.begin.Click += new System.EventHandler(this.begin_Click);
            // 
            // import
            // 
            this.import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.import.AutoSize = true;
            this.import.Location = new System.Drawing.Point(240, 16);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(76, 34);
            this.import.TabIndex = 2;
            this.import.Text = "导出结果";
            this.import.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reFresh);
            this.splitContainer1.Panel1.Controls.Add(this.showIpOnly);
            this.splitContainer1.Panel1.Controls.Add(this.begin);
            this.splitContainer1.Panel1.Controls.Add(this.import);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pingRichTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(319, 631);
            this.splitContainer1.SplitterDistance = 66;
            this.splitContainer1.TabIndex = 3;
            // 
            // showIpOnly
            // 
            this.showIpOnly.AutoSize = true;
            this.showIpOnly.Location = new System.Drawing.Point(96, 3);
            this.showIpOnly.Name = "showIpOnly";
            this.showIpOnly.Size = new System.Drawing.Size(132, 16);
            this.showIpOnly.TabIndex = 3;
            this.showIpOnly.Text = "是否只显示可连接IP";
            this.showIpOnly.UseVisualStyleBackColor = true;
            // 
            // pingRichTextBox
            // 
            this.pingRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pingRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.pingRichTextBox.Name = "pingRichTextBox";
            this.pingRichTextBox.Size = new System.Drawing.Size(319, 561);
            this.pingRichTextBox.TabIndex = 0;
            this.pingRichTextBox.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(975, 637);
            this.splitContainer2.SplitterDistance = 325;
            this.splitContainer2.TabIndex = 4;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(646, 637);
            this.dataGridView.TabIndex = 0;
            // 
            // reFresh
            // 
            this.reFresh.Location = new System.Drawing.Point(96, 38);
            this.reFresh.Name = "reFresh";
            this.reFresh.Size = new System.Drawing.Size(59, 25);
            this.reFresh.TabIndex = 4;
            this.reFresh.Text = "刷新";
            this.reFresh.UseVisualStyleBackColor = true;
            this.reFresh.Click += new System.EventHandler(this.reFresh_Click);
            // 
            // Ping_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 637);
            this.Controls.Add(this.splitContainer2);
            this.Name = "ping_main";
            this.Text = "ping_main";
            this.Load += new System.EventHandler(this.ping_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button begin;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.RichTextBox pingRichTextBox;
        private System.Windows.Forms.CheckBox showIpOnly;
        private System.Windows.Forms.Button reFresh;
    }
}

