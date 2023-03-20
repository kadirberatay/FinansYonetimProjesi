using FinansYonetimProjesi.Bilanco;
using FinansYonetimProjesi.GelirGider;
using FinansYonetimProjesi.İSTATİSTİK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansYonetimProjesi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string kullanicirolu;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = kullanicirolu;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GelirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void bİLANÇOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BİLANCO BLN = new BİLANCO();
            BLN.ShowDialog();

        }
        private void iSTATİSTİKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISTATISTIK ist = new ISTATISTIK();
            ist.ShowDialog();
            
        }

        private void eKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADD gelirGider = new ADD();
            gelirGider.ShowDialog();
        }

        private void sİLMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DELETED dELETED = new DELETED();
            dELETED.ShowDialog();
        }

        private void eDİTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UPDATE update = new UPDATE();
            update.ShowDialog();
        }

        private void gELİRBİLANÇOSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GelirBLNC gelir = new GelirBLNC();
            gelir.ShowDialog();
        }

        private void gİDERBİLANÇOSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiderBLNC gider = new GiderBLNC();
            gider.ShowDialog();
        }

        private void gELİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GelirIST gelirIST = new GelirIST();
            gelirIST.ShowDialog();
        }

        private void gİDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiderIST giderIST = new GiderIST();
            giderIST.ShowDialog();
        }

        private void kARZARARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AylıkKarZararDurumu aylık = new AylıkKarZararDurumu();
            aylık.ShowDialog();
        }
    }
}
