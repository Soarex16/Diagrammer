using Diagrammer.Api;
using System;
using System.Drawing;
using System.Linq;

namespace Diagrammer.Charts {
    [Serializable]
    public class PetalChart : Chart {
        // how much data takes place on the line
        float DataAreaSize { get; set; } = 0.9f;

        public PetalChart() : base() { }

        public PetalChart(params DataSeries[] dataSeries) : base(dataSeries) {
            ChartMargins = new Rectangle(10, 10, 10, 10);
        }

        public PetalChart(String title, params DataSeries[] dataSeries) : this(dataSeries) {
            Title = title;
        }

        public override void Draw(Graphics g, float x, float y, float width, float height) {
            int linesCount = int.MaxValue;
            double maxVal = float.MinValue;

            // offset from 0 angle
            double angleOffset = Math.PI / 2;

            if (Data.Count == 0) {
                linesCount = 0;
            }

            foreach (var ds in Data) {
                linesCount = Math.Min(linesCount, ds.Value.Data.Length);

                if (ds.Value.Data.Length > 0)
                    maxVal = Math.Max(maxVal, ds.Value.Data.Max());
            }

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

            float radius = width / 2;
            float centerX = x + width / 2, centerY = y + height / 2;
            double angle = 2 * Math.PI / linesCount;

            // draw lines
            for (int i = 0; i < linesCount; ++i) {
                float x1 = radius * (float)Math.Cos(angleOffset + angle * i);
                float y1 = radius * (float)Math.Sin(angleOffset + angle * i);
                g.DrawLine(Pens.Black, centerX, centerY, centerX + x1, centerY + y1);
            }

            // limiting how much plot takes place on the line
            radius *= DataAreaSize;

            // draw data
            foreach (var ds in Data) {
                var series = ds.Value;

                PointF[] dsPoints = new PointF[linesCount + 1];
                for (int i = 0; i < linesCount; ++i) {
                    using (Brush p = new SolidBrush(series.Color)) {
                        float x1 = centerX + (float)(series.Data[i] / maxVal * radius * Math.Cos(angleOffset + angle * i));
                        float y1 = centerY + (float)(series.Data[i] / maxVal * radius * Math.Sin(angleOffset + angle * i));

                        dsPoints[i] = new PointF(x1, y1);
                        g.FillEllipse(p, x1 - 5, y1 - 5, 10, 10);
                    }
                }
                dsPoints[linesCount] = dsPoints[0];

                var c = series.Color.ToArgb() & 0x5FFFFFFF;
                using (Brush b = new SolidBrush(Color.FromArgb(c))) {
                    g.FillPolygon(b, dsPoints);
                }
            }
        }

        public override void Draw(Graphics g, Rectangle rect) {
            this.Draw(g, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public override void DrawCaptions(Graphics g, float x, float y, float width, float height, Font font) {
            // doesn't anything, because I don't know where to draw captions :/
        }

        public override void DrawCaptions(Graphics g, Rectangle rect, Font font) {
            // doesn't anything
        }
    }
}
