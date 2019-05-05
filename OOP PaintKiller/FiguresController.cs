using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using BaseFigure;

namespace OOP_PaintKiller
{
	class FiguresController
	{
		public List<Figure> Figures = new List<Figure>();

		public void NewFigure(Type figType)
		{
			Figure fig = (Figure)Activator.CreateInstance(figType);
			this.Figures.Add(fig);
		}

		public void ClearFigures()
		{
			this.Figures.Clear();
		}

		public Figure LastFigure()
		{
			return this.Figures.Last();
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
			   	
		public void Load(string pathToFile)
		{
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

					Figure figure = createFigure(className, textFieldsValues);
					if (figure != null) { this.Figures.Add(figure); } else { continue; }
				}
			}
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

		private Figure createFigure(string className, string[] fields)
		{
			//className = className + "Creator";
			//for (int i = 0; i < delgFigure.Count(); i++)
			//{
			//	if (delgFigure[i].Method.Name == className)
			//	{
			//		Figure loadedFigure = delgFigure[i]();
			//		loadedFigure.SetCoord(Array.ConvertAll(fields, int.Parse));
			//		return loadedFigure;
			//	}
			//}
			return null;
		}
	}
}
