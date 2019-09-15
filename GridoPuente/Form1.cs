using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace GridoPuente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        /****** Script for SelectTopNRows command from SSMS  ******/
//        SELECT TOP 1000 [PUNTO]
//      ,[CLIENTE]
//      ,[FREEZER]
//      ,D.[LOCDESCRIP]
//      ,[PUNDIRECCION]
//      ,[PUNTELEFONO]
//      ,[PUNCONTACTO]
//      ,[RUBDESCRIP]
//      ,[CANDESCRIP]
//      ,[ZONA]
//      ,[VENDEDOR]
//      ,[ACTIVO]

//        FROM[gestion].[dbo].[CLIPUNTOSVTA]
//        a
//left join[gestion].[dbo].[RUBROS]
//        b
//on b.[RUBRO]=a.[RUBRO]
//left join[gestion].[dbo].[CANALES]
//        c
//on c.[CANAL]=a.[CANAL]
//left join[gestion].[dbo].[LOCALIDADES]
//        d
//on d.[LOCALIDAD]=a.[LOCALIDAD]
        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                String str = "Server=.\\SQLEXPRESS;Database=GESTION;Trusted_Connection=True;MultipleActiveResultSets=true; Integrated Security=true";

                //String query = "select * from CLIPUNTOSVTA";
                String query = "SELECT TOP 1000 [PUNTO] ,[CLIENTE],[FREEZER], D.[LOCDESCRIP],[PUNDIRECCION],[PUNTELEFONO],[PUNCONTACTO],[RUBDESCRIP],[CANDESCRIP],[ZONA],[VENDEDOR],[ACTIVO]FROM[gestion].[dbo].[CLIPUNTOSVTA] a left join[gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO] left join[gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL] left join[gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD]";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                textBox1.Text = json;

                MessageBox.Show("connect with sql server");

                con.Close();

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try

            {

                String str = "Server=.\\SQLEXPRESS;Database=GESTION;Trusted_Connection=True;MultipleActiveResultSets=true; Integrated Security=true";

                //String query = "select * from CLIPUNTOSVTA";
                //String query = "SELECT TOP 1000 [PUNTO] ,[CLIENTE],[FREEZER], D.[LOCDESCRIP],[PUNDIRECCION],[PUNTELEFONO],[PUNCONTACTO],[RUBDESCRIP],[CANDESCRIP],[ZONA],[VENDEDOR],[ACTIVO]FROM[gestion].[dbo].[CLIPUNTOSVTA] a left join[gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO] left join[gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL] left join[gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD]";
                String query = "SELECT [PUNTO] as PUNTO ,a.[CLIENTE] as CODIGO ,[FREEZER]  ,D.[LOCDESCRIP] LOCALIDAD ,trim([PUNDIRECCION]) DIRECCION ,[PUNTELEFONO] TELEFONO ,trim([PUNCONTACTO]) CONTACTO ,[RUBDESCRIP] RUBRO ,[CANDESCRIP] CANAL ,a.[VENDEDOR] 	  , e.[CLINOMBRE] NOMBRECLIENTE 	  , e.[CLICUIT] CUIT    FROM [gestion].[dbo].[CLIPUNTOSVTA] a   left join  [gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO]   left join  [gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL]   left join  [gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD] left join [gestion].[dbo].[CLIENTES] e on e.CLIENTE=a.CLIENTE";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                textBox1.Text = json;
                

                MessageBox.Show("connect with sql server");

                con.Close();

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try

            {

                String str = "Server=.\\SQLEXPRESS;Database=GESTION;Trusted_Connection=True;MultipleActiveResultSets=true; Integrated Security=true";

                //String query = "select * from CLIPUNTOSVTA";
                //String query = "SELECT TOP 1000 [PUNTO] ,[CLIENTE],[FREEZER], D.[LOCDESCRIP],[PUNDIRECCION],[PUNTELEFONO],[PUNCONTACTO],[RUBDESCRIP],[CANDESCRIP],[ZONA],[VENDEDOR],[ACTIVO]FROM[gestion].[dbo].[CLIPUNTOSVTA] a left join[gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO] left join[gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL] left join[gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD]";
                String query = "SELECT [ARTICULO] as ID ,[ARTDESCRIP] NOMBRE_PRODUCTO, 1 as CANT_X_UNIDAD ,[ARTPRECIONORMAL1] AS PRECIO_UNIDAD FROM [gestion].[dbo].[ARTICULOS] where ARTESTADO='ACTIVO' AND [ARTPRECIONORMAL1]>0 AND ARTVENTA='SI' AND ARTCANALMAYORISTA='SI'";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                textBox1.Text = json;


                MessageBox.Show("connect with sql server");

                con.Close();

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }
        }
    }
}
