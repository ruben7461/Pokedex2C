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
        private static MySqlCommand comando2;
        private string consulta;
        private MySqlDataReader resultado;
        private MySqlDataReader resultado2;


        private DataTable datos = new DataTable();
      
       

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
            
            dataGridView1.DataSource = datos;
            conexion.Close();
            lblFoto.Image = Image.FromFile(@"C:\Users\xp\Source\Repos\Pokedex2C2\Pokedex\imagenes\0.png");


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                conexion2.Open();
              
                String prueba1 = cell.Value.ToString();
                
                comando2  = new MySqlCommand("Select * from pokemon where name ='"+ prueba1 +"'", conexion2);
                resultado2 = comando2.ExecuteReader();


                if (resultado2.Read())
                {
                    idPoke.Text = resultado2["id"].ToString();
                    lblColor.Text = resultado2["color"].ToString();
                    lblTipo.Text = resultado2["species"].ToString();
                    lblAltura.Text = resultado2["height"].ToString();
                    lblPeso.Text = resultado2["weight"].ToString();
                    lblGeneracion.Text = resultado2["generation_id"].ToString();
                    lblFelicidad.Text = resultado2["base_happiness"].ToString();
                    lblHabitat.Text = resultado2["habitat"].ToString();
                    String  numeroImagen = resultado2["id"].ToString();
                    int numeroNuevo = Int32.Parse(numeroImagen) - 1;
                    String numeroNuevo2 = numeroNuevo.ToString();
                   Image imagen = Image.FromFile(@"C:\Users\xp\Source\Repos\Pokedex2C2\Pokedex\imagenes\" + numeroNuevo2+".png");
                    lblFoto.Image = imagen;
                }
                
                //Console.WriteLine(resultado6[""] as String);
            }
            conexion2.Close();
        }

    }
}
