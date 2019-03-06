using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_PaintKiller
{
	public partial class MainForm : Form
	{
		List<Figure> listOfFigures = new List<Figure> { };
		Bitmap bmp;
		Graphics grph;
		Pen pen;
		Point startPoint, endPoint;
		Figure chosenFigure;

		public MainForm()
		{
			InitializeComponent();
			InitializeGrph();
		}

		private void InitializeGrph()
		{			 
			bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
			grph = Graphics.FromImage(bmp);	
			pen = new Pen(Color.Black); 
		}

		private void RepaintBMP()
		{
			foreach (Figure fig in listOfFigures)
			{
				fig.Draw(grph, pen);
			}
			pictureBox.Image = bmp;
		}

		private void btnLine_Click(object sender, EventArgs e)
		{
			Line newLine = new Line();
			chosenFigure = newLine;
		}

		private void btnCircle_Click(object sender, EventArgs e)
		{
			Ellipse newCircle = new Ellipse();
			chosenFigure = newCircle;
		}


		private void btnRectangle_Click(object sender, EventArgs e)
		{
			Rectangle newRectangle = new Rectangle();
			chosenFigure = newRectangle;
		}

		private void btnTreangle_Click(object sender, EventArgs e)
		{
			Treangle newTreangle = new Treangle();
			chosenFigure = newTreangle;
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (chosenFigure == null)
			{
				MessageBox.Show("Figure was not chosen!", "Warning");
				return;
			}
			startPoint.X = e.X;
			startPoint.Y = e.Y;
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			endPoint.X = e.X;
			endPoint.Y = e.Y;

			chosenFigure.SetCoord(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
			listOfFigures.Add(chosenFigure);
			RepaintBMP();
		}
	}
}
