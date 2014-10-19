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
using ICSharpCode.SharpZipLib.Zip;

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
            if (File.Exists(archivo_configuracion))
            {
                TextReader config = new StreamReader(archivo_configuracion);//abrimos el archivo para ver su contenido
                ruta_origen = config.ReadLine(); //leemos la primera linea del archivo de texto que sera la ruta origen
                ruta_destino = config.ReadLine();//leemos la segunda linea del archivo de texto que sera la ruta destino
                txb_nombre.Text = DateTime.Now.ToString("yyyy-MM-dd_hh.mm");
                txb_origen.Text = ruta_origen;
                txb_destino.Text = ruta_destino;
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.WorkerSupportsCancellation = true;

                if (!File.Exists(archivo_checkados))
                {
                    TextWriter config00 = new StreamWriter(archivo_checkados);//lo creamos
                    config00.Close();
                    ///////////////////////////////////////////////////////////////////////////////////////
                    //aca ademas debemos abrir el archivo chekados y verificar que las subcarpetas existan
                    ///////////////////////////////////////////////////////////////////////////////////////
                }
                llenar_grupo_subcarpetas(panel_check2, ruta_origen, "S");
                llenar_grupo_subcarpetas(panel_check1, ruta_origen, "S");

            }
            else
            {
                TextWriter config0 = new StreamWriter(archivo_configuracion);//lo creamos
                if (!File.Exists(archivo_checkados))
                {
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
                if (rellenar == "S")
                {
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

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
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
            if (ruta_origen_elegida.SelectedPath != ruta_temp)
                llenar_grupo_subcarpetas(panel_check1, ruta_origen_elegida.SelectedPath, "N");
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

            if (File.Exists(archivo_configuracion))
            {
                File.Delete(archivo_configuracion);  //si existe el archivo lo eliminamos                 
            }
            TextWriter config1 = new StreamWriter(archivo_configuracion); //creamos el puntero al archivo config.txt (si el archivo no existe, lo crea)
            config1.WriteLine(txb_origen.Text);  //Escribe en la primera linea la ruta de origen
            config1.WriteLine(txb_destino.Text); //Escribe en la segunda linea la ruta de destino                        
            if (File.Exists(archivo_checkados))
            {
                File.Delete(archivo_checkados);  //si existe el archivo lo eliminamos                 
            }
            TextWriter config2 = new StreamWriter(archivo_checkados); //creamos el puntero al archivo config.txt (si el archivo no existe, lo crea)
            foreach (Control chb in panel_check1.Controls)
            {
                if (chb is CheckBox)
                    if (((CheckBox)chb).Checked)
                        config2.WriteLine(((CheckBox)chb).Name);
            }
            config1.Close();
            config2.Close();
            //llenar_grupo_subcarpetas(panel_check1,txb_origen.Text);
            llenar_grupo_subcarpetas(panel_check2, txb_origen.Text, "S");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            foreach (Control chb in panel_check2.Controls)
            {
                if (chb is CheckBox)
                    if (((CheckBox)chb).Checked)
                    {
                        string directorio_origen = txb_origen.Text + "/" + ((CheckBox)chb).Name;
                        string nombre_archivo = txb_nombre.Text + "_" + chb.Name + ".zip";
                        //Comprension_SharpZipLib.iniciar_comprension(txb_origen.Text + "/" + ((CheckBox)chb).Name, txb_destino.Text, txb_nombre.Text + "_" + chb.Name + ".zip",worker,e);
                        //creamos la el objeto zip que contendra los archivos respaldados
                        ZipOutputStream zip = new ZipOutputStream(File.Create(@txb_destino.Text + @"\" + nombre_archivo));
                        //Grado de compresión
                        zip.SetLevel(9);
                        string folder = @directorio_origen + "\\";
                        ComprimirCarpeta(folder, folder, zip, worker, e);
                        zip.Finish();
                        zip.Close();
                    }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //progressBar1.Value = 100;

            if (e.Error == null)
            {
                MessageBox.Show("Respaldo realizado con Exito");
            }
            else
            {
                MessageBox.Show(
                    "Se presentaron errores",
                    "NO se realizó el Respaldo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Enable the download button and reset the progress bar.            
            progressBar1.Value = 0;
        }

        public static void ComprimirCarpeta(string RootFolder, string CurrentFolder, ZipOutputStream zStream, BackgroundWorker worker, DoWorkEventArgs e)
        {
            string[] SubFolders = Directory.GetDirectories(CurrentFolder);

            //Llama de nuevo al metodo recursivamente para cada carpeta
            foreach (string Folder in SubFolders)
            {                
                ComprimirCarpeta(RootFolder, Folder, zStream, worker, e);
            }

            //obtenemos la ruta relativa de la subcarpeta que estamos recorriendo
            string relativePath = CurrentFolder.Substring(RootFolder.Length) + "/";

            //the path "/" is not added or a folder will be created
            //at the root of the file
            if (relativePath.Length > 1)
            {
                ZipEntry dirEntry;
                dirEntry = new ZipEntry(relativePath);
                dirEntry.DateTime = DateTime.Now;
            }

            //Añade todos los ficheros de la carpeta al zip
            foreach (string file in Directory.GetFiles(CurrentFolder))
            {
                //MessageBox.Show(Path.GetFileName(file));
              AñadirFicheroaZip(zStream, relativePath, file);
              
            }
        }

        private static void AñadirFicheroaZip(ZipOutputStream zStream, string relativePath, string file)
        {
            FileStream fs = null;
            byte[] buffer = new byte[4096];

            //the relative path is added to the file in order to place the file within
            //this directory in the zip
            string fileRelativePath = (relativePath.Length > 1 ? relativePath : string.Empty)
                                      + Path.GetFileName(file);
            ZipEntry entry = new ZipEntry(fileRelativePath);
            entry.DateTime = DateTime.Now;
            //zStream.PutNextEntry(entry);
            try
            {
                if ((fs = File.OpenRead(file)) != null)//cuando el archivo esta abierto aca existe una excepcion, habría que agregar tal excepcion y ver si podemos crear una copia y despues eliminarla
                {
                    zStream.PutNextEntry(entry); //Esta instruccion se movio a este bloque ya que solo debe guardar en el zip las rutas de arhivos que se respaldaran, es decir, si un archivo esta abierto, se obtiene la ruta que se agregara al zip y despues no lo podra guardar por endo queremos que no haya archivos vacios
                    using (fs)
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            zStream.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }
            }
            catch (Exception ex) 
            {
                //MessageBox.Show("aca se produce el error: " + ex.Message + "\n" + ex.Source + "\n" + ex.HResult + "\n" + ex.TargetSite + "\n ver que codigo poner si sucede la excepcion");
                //MessageBox.Show("El archivo "+file+" esta siendo usado por otro programa \n se creara una copia y se agregara al respaldo");
                String ruta_completa_archivo_temporal="temp/"+Path.GetFileName(file);
                File.Copy(file,ruta_completa_archivo_temporal,true);//EL atributo booleano "true" permite la sobre escritura
                AñadirFicheroaZip(zStream, relativePath, ruta_completa_archivo_temporal);
            }
        }

    }
}


    }
}
