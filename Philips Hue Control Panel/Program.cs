using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Philips_Hue_Control_Panel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();


            string user = "Cz9elgjrfrSqKoxSb7lRCrtl7j7fgJlF9zUbCb4q";
            Hub mainHub = new Hub("192.168.1.77", user);

        
            DataSet dataSet = mainForm.dataSet1;

            DataTable lightsTable = dataSet.Tables.Add("Lights");
            DataColumn PKlightID = lightsTable.Columns.Add("Light ID", typeof(int));
            DataColumn lightStateBool = lightsTable.Columns.Add("Light state", typeof(bool));

            DataRow workRow = lightsTable.NewRow();
            List<SmartLight> lights = mainHub.getAllLights();
            workRow["Light ID"] = lights[1].lightState.bri;
            workRow["Light state"] = lights[1].lightState.on;
            lightsTable.BeginInit();
            dataSet.AcceptChanges();



            Application.Run(mainForm);

            
            
        }
    }
}
