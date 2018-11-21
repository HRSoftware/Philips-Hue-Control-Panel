using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Philips_Hue_Control_Panel
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            mainHub = new Hub(baseURL);
            lights = mainHub.getAllLights();
            dataSet = dataSet1;

            DataColumn PKlightID = lightsTable.Columns.Add("Light ID", typeof(int));
            DataColumn lightStateBool = lightsTable.Columns.Add("Light state", typeof(bool));

            foreach (var light in lights)
            {
                lightsTable.Rows.Add(new Object[] { light.Value.lightID, light.Value.lightState.on });
                //dataGridView1.DataSource = lightsTable;
            }

        }

        static string user = "Cz9elgjrfrSqKoxSb7lRCrtl7j7fgJlF9zUbCb4q";
        static string ip = "192.168.1.77";

        string baseURL = "http://" + ip + "/api/" + user;

        private Hub mainHub;

        private Dictionary<int, SmartLight> lights;
        private DataSet dataSet;

        DataTable lightsTable = new DataTable();
        
  

        private void btnOn_Click(object sender, EventArgs e)
        {
            
            txtBox.Text = mainHub.TurnOnLight(14);
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            txtBox.Text = mainHub.TurnOffLight(14);
        }
    }
}
