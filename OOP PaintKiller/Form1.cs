using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Linq;

namespace OOP_PaintKiller
{
	public partial class MainForm : Form
	{
		bool mouseDown = false;

		DrawingController drawingController = new DrawingController();
		FiguresController figuresController = new FiguresController();

		List<Type> figuresTypes = new List<Type>();
		List<string> dllNames   = new List<string> { "Figures.dll" };



		public MainForm()
		{
			InitializeComponent();
			drawingController.InitializeGraphics(pictureBox.Width, pictureBox.Height);
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

			   		 

		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (FiguresListBox.SelectedIndex == -1) { return; }

			Type figType = figuresTypes.ElementAt(FiguresListBox.SelectedIndex);
			figuresController.NewFigure(figType);

			mouseDown = true;

			drawingController.SaveStartPoint(e.X, e.Y);
			drawingController.SaveEndPoint(e.X, e.Y);
		}



		private void pictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (!mouseDown) { return; }
		
			drawingController.SaveEndPoint(e.X, e.Y);
			figuresController.LastFigure().SetCoord(drawingController.startPoint, drawingController.endPoint);
			pictureBox.Image = drawingController.Redraw(figuresController.Figures);
		}



		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			if (!mouseDown) { return; }

			mouseDown = false;

			figuresController.LastFigure().SetCoord(drawingController.startPoint, drawingController.endPoint);
			pictureBox.Image = drawingController.Redraw(figuresController.Figures);
		}



		private void btnClear_Click(object sender, EventArgs e)
		{
			figuresController.ClearFigures();
			pictureBox.Image = drawingController.Redraw(figuresController.Figures);
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

			figuresController.Load(pathToFile, figuresTypes);

			pictureBox.Image = drawingController.Redraw(figuresController.Figures);
		}
	}
}
