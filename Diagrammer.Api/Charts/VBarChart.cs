using Diagrammer.Api;
using System;
using System.Drawing;
using System.Linq;

namespace Diagrammer.Charts {
    [Serializable]
    public class VBarChart : BarChart {
        public VBarChart() : base() { }

        public VBarChart(params DataSeries[] dataSeries) : base(dataSeries) {
            ChartMargins = new Rectangle(10, 10, 10, 30);
        }

        public VBarChart(String title, params DataSeries[] dataSeries) : this(dataSeries) {
            Title = title;
        }

        // TODO: make calculations simplier! You can do it!
        public override void Draw(Graphics g, float x, float y, float width, float height) {
            if (this.Data.Any(ds => ds.Value.Data.Count() == 0))
                throw new ArgumentException("Data set is empty!");

            int n = Data.Count;

            // draw bounding rectangle
            g.DrawRectangle(Pens.Black, x, y, width - x, height - y);

            x += ChartMargins.X;
            y += ChartMargins.Y;

            // recalculate width and height so that they are relative
            width = width - (ChartMargins.Width + x);
            height = height - (ChartMargins.Height + y);

            float totalIndents = (ChartMargins.X + ChartMargins.Width) * n;
            float barWidth = (width - totalIndents) / n;

            // g.DrawRectangle(Pens.Red, x, y, width, height);

            double maxValue = double.MinValue;
            foreach (var ds in Data) {
                // Если данные обработаны неверно и массив пуст, то не рисуем
                // по хорошему счету надо просать исключение
                // if (ds.Value.Data.Length == 0)
                //    return;

                maxValue = Math.Max(maxValue, ds.Value.Data[0]);
            }

            float startX = x;
            float step = barWidth + ChartMargins.X + ChartMargins.Width;

            foreach (var ds in Data) {
                DataSeries data = ds.Value;

                var c = data.Color.ToArgb() & 0x5FFFFFFF;
                using (Brush b = new SolidBrush(Color.FromArgb(c))) {
                    double barHeight = data.Data[0] / maxValue * height;
                    g.FillRectangle(b, startX, (float)(height - barHeight + y + ChartMargins.Height), 
                        barWidth, (float)barHeight - ChartMargins.Height);
                }

                startX += step;
            }

            // draw arrows
            g.DrawLine(Pens.Black, x, y, x, y + height);
            g.DrawLine(Pens.Black, x, y + height, x + width, y + height);
            g.FillClosedCurve(Brushes.Black, new PointF[] { new PointF(x - 5, y + 20),
            new PointF(x, y), new PointF(x + 5, y + 20)});
            g.FillClosedCurve(Brushes.Black, new PointF[] { new PointF(width + x - 20, height + y + 5),
            new PointF(width + x, height + y), new PointF(width + x - 20, height + y - 5)});

            // DrawCaptions(g, x, y, width, height, SystemFonts.CaptionFont);
            // DrawLegend(g, x + 10, y + 10, SystemFonts.CaptionFont);
        }

        public override void Draw(Graphics g, Rectangle rect) {
            this.Draw(g, rect.X, rect.Y, rect.Width, rect.Height);
        }

        // TODO: make calculations simplier! You can do it!
        // TODO: иногда криво отрисовываются подписи
        public override void DrawCaptions(Graphics g, float x, float y, float width, float height, Font font) {
            int n = Data.Count;

            float totalIndents = (ChartMargins.X + ChartMargins.Width) * n;
            float barWidth = (width - totalIndents) / n;

            double maxValue = double.MinValue;
            foreach (var ds in Data) {
                maxValue = Math.Max(maxValue, ds.Value.Data[0]);
            }

            float startX = x;
            float step = barWidth + ChartMargins.X + ChartMargins.Width;

            foreach (var ds in Data) {
                DataSeries data = ds.Value;
                using (Brush b = new SolidBrush(data.Color)) {
                    double barHeight = data.Data[0] / maxValue * height;

                    float strWidth = g.MeasureString(data.Label, font).Width / 2;
                    float valStrWidth = g.MeasureString(data.Data[0].ToString(), font).Width / 2;
                    // draw caption
                    g.DrawString(data.Label, font, Brushes.Black, startX + barWidth / 2 - strWidth, 
                        height + ChartMargins.Height - ChartMargins.Y);
                    // draw value
                    g.DrawString(data.Data[0].ToString(), font, Brushes.Black, startX + barWidth / 2 - valStrWidth,
                        (float)(height - barHeight + y + ChartMargins.Height));
                }

                startX += step;
            }
        }

        public override void DrawCaptions(Graphics g, Rectangle rect, Font font) {
            this.DrawCaptions(g, rect.X, rect.Y, rect.Width, rect.Height, font);
        }
    }
}
