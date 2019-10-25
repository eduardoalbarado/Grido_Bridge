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
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using System.Configuration;

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
            string valueconnectionstring = Properties.Settings.Default.connectionstring;
            textBoxString.Text = valueconnectionstring;

            string valueurlapi = Properties.Settings.Default.urlapi;
            Apitext.Text = valueurlapi;
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

                String str = textBoxString.Text;

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

        private void bot_clientes_Click(object sender, EventArgs e)
        {

            try

            {
                
                String str = textBoxString.Text;
                AddEntry("Connection to DB");

                //String query = "select * from CLIPUNTOSVTA";
                //String query = "SELECT TOP 1000 [PUNTO] ,[CLIENTE],[FREEZER], D.[LOCDESCRIP],[PUNDIRECCION],[PUNTELEFONO],[PUNCONTACTO],[RUBDESCRIP],[CANDESCRIP],[ZONA],[VENDEDOR],[ACTIVO]FROM[gestion].[dbo].[CLIPUNTOSVTA] a left join[gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO] left join[gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL] left join[gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD]";
                String query = "SELECT [PUNTO] as PUNTO ,a.[CLIENTE] as CODIGO ,[FREEZER]  ,D.[LOCDESCRIP] LOCALIDAD ,ltrim(rtrim([PUNDIRECCION])) DIRECCION ,ltrim(rtrim([PUNTELEFONO])) TELEFONO ,ltrim(rtrim([PUNCONTACTO])) CONTACTO ,ltrim(rtrim([RUBDESCRIP])) RUBRO ,ltrim(rtrim([CANDESCRIP])) CANAL ,a.[VENDEDOR] as VENDEDOR 	  , ltrim(rtrim(e.[CLINOMBRE])) NOMBRECLIENTE 	  , ltrim(rtrim(e.[CLICUIT])) CUIT    FROM [gestion].[dbo].[CLIPUNTOSVTA] a   left join  [gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO]   left join  [gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL]   left join  [gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD] left join [gestion].[dbo].[CLIENTES] e on e.CLIENTE=a.CLIENTE";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                textBox1.Text = json;
               
                con.Close();
                AddEntry("Retriving Customers");


                string address = "http://api.com/mitablero/apirest.aspx";
                string jsonData = json;
                //string jsonResponse = "";
                ConsoleBox.Text = ConsoleBox.Text + DateTime.Now + " Sending data" + "\n\r" + Environment.NewLine;
                try
                {
                    using (WebClient WC = new WebClient())
                    {
                        NameValueCollection requestParameters = new NameValueCollection();
                        requestParameters.Add("Tipo", "uploadclientes");
                        requestParameters.Add("MyJSON", jsonData);
                        //WC.Headers["Content-type"] = "application/json";
                        byte[] jsonResponse = WC.UploadValues(address, requestParameters);
                        string responseBody = Encoding.UTF8.GetString(jsonResponse);
                        AddEntry("API Response (" + responseBody + ")");
                    }
                }
                catch (Exception)
                {
                    AddEntry("API Error post");
                    throw;
                }

                

            }

            catch (Exception es)

            {
                AddEntry(es.Message);
                



            }

        }

        void AddEntry(string message) {
            ConsoleBox.Text = ConsoleBox.Text + DateTime.Now + " " + message + Environment.NewLine;
            ConsoleBox.ScrollToCaret();
        }



        private void bot_productos_Click(object sender, EventArgs e)
        {

            try

            {

                String str = textBoxString.Text;

                //String query = "select * from CLIPUNTOSVTA";
                //String query = "SELECT TOP 1000 [PUNTO] ,[CLIENTE],[FREEZER], D.[LOCDESCRIP],[PUNDIRECCION],[PUNTELEFONO],[PUNCONTACTO],[RUBDESCRIP],[CANDESCRIP],[ZONA],[VENDEDOR],[ACTIVO]FROM[gestion].[dbo].[CLIPUNTOSVTA] a left join[gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO] left join[gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL] left join[gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD]";
                String query = "select d.articulo as ID, ltrim(rtrim(a.artdescrip)) as NOMBRE_PRODUCTO, d.preimporte as PRECIO_UNIDAD, a.ARTPRECIONORMAL1 as PRECIO_SEGUERIDO from detcanales d inner join articulos a on(d.articulo=a.articulo) where  d.canal=1 and isnull(d.prefechabaja,0)=0";

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            bot_clientes_Click(null,null);
        }
    }
}
