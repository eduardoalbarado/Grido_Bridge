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

        private void bot_clientes_Click(object sender, EventArgs e)
        {
            SyncCustomer();
        }

        private void bot_productos_Click(object sender, EventArgs e)
        {
            SyncProducts();
        }

        void AddEntry(string message) {
            ConsoleBox.Text = DateTime.Now + " " + message + Environment.NewLine + ConsoleBox.Text;
            ConsoleBox.SelectionLength = 0;
            ConsoleBox.ScrollToCaret();
        }

        void SyncProducts()
        {
            string query = "select d.articulo as ID, ltrim(rtrim(a.artdescrip)) as NOMBRE_PRODUCTO, d.preimporte as PRECIO_UNIDAD, a.ARTPRECIONORMAL1 as PRECIO_SEGUERIDO from detcanales d inner join articulos a on(d.articulo=a.articulo) where  d.canal=1 and isnull(d.prefechabaja,0)=0";
            Sync(query, "Products", "uploadproductos");
        }


        void SyncCustomer()
        {
            string query = "SELECT [PUNTO] as PUNTO ,a.[CLIENTE] as CODIGO ,[FREEZER]  ,D.[LOCDESCRIP] LOCALIDAD ,ltrim(rtrim([PUNDIRECCION])) DIRECCION ,ltrim(rtrim([PUNTELEFONO])) TELEFONO ,ltrim(rtrim([PUNCONTACTO])) CONTACTO ,ltrim(rtrim([RUBDESCRIP])) RUBRO ,ltrim(rtrim([CANDESCRIP])) CANAL ,a.[VENDEDOR] as VENDEDOR 	  , ltrim(rtrim(e.[CLINOMBRE])) NOMBRECLIENTE 	  , ltrim(rtrim(e.[CLICUIT])) CUIT, CASE a.[ACTIVO] WHEN 'SI' THEN 1 ELSE 0 END AS ACTIVO FROM [gestion].[dbo].[CLIPUNTOSVTA] a   left join  [gestion].[dbo].[RUBROS] b on b.[RUBRO]=a.[RUBRO]   left join  [gestion].[dbo].[CANALES] c on c.[CANAL]=a.[CANAL]   left join  [gestion].[dbo].[LOCALIDADES] d on d.[LOCALIDAD]=a.[LOCALIDAD] left join [gestion].[dbo].[CLIENTES] e on e.CLIENTE=a.CLIENTE";
            Sync(query, "Customer", "uploadclientes");
        }



        void Sync(string query, string entity, string tipo)
        {
            try

            {

                String str = textBoxString.Text;
                AddEntry("Connection to DB");

                try
                {

                    SqlConnection con = new SqlConnection(str);

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    textBox1.Text = json;

                    con.Close();
                    AddEntry("Retriving "+ entity);


                    string address = Properties.Settings.Default.urlapi;
                    string jsonData = json;
                    //string jsonResponse = "";
                    AddEntry("Sending data...");
                    try
                    {
                        using (WebClient WC = new WebClient())
                        {
                            NameValueCollection requestParameters = new NameValueCollection();
                            requestParameters.Add("Tipo", tipo);
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
                catch (Exception)
                {

                    AddEntry("DB Connection Error");
                }




            }

            catch (Exception ex)

            {
                AddEntry(ex.Message);




            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SyncCustomer();
            SyncProducts();
        }

        private void Todo_Click(object sender, EventArgs e)
        {
            Todo.PerformClick();
        }
    }
}
