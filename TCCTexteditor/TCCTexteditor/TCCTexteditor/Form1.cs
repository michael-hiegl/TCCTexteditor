using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCCTexteditor
{
    public partial class Form1 : Form
    {
        Filewriter MyFilewriter= new Filewriter(); 
        private string DateiPfad;


        public Form1()
        {
            InitializeComponent();

            
        }

        #region Datei
        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.Text = null;
            speichernToolStripMenuItem.Enabled = false;
        }


        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Überschreibe das aktuelle Dokument
            MyFilewriter.WriteDataFile(RTB_Data.Text);
        }


        private void speichernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if( saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DateiPfad = saveFileDialog1.FileName;
            }

            MyFilewriter.DateiPfad=DateiPfad;
            MyFilewriter.WriteDataFile(RTB_Data.Text);
            speichernToolStripMenuItem.Enabled = true;
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DateiPfad = openFileDialog1.FileName;
            }
            MyFilewriter.DateiPfad = DateiPfad;
            RTB_Data.Text= MyFilewriter.ReadDataFile();
            speichernToolStripMenuItem.Enabled = true;

        }


        private void schließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

#endregion





        #region BackgroundColor
        private void weißToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.BackColor = Color.White;
        }

        private void schwarzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.BackColor = Color.Black;
        }

        private void blauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.BackColor = Color.Blue;
        }

        private void grünToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.BackColor = Color.Green;
        }
        #endregion


        #region ForeColor
        private void weißToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RTB_Data.ForeColor = Color.White;
        }

        private void schwarzToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RTB_Data.ForeColor = Color.Black;
        }

        private void rotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.ForeColor = Color.Red;
        }
        #endregion


        #region Format
        private void microsoftSansSerifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.Font = new Font(new FontFamily("Microsoft Sans Serif"), 10);
        }

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.Font = new Font(new FontFamily("Arial"), 10);
        }

        private void modernNo20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB_Data.Font = new Font(new FontFamily("Modern No. 20"), 12);
        }

        #endregion


        #region Help
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm MyHelpForm = new HelpForm();
            MyHelpForm.Show();
        }
        #endregion

    }
}
