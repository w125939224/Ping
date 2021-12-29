
namespace PingResult
{
    partial class Ping_Main
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
            this.Begin = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timershowtext = new System.Windows.Forms.Label();
            this.refresh = new System.Windows.Forms.Button();
            this.showiponly = new System.Windows.Forms.CheckBox();
            this.pingrichtextbox = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.pingtimercounter = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // Begin
            // 
            this.Begin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Begin.AutoSize = true;
            this.Begin.Location = new System.Drawing.Point(3, 16);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(87, 34);
            this.Begin.TabIndex = 1;
            this.Begin.Text = "开始ping测试";
            this.Begin.UseVisualStyleBackColor = true;
            this.Begin.Click += new System.EventHandler(this.Begin_Click);
            // 
            // Import
            // 
            this.Import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Import.AutoSize = true;
            this.Import.Location = new System.Drawing.Point(240, 16);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(76, 34);
            this.Import.TabIndex = 2;
            this.Import.Text = "导出结果";
            this.Import.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.timershowtext);
            this.splitContainer1.Panel1.Controls.Add(this.refresh);
            this.splitContainer1.Panel1.Controls.Add(this.showiponly);
            this.splitContainer1.Panel1.Controls.Add(this.Begin);
            this.splitContainer1.Panel1.Controls.Add(this.Import);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pingrichtextbox);
            this.splitContainer1.Size = new System.Drawing.Size(319, 631);
            this.splitContainer1.SplitterDistance = 66;
            this.splitContainer1.TabIndex = 3;
            // 
            // timershowtext
            // 
            this.timershowtext.Location = new System.Drawing.Point(94, 22);
            this.timershowtext.Name = "timershowtext";
            this.timershowtext.Size = new System.Drawing.Size(134, 14);
            this.timershowtext.TabIndex = 5;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(136, 39);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(59, 25);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "刷新";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_click);
            // 
            // showiponly
            // 
            this.showiponly.AutoSize = true;
            this.showiponly.Location = new System.Drawing.Point(96, 3);
            this.showiponly.Name = "showiponly";
            this.showiponly.Size = new System.Drawing.Size(132, 16);
            this.showiponly.TabIndex = 3;
            this.showiponly.Text = "是否只显示不可连接IP";
            this.showiponly.UseVisualStyleBackColor = true;
            // 
            // pingrichtextbox
            // 
            this.pingrichtextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pingrichtextbox.Location = new System.Drawing.Point(0, 0);
            this.pingrichtextbox.Name = "pingrichtextbox";
            this.pingrichtextbox.Size = new System.Drawing.Size(319, 561);
            this.pingrichtextbox.TabIndex = 0;
            this.pingrichtextbox.Text = "";
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
            this.splitContainer2.Panel2.Controls.Add(this.datagridview);
            this.splitContainer2.Size = new System.Drawing.Size(975, 637);
            this.splitContainer2.SplitterDistance = 325;
            this.splitContainer2.TabIndex = 4;
            // 
            // datagridview
            // 
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridview.Location = new System.Drawing.Point(0, 0);
            this.datagridview.Name = "datagridview";
            this.datagridview.RowTemplate.Height = 23;
            this.datagridview.Size = new System.Drawing.Size(646, 637);
            this.datagridview.TabIndex = 0;
            // 
            // Ping_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 637);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Ping_Main";
            this.Text = "Ping_main";
            this.Load += new System.EventHandler(this.Ping_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Begin;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.RichTextBox pingrichtextbox;
        private System.Windows.Forms.CheckBox showiponly;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label timershowtext;
        private System.Windows.Forms.Timer pingtimercounter;
    }
}

