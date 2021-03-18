
namespace AutoUpdate
{
    partial class Checker
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
            this.label1 = new System.Windows.Forms.Label();
            this.serverDGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.version_label = new System.Windows.Forms.Label();
            this.programDGV = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.clientIp_label = new System.Windows.Forms.Label();
            this.logDGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.serverDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(75, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // serverDGV
            // 
            this.serverDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverDGV.Location = new System.Drawing.Point(33, 55);
            this.serverDGV.Name = "serverDGV";
            this.serverDGV.RowTemplate.Height = 23;
            this.serverDGV.Size = new System.Drawing.Size(285, 400);
            this.serverDGV.TabIndex = 4;
            this.serverDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "버튼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(27, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "서버 현황";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // version_label
            // 
            this.version_label.AutoSize = true;
            this.version_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.version_label.Location = new System.Drawing.Point(95, 51);
            this.version_label.Name = "version_label";
            this.version_label.Size = new System.Drawing.Size(0, 21);
            this.version_label.TabIndex = 7;
            // 
            // programDGV
            // 
            this.programDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.programDGV.Location = new System.Drawing.Point(330, 55);
            this.programDGV.Name = "programDGV";
            this.programDGV.RowTemplate.Height = 23;
            this.programDGV.Size = new System.Drawing.Size(546, 204);
            this.programDGV.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(324, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "버전 관리";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // clientIp_label
            // 
            this.clientIp_label.AutoSize = true;
            this.clientIp_label.Location = new System.Drawing.Point(152, 29);
            this.clientIp_label.Name = "clientIp_label";
            this.clientIp_label.Size = new System.Drawing.Size(56, 12);
            this.clientIp_label.TabIndex = 10;
            this.clientIp_label.Text = "접속 IP : ";
            this.clientIp_label.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // logDGV
            // 
            this.logDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDGV.Location = new System.Drawing.Point(330, 307);
            this.logDGV.Name = "logDGV";
            this.logDGV.RowTemplate.Height = 23;
            this.logDGV.Size = new System.Drawing.Size(546, 148);
            this.logDGV.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(324, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "작업 로그";
            this.label2.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.updateBtn.Location = new System.Drawing.Point(772, 11);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(104, 34);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "업데이트";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // AutoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 480);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logDGV);
            this.Controls.Add(this.clientIp_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.programDGV);
            this.Controls.Add(this.version_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serverDGV);
            this.Controls.Add(this.label1);
            this.Name = "AutoUpdate";
            this.Text = "Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serverDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView serverDGV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label version_label;
        private System.Windows.Forms.DataGridView programDGV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label clientIp_label;
        private System.Windows.Forms.DataGridView logDGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateBtn;
    }
}

