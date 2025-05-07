namespace StopWatch {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lbTimeDisp = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.tmDispTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbTimeDisp
            // 
            this.lbTimeDisp.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbTimeDisp.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbTimeDisp.Location = new System.Drawing.Point(12, 9);
            this.lbTimeDisp.Name = "lbTimeDisp";
            this.lbTimeDisp.Size = new System.Drawing.Size(765, 85);
            this.lbTimeDisp.TabIndex = 0;
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStart.Location = new System.Drawing.Point(44, 117);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(255, 130);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "スタート";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStop.Location = new System.Drawing.Point(44, 285);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(255, 130);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "ストップ";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btReset
            // 
            this.btReset.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btReset.Location = new System.Drawing.Point(380, 117);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(255, 130);
            this.btReset.TabIndex = 3;
            this.btReset.Text = "リセット";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // tmDispTimer
            // 
            this.tmDispTimer.Tick += new System.EventHandler(this.tmDispTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lbTimeDisp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTimeDisp;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Timer tmDispTimer;
    }
}

