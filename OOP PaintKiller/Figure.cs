using System.Drawing;
using System.Reflection;

namespace Figures
{
	abstract class Figure
	{
		//public bool Public { get; set; }
		abstract public void SetCoord(int startX, int startY, int endX, int endY);
		abstract public void SetCoord(int[] fields);
		abstract public void Draw(Graphics grph, Pen pen);

		public string ToText()
		{
			string textName = this.GetType().Name;
			string textFields = string.Empty;

			PropertyInfo[] fields = this.GetType().GetProperties();
			foreach (PropertyInfo field in fields)
			{
				textFields += field.Name + ":" + field.GetValue(this) + " ";
			}
			
			return textName + " | " + textFields + "\n";
		}
	}
}
 