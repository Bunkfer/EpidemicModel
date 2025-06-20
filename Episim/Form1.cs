using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Sim03;
using System.IO;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Collections.Generic; // Asegúrate de que el namespace coincide con donde están definidas Bola, MallaEspacial y InterfaceManager

namespace Sim03
{
    public partial class Form1 : Form
    {
        //Variables
        #region Form
        private Bitmap perlinNoiseBitmap;  // Campo de clase para almacenar el bitmap
        public Bola[] bolas;
        private MallaEspacial mallaEspacial;

        public float[,] TerrainCopy { get; set; }
        public float[,] MX { get; set; }
        public float[,] MY { get; set; }
        public int[] countsV { get; set; }
        private bool isFirstTimeWriting { get; set; } = true;
        private bool _isSimulationInitialized { get; set; } = false; // Variable de respaldo
             
        public Panel PanelConfig
        {
            get { return panelConfig; }
        }

        public bool isSimulationInitialized
        {
            get { return _isSimulationInitialized; }
            set { _isSimulationInitialized = value; }
        }
        #endregion

        //Construccion Form
        #region Construccion
        public Form1()
        {
            InitializeComponent();
            

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.BackColor = Color.DarkGray;

            InterfaceManager.customizeDesign(this, panelPropSubmenu, panelMain);

            InterfaceManager.SetupCustomTitleBar(this, panelMain);
            SetupChart();
        }

        private void InitializeSimulation()
        {
            int totalBolas = VariablesEpModel.numeroBolas;
            int[] bolasPorEstado = VariablesEpModel.bolasPorEstado;

            bolas = new Bola[totalBolas];
            Random random = new Random();
            int ancho = this.ClientSize.Width;
            int alto = this.ClientSize.Height;
            mallaEspacial = new MallaEspacial(ancho, alto, VariablesEpModel.TamañoCelda);
            countsV = new int[VariablesEpModel.T.GetLength(0)];

            if (bolasPorEstado == null || bolasPorEstado.Length == 0)
            {
                // Modo aleatorio si no se especifica la cantidad por estado
                for (int i = 0; i < totalBolas; i++)
                {
                    var estadoInicial = random.Next(0, VariablesEpModel.T.GetLength(0));
                    var ubicacionInicial = new PointF(random.Next(0, ancho), random.Next(0, alto));

                    bolas[i] = new Bola(ubicacionInicial, estadoInicial);
                    mallaEspacial.AñadirBola(bolas[i]);
                    countsV[estadoInicial]++;
                }
            }
            else
            {
                // Modo definido si bolasPorEstado está especificado
                if (bolasPorEstado.Sum() != totalBolas)
                {
                    throw new Exception("The total number of balls does not match the configured number.");
                }

                int estadoActual = 0;
                int bolasAsignadas = 0;

                for (int i = 0; i < totalBolas; i++)
                {
                    if (bolasAsignadas >= bolasPorEstado[estadoActual])
                    {
                        estadoActual++;
                        bolasAsignadas = 0;
                    }

                    var ubicacionInicial = new PointF(random.Next(0, ancho), random.Next(0, alto));
                    bolas[i] = new Bola(ubicacionInicial, estadoActual);

                    mallaEspacial.AñadirBola(bolas[i]);
                    countsV[estadoActual]++;
                    bolasAsignadas++;
                }
            }

            // Imprimir conteo inicial para verificar
            Debug.WriteLine($"Conteo inicial: {string.Join(", ", countsV)}");
        }

        public void SetPanelConfigVisibility(bool isVisible)
        {
            panelConfig.Visible = isVisible;
        }

        private void ActualizarTiempoEjecucion(TimeSpan reloj)
        {
            rTEjec.Clear();  // Limpia el contenido actual

            // Establece "Ejecución:" en color blanco
            rTEjec.SelectionColor = Color.White;
            rTEjec.AppendText("Execution Time: ");  // Añade texto "Ejecución:" en blanco

            // Determina el color del texto según el tiempo de ejecución
            int tiempo = (int)Math.Round(reloj.TotalMilliseconds);
            if (tiempo < 90)
            {
                rTEjec.SelectionColor = Color.Green;  // Tiempo rápido, color verde
            }
            else if (tiempo >= 90 && tiempo <= 140)
            {
                rTEjec.SelectionColor = Color.Yellow;  // Tiempo medio, color amarillo
            }
            else
            {
                rTEjec.SelectionColor = Color.Red;  // Tiempo lento, color rojo
            }

            rTEjec.AppendText($"{tiempo} ms");  // Añade el tiempo de ejecución en el color seleccionado
            rTEjec.SelectionAlignment = HorizontalAlignment.Center;
            rTEjec.SelectionColor = rTEjec.ForeColor;  // Restablece el color a la configuración predeterminada
        }

        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.Series.Add("Estados");
            chart1.Series["Estados"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series["Estados"].IsVisibleInLegend = false;
        }

