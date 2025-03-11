using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing.Text;
using System.Net.Http.Json;
using System.Text;

namespace ProcesadorDeTarjetas
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpClient;
        public Form1()
        {
            InitializeComponent();
            apiURL = "https://localhost:7037";
            httpClient = new HttpClient();
        }

        private List<string> ObtenerTarjetasDeCredito(int cantidadTarjetas)
        {
            var tarjetas = new List<string>();

            for (int i = 0; i < cantidadTarjetas; i++)
            {
                //Genera Strings como 000000000002 y 00000000001
                tarjetas.Add(i.ToString().PadLeft(16, '0'));
            }

            return tarjetas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btn_iniciar_Click(object sender, EventArgs e)
        {
           
                var tarjetas = ObtenerTarjetasDeCredito(15);
            //Iniciamos cronómetro
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                await ProcesarTarjetas(tarjetas);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }

            var segundosTranscurridos = stopwatch.ElapsedMilliseconds / 1000.0;
            MessageBox.Show("Operación finalizada en " + segundosTranscurridos + "segundos.");
        }

        private async Task ProcesarTarjetas(List<string>tarjetas)
        {
            var tareas = new List<Task>();

            foreach(var tarjeta in tarjetas)
            {
                var json = JsonConvert.SerializeObject(tarjeta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // en repuestaTask prepara el request, el post
                var respuestaTask = httpClient.PostAsync(apiURL + "/tarjetas", content);
                tareas.Add(respuestaTask);
            }

            // Cada tarjeta es un hilo

            await Task.WhenAll(tareas);
            

        }
    }
}
