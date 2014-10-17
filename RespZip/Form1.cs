using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RespZip
{
    public partial class form_respaldo : Form
    {
        String archivo_configuracion = "config.txt";//archivo donde guardaremos la ruta origen y destino elegidos
        String archivo_checkados = "checkados.txt";//archivo donde guardaremos todas las subcarpetas elegidas por defecto para hacer respaldo
        String ruta_origen, ruta_destino, nombre_carpeta;
        int posy;
        
        public form_respaldo()
        {
            InitializeComponent();
            if (File.Exists(archivo_configuracion)){
                TextReader config = new StreamReader(archivo_configuracion);//abrimos el archivo para ver su contenido
                ruta_origen = config.ReadLine(); //leemos la primera linea del archivo de texto que sera la ruta origen
                ruta_destino = config.ReadLine();//leemos la segunda linea del archivo de texto que sera la ruta destino
                txb_nombre.Text = DateTime.Now.ToString("yyyy-MM-dd_hh.mm");
                txb_origen.Text = ruta_origen;
                txb_destino.Text = ruta_destino;
                if (!File.Exists(archivo_checkados)){
                    TextWriter config00 = new StreamWriter(archivo_checkados);//lo creamos
                    config00.Close();
                    ///////////////////////////////////////////////////////////////////////////////////////
                    //aca ademas debemos abrir el archivo chekados y verificar que las subcarpetas existan
                    ///////////////////////////////////////////////////////////////////////////////////////
                }
                llenar_grupo_subcarpetas(panel_check2,ruta_origen,"S");
                llenar_grupo_subcarpetas(panel_check1,ruta_origen,"S");

            } else {
                TextWriter config0 = new StreamWriter(archivo_configuracion);//lo creamos
                if (!File.Exists(archivo_checkados)) {
                    TextWriter config000 = new StreamWriter(archivo_checkados);//lo creamos
                    config000.Close();
                }
                MessageBox.Show("AL NO ENCONTRAR ARCHIVO 'configuracion.txt'\nEL PROGRAMA LO CREO PERO ES ES NECESARIO\n QUE ELIJA UNA RUTA DE ORIGEN\nY DESTINO POR DEFECTO");
                pan_configurar.Visible = true;
                pan_respaldar.Visible = false;
                config0.Close();
            }
        }

        private void tsb_respaldar_Click(object sender, EventArgs e)
        {
            pan_respaldar.Visible = true;
            pan_configurar.Visible = false;
        }

        private void tsb_configurar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("boton 2: tsb_configurar llama a panel configurar verde");
            pan_configurar.Visible = true;
            pan_respaldar.Visible = false;
        }

        private void llenar_grupo_subcarpetas(Panel gb, string directorio, string rellenar) //funcion que llena todos los nombres de subcarpetas en la ruta especificada, ademas de activar el atributo selected en las subcarpetas configuradas para que esten activas
        {
            posy = 0;
            String linea;
            gb.Controls.Clear(); //eliminamos los controles del grupo                       
            
            if (Directory.Exists(directorio))
            {
                string[] subcarpetas = Directory.GetDirectories(directorio);
                foreach (string subcar in subcarpetas)
                {
                    nombre_carpeta = subcar.Substring(subcar.LastIndexOf("\\") + 1, subcar.Length - subcar.LastIndexOf('\\') - 1);
                    CheckBox chb_dinamico = new CheckBox();
                    posy += 22;
                    chb_dinamico.Name = nombre_carpeta;
                    chb_dinamico.Text = nombre_carpeta;
                    chb_dinamico.Visible = true;
                    chb_dinamico.Width = 200;
                    chb_dinamico.Top = posy;
                    chb_dinamico.Left = 25;                    
                    gb.Controls.Add(chb_dinamico);
                }
                if (rellenar=="S") {
                    TextReader config3 = new StreamReader(archivo_checkados);
                    while ((linea = config3.ReadLine()) != null)
                    {
                        Control[] checkbs = gb.Controls.Find(linea, true);
                        ((CheckBox)checkbs[0]).Checked = true;
                    }
                    config3.Close();
                }
            }
            else
            {
                MessageBox.Show("no se encuentra la ruta origen por favor elija la ruta correcta donde estan las carpetas a respaldar");
            }
        }
       
        private void pb_respaldar_Click(object sender, EventArgs e)
        {
            //Comprension1.comprimir_archivo(@"C:\ABEL\ESTADOS DE CUENTA\CENTROS ESPECIALES\PRUEBA1.xlsx");
            ///////////////////////////////////////////////////////////////////////////////////////////
            //debe ir un condicional que muestre un mensaje cuando no hay algun archivo seleccionado
            ///////////////////////////////////////////////////////////////////////////////////////////

            foreach (Control chb in panel_check2.Controls)
            {
                if (chb is CheckBox)
                    if (((CheckBox)chb).Checked)
                        //Comprimir_GZipStream.comprimir_carpeta(txb_origen.Text + "/" + ((CheckBox)chb).Name);
                        Comprension_SharpZipLib.iniciar_comprension(txb_origen.Text + "/" + ((CheckBox)chb).Name, txb_destino.Text, txb_nombre.Text + "_" + chb.Name + ".zip");
            }
        }

        private void pb_actualizar_origen_Click(object sender, EventArgs e)
        {
            String ruta_temp = txb_origen.Text;
            FolderBrowserDialog ruta_origen_elegida = new FolderBrowserDialog();
            if (ruta_origen_elegida.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            txb_origen.Text = ruta_origen_elegida.SelectedPath;
            if (ruta_origen_elegida.SelectedPath!=ruta_temp)
                llenar_grupo_subcarpetas(panel_check1, ruta_origen_elegida.SelectedPath,"N");                        
        }

        private void pb_actualizar_destino_Click(object sender, EventArgs e)
        {                     
            FolderBrowserDialog ruta_destino_elegida = new FolderBrowserDialog(); //se usa para elegir carpeta destino            
            if (ruta_destino_elegida.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            txb_destino.Text = ruta_destino_elegida.SelectedPath;            
        }

        private void pb_guardar_configuracion_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //aca tenemos que validar el formulario y condicionar a que las cajas de texto no esten vacias y tengan sintaxis de rutas correctas
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        
            if (File.Exists(archivo_configuracion)){
                File.Delete(archivo_configuracion);  //si existe el archivo lo eliminamos                 
            }
            TextWriter config1 = new StreamWriter(archivo_configuracion); //creamos el puntero al archivo config.txt (si el archivo no existe, lo crea)
            config1.WriteLine(txb_origen.Text);  //Escribe en la primera linea la ruta de origen
            config1.WriteLine(txb_destino.Text); //Escribe en la segunda linea la ruta de destino                        
            if (File.Exists(archivo_checkados)) {
                File.Delete(archivo_checkados);  //si existe el archivo lo eliminamos                 
            }
            TextWriter config2 = new StreamWriter(archivo_checkados); //creamos el puntero al archivo config.txt (si el archivo no existe, lo crea)
            foreach (Control chb in panel_check1.Controls) {
                if (chb is CheckBox)
                    if (((CheckBox)chb).Checked)
                        config2.WriteLine(((CheckBox)chb).Name);
            }
            config1.Close();
            config2.Close();
            //llenar_grupo_subcarpetas(panel_check1,txb_origen.Text);
            llenar_grupo_subcarpetas(panel_check2, txb_origen.Text,"S");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
        }
      }
}
