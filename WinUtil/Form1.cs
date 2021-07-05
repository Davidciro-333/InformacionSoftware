using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using MaterialSkin;
using MaterialSkin.Controls;


namespace WinUtil
{
    public partial class frmSoftwareInfo : MaterialForm
    {
        public frmSoftwareInfo()
        {
            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey600, Primary.Cyan600, Primary.Grey600, Accent.LightBlue200, TextShade.WHITE);
        }


        private void btnInventario_Click(object sender, EventArgs e)
        {
            clsCaracteristicas Informacion = new clsCaracteristicas();

            txtInventario.Text = Informacion.GPU();
            txtInventario.Text += Informacion.Disco_Duro();
            txtInventario.Text += Informacion.Procesadores();
            txtInventario.Text += Informacion.SO();
            txtInventario.Text += Informacion.Interfaz_Red();
            txtInventario.Text += Informacion.ShowNetworkInterfaces();
            txtInventario.Text += Informacion.Tarjeta_Sonido();
            txtInventario.Text += Informacion.Impresoras();
        }
    }
}
