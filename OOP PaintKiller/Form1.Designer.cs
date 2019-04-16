namespace OOP_PaintKiller
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.btnCircle = new System.Windows.Forms.Button();
			this.btnLine = new System.Windows.Forms.Button();
			this.btnRectangle = new System.Windows.Forms.Button();
			this.btnTreangle = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.Snow;
			this.pictureBox.Location = new System.Drawing.Point(106, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(877, 583);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// btnCircle
			// 
			this.btnCircle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCircle.Location = new System.Drawing.Point(12, 12);
			this.btnCircle.Name = "btnCircle";
			this.btnCircle.Size = new System.Drawing.Size(75, 50);
			this.btnCircle.TabIndex = 1;
			this.btnCircle.Text = "Circle";
			this.btnCircle.UseVisualStyleBackColor = true;
			this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
			// 
			// btnLine
			// 
			this.btnLine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLine.Location = new System.Drawing.Point(12, 68);
			this.btnLine.Name = "btnLine";
			this.btnLine.Size = new System.Drawing.Size(75, 50);
			this.btnLine.TabIndex = 2;
			this.btnLine.Text = "Line";
			this.btnLine.UseVisualStyleBackColor = true;
			this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
			// 
			// btnRectangle
			// 
			this.btnRectangle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRectangle.Location = new System.Drawing.Point(12, 124);
			this.btnRectangle.Name = "btnRectangle";
			this.btnRectangle.Size = new System.Drawing.Size(75, 50);
			this.btnRectangle.TabIndex = 3;
			this.btnRectangle.Text = "Rectangle";
			this.btnRectangle.UseVisualStyleBackColor = true;
			this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
			// 
			// btnTreangle
			// 
			this.btnTreangle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnTreangle.Location = new System.Drawing.Point(12, 180);
			this.btnTreangle.Name = "btnTreangle";
			this.btnTreangle.Size = new System.Drawing.Size(75, 50);
			this.btnTreangle.TabIndex = 4;
			this.btnTreangle.Text = "Treangle";
			this.btnTreangle.UseVisualStyleBackColor = true;
			this.btnTreangle.Click += new System.EventHandler(this.btnTreangle_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(12, 556);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(12, 340);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(995, 607);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnTreangle);
			this.Controls.Add(this.btnRectangle);
			this.Controls.Add(this.btnLine);
			this.Controls.Add(this.btnCircle);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.RightToLeftLayout = true;
			this.Text = "PaintKiller";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button btnCircle;
		private System.Windows.Forms.Button btnLine;
		private System.Windows.Forms.Button btnRectangle;
		private System.Windows.Forms.Button btnTreangle;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnSave;
	}
}

