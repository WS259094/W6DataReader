using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//added by user
using MySql.Data;
using MySql.Data.MySqlClient;

namespace W6DataReader
{
    public partial class frmDataReader : Form
    {
        public frmDataReader()
        {
            InitializeComponent();
        }

        private void FrmDataReader_Load(object sender, EventArgs e)
        {
            string conString = "server=server1.logicalview.co.uk;user=c444WS259094;database=c444WS259094Colab;password=Friday@63;CharSet=utf8;";

            MySqlConnection Mycon = new MySqlConnection(conString);

            string MyCommandstring = "SELECT `ID` FROM `tbl_Test`";

            MySqlCommand myCommand = new MySqlCommand(MyCommandstring, Mycon);

            //open the connection to the database
            Mycon.Open();


            //read data from a database that wont be edited
            MySqlDataReader r = myCommand.ExecuteReader();

            
            //while the data from the database is being read
            while (r.Read())
              {
                cboUserID.Items.Add(r[0]);
              }

            Mycon.Close();
        }

        private void CboUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // connection and the command that will run
            string conString = "server=server1.logicalview.co.uk;user=c444WS259094;database=c444WS259094Colab;password=Friday@63;CharSet=utf8;";

            MySqlConnection Mycon = new MySqlConnection(conString);

            string MyCommandstring = "SELECT `ID` FROM `tbl_Test`";

            MySqlCommand myCommand = new MySqlCommand(MyCommandstring, Mycon);


        }
    }
}
           
    
    
 
  
