using Diagrammer.Api;
using Diagrammer.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagrammer.Forms {

    public partial class ManageDataSeriesForm : Form {
        public BindingList<DataSeries> Series { get; private set; }

        int prevIndex = -1;
        static int NewChartCounter = 0;

        public event EventHandler onOK;

        #region Constructors
        public ManageDataSeriesForm() {
            InitializeComponent();

            comboBoxChartType.Items.AddRange(ChartUtils.ChartNames);

            Series = new BindingList<DataSeries>();
            listBoxSeries.DataSource = Series;
            listBoxSeries.DisplayMember = "Label";

            comboBoxChartType.SelectedIndex = 0;

            NewChartCounter++;
            textBoxChartTitle.Text = $"New chart {NewChartCounter}";
        }

        public ManageDataSeriesForm(Chart chart) : this() {
            foreach(var ds in chart.Data) {
                Series.Add(ds.Value);
            }

            textBoxChartTitle.Text = chart.Title;
            comboBoxChartType.SelectedIndex = (int)ChartUtils.ToEnum(chart);
            textBoxChartTitle.Text = chart.Title;
        }
        #endregion

        private void buttonSeriesColor_Click(object sender, EventArgs e) {
            using (ColorDialog dialog = new ColorDialog()) {
                dialog.AllowFullOpen = true;
                dialog.FullOpen = true;

                DialogResult result = dialog.ShowDialog();

                if (result != DialogResult.OK) {
                    return;
                }

                buttonSeriesColor.BackColor = dialog.Color;
            }
        }

        private void listBoxSeries_SelectedIndexChanged(object sender, EventArgs e) {
            if (prevIndex != -1) {
                var s = Series[prevIndex];
                s.Data = StringUtils.ParseDataString(textBoxSeriesData.Text);
                s.Color = buttonSeriesColor.BackColor;
                s.Label = textBoxSeriesLabel.Text;
            }

            prevIndex = listBoxSeries.SelectedIndex;
            textBoxSeriesData.Focus();

            if (listBoxSeries.SelectedIndex == -1) {
                textBoxSeriesData.Text = "";
                textBoxSeriesLabel.Text = "";
                buttonSeriesColor.BackColor = SystemColors.Window;
            } else {
                double[] arr = Series[listBoxSeries.SelectedIndex]?.Data ?? new double[0];

                StringBuilder builder = new StringBuilder(arr.Length * 3);
                for (int i = 0; i < arr.Length; ++i) {
                    builder.Append(arr[i]);
                    builder.Append(' ');
                }

                textBoxSeriesData.Text = builder.ToString();
                textBoxSeriesLabel.Text = Series[listBoxSeries.SelectedIndex].Label;
                buttonSeriesColor.BackColor = Series[listBoxSeries.SelectedIndex].Color;
            }
        }

        private void buttonAddSeries_Click(object sender, EventArgs e) {
            int idx = listBoxSeries.SelectedIndex;

            DataSeries ds = new DataSeries();
            Series.Add(ds);

            if (idx == -1) {
                listBoxSeries_SelectedIndexChanged(this, null);
            }

            listBoxSeries.SelectedItem = ds;
            //listBoxSeries.SelectedIndex = Series.Count - 1;
        }

        private void buttonRemoveSeries_Click(object sender, EventArgs e) {
            if (Series.Count > 0) {
                prevIndex = -1;
                int idx = listBoxSeries.SelectedIndex--;

                Series.RemoveAt(idx);
            }
        }

        public Chart GetChartData() {
            // save last selected series explicitly (because we can edit them and then hit "OK")
            if (listBoxSeries.SelectedIndex != -1) {
                var s = Series[listBoxSeries.SelectedIndex];
                s.Data = StringUtils.ParseDataString(textBoxSeriesData.Text);
                s.Color = buttonSeriesColor.BackColor;
                s.Label = textBoxSeriesLabel.Text;
            }

            Chart c = ChartUtils.ToChart((ChartType)comboBoxChartType.SelectedIndex, Series.ToArray());
            
            if (c != null) {
                c.Title = textBoxChartTitle.Text;
            }

            return c;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            onOK?.Invoke(this, null);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
