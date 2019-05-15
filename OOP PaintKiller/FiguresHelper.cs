using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using BaseFigure;

namespace OOP_PaintKiller
{
	class FiguresHelper
	{
		public List<Figure> Figures = new List<Figure>();
		public List<List<Figure>> CustomFigures = new List<List<Figure>>();
				
		public void NewFigure(Type figType)
		{
			Figure fig = (Figure)Activator.CreateInstance(figType);
			Figures.Add(fig);
		}



		public void ClearFigures()
		{
			Figures.Clear();
		}



		public Figure LastFigure()
		{
			return Figures.Last();
		}



		public void Save(List<Figure> listOfFigures, string pathToFile)
		{
			using (StreamWriter file = File.CreateText(pathToFile))
			{
				foreach (Figure fig in listOfFigures)
				{
					file.Write(ToText(fig));
				}
			}
		}
		


		public void Load(string pathToFile, List<Type> figuresTypes)
		{
			ClearFigures();

			string textFigure, className;
			string[] textFieldsValues;

			using (StreamReader file = File.OpenText(pathToFile))
			{
				while ((textFigure = file.ReadLine()) != null)
				{
					if (string.IsNullOrEmpty(textFigure)) { continue; }

					className = textFigure.Split('|').First().Trim();
					textFieldsValues = parseFields(textFigure.Split('|').Last().Trim());
					if (textFieldsValues == null) { continue; }

					foreach (Type figType in figuresTypes)
					{
						if (figType.Name == className)
						{
							Figure loadedFigure = (Figure)Activator.CreateInstance(figType);
							loadedFigure.SetCoord(Array.ConvertAll(textFieldsValues, int.Parse));
							this.Figures.Add(loadedFigure);
							break;
						}
					}									
				}
			}
			return;
		}



		private string ToText(Figure fig)
		{
			string textName = fig.GetType().Name;
			string textFields = string.Empty;

			PropertyInfo[] fields = fig.GetType().GetProperties();
			foreach (PropertyInfo field in fields)
			{
				textFields += field.Name + ":" + field.GetValue(fig) + " ";
			}

			return textName + " | " + textFields + "\n";
		}



		private string[] parseFields(string line)
		{
			List<string> textFieldsValues = new List<string>();
			string[] textFields = line.Split(' ');

			foreach (string field in textFields)
			{
				textFieldsValues.Add(field.Split(':').Last());
			}

			return textFieldsValues.ToArray();
		}		
	}
}
