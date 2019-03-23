using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_PaintKiller
{
	public partial class MainForm : Form
	{
		// Delegate
		delegate Figure delegateFigure();

		// Figures creators
		private static Figure LineCreator()
		{
			return new Line();
		}

		private static Figure EllipseCreator()
		{
			return new Ellipse();
		}

		private static Figure RectangleCreator()
		{
			return new Rectangle();
		}

		private static Figure TreangleCreator()
		{
			return new Treangle();
		}

		delegateFigure[] delgFigure = new delegateFigure[]
		{
			LineCreator,
			EllipseCreator,
			RectangleCreator,
			TreangleCreator
		};

		List<Figure> listOfFigures = new List<Figure>();
		Bitmap bmp;
		Graphics grph;
		Pen pen;
		Point startPoint, currPoint, endPoint;
		int currFigureIndex = 0;
		Figure chosenFigure;
		bool mouseDown = false;

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
			pen.Width = 3.0F;
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
			currFigureIndex = 0;
		}

		private void btnCircle_Click(object sender, EventArgs e)
		{
			currFigureIndex = 1;
		}


		private void btnRectangle_Click(object sender, EventArgs e)
		{
			currFigureIndex = 2;
		}

		private void btnTreangle_Click(object sender, EventArgs e)
		{
			currFigureIndex = 3;
		}
	
		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;

			chosenFigure = delgFigure[currFigureIndex]();

			listOfFigures.Add(chosenFigure);

			startPoint.X = e.X;
			startPoint.Y = e.Y;
		}

		private void pictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			currPoint.X = e.X;
			currPoint.Y = e.Y;

			if (mouseDown == true)
			{
				Figure currFigure = listOfFigures[listOfFigures.Count - 1];
				currFigure.SetCoord(startPoint.X, startPoint.Y, currPoint.X, currPoint.Y);
				grph.Clear(Color.White);
				RepaintBMP();
			}
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;

			endPoint.X = e.X;
			endPoint.Y = e.Y;

			chosenFigure.SetCoord(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
			RepaintBMP();
		}
		
		private void btnClear_Click(object sender, EventArgs e)
		{
			listOfFigures.Clear();
			grph.Clear(Color.White);
			RepaintBMP();
		}
	}
}
