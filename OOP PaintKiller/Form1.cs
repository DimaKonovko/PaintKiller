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

		DrawingHelper drawingHelper = new DrawingHelper();
		FiguresHelper figuresHelper = new FiguresHelper();

		Type customFigureType;
		List<Type> figuresTypes = new List<Type>();
		List<string> customFiguresNames = new List<string>();
		List<string> dllNames   = new List<string> { "Figures.dll" };



		public MainForm()
		{
			InitializeComponent();
			drawingHelper.InitializeGraphics(pictureBox.Width, pictureBox.Height);
			LoadPlugins();
			LoadCustomFigures();
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
						if (type.GetInterface("IFigure") != null)
						{
							figuresTypes.Add(type);
							FiguresListBox.Items.Add(type.Name);
						}
						else if (type.GetInterface("ICustomFigure") != null)
						{
							figuresTypes.Add(type);
							FiguresListBox.Items.Add(type.Name);
							customFigureType = type;
						}
					}
				}
			}

		}



		private void LoadCustomFigures()
		{
			string pathToDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\CustomFigures\\");
			string[] fullPath = Directory.GetFiles(pathToDir, "*.txt");
			// FiguresListBox.Items.Add(Path.GetFileName(customFigureName).Replace(".txt", ""));
			foreach (string path in fullPath)
			{
				string figureName = Path.GetFileName(path).Replace(".txt", "");
				CustomFiguresListBox.Items.Add(figureName);

				figuresHelper.Load(path, figuresTypes);
				figuresHelper.CustomFigures.Add(figuresHelper.Figures.ToList());
				figuresHelper.ClearFigures();
			}

		}

			   		 

		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (FiguresListBox.SelectedIndex == -1) { return; }

			Type figType = figuresTypes.ElementAt(FiguresListBox.SelectedIndex);
			if (figType == customFigureType)
			{
				if (CustomFiguresListBox.SelectedIndex == -1) { return; }
				figuresHelper.NewFigure(figType);
				figuresHelper.LastFigure().SetList(figuresHelper.CustomFigures.ElementAt(CustomFiguresListBox.SelectedIndex));
			}
			else
			{
				figuresHelper.NewFigure(figType);
			}

			mouseDown = true;

			drawingHelper.SaveStartPoint(e.X, e.Y);
			drawingHelper.SaveEndPoint(e.X, e.Y);
		}



		private void pictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (!mouseDown) { return; }
		
			drawingHelper.SaveEndPoint(e.X, e.Y);
			figuresHelper.LastFigure().SetCoord(drawingHelper.startPoint, drawingHelper.endPoint);
			pictureBox.Image = drawingHelper.Redraw(figuresHelper.Figures);
		}



		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			if (!mouseDown) { return; }

			mouseDown = false;

			figuresHelper.LastFigure().SetCoord(drawingHelper.startPoint, drawingHelper.endPoint);
			pictureBox.Image = drawingHelper.Redraw(figuresHelper.Figures);
		}



		private void btnClear_Click(object sender, EventArgs e)
		{
			figuresHelper.ClearFigures();
			pictureBox.Image = drawingHelper.Redraw(figuresHelper.Figures);
		}



		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
			string pathToFile = dialog.FileName;

			figuresHelper.Save(figuresHelper.Figures, pathToFile);
		}
		


		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
			string pathToFile = dialog.FileName;

			figuresHelper.Load(pathToFile, figuresTypes);

			pictureBox.Image = drawingHelper.Redraw(figuresHelper.Figures);
		}



		private void SaveCustomFigure_Click(object sender, EventArgs e)
		{
			string pathToFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\CustomFigures\\");
			string fullPath = pathToFile + CustomFigureName.Text + ".txt";
			figuresHelper.Save(figuresHelper.Figures, fullPath);

			MessageBox.Show("Successfully saved!", "Hint");

			FiguresListBox.Items.Add(Path.GetFileName(fullPath).Replace(".txt", ""));
		}

	}
}
