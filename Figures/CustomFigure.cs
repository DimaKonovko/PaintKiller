using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using BaseFigure;

namespace Figures
{
	class CustomFigure : Figure, ICustomFigure
	{		
		public List<Figure> Figures { get; set; }
		private List<Figure> CopiesFigures { get; set; }



		public override void SetList(List<Figure> figures)
		{
			Figures = MyCopy(figures);
			CopiesFigures = MyCopy(figures);
		}



		public override void Recalculate(float percentX, float percentY, int pX, int pY)
		{
			Figures = MyCopy(CopiesFigures);
			foreach(Figure fig in this.Figures)
			{
				fig.Recalculate(percentX, percentY, pX, pY);
			}
		}



		public override string ToText()
		{
			string result = string.Empty;
			foreach(Figure fig in Figures)
			{
				
				result = result + fig.ToText();
			}
			return result;
		}



		public override void Draw(Graphics grph, Pen pen)
		{
			foreach (Figure fig in Figures)
			{
				fig.Draw(grph, pen);
			}
		}

	}
}
