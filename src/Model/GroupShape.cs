using System;
using System.Drawing;
using System.Collections.Generic;
namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	
	[Serializable]
	public class GroupShape : Shape
	{
		#region Constructor

		public GroupShape(RectangleF rect) : base(rect)
		{
		}

		public GroupShape(RectangleShape rectangle) : base(rectangle)
		{
		}

		#endregion

		public List<Shape> groupedShape = new List<Shape>();
		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			if (base.Contains(point))
			{
				foreach (Shape item in groupedShape)
				{
					if (item.Contains(point)) return true;
                    
				}

				return true;
			}
            else
            {
				return false;
            }
		}


		public override void MoveGroupedShape(float dx, float dy)
		{
			base.MoveGroupedShape(dx, dy);
			foreach (var shape in groupedShape)
			{
				shape.MoveGroupedShape(dx * 2, dy * 2);
			}
		}

		public override void ChangeGroupFillColor(Color color)
        {
			base.ChangeGroupFillColor(color);
			foreach (var shape in groupedShape)
			{
				shape.FillColor = color;
			}
		}
		public override void ChangeGroupStrokeColor(Color color)
		{
			base.ChangeGroupStrokeColor(color);
			foreach (var shape in groupedShape)
			{
				shape.StrokeColor = color;
			}
		}
		public override void ChangeGroupStrokeWidth(float borderWidthShape)
		{
			base.ChangeGroupStrokeWidth(borderWidthShape);
			foreach (var shape in groupedShape)
			{
				shape.BorderWidth = borderWidthShape;
			}
		}
		public override void ChangeGroupOpacity(int opacity)
		{
			base.ChangeGroupOpacity(opacity);
			foreach (var shape in groupedShape)
			{
				shape.Opacity = opacity;
			}
		}

		public override void ChangeGroupRotate(float angle)
		{
			base.ChangeGroupRotate(angle);
			foreach (var shape in groupedShape)
			{
				shape.ShapeAngle = angle;
			}
		}


		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			foreach (Shape item in groupedShape)
			{
				item.DrawSelf(grfx);
			}


		}
	}
}

