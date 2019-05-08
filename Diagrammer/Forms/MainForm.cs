using Diagrammer.Api;
using Diagrammer.Charts;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Diagrammer.Forms {

    public partial class MainForm : Form {
        public BindingList<Chart> Charts { get; private set; } = new BindingList<Chart>();

        // TODO: УПРОСТИТЬ КОД, ВЫНЕСТИ ПОВТОРЯЮЩИЕСЯ УЧАСТКИ В УТИЛИТАРНЫЕ МЕТОДЫ
        public MainForm() {
            InitializeComponent();
            
            listBoxCharts.DataSource = Charts;
            listBoxCharts.DisplayMember = "Title";
        }

        #region Main menu
        private void menuItemSaveImg_Click(object sender, EventArgs e) {
            int chartIndex = listBoxCharts.SelectedIndex;

            int width = splitContainer.Panel2.ClientRectangle.Width, 
                height = splitContainer.Panel2.ClientRectangle.Height;
            string fileName = "";

            using (SaveFileDialog fileDialog = new SaveFileDialog()) {
                fileDialog.FileName = Charts[chartIndex].Title;
                fileDialog.DefaultExt = ".png";
                fileDialog.Filter = "Portable network graphics (.png)|*.png";

                DialogResult dialogResult = fileDialog.ShowDialog();

                if (dialogResult != DialogResult.OK)
                    return;

                fileName = fileDialog.FileName;
            }

            using (Bitmap bmp = new Bitmap(width, height))
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.Clear(SystemColors.Window);
                Charts[chartIndex]?.Draw(g, 0, 0, width, height);
                Charts[chartIndex]?.DrawCaptions(g, 0, 0, width, height, SystemFonts.CaptionFont);
                Charts[chartIndex]?.DrawLegend(g, 0, 0, SystemFonts.CaptionFont);

                bmp.Save(fileName, ImageFormat.Png);
            }
        }

        private void menuItemSerialize_Click(object sender, EventArgs e) {
            DirectoryInfo saveDirInfo;
            string saveDir = "";

            using (OpenFileDialog fileDialog = new OpenFileDialog()) {
                DialogResult dialogResult = fileDialog.ShowDialog();

                if (dialogResult != DialogResult.OK)
                    return;

                saveDirInfo = new DirectoryInfo(Path.GetFullPath(fileDialog.FileName));
                saveDir = saveDirInfo.Parent.FullName;
                saveDirInfo = saveDirInfo.Parent;
            }

            String chartsBasePath = $"charts_{DateTime.Now.ToLongTimeString().Replace(':', '_')}";
            saveDirInfo.CreateSubdirectory(chartsBasePath);

            saveDir = Path.Combine(saveDir, chartsBasePath);
            BinaryFormatter serializer = new BinaryFormatter();
            for (int i = 0; i < Charts.Count; ++i) {
                try {
                    String filePath = Path.Combine(saveDir, $"{Charts[i].Title}.bchrt");
                    using (FileStream fs = new FileStream(filePath, FileMode.CreateNew)) {
                        serializer.Serialize(fs, Charts[i]);
                    }
                } catch (SerializationException exc) {
                    MessageBox.Show($"An error occurred during the save!\n{exc.Message}", "Saving error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuItemLoad_Click(object sender, EventArgs e) {
            string[] fileNames;

            using (OpenFileDialog fileDialog = new OpenFileDialog()) {
                fileDialog.Multiselect = true;
                DialogResult dialogResult = fileDialog.ShowDialog();

                if (dialogResult != DialogResult.OK)
                    return;

                fileNames = fileDialog.FileNames;
            }

            Charts.Clear();

            BinaryFormatter deserializer = new BinaryFormatter();
            foreach (var fileName in fileNames) {
                using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
                    if (deserializer.Deserialize(fs) is Chart c) {
                        Charts.Add(c);
                    }
                }
            }

            if (Charts.Count > 0) {
                listBoxCharts.SelectedIndex = 0;
            } else {
                listBoxCharts.SelectedIndex = -1;
            }

            splitContainer.Panel2.Invalidate(true);
        }

        private void menuItemAbout_Click(object sender, EventArgs e) {
            using (AboutBox aboutBox = new AboutBox()) {
                aboutBox.ShowDialog();
            }
        }
        #endregion
        
        #region Chart panel
        private void chartPanel_Paint(object sender, PaintEventArgs e) {
            int chartIndex = listBoxCharts.SelectedIndex;

            if (chartIndex < 0) {
                e.Graphics.Clear(splitContainer.Panel2.BackColor);
                return;
            }

            Charts[chartIndex].Draw(e.Graphics, e.ClipRectangle);
            Charts[chartIndex].DrawCaptions(e.Graphics, e.ClipRectangle, SystemFonts.CaptionFont);
            Charts[chartIndex].DrawLegend(e.Graphics, e.ClipRectangle.X, e.ClipRectangle.Y, SystemFonts.CaptionFont);
        }

        private void chartPanel_Resize(object sender, EventArgs e) {
            splitContainer.Panel2.Invalidate(true);
        }
        #endregion

        #region List box
        private void listBoxCharts_SelectedIndexChanged(object sender, EventArgs e) {
            splitContainer.Panel2.Invalidate(true);
        }

        private void listBoxCharts_MouseDoubleClick(object sender, MouseEventArgs e) {
            int index = listBoxCharts.IndexFromPoint(e.Location);

            using (var form = new ManageDataSeriesForm(Charts[index])) {
                form.onOK += delegate {
                    Chart c = form.GetChartData();

                    if (c != null) {
                        Charts[index] = c;
                    }
                };

                form.ShowDialog();
                splitContainer.Panel2.Invalidate(true);
            }
        }
        #endregion

        #region Add/Remove buttons
        private void buttonAdd_Click(object sender, EventArgs e) {
            using (var form = new ManageDataSeriesForm()) {
                form.onOK += delegate {
                    Chart c = form.GetChartData();
                    
                    if (c != null) {
                        Charts.Add(c);
                        listBoxCharts.SelectedIndex = Charts.Count - 1;
                    }
                };

                form.ShowDialog();
                splitContainer.Panel2.Invalidate(true);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            if (Charts.Count > 0) {
                Charts.RemoveAt(listBoxCharts.SelectedIndex);
                splitContainer.Panel2.Invalidate(true);
            }
        }
        #endregion
    }
}
