using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //es para el manejo de archivos
using System.IO.Compression; //para el manejo de archivos comprimidos
using System.Drawing;
using System.Windows.Forms;

namespace RespZip
{
    class Comprension1
    {
        //metodo que comprime un archivo por una ruta que se especifique
        public static void comprimir_archivo(string path)
        {
            if (!File.Exists(path))
            {
                //throw new ApplicationException("El archivo no existe");
                MessageBox.Show("no se encuentra archivo de origen");
                return;
            }
            FileStream sourceFile = File.OpenRead(path);
            FileStream destinatioFile = File.Create(path + ".gz");

            byte[] buffer = new byte[sourceFile.Length];
            sourceFile.Read(buffer, 0, buffer.Length);

            using (GZipStream output = new GZipStream(destinatioFile, CompressionMode.Compress))
            {
                output.Write(buffer, 0, buffer.Length);
                MessageBox.Show("compresed from " + buffer[0] + " bytes to " + buffer[1] + " bytes ");
            }
            sourceFile.Close();
            destinatioFile.Close();
        }
    }
}
