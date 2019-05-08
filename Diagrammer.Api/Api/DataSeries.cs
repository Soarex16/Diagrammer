using System;
using System.Drawing;

namespace Diagrammer.Api {
    [Serializable]
    public class DataSeries {
        
        [NonSerialized]
        private static Random rand = new Random();
        private static int defaultLabel = 0;

        #region Properties
        private Color color_ = Color.Empty;
        public Color Color {
            get {
                if (color_.IsEmpty) {
                    color_ = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    return color_;
                } else {
                    return color_;
                }
            }

            set {
                color_ = value;
            }
        }

        public string Label { get; set; } = "";

        public double[] Data { get; set; }
        #endregion Properties

        public DataSeries() {
            this.Label = defaultLabel.ToString();

            ++defaultLabel;
        }

        public DataSeries(params double[] vals): this() {
            this.Data = vals;
        }

        public DataSeries(Color c, params double[] vals): this(vals) {
            this.Color = c;
        }

        public DataSeries(String label, params double[] vals) : this(vals) {
            this.Label = label;
        }

        public DataSeries(String label, Color c, params double[] vals): this(c, vals) {
            this.Label = label;
        }
    }
}
