namespace ReadCSV
{
    partial class MainForm
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
            this.findBtn = new System.Windows.Forms.Button();
            this.parseBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.csvDGV = new System.Windows.Forms.DataGridView();
            this.userDataDGV = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawCsvTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstRowNUD = new System.Windows.Forms.NumericUpDown();
            this.lastRowNUD = new System.Windows.Forms.NumericUpDown();
            this.colName = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.colPNo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colSeatAndSex = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.extractBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.csvDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRowNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastRowNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colPNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSeatAndSex)).BeginInit();
            this.SuspendLayout();
            // 
            // findBtn
            // 
            this.findBtn.AutoSize = true;
            this.findBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.findBtn.Location = new System.Drawing.Point(12, 12);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(63, 22);
            this.findBtn.TabIndex = 0;
            this.findBtn.Text = "불러오기";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.Find_file_btn);
            // 
            // parseBtn
            // 
            this.parseBtn.AutoSize = true;
            this.parseBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.parseBtn.Location = new System.Drawing.Point(322, 12);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(75, 22);
            this.parseBtn.TabIndex = 0;
            this.parseBtn.Text = "데이터파싱";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.DB_btn);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // csvDGV
            // 
            this.csvDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvDGV.Location = new System.Drawing.Point(417, 40);
            this.csvDGV.Name = "csvDGV";
            this.csvDGV.RowTemplate.Height = 23;
            this.csvDGV.Size = new System.Drawing.Size(616, 404);
            this.csvDGV.TabIndex = 2;
            // 
            // userDataDGV
            // 
            this.userDataDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.userDataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnPNo,
            this.columnSex,
            this.columnSeatNo});
            this.userDataDGV.Location = new System.Drawing.Point(1039, 12);
            this.userDataDGV.Name = "userDataDGV";
            this.userDataDGV.RowTemplate.Height = 23;
            this.userDataDGV.Size = new System.Drawing.Size(440, 420);
            this.userDataDGV.TabIndex = 3;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "이름";
            this.columnName.Name = "columnName";
            this.columnName.Width = 54;
            // 
            // columnPNo
            // 
            this.columnPNo.HeaderText = "전화번호";
            this.columnPNo.Name = "columnPNo";
            this.columnPNo.Width = 78;
            // 
            // columnSex
            // 
            this.columnSex.HeaderText = "성별";
            this.columnSex.Name = "columnSex";
            this.columnSex.Width = 54;
            // 
            // columnSeatNo
            // 
            this.columnSeatNo.HeaderText = "좌석번호";
            this.columnSeatNo.Name = "columnSeatNo";
            this.columnSeatNo.Width = 78;
            // 
            // rawCsvTB
            // 
            this.rawCsvTB.Location = new System.Drawing.Point(13, 40);
            this.rawCsvTB.Multiline = true;
            this.rawCsvTB.Name = "rawCsvTB";
            this.rawCsvTB.Size = new System.Drawing.Size(398, 404);
            this.rawCsvTB.TabIndex = 4;
            this.rawCsvTB.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "헤더 위치";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "푸터 길이";
            // 
            // firstRowNUD
            // 
            this.firstRowNUD.Location = new System.Drawing.Point(144, 12);
            this.firstRowNUD.Name = "firstRowNUD";
            this.firstRowNUD.Size = new System.Drawing.Size(39, 21);
            this.firstRowNUD.TabIndex = 7;
            // 
            // lastRowNUD
            // 
            this.lastRowNUD.Location = new System.Drawing.Point(252, 12);
            this.lastRowNUD.Name = "lastRowNUD";
            this.lastRowNUD.Size = new System.Drawing.Size(39, 21);
            this.lastRowNUD.TabIndex = 8;
            // 
            // colName
            // 
            this.colName.Location = new System.Drawing.Point(506, 12);
            this.colName.Name = "colName";
            this.colName.Size = new System.Drawing.Size(39, 21);
            this.colName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "이름 칼럼 위치";
            // 
            // colPNo
            // 
            this.colPNo.Location = new System.Drawing.Point(675, 12);
            this.colPNo.Name = "colPNo";
            this.colPNo.Size = new System.Drawing.Size(39, 21);
            this.colPNo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "전화번호 칼럼 위치";
            // 
            // colSeatAndSex
            // 
            this.colSeatAndSex.Location = new System.Drawing.Point(865, 12);
            this.colSeatAndSex.Name = "colSeatAndSex";
            this.colSeatAndSex.Size = new System.Drawing.Size(39, 21);
            this.colSeatAndSex.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "성별/좌석번호 칼럼 위치";
            // 
            // extractBtn
            // 
            this.extractBtn.AutoSize = true;
            this.extractBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extractBtn.Location = new System.Drawing.Point(958, 9);
            this.extractBtn.Name = "extractBtn";
            this.extractBtn.Size = new System.Drawing.Size(79, 22);
            this.extractBtn.TabIndex = 15;
            this.extractBtn.Text = "데이터 추출";
            this.extractBtn.UseVisualStyleBackColor = true;
            this.extractBtn.Click += new System.EventHandler(this.extractBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1040, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "sql conn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SqlConn_btn_click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 483);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.extractBtn);
            this.Controls.Add(this.colSeatAndSex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.colPNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.colName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastRowNUD);
            this.Controls.Add(this.firstRowNUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rawCsvTB);
            this.Controls.Add(this.userDataDGV);
            this.Controls.Add(this.csvDGV);
            this.Controls.Add(this.parseBtn);
            this.Controls.Add(this.findBtn);
            this.Name = "MainForm";
            this.Text = "ReadCSV";
            ((System.ComponentModel.ISupportInitialize)(this.csvDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRowNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastRowNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colPNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSeatAndSex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView csvDGV;
        private System.Windows.Forms.DataGridView userDataDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSeatNo;
        private System.Windows.Forms.TextBox rawCsvTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown firstRowNUD;
        private System.Windows.Forms.NumericUpDown lastRowNUD;
        private System.Windows.Forms.NumericUpDown colName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown colPNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown colSeatAndSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button extractBtn;
        private System.Windows.Forms.Button button1;
    }
}

