using System;
using System.Collections.Generic;
using System.Drawing;

//TODO: рефакторинг (прям всего, чтоб в одном стиле весь код был, особенно касается именования переменных)
//TODO: граничные случаи в API не рассматриваются
//TODO: tests!
//TODO: close other todo's
namespace Diagrammer.Api {
    [Serializable]
    public abstract class Chart {

        #region Properties
        // left up right down
        public Rectangle ChartMargins { get; set; } = new Rectangle(10, 10, 10, 10);
        public Rectangle LegendMargins { get; set; } = new Rectangle(3, 3, 3, 3);

        public int LineSpacing { get; set; } = 3;
        public int LegendSampleSize { get; set; } = 10;

        public String Title { get; set; }
        public Dictionary<string, DataSeries> Data { get; protected set; }
        #endregion Properties

        #region Constructors
        public Chart() {
            Data = new Dictionary<string, DataSeries>();
        }

        public Chart(params DataSeries[] series): this() {
            foreach(var s in series) {
                Data.Add(s.Label, s);
            }
        }

        public Chart(String title, params DataSeries[] series): this() {
            Title = title;
        }
        #endregion Constructors

        public abstract void Draw(Graphics g, float x, float y, float width, float height);

        public abstract void Draw(Graphics g, Rectangle rect);

        public abstract void DrawCaptions(Graphics g, float x, float y, float width, float height, Font font);

        public abstract void DrawCaptions(Graphics g, Rectangle rect, Font font);

        public virtual void DrawLegend(Graphics g, float x, float y, Font font) {            
            float sampleSize = Math.Max(LegendSampleSize, font.Height);

            float legendHeight = (sampleSize + LegendMargins.Y + LegendMargins.Height) * Data.Count;
            float leftStrMargin = LegendMargins.Width + LegendSampleSize;

            float startX = x;
            float startY = y;

            x += LegendMargins.X;
            y += LegendMargins.Y;

            float legendWidth = 0;
            foreach (var ds in Data) {
                using (Brush b = new SolidBrush(ds.Value.Color)) {
                    var measures = g.MeasureString(ds.Key, font);

                    // draw dample color
                    g.FillRectangle(b, x, y, LegendSampleSize, sampleSize);

                    float strOffset = (sampleSize - measures.Height) / 2;
                    g.DrawString(ds.Key, font, Brushes.Black, x + leftStrMargin, y + strOffset);

                    // debug draws
                    // g.DrawRectangle(Pens.Black, x + leftStrMargin, y, measures.Width, measures.Height);
                    // g.DrawRectangle(Pens.Black, x + leftStrMargin, y, measures.Width, legendSampleHeight);

                    y += sampleSize + LegendMargins.Y + LegendMargins.Height;
                    legendWidth = Math.Max(legendWidth, measures.Width);
                }
            }

            g.DrawRectangle(Pens.Black, startX, startY, legendWidth + leftStrMargin + LegendMargins.Right, legendHeight);
        }
    }
}
