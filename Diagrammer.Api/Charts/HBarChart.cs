using Diagrammer.Api;
using System;
using System.Drawing;

namespace Diagrammer.Charts {
    [Serializable]
    public class HBarChart : BarChart {
        public HBarChart() : base() { }

        public HBarChart(params DataSeries[] dataSeries) : base(dataSeries) {
            ChartMargins = new Rectangle(10, 10, 10, 10);
        }

        public HBarChart(String title, params DataSeries[] dataSeries) : this(dataSeries) {
            Title = title;
        }

        public override void Draw(Graphics g, float x, float y, float width, float height) {
            int n = Data.Count;

            // draw bounding rectangle
            g.DrawRectangle(Pens.Black, x, y, width - x, height - y);

            x += ChartMargins.X;
            y += ChartMargins.Y;

            // recalculate width and height so that they are relative
            width = width - (ChartMargins.Width + x);
            height = height - (ChartMargins.Height + y);

            float totalIndents = (ChartMargins.Y + ChartMargins.Height) * n;
            float barHeight = (height - totalIndents) / n;

            // g.DrawRectangle(Pens.Red, x, y, width, height);

            double maxValue = double.MinValue;
            foreach (var ds in Data) {
                maxValue = Math.Max(maxValue, ds.Value.Data[0]);
            }

            float startY = y + ChartMargins.Y + ChartMargins.Height;
            float step = barHeight + ChartMargins.Y + ChartMargins.Height;

            foreach (var ds in Data) {
                DataSeries data = ds.Value;

                var c = data.Color.ToArgb() & 0x5FFFFFFF;
                using (Brush b = new SolidBrush(Color.FromArgb(c))) {
                    double barWidth = data.Data[0] / maxValue * width;
                    g.FillRectangle(b, x, startY, (float)barWidth, barHeight);
                }

                startY += step;
            }

            // draw arrows
            g.DrawLine(Pens.Black, x, y, x, y + height);
            g.DrawLine(Pens.Black, x, y + height, x + width, y + height);
            g.FillClosedCurve(Brushes.Black, new PointF[] { new PointF(x - 5, y + 20),
            new PointF(x, y), new PointF(x + 5, y + 20)});
            g.FillClosedCurve(Brushes.Black, new PointF[] { new PointF(width + x - 20, height + y + 5),
            new PointF(width + x, height + y), new PointF(width + x - 20, height + y - 5)});

            // DrawCaptions(g, x, y, width, height, SystemFonts.CaptionFont);
            // DrawLegend(g, width - 100, y + 30, SystemFonts.CaptionFont);
        }

        public override void Draw(Graphics g, Rectangle rect) {
            this.Draw(g, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public override void DrawCaptions(Graphics g, float x, float y, float width, float height, Font font) {
            int n = Data.Count;

            float totalIndents = (ChartMargins.Y + ChartMargins.Height) * n;
            float barHeight = (height - totalIndents) / n;

            double maxValue = double.MinValue;
            foreach (var ds in Data) {
                maxValue = Math.Max(maxValue, ds.Value.Data[0]);
            }

            float startY = y + ChartMargins.Y + ChartMargins.Height;
            float step = barHeight + ChartMargins.Y + ChartMargins.Height;

            foreach (var ds in Data) {
                DataSeries data = ds.Value;
                using (Brush b = new SolidBrush(data.Color)) {
                    double barWidth = data.Data[0] / maxValue * width;

                    float strWidth = g.MeasureString(data.Label, font).Width;
                    float valStrWidth = g.MeasureString(data.Data[0].ToString(), font).Width / 2;
                    // draw caption
                    g.DrawString(data.Label, font, Brushes.Black, x + ChartMargins.X, startY + (barHeight - font.Height) / 2);
                    // draw value
                    g.DrawString(data.Data[0].ToString(), font, Brushes.Black, (float)(barWidth - x),
                        startY + (barHeight - font.Height) / 2);
                }

                startY += step;
            }
        }

        public override void DrawCaptions(Graphics g, Rectangle rect, Font font) {
            this.DrawCaptions(g, rect.X, rect.Y, rect.Width, rect.Height, font);
        }
    }
}
