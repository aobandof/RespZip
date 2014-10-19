using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Windows.Forms;

namespace RespZip
{
    class Comprension_SharpZipLib
    {
        //puse el mismo nombre de la libreria ver si despues tenemos problemas
        public static void iniciar_comprension(String directorio_origen, string directorio_destino, string nombre_archivo, BackgroundWorker worker, DoWorkEventArgs e)
        {          
            //creamos la el objeto zip que contendra los archivos respaldados
            ZipOutputStream zip = new ZipOutputStream(File.Create(@directorio_destino + @"\" + nombre_archivo));
            //Grado de compresión
            zip.SetLevel(9);
            string folder = @directorio_origen + "\\";
            ComprimirCarpeta(folder, folder, zip);
            zip.Finish();
            zip.Close();
            
        }

        public static void ComprimirCarpeta(string RootFolder, string CurrentFolder, ZipOutputStream zStream)
        {
            string[] SubFolders = Directory.GetDirectories(CurrentFolder);

            //Llama de nuevo al metodo recursivamente para cada carpeta
            foreach (string Folder in SubFolders)
            {                
                ComprimirCarpeta(RootFolder, Folder, zStream);
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
