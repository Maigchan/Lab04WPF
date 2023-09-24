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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;

        public static string connectionString = "Data Source=LAB1504-21\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=true";

        private static List<Client> ListarClients()
        {
            List<Client> clientes = new List<Client>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para seleccionar datos
                string query = "ListarClientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Lista de Trabajadores:");
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila

                                clientes.Add(new Client
                                {
                                    IdCliente = reader["idCliente"].ToString(),
                                    CargoContacto = reader["CargoContacto"].ToString(),
                                    Ciudad = reader["Ciudad"].ToString(),

                                });

                            }
                        }
                    }
                }
                // Cerrar la conexión
                connection.Close();


            }
            return clientes;

        }


        public MainWindow()
        {
            InitializeComponent();


            List<Client> clients = ListarClients();


            dgSimple.ItemsSource = clients;
        }
    }
    public class Client
    {

        public string IdCliente { get; set; }

        public string CargoContacto { get; set; }

        public string Ciudad { get; set; }
    }
}
