using System.Collections.Generic;
using System.Drawing;
using BaseFigure;

namespace Figures
{
	class CustomFigure : Figure, ICustomFigure
	{		
		public List<Figure> Figures { get; private set; }



		public override void SetCoord(Point startPoint, Point endPoint) { }
		public override void SetCoord(int[] fields) { }



		public override void SetList(List<Figure> figures)
		{
			Figures = figures;
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