        public void Stadistics()
        {
            chart1.Visible = true;
            //chart1.BackColor = Color.FromArgb(35, 32, 39);
            chart1.Series["Estados"].Points.Clear();
            
            for (int i = 0; i < countsV.Length; i++)
            {
                var point = chart1.Series["Estados"].Points.AddXY(i, countsV[i]);
                chart1.Series["Estados"].Points[i].Color = VariablesEpModel.colores[i];
                chart1.Series["Estados"].Points[i].Label = VariablesEpModel.nombre[i];
                
            }
        }

        public void SaveStatisticsToCSV(string filePath)
        {
            try
            {
                // Si es la primera vez, sobrescribimos el archivo y escribimos el encabezado
                if (isFirstTimeWriting)
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false)) // false para sobrescribir
                    {
                        // Crear el encabezado dinámicamente usando los nombres en bolas[0].nombre
                        string header = string.Join(",", VariablesEpModel.nombre); // Usa los nombres de los estados
                        writer.WriteLine(header);

                        // Escribir los datos de countsV
                        string data = string.Join(",", countsV); // Une los valores del arreglo countsV con comas
                        writer.WriteLine(data);
                    }

                    isFirstTimeWriting = false;  // Marcar que ya escribimos una vez
                }
                else
                {
                    // Si no es la primera vez, agregamos nuevas filas al archivo
                    using (StreamWriter writer = new StreamWriter(filePath, true)) // true para agregar
                    {
                        string data = string.Join(",", countsV); // Une los valores del arreglo countsV con comas
                        writer.WriteLine(data); // Escribe la línea en el archivo CSV
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos en CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveStatisticsToCSV(string filePath, int[] bolasPorEstado = null)
        {
            try
            {
                // Si es la primera vez, sobrescribimos el archivo y escribimos el encabezado
                if (isFirstTimeWriting)
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false)) // false para sobrescribir
                    {
                        // Crear el encabezado dinámicamente usando los nombres en VariablesEpModel.nombre
                        string header = string.Join(",", VariablesEpModel.nombre); // Usa los nombres de los estados
                        writer.WriteLine(header);

                        // Escribir la distribución inicial de bolasPorEstado si existe
                        if (bolasPorEstado != null)
                        {
                            string initialState = string.Join(",", bolasPorEstado);
                            writer.WriteLine(initialState); // Escribe la fila de estados iniciales
                        }
                    }

                    isFirstTimeWriting = false; // Marcar que ya escribimos una vez
                }

                // Escribir los datos actuales de countsV
                using (StreamWriter writer = new StreamWriter(filePath, true)) // true para agregar
                {
                    string data = string.Join(",", countsV); // Une los valores del arreglo countsV con comas
                    writer.WriteLine(data); // Escribe la línea en el archivo CSV
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos en CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        //Dibujar simulacion
        #region Dibujar

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.FromArgb(21, 23, 32));

            // Primero dibuja el bitmap de Perlin Noise si existe
            if (perlinNoiseBitmap != null)
            {
                e.Graphics.DrawImage(perlinNoiseBitmap, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            }

            // Luego dibuja las bolas encima del ruido Perlin
            if (bolas != null)
            {
                foreach (var bola in bolas)
                {
                    if (bola != null)
                    {
                        bola.Dibujar(e.Graphics);
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (timer1.Enabled)
            {
                foreach (var bola in bolas)
                {
                    bola.Dibujar(e.Graphics);
                }
            }
        }

        #endregion

        //Eventos
        #region Event
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Stopwatch reloj = new Stopwatch();
            reloj.Restart();
            reloj.Start();
            
            foreach (var bola in bolas)
            {
                var ubicacionAnterior = bola.Ubicacion;
                bola.Mover(this.ClientRectangle, TerrainCopy, MX, MY);
                mallaEspacial.ActualizarBola(bola, ubicacionAnterior);
                countsV = bola.Actualizar(countsV);
            }

            /*
            Parallel.ForEach(bolas, bola => 
            {
                var ubicacionAnterior = bola.Ubicacion;
                bola.Mover(this.ClientRectangle, TerrainCopy, MX, MY);
                mallaEspacial.ActualizarBola(bola, ubicacionAnterior);
                bola.Actualizar();
            });
            */

            foreach (var bola in bolas)
            {
                foreach (var otraBola in mallaEspacial.ObtenerVecinos(bola))
                {
                    countsV = bola.ProcesarColisiones(new[] {otraBola}, countsV);
                }
            }
            reloj.Stop();
            ActualizarTiempoEjecucion(reloj.Elapsed);
            this.Invalidate(); // Redibuja el formulario
            Stadistics();
            //SaveStatisticsToCSV(@"C:\OnedriveOut\Maestria\Tesis\Proyecto\estadisticas.csv", VariablesEpModel.bolasPorEstado);
            SaveStatisticsToCSV(@"..\..\..\Episolver\models\Sim_Result.csv", VariablesEpModel.bolasPorEstado);
        }

        private void Run_1_Click(object sender, EventArgs e)
        {
            InitializeSimulation();
            Run_1.Text = "Running";
            Run_1.BackColor = Color.Yellow;
            Run_1.ForeColor = Color.Black;
            isSimulationInitialized = true; // Marcamos que la simulación ha sido inicializada

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            float sigma = 1.0f;
            float[] VAltura = new float[] { 1.5f, 1f, 1f, 1.5f };
            // Definir los porcentajes relativos a las posiciones horizontales y verticales
            float[] VmuiPercent = new float[] { 0.01f, 0.5f, 0.5f, 0.99f };  // Proporciones horizontales
            float[] VmujPercent = new float[] { 0.1f, 0.8f, 0.99f, 0.1f };    // Proporciones verticales

            // Calcular las posiciones reales según el tamaño actual del formulario
            float[] Vmui = new float[VmuiPercent.Length];
            float[] Vmuj = new float[VmujPercent.Length];
            isFirstTimeWriting = true;

            for (int i = 0; i < VmuiPercent.Length; i++)
            {
                Vmui[i] = VmuiPercent[i] * this.ClientSize.Width;  // Calcula posición en X basada en el tamaño del formulario
                Vmuj[i] = VmujPercent[i] * this.ClientSize.Height; // Calcula posición en Y basada en el tamaño del formulario
            }

            float[] Va = new float[] { 0.0002f, 0.000035f, 0.000008f, 0.0002f };
            float[] Vb = new float[] { 0f, 0f, 0f , 0f };
            float[] Vd = new float[] { 0.000009f, 0.00001f, 0.0002f, 0.000009f };

            try
            {
                float[,] MatrixTerrain = TerrainGenerator.CalcularMatriz(ClientSize.Width, ClientSize.Height, 
                    VAltura, Vmui, Vmuj, Va, Vb, Vd);
                //Revision del campo con derivadas
                //float[,] MatrixTerrain = TerrainGenerator.CheckDerivate(ClientSize.Width, ClientSize.Height);

                TerrainCopy = MatrixTerrain;
                MX = TerrainGenerator.GaussianDerivative(TerrainCopy, sigma, true);  // Derivada en X
                MY = TerrainGenerator.GaussianDerivative(TerrainCopy, sigma, false); // Derivada en Y

                if (VariablesEpModel.GenerateTerrainField)
                {
                    perlinNoiseBitmap = TerrainGenerator.GenerateBitmapFromMatrix(MatrixTerrain, width, height);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating Perlin Noise: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Start_1_Click(object sender, EventArgs e)
        {
            // Verifica si el botón 1 ha sido clickeado antes de proceder
            if (!isSimulationInitialized)
            {
                MessageBox.Show("Please Run the simulation first.", "Simulation Not Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cambia el estado del timer
            timer1.Enabled = !timer1.Enabled;

            // Cambia el texto y color del botón dependiendo de su estado actual
            if (Start_1.Text == "Start")
            {
                Start_1.Text = "Stop";
                Start_1.BackColor = Color.Red;
                Start_1.ForeColor = Color.Black;
            }
            else if (Start_1.Text == "Stop")
            {
                Start_1.Text = "Play";
                Start_1.BackColor = Color.Green;
                Start_1.ForeColor = Color.Black;
            }
            else if (Start_1.Text == "Play")
            {
                Start_1.Text = "Stop";
                Start_1.BackColor = Color.Red;
                Start_1.ForeColor = Color.Black;
            }
        }

        private void Properties_Click(object sender, EventArgs e)
        {
            InterfaceManager.ShowSubMenu(panelPropSubmenu);
        }

        private void Models_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            panelConfig.Visible = true;
            InterfaceManager.StopSimulation(timer1, Run_1, Start_1, (value) => this.isSimulationInitialized = value);
            InterfaceManager.ClearSimulation(this, this.bolas, this.mallaEspacial, VariablesEpModel.TamañoCelda);
            // Pasar 'this' como referencia al nuevo Form2
            InterfaceManager.OpenChildForm(this, new Form3(this)); // Abrir Form2
            InterfaceManager.HideSubMenu(panelPropSubmenu);
        }

        private void Config_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            panelConfig.Visible = true;
            InterfaceManager.StopSimulation(timer1, Run_1, Start_1, (value) => this.isSimulationInitialized = value);
            InterfaceManager.ClearSimulation(this, this.bolas, this.mallaEspacial, VariablesEpModel.TamañoCelda);
            // Pasar 'this' como referencia al nuevo Form2
            InterfaceManager.OpenChildForm(this, new Form2(this)); // Abrir Form2
            InterfaceManager.HideSubMenu(panelPropSubmenu);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            chart1.Visible = false;
            perlinNoiseBitmap = null;
            InterfaceManager.StopSimulation(timer1, Run_1, Start_1 ,(value) => this.isSimulationInitialized = value);
            InterfaceManager.ClearSimulation(this, this.bolas, this.mallaEspacial, VariablesEpModel.TamañoCelda);
            InterfaceManager.HideSubMenu(panelPropSubmenu);
        }

        private void BttnHideMain_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelSideMenu.Visible = false;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            panelMain.Visible = false;
            panelSideMenu.Visible = true;
        }
        #endregion

    }
}

