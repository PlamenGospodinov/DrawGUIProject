using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    class TriangleShape:Shape
    {
        #region Constructor

        public TriangleShape(RectangleF triang) : base(triang)
        {
        }

        public TriangleShape(TriangleShape triangle) : base(triangle)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {

            base.DrawSelf(grfx);

            base.RotateShape(grfx);

            //first point is in the middle - X + Width / 2
            Point[] pointOfShape = { new Point((int)Rectangle.X + ((int)Rectangle.Width / 2), (int)Rectangle.Y), new Point((int)Rectangle.X, (int)(Rectangle.Y + Rectangle.Height)), new Point((int)(Rectangle.X + Rectangle.Width), (int)(Rectangle.Y + Rectangle.Height)) };
            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Opacity, FillColor)), pointOfShape);
            grfx.DrawPolygon(new Pen(StrokeColor, BorderWidth), pointOfShape);
            PointF P1 = new PointF(pointOfShape[0].X,pointOfShape[0].Y);
            PointF P2 = new PointF(pointOfShape[0].X, pointOfShape[0].Y+Rectangle.Height/2);
            PointF P3 = new PointF(pointOfShape[1].X, pointOfShape[1].Y);
            PointF P4 = new PointF(pointOfShape[1].X+Rectangle.Width/2, pointOfShape[1].Y-Rectangle.Height/2);
            PointF P5 = new PointF(pointOfShape[2].X, pointOfShape[2].Y);
            PointF P6 = new PointF(pointOfShape[2].X-Rectangle.Width/2, pointOfShape[2].Y-Rectangle.Height/2);
            Pen blackPen = new Pen(Color.White, BorderWidth);
            grfx.DrawLine(blackPen, P1, P2);
            grfx.DrawLine(blackPen, P3, P4);
            grfx.DrawLine(blackPen, P5, P6);

            grfx.ResetTransform();

        }
    }
}
