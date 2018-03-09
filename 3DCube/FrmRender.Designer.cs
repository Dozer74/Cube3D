namespace Cube3D
{
    partial class FrmRender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gFilling = new System.Windows.Forms.GroupBox();
            this.rbShowColorFaces = new System.Windows.Forms.RadioButton();
            this.rbShowFaces = new System.Windows.Forms.RadioButton();
            this.rbShowLines = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbZ = new System.Windows.Forms.CheckBox();
            this.cbY = new System.Windows.Forms.CheckBox();
            this.cbX = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gFilling.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(141, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 275);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gFilling
            // 
            this.gFilling.Controls.Add(this.rbShowColorFaces);
            this.gFilling.Controls.Add(this.rbShowFaces);
            this.gFilling.Controls.Add(this.rbShowLines);
            this.gFilling.Location = new System.Drawing.Point(12, 12);
            this.gFilling.Name = "gFilling";
            this.gFilling.Size = new System.Drawing.Size(123, 90);
            this.gFilling.TabIndex = 16;
            this.gFilling.TabStop = false;
            this.gFilling.Text = "Отображать";
            // 
            // rbShowColorFaces
            // 
            this.rbShowColorFaces.AutoSize = true;
            this.rbShowColorFaces.Location = new System.Drawing.Point(12, 65);
            this.rbShowColorFaces.Name = "rbShowColorFaces";
            this.rbShowColorFaces.Size = new System.Drawing.Size(102, 17);
            this.rbShowColorFaces.TabIndex = 20;
            this.rbShowColorFaces.Text = "Цветные грани";
            this.rbShowColorFaces.UseVisualStyleBackColor = true;
            this.rbShowColorFaces.CheckedChanged += new System.EventHandler(this.rbShowMode_CheckedChanged);
            // 
            // rbShowFaces
            // 
            this.rbShowFaces.AutoSize = true;
            this.rbShowFaces.Checked = true;
            this.rbShowFaces.Location = new System.Drawing.Point(12, 42);
            this.rbShowFaces.Name = "rbShowFaces";
            this.rbShowFaces.Size = new System.Drawing.Size(55, 17);
            this.rbShowFaces.TabIndex = 18;
            this.rbShowFaces.TabStop = true;
            this.rbShowFaces.Text = "Грани";
            this.rbShowFaces.UseVisualStyleBackColor = true;
            this.rbShowFaces.CheckedChanged += new System.EventHandler(this.rbShowMode_CheckedChanged);
            // 
            // rbShowLines
            // 
            this.rbShowLines.AutoSize = true;
            this.rbShowLines.Location = new System.Drawing.Point(12, 19);
            this.rbShowLines.Name = "rbShowLines";
            this.rbShowLines.Size = new System.Drawing.Size(62, 17);
            this.rbShowLines.TabIndex = 19;
            this.rbShowLines.Text = "Каркас";
            this.rbShowLines.UseVisualStyleBackColor = true;
            this.rbShowLines.CheckedChanged += new System.EventHandler(this.rbShowMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbZ);
            this.groupBox1.Controls.Add(this.cbY);
            this.groupBox1.Controls.Add(this.cbX);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 45);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вращение";
            // 
            // cbZ
            // 
            this.cbZ.AutoSize = true;
            this.cbZ.Location = new System.Drawing.Point(84, 19);
            this.cbZ.Name = "cbZ";
            this.cbZ.Size = new System.Drawing.Size(33, 17);
            this.cbZ.TabIndex = 0;
            this.cbZ.Text = "Z";
            this.cbZ.UseVisualStyleBackColor = true;
            // 
            // cbY
            // 
            this.cbY.AutoSize = true;
            this.cbY.Location = new System.Drawing.Point(45, 19);
            this.cbY.Name = "cbY";
            this.cbY.Size = new System.Drawing.Size(33, 17);
            this.cbY.TabIndex = 0;
            this.cbY.Text = "Y";
            this.cbY.UseVisualStyleBackColor = true;
            // 
            // cbX
            // 
            this.cbX.AutoSize = true;
            this.cbX.Location = new System.Drawing.Point(6, 19);
            this.cbX.Name = "cbX";
            this.cbX.Size = new System.Drawing.Size(33, 17);
            this.cbX.TabIndex = 0;
            this.cbX.Text = "X";
            this.cbX.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(11, 236);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 23);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSpeed);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 71);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Скорость";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(6, 19);
            this.tbSpeed.Minimum = 1;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(104, 45);
            this.tbSpeed.TabIndex = 0;
            this.tbSpeed.Value = 3;
            // 
            // FrmRender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gFilling);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRender";
            this.Text = "3D Cube";
            this.Load += new System.EventHandler(this.FrmRender_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gFilling.ResumeLayout(false);
            this.gFilling.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gFilling;
        private System.Windows.Forms.RadioButton rbShowFaces;
        private System.Windows.Forms.RadioButton rbShowLines;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbZ;
        private System.Windows.Forms.CheckBox cbY;
        private System.Windows.Forms.CheckBox cbX;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.RadioButton rbShowColorFaces;
    }
}

