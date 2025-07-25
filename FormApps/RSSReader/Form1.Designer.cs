namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            tbFavorite = new TextBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btGoback = new Button();
            btGoFoward = new Button();
            label1 = new Label();
            label2 = new Label();
            cbUrl = new ComboBox();
            itemDateBindingSource = new BindingSource(components);
            btRegistration = new Button();
            btDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemDateBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tbFavorite
            // 
            tbFavorite.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbFavorite.Location = new Point(129, 80);
            tbFavorite.Name = "tbFavorite";
            tbFavorite.Size = new Size(353, 33);
            tbFavorite.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(558, 2);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(69, 30);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 119);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(607, 88);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(12, 213);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(607, 442);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            // 
            // btGoback
            // 
            btGoback.Location = new Point(12, 2);
            btGoback.Name = "btGoback";
            btGoback.Size = new Size(36, 30);
            btGoback.TabIndex = 4;
            btGoback.Text = "戻る";
            btGoback.UseVisualStyleBackColor = true;
            btGoback.Click += btGoback_Click;
            // 
            // btGoFoward
            // 
            btGoFoward.Location = new Point(54, 2);
            btGoFoward.Name = "btGoFoward";
            btGoFoward.Size = new Size(40, 30);
            btGoFoward.TabIndex = 4;
            btGoFoward.Text = "進む";
            btGoFoward.UseVisualStyleBackColor = true;
            btGoFoward.Click += btGoFoward_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 86);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 5;
            label1.Text = "お気に入り登録";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label2.Location = new Point(-1, 44);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 6;
            label2.Text = "URLまたはお気に入り名称";
            // 
            // cbUrl
            // 
            cbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            cbUrl.FormattingEnabled = true;
            cbUrl.Location = new Point(173, 37);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(369, 33);
            cbUrl.TabIndex = 7;
            // 
            // itemDateBindingSource
            // 
            itemDateBindingSource.DataSource = typeof(RSSReader.ItemDate);
            // 
            // btRegistration
            // 
            btRegistration.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            btRegistration.Location = new Point(496, 87);
            btRegistration.Name = "btRegistration";
            btRegistration.Size = new Size(54, 23);
            btRegistration.TabIndex = 8;
            btRegistration.Text = "登録";
            btRegistration.UseVisualStyleBackColor = true;
            btRegistration.Click += btRegistration_Click;
            // 
            // btDelete
            // 
            btDelete.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            btDelete.Location = new Point(558, 86);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(51, 23);
            btDelete.TabIndex = 9;
            btDelete.Text = "削除";
            btDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 667);
            Controls.Add(btDelete);
            Controls.Add(btRegistration);
            Controls.Add(cbUrl);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btGoFoward);
            Controls.Add(btGoback);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(tbFavorite);
            Name = "Form1";
            Text = "RSSリーダー";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemDateBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbFavorite;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btGoback;
        private Button btGoFoward;
        private Label label1;
        private Label label2;
        private ComboBox cbUrl;
        private Button btRegistration;
        private Button btDelete;
        private BindingSource itemDateBindingSource;
    }
}
