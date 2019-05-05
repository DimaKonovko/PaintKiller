using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using BaseFigure;
using System.Reflection;
using System.Linq;

namespace OOP_PaintKiller
{
	public partial class MainForm : Form
	{
		Bitmap bmp;
		Graphics grph;
		Pen pen;
		Point startPoint, currPoint, endPoint;
		bool mouseDown = false;
		FiguresController figuresController = new FiguresController();
		List<string> dllNames = new List<string> { "Figures.dll" };
		List<Type> figuresTypes = new List<Type>();


		public MainForm()
		{
			InitializeComponent();
			InitializeGrph();
			LoadPlugins();
		}



		private void LoadPlugins()
		{
			string pathToDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\lib\\");
			//string[] dllFiles = Directory.GetFiles(pathToDll, "*.dll");
			foreach (string dllName in dllNames)
			{
				Assembly asm = Assembly.LoadFrom(pathToDll + dllName);
				foreach (Type type in asm.GetTypes())
				{
					if (type.Namespace == "Figures")
					{
						figuresTypes.Add(type);
						FiguresListBox.Items.Add(type.Name);
					}
				}
			}
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
			foreach (Figure fig in figuresController.Figures)
			{
				fig.Draw(grph, pen);
			}
			pictureBox.Image = bmp;
		}



		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;

			if (FiguresListBox.SelectedIndex > -1)
			{
				Type figType = figuresTypes.ElementAt(FiguresListBox.SelectedIndex);
				figuresController.NewFigure(figType);
			}

			startPoint.X = e.X;
			startPoint.Y = e.Y;
		}



		private void pictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			currPoint.X = e.X;
			currPoint.Y = e.Y;

			if (mouseDown == true)
			{
				figuresController.LastFigure().SetCoord(startPoint.X, startPoint.Y, currPoint.X, currPoint.Y);
				grph.Clear(Color.White);
				RepaintBMP();
			}
		}



		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			if (mouseDown) { mouseDown = false; } else { return; }

			endPoint.X = e.X;
			endPoint.Y = e.Y;

			figuresController.LastFigure().SetCoord(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
			RepaintBMP();
		}



		private void btnClear_Click(object sender, EventArgs e)
		{
			figuresController.ClearFigures();
			grph.Clear(Color.White);
			RepaintBMP();
		}



		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
			string pathToFile = dialog.FileName;

			figuresController.Save(figuresController.Figures, pathToFile);
		}
		


		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
			string pathToFile = dialog.FileName;

			grph.Clear(Color.White);

			figuresController.Load(pathToFile, figuresTypes);

			RepaintBMP();
		}
	}
}
