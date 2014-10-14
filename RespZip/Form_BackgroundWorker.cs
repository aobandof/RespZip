using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RespZip
{
    public partial class Form_BackgroundWorker : Form
    {
        public Form_BackgroundWorker()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //no usaremos código try/catch aquí, a no ser que después hagamos un throw de la excepción capturada.
            //es necesario dejar que el backgroundworker sea quien capture cualquier excepción producida.
            //si se produce una excepción, el control la disponibilizará una vez haya finalizado su ejecución,
            //y disparado el evento "backgroundWorker1_RunWorkerCompleted"
            //the RunWorkerCompletedEventArgs object, method backgroundWorker1_RunWorkerCompleted
            //try
            //{
            DateTime start = DateTime.Now;
            e.Result = "";
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(500); //simulamos trabajo

                //hemos completado un porcentaje del trabajo previsto, luego notificamos de ello.
                backgroundWorker1.ReportProgress(i, DateTime.Now);

                //descomenta este código para ver como esta excepción es gestionada por el
                //control backgroundworker
                //descomenta también el atributo indicado arriba para evitar que el depurador
                //pare en la excepción, ya que queremos simular
                //el comportamiento del control en tiempo de ejecución.
                //if (i == 34)
                //    throw new Exception("something wrong here!!");

                //en caso de que soporte cancelación y el control haya recibido la petición de cancelación,
                //cancelamos el trabajo. Es la manera en la que realizamos una salida "limpia".
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }

            TimeSpan duration = DateTime.Now - start;

            //aquí podríamos devolver información de utilidad, como el resultado de un cálculo,
            //número de elementos afectados, etc.. de manera sencilla y segura
            //al hilo principal
            e.Result = "Duration: " + duration.TotalMilliseconds.ToString() + " ms.";
            //}
            //catch(Exception ex){
            //    MessageBox.Show("Don't use try catch here!");
            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; //actualizamos la barra de progreso
            DateTime time = Convert.ToDateTime(e.UserState); //obtenemos información adicional si procede

            //en este ejemplo, logamos a un textbox
            textBox1.AppendText(time.ToLongTimeString());
            textBox1.AppendText(Environment.NewLine);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
            }
            else
            {
                MessageBox.Show("The task has been completed. Results: " + e.Result.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //este código no mata ni afecta al hilo en el que se está ejecutando el procesamiento.
            //Sirve a efectos de notificación, que debe de ser
            //gestionada de la manera que se indica arriba en el ejemplo
            backgroundWorker1.CancelAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
