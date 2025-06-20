using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sim03
{
    //Variables Universales
    public static class VariablesEpModel
    {
        public static int[] bolasPorEstado { get; set; } = { };

        public static int numeroBolas { get; set; } = 10000;

        public static int Radio { get; set; } = 3;

        public static int ContagioDistancia { get; set; } = 5;

        public static bool GenerateTerrainMove { get; set; } = true;

        public static bool GenerateTerrainField { get; set; } = true;

        public static string[] nombre { get; set; }  = { "S", "V", "E", "Is", "Ia", "Q", "R", "M" };

        public static int TamañoCelda { get; set; } = 20;

        public static double[,] T { get; set; } =
        {
            {0.5,0.5,0.0,0.0,0.0,0.0,0.0,0.0 }, //S
            {0.5,0.5,0.0,0.0,0.0,0.0,0.0,0.0 }, //V
            {0.0,0.0,0.25,0.25,0.25,0.25,0.0,0.0 }, //E
            {0.0,0.0,0.0,0.25,0.0,0.25,0.25,0.25 }, //Is
            {0.0,0.0,0.0,0.0,0.5,0.0,0.5,0.0 }, //Ia
            {0.0,0.0,0.0,0.0,0.0,0.3333,0.3333,0.3334 }, //Q
            {0.5,0.0,0.0,0.0,0.0,0.0,0.5,0.0 }, //R
            {0.0,0.0,0.0,0.0,0.0,0.0,0.0,1.0 } //M
        };

        public static int[,] D { get; set; } =
        {
            {50,100 },
            {50,100 },
            {0,1 },
            {25,50 },
            {25,50 },
            {25,50 },
            {0,1 },
            {0,1 },
        };

        public static Color[] colores { get; set; } = new Color[]
        {
            Color.FromArgb(144, 238, 144), // LightGreen
            Color.FromArgb(173, 216, 230), // LightBlue
            Color.FromArgb(128, 128, 128), //Prueba Gris
            Color.FromArgb(255, 0, 0),     // Red
            Color.FromArgb(255, 165, 0),   // Orange
            Color.FromArgb(255, 255, 0),   // Yellow
            Color.FromArgb(0, 128, 0),     // Green
            Color.FromArgb(11, 7, 17)        // Black
        };

        public static int EstadoMuertoIndex
        {
            get
            {
                // Retorna el índice de "M" o -1 si no existe en el arreglo actual
                return Array.IndexOf(nombre, "M");
            }
        }

        public static int estadoInicialContagio { get; set; } = 0; // Por defecto es 0, el estado inicial

        public static int estadoExpuesto { get; set; } = 2; // Por defecto es 2, el estado de exposición
    }
    public class Bola
    {
        //Variables
        #region VBall
        private static readonly Random random = new Random();
        public int duracionEstado { get; set; } = 100;
        public bool active { get; set; }
        public int IteracionesEstado { get; set; }
        public PointF Velocidad { get; set; }

        //Variables usadas en varios programas
        public int Estado { get; set; }
        public PointF Ubicacion { get; set; }
        #endregion

        //Funciones Ball
        #region FBall
        public Bola(PointF ubicacion, int estado)
        {
            Estado = estado;
            IteracionesEstado = 0;
            duracionEstado = random.Next(VariablesEpModel.D[Estado,0], VariablesEpModel.D[Estado, 1]+1);
            Ubicacion = ubicacion;
            active = true;
            Velocidad = new PointF(random.Next(-5, 6), random.Next(-5, 6));
            
        }
        
        public void Mover(Rectangle bounds, float[,] TerrainCopy, float[,]  MX, float[,]  MY)
        {
            float pendiente = 400;

            int i = (int)Math.Round((double)Math.Max(0, Math.Min(Ubicacion.X, TerrainCopy.GetLength(0) - 1)));
            int j = (int)Math.Round((double)Math.Max(0, Math.Min(Ubicacion.Y, TerrainCopy.GetLength(1) - 1)));
            float [,] perlinValue = TerrainCopy;

            float mx = MX[i,j]*pendiente;
            float my = MY[i,j]*pendiente;


            if (active == false)
            {
                Velocidad = new PointF(random.Next(0, 0), random.Next(0, 0));
            }

            if (VariablesEpModel.GenerateTerrainMove)
            {
                Ubicacion = new PointF(Ubicacion.X + mx + Velocidad.X, Ubicacion.Y + my + Velocidad.Y);
                //Revision de solamente derivadas
                //Ubicacion = new PointF(Ubicacion.X + mx, Ubicacion.Y + my);
            }
            else
            {
                Ubicacion = new PointF(Ubicacion.X  + Velocidad.X, Ubicacion.Y  + Velocidad.Y);
            }

            if (Ubicacion.X < 0 || Ubicacion.X > bounds.Width)
                Velocidad = new PointF(-Velocidad.X, Velocidad.Y);
            if (Ubicacion.Y < 0 || Ubicacion.Y > bounds.Height)
                Velocidad = new PointF(Velocidad.X, -Velocidad.Y);
        }

        public int[] Actualizar(int[] countsV)
        {
            double r = random.NextDouble();
            double acum = 0.0;
            IteracionesEstado++;
            if (IteracionesEstado >= duracionEstado)
            {
                for (int i = 0; i < VariablesEpModel.T.GetLength(1); i++)
                {
                    acum += VariablesEpModel.T[Estado, i];
                    if (acum >= r)
                    {
                        countsV[Estado]--;
                        Estado = i;
                        countsV[Estado]++;
                        IteracionesEstado = 0;
                        duracionEstado = random.Next(VariablesEpModel.D[Estado, 0], VariablesEpModel.D[Estado, 1] + 1);
                        break;
                    }
                }
                if (Estado == VariablesEpModel.EstadoMuertoIndex)
                {
                    active = false;
                }
            }

            return countsV;
        }
        
        public void Dibujar(Graphics g)
        {
            Color color = VariablesEpModel.colores[Estado];
            using (Brush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, Ubicacion.X - VariablesEpModel.Radio, Ubicacion.Y - VariablesEpModel.Radio, VariablesEpModel.Radio * 2, VariablesEpModel.Radio * 2);
            }
        }
        
        public bool ColisionaCon(Bola otraBola)
        {
            var distancia = Math.Sqrt(Math.Pow(Ubicacion.X - otraBola.Ubicacion.X, 2) +
                                      Math.Pow(Ubicacion.Y - otraBola.Ubicacion.Y, 2));
            return distancia < VariablesEpModel.ContagioDistancia;
        }

        public int[] ProcesarColisiones(Bola[] bolas, int[] countsV)
        {
            foreach (var bola in bolas)
            {
                if (bola != this && ColisionaCon(bola))
                {
                    if (Estado == VariablesEpModel.estadoInicialContagio && bola.Estado == VariablesEpModel.estadoExpuesto)
                    {
                        countsV[Estado]--;
                        Estado = bola.Estado;
                        //Estado = VariablesEpModel.estadoExpuesto;
                        countsV[Estado]++;
                    }
                }
            }
            return countsV;
        }
        #endregion
    }

    public class MallaEspacial
    {
        //Variables
        #region Variables Malla Espacial 
        private readonly float anchoCelda;
        private readonly float altoCelda;
        private readonly Dictionary<PointF, List<Bola>> celdas;
        private readonly int anchoMalla;
        private readonly int altoMalla;
        #endregion

        //Funciones Malla
        #region FMalla

        public MallaEspacial(int anchoMalla, int altoMalla, int tamañoCelda)
        {
            this.anchoMalla = anchoMalla;
            this.altoMalla = altoMalla;
            this.anchoCelda = tamañoCelda;
            this.altoCelda = tamañoCelda;
            celdas = new Dictionary<PointF, List<Bola>>();

            for (int x = 0; x < anchoMalla / anchoCelda; x++)
            {
                for (int y = 0; y < altoMalla / altoCelda; y++)
                {
                    celdas[new PointF(x, y)] = new List<Bola>();
                }
            }
        }

        public void EliminarBola(Bola bola, PointF ubicacionAnterior)
        {
            var celda = ObtenerCelda(ubicacionAnterior);
            if (celdas.ContainsKey(celda))
            {
                celdas[celda].Remove(bola);
            }
        }

        public void AñadirBola(Bola bola)
        {
            var celda = ObtenerCelda(bola.Ubicacion);
            if (!celdas.ContainsKey(celda))
            {
                celdas[celda] = new List<Bola>();
            }
            celdas[celda].Add(bola);
        }

        public void ActualizarBola(Bola bola, PointF ubicacionAnterior)
        {
            EliminarBola(bola, ubicacionAnterior);
            AñadirBola(bola);
        }

        private PointF ObtenerCelda(PointF ubicacion)
        {
            int x = (int)(ubicacion.X / anchoCelda);
            int y = (int)(ubicacion.Y / altoCelda);
            return new PointF(x, y);
        }

        public IEnumerable<Bola> ObtenerVecinos(Bola bola)
        {
            var celdaActual = ObtenerCelda(bola.Ubicacion);
            var celdasVecinas = ObtenerCeldasVecinas(celdaActual);
            foreach (var celda in celdasVecinas)
            {
                if (celdas.ContainsKey(celda))
                {
                    foreach (var otraBola in celdas[celda])
                    {
                        if (bola != otraBola)
                        {
                            yield return otraBola;
                        }
                    }
                }
            }
        }
        
        private IEnumerable<PointF> ObtenerCeldasVecinas(PointF celda)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    yield return new PointF(celda.X + dx, celda.Y + dy);
                }
            }
        }
        #endregion
    }

    public static class TerrainGenerator
    {
        public static Bitmap GenerateBitmapFromMatrix(float[,] perlinNoiseMatrix, int width, int height)
        {
            // Crear un bitmap del tamaño correcto
            Bitmap bitmap = new Bitmap(width, height);

            // Calcula la resolución del grid de Perlin Noise para adaptarla al tamaño del bitmap
            int gridWidth = perlinNoiseMatrix.GetLength(0);
            int gridHeight = perlinNoiseMatrix.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Calcula la posición correcta en la matriz de ruido Perlin
                    int gridX = (int)((float)x / width * (gridWidth - 1));
                    int gridY = (int)((float)y / height * (gridHeight - 1));

                    // Asegúrate de que gridX y gridY estén dentro de los límites
                    gridX = Clamp(gridX, 0, gridWidth - 1);
                    gridY = Clamp(gridY, 0, gridHeight - 1);

                    // Obtén el valor de ruido Perlin y escálalo de 0 a 255 para representarlo como color
                    float value = perlinNoiseMatrix[gridX, gridY];
                    int colorValue = (int)((value - 0.5f) * 255 * 2); // Aumenta el contraste
                    colorValue = Clamp(colorValue, 30, 255);  // Evita que el valor caiga por debajo de 30

                    // Crear un color en escala de grises
                    Color color = Color.FromArgb(colorValue, colorValue, colorValue);

                    // Establecer el color del pixel
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static float[,] CalcularMatriz(int sizeX, int sizeY, float[] altura, float[] mui, float[] muj, float[] a, float[] b, float[] d)
        {
            float[,] matriz = new float[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                {
                    matriz[x, y] = 0;
                    for (int k = 0; k < mui.Length; k++)
                    {
                        float i = x - mui[k];
                        float j = y - muj[k];
                        matriz[x, y] = matriz[x, y] + altura[k] * (float)Math.Exp(-(i * i * a[k]) - (2 * i * j * b[k]) - (j * j * d[k]));
                    }
                }
            return matriz;
        }

        public static float[,] GaussianDerivative(float[,] M, float sigma, bool isX)
        {
            int width = M.GetLength(0);
            int height = M.GetLength(1);
            float[,] derivative = new float[width, height];

            // Tamaño del kernel gaussiano (lo suficiente para contener la mayoría de la distribución)
            int kernelRadius = (int)(3.0f * sigma);
            int kernelSize = 2 * kernelRadius + 1;

            // Crear el kernel gaussiano
            float[] gaussianKernel = new float[kernelSize];
            float[] gaussianDerivativeKernel = new float[kernelSize];

            // Constantes
            float sigma2 = sigma * sigma;
            float sigma4 = sigma2 * sigma2;
            float normalization = 1.0f / (float)(Math.Sqrt(2.0 * Math.PI) * sigma);

            // Calcular el kernel gaussiano y su derivada
            for (int x = -kernelRadius; x <= kernelRadius; x++)
            {
                gaussianKernel[x + kernelRadius] = normalization * (float)Math.Exp(-(x * x) / (2 * sigma2));
                gaussianDerivativeKernel[x + kernelRadius] = -x / sigma2 * gaussianKernel[x + kernelRadius];
            }

            // Aplicar el filtro gaussiano y su derivada
            if (isX)
            {
                // Derivada en X
                for (int y = kernelRadius; y < height - kernelRadius; y++)
                {
                    for (int x = kernelRadius; x < width - kernelRadius; x++)
                    {
                        float sum = 0.0f;
                        for (int k = -kernelRadius; k <= kernelRadius; k++)
                        {
                            sum += M[x + k, y] * gaussianDerivativeKernel[k + kernelRadius];
                        }
                        derivative[x, y] = sum;
                    }
                }
            }
            else
            {
                // Derivada en Y
                for (int y = kernelRadius; y < height - kernelRadius; y++)
                {
                    for (int x = kernelRadius; x < width - kernelRadius; x++)
                    {
                        float sum = 0.0f;
                        for (int k = -kernelRadius; k <= kernelRadius; k++)
                        {
                            sum += M[x, y + k] * gaussianDerivativeKernel[k + kernelRadius];
                        }
                        derivative[x, y] = sum;
                    }
                }
            }

            return derivative;
        }

        /*Se usa para revisar el terreno y movimiento
        1. Movimiento en EpModel.cs -> Funcion "Mover"
        2. Terreno en Form1.cs -> Evento "Run_1_Click"*/
        public static float[,] CheckDerivate(int Width, int Height)
        {
            float[,] perlinNoiseMatrix = new float[Width, Height];
            for (int i = 0; i < perlinNoiseMatrix.GetLength(0); i++)
            {
                for (int j = 0;  j < perlinNoiseMatrix.GetLength(1); j++)
                {
                    float R = (float)Math.Pow(((float)(2.0 * i) / (float)perlinNoiseMatrix.GetLength(0)) - 1, 2) +
                        (float)Math.Pow(((float)(2.0 * j) / (float)perlinNoiseMatrix.GetLength(1)) - 1, 2);
                    perlinNoiseMatrix[i, j] = 1-((float)Math.Cos( Math.Sqrt(R) * Math.Sqrt(2) * Math.PI*3));
                }
            }
            return perlinNoiseMatrix;
        }
    }
}
