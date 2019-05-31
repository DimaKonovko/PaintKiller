using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Xml;
using System.Drawing;
using System.Text.RegularExpressions;

namespace OOP_PaintKiller
{
	public partial class MainForm : Form
	{
		bool mouseDown = false;

		DrawingHelper drawingHelper = new DrawingHelper();
		FiguresHelper figuresHelper = new FiguresHelper();

		Type customFigureType;
		List<Type> figuresTypes = new List<Type>();
		List<string> dllNames   = new List<string> { "Figures.dll" };

		XmlDocument xmlDoc;
		string backColor;
		
		string pathToConfig = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\config\\config.xml");

		public MainForm()
		{
			InitializeComponent();
			drawingHelper.InitializeGraphics(pictureBox.Width, pictureBox.Height);
			LoadSettings();
			LoadPlugins();
			LoadCustomFigures();
		}



		private void LoadSettings()
		{
			xmlDoc = new XmlDocument();
			try
			{
				xmlDoc.Load(pathToConfig);
				XmlElement root = xmlDoc.DocumentElement;
				foreach (XmlNode xNode in root)
				{
					if (xNode.Name == "background")
					{
						backColor = xNode.InnerText;
						SetBackgroundColor(backColor);
					}
				}
			}
			catch
			{
				MessageBox.Show("Could not use config!", "Error");
				SetDefaultConfig();
			}
		}



		private void SetBackgroundColor(string color)
		{
			string[] parts = color.Split(' ');
			this.BackColor = Color.FromArgb(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]));
		}



		private void SetDefaultConfig()
		{
			this.BackColor = Color.FromArgb(255, 17, 103, 17);
		}



		private void LoadPlugins()
		{
			string pathToDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\lib\\");
			//string[] dllFiles = Directory.GetFiles(pathToDll, "*.dll");
			foreach (string dllName in dllNames)
			{
				try
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
				catch
				{
					MessageBox.Show("There are no plugins!", "Hint");
				}
			}

		}



		private void LoadCustomFigures()
		{
			string pathToDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\CustomFigures\\");
			string[] fullPath = Directory.GetFiles(pathToDir, "*.txt");
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
				figuresHelper.SetListToCustom(CustomFiguresListBox.SelectedIndex);
			}
			else
			{
				figuresHelper.NewFigure(figType);
			}

			mouseDown = true;

			drawingHelper.SaveStartPoint(e.X, e.Y);
			drawingHelper.SaveEndPoint(e.X + 1, e.Y + 1);
		}



		private void pictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (!mouseDown) { return; }

			drawingHelper.SaveEndPoint(e.X, e.Y);

			Type figType = figuresTypes.ElementAt(FiguresListBox.SelectedIndex);
			if (figType == customFigureType)
			{
				if (CustomFiguresListBox.SelectedIndex == -1) { return; }

				int width = drawingHelper.endPoint.X - drawingHelper.startPoint.X;
				int height = drawingHelper.endPoint.Y - drawingHelper.startPoint.Y;
				figuresHelper.LastFigure().Recalculate((float)((width + 0.1) / pictureBox.Width), (float)((height + 0.1) / pictureBox.Height), drawingHelper.startPoint.X, drawingHelper.startPoint.Y);
			}

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

			CustomFiguresListBox.Items.Add(Path.GetFileName(fullPath).Replace(".txt", ""));

			FiguresHelper tempHelper = new FiguresHelper();
			tempHelper.Load(fullPath, figuresTypes);
			figuresHelper.CustomFigures.Add(figuresHelper.Figures.ToList());
			tempHelper.ClearFigures();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			int r, g, b;
			r = this.BackColor.R;
			g = this.BackColor.G;
			b = this.BackColor.B;
			string colorStr = r.ToString() + ' ' + g.ToString() + ' ' + b.ToString();

			try
			{
				XmlElement root = xmlDoc.DocumentElement;
				foreach (XmlNode xNode in root)
				{
					if (xNode.Name == "background")
					{
						xNode.InnerText = colorStr;
					}
				}
				xmlDoc.Save(pathToConfig);
			}
			catch
			{
				MessageBox.Show("Could not save config!", "Error");
			}
		}

		private void backColorText_Leave(object sender, EventArgs e)
		{
			string color = backColorText.Text;
			Regex regex = new Regex(@"[0-2]{0,1}[0-5]{0,1}[0-5]{0,1} [0-2]{0,1}[0-5]{0,1}[0-5]{0,1} [0-2]{0,1}[0-5]{0,1}[0-5]{0,1}");
			if (regex.IsMatch(color))
			{
				string[] parts = color.Split(' ');
				try
				{
					this.BackColor = Color.FromArgb(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]));
				}
				catch
				{
					MessageBox.Show("Uncorrect RGB!", "Error");
				}
			}
		}
	}
}
