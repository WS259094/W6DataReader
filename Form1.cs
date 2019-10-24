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

            string MyCommandstring = "SELECT `Name`, `Score` FROM `tbl_Test` WHERE `ID` = @ID";

            MySqlCommand myCommand = new MySqlCommand(MyCommandstring, Mycon);

            Mycon.Open();
            //insures that the command is returned
            myCommand.Prepare();

            myCommand.Parameters.AddWithValue("@ID", cboUserID.SelectedItem.ToString());

            MySqlDataReader r = myCommand.ExecuteReader();

            while(r.Read())
            {

                //grabbing data from the rows in the database and placing them into the textboxes as a string
                txtName.Text = r[0].ToString();
                txtScore.Text = r[1].ToString();
            }

            

            Mycon.Close();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtScore_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
           
    
    
 
  
