namespace listView_speed
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataLoadBtn = new System.Windows.Forms.Button();
            this.tmpTextBox = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // dataLoadBtn
            // 
            this.dataLoadBtn.Location = new System.Drawing.Point(35, 30);
            this.dataLoadBtn.Name = "dataLoadBtn";
            this.dataLoadBtn.Size = new System.Drawing.Size(107, 23);
            this.dataLoadBtn.TabIndex = 0;
            this.dataLoadBtn.Text = "dataLoad";
            this.dataLoadBtn.UseVisualStyleBackColor = true;
            this.dataLoadBtn.Click += new System.EventHandler(this.dataLoadBtn_Clicked);
            // 
            // tmpTextBox
            // 
            this.tmpTextBox.Location = new System.Drawing.Point(1145, 28);
            this.tmpTextBox.Name = "tmpTextBox";
            this.tmpTextBox.Size = new System.Drawing.Size(219, 25);
            this.tmpTextBox.TabIndex = 1;
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.FullRowSelect = true;
            this.listView.HoverSelection = true;
            this.listView.Location = new System.Drawing.Point(35, 68);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1329, 386);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1376, 481);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.tmpTextBox);
            this.Controls.Add(this.dataLoadBtn);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dataLoadButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button dataLoadBtn;
        private System.Windows.Forms.TextBox tmpTextBox;
        private System.Windows.Forms.ListView listView;
    }
}

