using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace Pokedex
{
    public partial class Form1 : Form
    {

        private MySqlConnection conexion;
        private static MySqlCommand comando;
        private string consulta;
        private MySqlDataReader resultado;
        private DataTable datos = new DataTable();

        public Form1()
        {
            InitializeComponent();
            //iniciamos la conexion con la base de datos
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = listapokemon; Uid = root;Pwd =; Port = 3306");
            conexion.Open();

            comando = new MySqlCommand("Select name from pokemon", conexion);
            resultado = comando.ExecuteReader();
            datos.Load(resultado);
            conexion.Close();
            dataGridView1.DataSource = datos;
            
        }
    }
}
