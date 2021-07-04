using Draw;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using Draw.src.Model;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor

		public DialogProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Избран елемент.
		/// </summary>
		private List<Shape> selection = new List<Shape>();
		public List<Shape> Selection {
			get { return selection; }
			set { selection = value; }
		}

		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}

		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}

		#endregion

		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		/// 
		public Color currentStrokeColor = Color.Red;
		public Color currentFillColor = Color.Black;
		public double currentOpac = 1;
		public float currentWidth = 1;
		public Color currentSelectedColor = Color.Red;

		public void ChangeGroupFillColor(Color color)
        {
			foreach(GroupShape shape in Selection)
            {
				shape.ChangeGroupFillColor(color);
            }	
        }

		public void ChangeGroupStrokeColor(Color color)
		{
			foreach (GroupShape shape in Selection)
			{
				shape.ChangeGroupStrokeColor(color);
			}
		}

		public void ChangeGroupStrokeWidth(float num)
		{
			foreach (GroupShape shape in Selection)
			{
				shape.ChangeGroupStrokeWidth(num);
			}
		}

		public void ChangeGroupOpacity(int opac)
		{
			foreach (GroupShape shape in Selection)
			{
				shape.ChangeGroupOpacity(opac);
			}
		}

		public void AddRandomRectangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
			rect.Opacity = (int)currentOpac * 255;
			rect.FillColor = currentFillColor;
			rect.StrokeColor = currentStrokeColor;
			rect.BorderWidth = currentWidth;
			ShapeList.Add(rect);
		}

		public void AddRandomEllipse()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 100, 200));
			ellipse.Opacity = (int)currentOpac * 255;
			ellipse.FillColor = currentFillColor;
			ellipse.StrokeColor = currentStrokeColor;
			ellipse.BorderWidth = currentWidth;
			ShapeList.Add(ellipse);
		}

		public void AddRandomPoint()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);
			PointShape point = new PointShape(new Rectangle(x, y, 3, 3));
			point.FillColor = currentFillColor;
			point.Opacity = (int)currentOpac * 255;
			point.BorderWidth = currentWidth;
			ShapeList.Add(point);
		}

		public void AddRandomLine()
		{
			Random rnd = new Random();
			int x1 = rnd.Next(100, 1000);
			int y1 = rnd.Next(100, 600);
			//int x2 = rnd.Next(100, 1000);
			//int y2 = rnd.Next(100, 600);
			//LineShape line = new LineShape(new Rectangle(x1, y1, x2, y2));
			//PointF p1 = new PointF(x1, y1);
			//PointF p2 = new PointF(x2, y2);
			LineShape line = new LineShape(new Rectangle(x1, y1, 300, 300));
			line.Opacity = (int)currentOpac * 255;
			line.BorderWidth = currentWidth;
			line.FillColor = currentFillColor;
			ShapeList.Add(line);
		}

		public void AddRandomPolygon()
		{
			Random rnd = new Random();
			int firstX = rnd.Next(50, 550);
			int firstY = rnd.Next(150, 500);
			//int firstX = 80;
			//int firstY = 240;
			//Point[] polygonPoints = new Point[6];
			PointF one = new PointF(firstX, firstY);
			PointF two = new PointF(firstX-30, firstY-85);
			PointF three = new PointF(firstX+50, firstY-140);
			PointF four = new PointF(firstX + 125, firstY - 85);
			PointF five = new PointF(firstX + 100, firstY);
			PointF six = new PointF(firstX, firstY);
			/*polygonPoints[0] = new Point(250, 750);
			polygonPoints[1] = new Point(100, 325);
			polygonPoints[2] = new Point(500, 50);
			polygonPoints[3] = new Point(875, 325);
			polygonPoints[4] = new Point(750, 750);
			polygonPoints[5] = new Point(250, 750);*/
			/*polygonPoints[0] = new Point(firstX, firstY);
			polygonPoints[1] = new Point((int)(firstX / 2.5), (int)(firstY / 2.3));
			polygonPoints[2] = new Point(firstX * 2, firstY / 15);
			polygonPoints[3] = new Point((int)(firstX * 3.5), (int)(firstY / 2.3));
			polygonPoints[4] = new Point(firstY, firstY);
			polygonPoints[5] = new Point(firstX, firstY);*/
			PolygonShape polygon = new PolygonShape(one, two, three, four, five, six);
			polygon.Opacity = (int)currentOpac * 255;
			polygon.FillColor = currentFillColor;
			polygon.StrokeColor = currentStrokeColor;
			polygon.BorderWidth = currentWidth;
			 
			ShapeList.Add(polygon);
		}


		public void AddRandomCircle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			CircleShape circle = new CircleShape(new Rectangle(x, y, 200, 200));
			circle.Opacity = (int)currentOpac * 255;
			circle.FillColor = currentFillColor;
			circle.StrokeColor = currentStrokeColor;
			circle.BorderWidth = currentWidth;
			ShapeList.Add(circle);
		}

		public void AddRandomTriangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			TriangleShape triangle = new TriangleShape(new Rectangle(x, y, 200, 400));
			triangle.Opacity = (int)currentOpac * 255;
			triangle.FillColor = currentFillColor;
			triangle.StrokeColor = currentStrokeColor;
			triangle.BorderWidth = currentWidth;
			ShapeList.Add(triangle);
		}


		//Serialization method
		public void SerializeFile(object currentObject, string path = null)
		{

			Stream stream;
			IFormatter binaryFormatter = new BinaryFormatter();
			if (path == null)
			{
				stream = new FileStream("DrawFile.asd", FileMode.Create, FileAccess.Write, FileShare.None);
			}
			else
			{
				string preparePath = path + ".asd";
				stream = new FileStream(preparePath, FileMode.Create);

			}
			binaryFormatter.Serialize(stream, currentObject);
			stream.Close();
		}


		//Deserialization method
		public object DeSerializeFile(string path = null)
		{
			object currentObject;

			Stream stream;
			IFormatter binaryFormatter = new BinaryFormatter();
			if (path == null)
			{
				stream = new FileStream("DrawFile.asd", FileMode.Open);

			}
			else
			{
				stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
			}
			currentObject = binaryFormatter.Deserialize(stream);
			stream.Close();
			return currentObject;
		}


		//Delete Btn method
		public void DeleteSelectedShapes()
		{
			foreach (Shape shape in Selection)
			{
				ShapeList.Remove(shape);

			}
			Selection.Clear();
		}

		public void CopySelectedShapes()
		{
			CopiedShapeList.Clear();
			foreach (Shape shape in Selection)
			{
				CopiedShapeList.Add(shape);

			}
			//Selection.Clear();
		}

		public void PasteSelectedShapes()
		{

			foreach (Shape shape in CopiedShapeList.ToList())
			{
				var type = shape.GetType().Name.ToString();
				if (type.Equals("CircleShape"))
				{
					AddRandomCircle();
				}
				else if (type.Equals("EllipseShape"))
				{
					AddRandomEllipse();
				}
				else if (type.Equals("LineShape"))
				{
					AddRandomLine();
				}
				else if (type.Equals("PointShape"))
				{
					AddRandomPoint();
				}
				else if (type.Equals("RectangleShape"))
				{
					AddRandomRectangle();
				}


			}

		}
		
		public void RotateShape(float rotateAngle)
		{
			if (Selection.Count != 0)
            {
				foreach (var shape in Selection)
				{
					var type = shape.GetType().Name.ToString();
					if (type.Equals("GroupShape"))
					{
						shape.ChangeGroupRotate(rotateAngle);
					}
                    else
                    {
						shape.ShapeAngle = rotateAngle;
					}
					
				}
			}
		}

		public void SelectAllShapes()
		{
			foreach(Shape shape in ShapeList)
            {
				Selection.Add(shape);
            }
		}

		public void GroupSelectedShapes()
        {
			//checking if at least 2 shapes are selected
			if (Selection.Count < 2) return;

			float minimalX = 10000;
			float minimalY = 10000;
			float maximalX = -10000;
			float maximalY = -10000;
			foreach (var shape in Selection)
			{
				if (maximalX < shape.Location.X + shape.Width)
				{
					maximalX = shape.Location.X + shape.Width;
				}
				if (maximalY < shape.Location.Y + shape.Height)
				{
					maximalY = shape.Location.Y + shape.Height;
				}

				if (minimalX > shape.Location.X)
				{
					minimalX = shape.Location.X;
				}
				if (minimalY > shape.Location.Y)
				{
					minimalY = shape.Location.Y;
				}
			}
				
			var groupShape = new GroupShape(new RectangleF(minimalX, minimalY, maximalX - minimalX, maximalY - minimalY));
			groupShape.groupedShape = Selection;
			//Removing shapes from the ShapeList as they become one
			foreach (var shape in Selection)
			{
				ShapeList.Remove(shape);
			}

			Selection = new List<Shape>();
			ShapeList.Add(groupShape);
			Selection.Add(groupShape);
			
		}

		public void UnGroupSelectedShapes()
        {
			List<Shape> allShapesInGroup = new List<Shape>();
			foreach(GroupShape groupShape in Selection.ToList())
            {
				foreach(var shape in groupShape.groupedShape)
                {
					allShapesInGroup.Add(shape);
                }
				groupShape.groupedShape.Clear();
				ShapeList.Remove(groupShape);
				Selection.Remove(groupShape);
				foreach(var shape in allShapesInGroup)
                {
					Selection.Remove(shape);
					ShapeList.Add(shape);
                }
            }
        }
			/// <summary>
			/// Проверява дали дадена точка е в елемента.
			/// Обхожда в ред обратен на визуализацията с цел намиране на
			/// "най-горния" елемент т.е. този който виждаме под мишката.
			/// </summary>
			/// <param name="point">Указана точка</param>
			/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
			public Shape ContainsPoint(PointF point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){
					ShapeList[i].FillColor = currentSelectedColor;
					
					return ShapeList[i];
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			foreach(Shape shape in Selection)
            {
				var type = shape.GetType().Name.ToString();
				if (type.Equals("GroupShape"))
                {
					shape.MoveGroupedShape(p.X - lastLocation.X, p.Y - lastLocation.Y);
				}
                else
                {
					shape.Location = new PointF(shape.Location.X + p.X - lastLocation.X, shape.Location.Y + p.Y - lastLocation.Y);
				}
				
				
			}
			
			lastLocation = p;
		}
	}
}
