using Diagrammer.Api;
using System;
using System.Drawing;

namespace Diagrammer.Charts {
    [Serializable]
    public class PieChart : Chart {

        public PieChart() { }

        public PieChart(params DataSeries[] dataSeries) : base(dataSeries) { }

        public PieChart(String title, params DataSeries[] dataSeries) : base(title, dataSeries) { }

        public override void Draw(Graphics g, float x, float y, float width, float height) {
            // draw bounding rectangle
            g.DrawRectangle(Pens.Black, x, y, width - x, height - y);

            x += ChartMargins.X;
            y += ChartMargins.Y;

            // recalculate width and height so that they are relative
            width = width - (ChartMargins.Width + x);
            height = height - (ChartMargins.Height + y);

            // make plot area square
            float delta = Math.Abs(width - height);
            if (width > height) {
                x += delta / 2;
                width -= delta;
            } else {
                y += delta / 2;
                height -= delta;
            }

            double totalSum = 0;
            foreach (var ds in Data) {
                totalSum += ds.Value.Data[0];
            }

            float startAngle = 0;
            foreach (var ds in Data) {
                DataSeries data = ds.Value;

                var c = data.Color.ToArgb() & 0x5FFFFFFF;
                using (Brush b = new SolidBrush(Color.FromArgb(c))) {
                    float sweepAngle = (float)(data.Data[0] / totalSum) * 360;
                    g.FillPie(b, x, y, width, height, startAngle, sweepAngle);
                    startAngle += sweepAngle;
                }
            }
        }

        public override void Draw(Graphics g, Rectangle rect) {
            this.Draw(g, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public override void DrawCaptions(Graphics g, float x, float y, float width, float height, Font font) {
            float trX = (x + width) / 2, trY = (y + height) / 2;

            x += ChartMargins.X;
            y += ChartMargins.Y;

            // recalculate width and height so that they are relative
            width = width - (ChartMargins.Width + x);
            height = height - (ChartMargins.Height + y);

            float delta = Math.Abs(width - height);
            if (width > height) {
                x += delta / 2;
                width -= delta;
            } else {
                y += delta / 2;
                height -= delta;
            }

            float radius = width / 2;

            x += radius;
            y += radius;

            double totalSum = 0;
            foreach (var ds in Data) {
                totalSum += ds.Value.Data[0];
            }

            // draw debug pivot
            // g.DrawRectangle(Pens.Black, x - 5, y - 5, 10, 10);

            float startAngle = 0;
            foreach (var ds in Data) {
                DataSeries data = ds.Value;
                float sweepAngle = (float)(data.Data[0] / totalSum) * 2 * (float)Math.PI;

                var measures = g.MeasureString(data.Data[0].ToString(), font);
                float tempX = x - measures.Width / 2, tempY = y - measures.Height / 2;

                float xRot = (float)Math.Cos(startAngle + sweepAngle / 2) * (width - measures.Width)/ 2;
                float yRot = (float)Math.Sin(startAngle + sweepAngle / 2) * (height - measures.Height)/ 2;

                g.DrawString(data.Data[0].ToString(), font, Brushes.Black, tempX + xRot, tempY + yRot);

                startAngle += sweepAngle;
            }
        }

        public override void DrawCaptions(Graphics g, Rectangle rect, Font font) {
            this.DrawCaptions(g, rect.X, rect.Y, rect.Width, rect.Height, font);
        }
    }
}
