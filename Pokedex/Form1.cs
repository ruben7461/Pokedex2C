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
        private MySqlConnection conexion2;
        private static MySqlCommand comando;
        private string consulta;
        private MySqlDataReader resultado;
        private MySqlDataReader resultado1;
        private MySqlDataReader resultado2;
        private MySqlDataReader resultado3;
        private MySqlDataReader resultado4;
        private MySqlDataReader resultado5;
        private MySqlDataReader resultado6;
        private MySqlDataReader resultado7;
        private MySqlDataReader resultado8;
        private MySqlDataReader resultado9;
      
        private DataTable datos = new DataTable();
      
        private static MySqlCommand consultaNivel;
        private static MySqlCommand consultaTipo;
        private static MySqlCommand altura;
        private static MySqlCommand peso;
        private static MySqlCommand color;
        private static MySqlCommand generacion;
        private static MySqlCommand felicidad;
        private static MySqlCommand idPokemon;
        private static MySqlCommand habbitat;


        public Form1()
        {
            InitializeComponent();
            //iniciamos la conexion con la base de datos
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = listapokemon; Uid = root;Pwd =; Port = 3306");
            conexion2 = new MySqlConnection("Server = 127.0.0.1; Database = listapokemon; Uid = root;Pwd =; Port = 3306");
            conexion.Open();

            comando = new MySqlCommand("Select name from pokemon", conexion);
            resultado = comando.ExecuteReader();
            datos.Load(resultado);
            conexion.Close();
            dataGridView1.DataSource = datos;

           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                conexion2.Open();
                String prueba1 = cell.Value.ToString();
                Console.WriteLine(prueba1);
                idPokemon = new MySqlCommand("Select id from pokemon where name=  '+prueba1'", conexion2);
                consultaNivel = new MySqlCommand("Select base_experience from pokemon where name = '+prueba1'", conexion2);
                consultaTipo = new MySqlCommand("Select species from pokemon where name = '+prueba1'", conexion2);
                altura = new MySqlCommand("Select height from pokemon where name = '+prueba1'", conexion2);
                peso = new MySqlCommand("Select weight from pokemon where name = '+prueba1'", conexion2);
                color = new MySqlCommand("Select color from pokemon where name = '+prueba1'", conexion2);
                generacion = new MySqlCommand("Select generation_id from pokemon where name = '+prueba1'", conexion2);
                felicidad = new MySqlCommand("Select base_happiness from pokemon where name = '+prueba1'", conexion2);
                habbitat = new MySqlCommand("Select habitat  from pokemon where name = '+prueba1'", conexion2);
                resultado1 = idPokemon.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado2 = consultaNivel.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado3 = consultaTipo.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado4 = altura.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado5 = peso.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado6 = color.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado7 = generacion.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado8 = felicidad.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                resultado9 = habbitat.ExecuteReader();
                conexion2.Close();
                conexion2.Open();
                idPoke.Text = resultado1["id"] as String;
                lblColor.Text = resultado6["base_experience"] as String;
                lblTipo.Text = resultado6["species"] as String;
                lblAltura.Text = resultado6["height"] as String;
                lblPeso.Text = resultado6["weight"] as String;
                lblGeneracion.Text = resultado6["generation_id"] as String;
                lblFelicidad.Text = resultado6["base_happiness"] as String;
                lblHabitat.Text = resultado6["habitat"] as String;
                conexion2.Close();
                Console.WriteLine(resultado6[""] as String);
            }
        }
    }
}
