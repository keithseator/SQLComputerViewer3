using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace SQLComputerViewer3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            binddatagrid();

        }

        private void binddatagrid()
        {
            SqlConnection connew = new SqlConnection();
            //connew.ConnectionString = "Server = UKABZAPP3\\SQLEXPRESS; User ID = sa; Password = 'R3mote!'; Initial Catalog = Computers";
            connew.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionToComputers"].ConnectionString;
            connew.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Computers";
            cmd.Connection = connew;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ComputersDT");
            da.Fill(dt);

            g1.ItemsSource = dt.DefaultView;
        }
    }
}
