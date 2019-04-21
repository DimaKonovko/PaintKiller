using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace OOP_PaintKiller
{
	public partial class MainForm : Form
	{
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

		private static Figure TriangleCreator()
		{
			return new Triangle();
		}

		delegate Figure delegateFigure();

		delegateFigure[] delgFigure = new delegateFigure[]
		{
			LineCreator,
			EllipseCreator,
			RectangleCreator,
			TriangleCreator
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
			if (mouseDown) { mouseDown = false; } else { return; }

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

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
			string filePath = dialog.FileName;

			StreamWriter file = new StreamWriter(filePath);

			foreach (Figure fig in listOfFigures)
			{
				string textFigure = createTextFigure(fig);
				file.Write(textFigure);
			}

			file.Close();
		}

		private string createTextFigure(Figure fig)
		{
			string textFigure = fig.GetType().Name;

			textFigure += " | ";
			PropertyInfo[] fields = fig.GetType().GetProperties();
			foreach (PropertyInfo field in fields)
			{
				textFigure += field.Name + ":" + field.GetValue(fig) + " ";
			}
			textFigure += "\n";

			return textFigure;
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
			string filePath = dialog.FileName;

			listOfFigures.Clear();
			grph.Clear(Color.White);

			string line, className;
			int[] fields;

			StreamReader file = new StreamReader(filePath);
			while ((line = file.ReadLine()) != null)
			{
				if (String.IsNullOrEmpty(line)) { continue; }

				className = line.Split('|').First().Trim();
				fields = parseFields(line.Split('|').Last().Trim());
				if (fields == null) { continue; }

				Figure figure = createFigure(className, fields);
				if (figure != null) { listOfFigures.Add(figure); } else { continue; }
			}
			file.Close();
			RepaintBMP();
		}

		private int[] parseFields(string line)
		{
			List<int> intFields = new List<int>();
			string[] textFields = line.Split(' ');

			for (int i = 0; i < textFields.Count(); i++)
			{
				textFields[i] = textFields[i].Split(':').Last();
				if (Int32.TryParse(textFields[i], out int result)) { intFields.Add(result); } else { return null; }
			}

			return intFields.ToArray();
		}

		private Figure createFigure(string className, int[] fields)
		{
			className = className + "Creator";
			for (int i = 0; i < delgFigure.Count(); i++)
			{
				if (delgFigure[i].Method.Name == className)
				{
					Figure loadedFigure = delgFigure[i]();
					loadedFigure.SetCoord(fields);
					return loadedFigure;
				}
			}
			return null;
		}
	}
}
