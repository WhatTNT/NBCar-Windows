namespace NBCar_Windows
{
    partial class Form1
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
            this.textGPStatus = new System.Windows.Forms.Label();
            this.labelLeftPower = new System.Windows.Forms.Label();
            this.labelRightPower = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textGPStatus
            // 
            this.textGPStatus.AutoSize = true;
            this.textGPStatus.Location = new System.Drawing.Point(13, 13);
            this.textGPStatus.Name = "textGPStatus";
            this.textGPStatus.Size = new System.Drawing.Size(101, 12);
            this.textGPStatus.TabIndex = 0;
            this.textGPStatus.Text = "手柄状态：检测中";
            // 
            // labelLeftPower
            // 
            this.labelLeftPower.AutoSize = true;
            this.labelLeftPower.Location = new System.Drawing.Point(13, 29);
            this.labelLeftPower.Name = "labelLeftPower";
            this.labelLeftPower.Size = new System.Drawing.Size(77, 12);
            this.labelLeftPower.TabIndex = 1;
            this.labelLeftPower.Text = "左马达：100%";
            // 
            // labelRightPower
            // 
            this.labelRightPower.AutoSize = true;
            this.labelRightPower.Location = new System.Drawing.Point(13, 44);
            this.labelRightPower.Name = "labelRightPower";
            this.labelRightPower.Size = new System.Drawing.Size(77, 12);
            this.labelRightPower.TabIndex = 2;
            this.labelRightPower.Text = "右马达：100%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelRightPower);
            this.Controls.Add(this.labelLeftPower);
            this.Controls.Add(this.textGPStatus);
            this.Name = "Form1";
            this.Text = "NBCar管理程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textGPStatus;
        private System.Windows.Forms.Label labelLeftPower;
        private System.Windows.Forms.Label labelRightPower;
    }
}

