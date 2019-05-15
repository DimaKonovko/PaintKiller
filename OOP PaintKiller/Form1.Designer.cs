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
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.FiguresListBox = new System.Windows.Forms.ListBox();
			this.SaveCustomFigure = new System.Windows.Forms.Button();
			this.CustomFigureName = new System.Windows.Forms.TextBox();
			this.CustomFiguresListBox = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.Snow;
			this.pictureBox.Location = new System.Drawing.Point(138, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(845, 583);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(12, 556);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(105, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(12, 435);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(105, 23);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(12, 464);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(105, 23);
			this.btnLoad.TabIndex = 7;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// FiguresListBox
			// 
			this.FiguresListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FiguresListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FiguresListBox.FormattingEnabled = true;
			this.FiguresListBox.Location = new System.Drawing.Point(12, 12);
			this.FiguresListBox.Name = "FiguresListBox";
			this.FiguresListBox.Size = new System.Drawing.Size(105, 93);
			this.FiguresListBox.TabIndex = 8;
			// 
			// SaveCustomFigure
			// 
			this.SaveCustomFigure.Location = new System.Drawing.Point(12, 219);
			this.SaveCustomFigure.Name = "SaveCustomFigure";
			this.SaveCustomFigure.Size = new System.Drawing.Size(105, 23);
			this.SaveCustomFigure.TabIndex = 9;
			this.SaveCustomFigure.Text = "Save as Custom";
			this.SaveCustomFigure.UseVisualStyleBackColor = true;
			this.SaveCustomFigure.Click += new System.EventHandler(this.SaveCustomFigure_Click);
			// 
			// CustomFigureName
			// 
			this.CustomFigureName.Location = new System.Drawing.Point(12, 193);
			this.CustomFigureName.Name = "CustomFigureName";
			this.CustomFigureName.Size = new System.Drawing.Size(105, 20);
			this.CustomFigureName.TabIndex = 10;
			this.CustomFigureName.Text = "CustomFigureNameHere";
			// 
			// CustomFiguresListBox
			// 
			this.CustomFiguresListBox.FormattingEnabled = true;
			this.CustomFiguresListBox.Location = new System.Drawing.Point(12, 247);
			this.CustomFiguresListBox.Name = "CustomFiguresListBox";
			this.CustomFiguresListBox.Size = new System.Drawing.Size(105, 95);
			this.CustomFiguresListBox.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(995, 607);
			this.Controls.Add(this.CustomFiguresListBox);
			this.Controls.Add(this.CustomFigureName);
			this.Controls.Add(this.SaveCustomFigure);
			this.Controls.Add(this.FiguresListBox);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.RightToLeftLayout = true;
			this.Text = "PaintKiller";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.ListBox FiguresListBox;
		private System.Windows.Forms.Button SaveCustomFigure;
		private System.Windows.Forms.TextBox CustomFigureName;
		private System.Windows.Forms.ListBox CustomFiguresListBox;
	}
}
