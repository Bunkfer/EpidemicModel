using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sim03;

namespace Sim03
{
    public partial class Form2 : Form
    {
        //Variables
        #region Variables Form2
        private Form1 form1; // Referencia al Form1      
        
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1; // Asignar la referencia local
            this.bApply.Click -= this.bApply_Click;  // Desasignar primero para evitar duplicados
            this.bApply.Click += this.bApply_Click;  // Reasignar el evento

            //Variables para el numero de bolas
            string Tball = "1k - 10k";
            trackBar1.Value = 10000;  // Valor inicial
            labelNum.Text = trackBar1.Value.ToString();
            tBnumeroBolas.Text = Tball;  // Texto placeholder
            tBnumeroBolas.ForeColor = Color.Gray;  // Color gris para el texto placeholder
            SetUpTextBoxPlaceholder(tBnumeroBolas, Tball);

            //Variables para tamaño de celda
            string Tcell = "10 - 50";
            trackBar2.Value = 20;
            labelCell.Text = trackBar2.Value.ToString();
            tBTamCell.Text = Tcell;  // Texto placeholder
            tBTamCell.ForeColor = Color.Gray;
            SetUpTextBoxPlaceholder(tBTamCell, Tcell);

            //Variables para radio de bola
            string Tradio = "1 - 10";
            trackBar3.Value = 3;
            labelRadio.Text = trackBar3.Value.ToString();
            tBRadio.Text = Tradio;  // Texto placeholder
            tBRadio.ForeColor = Color.Gray;
            SetUpTextBoxPlaceholder(tBRadio, Tradio);

            //Variables para distancia de contagio
            string Tcontdist = "1 - 50";
            trackBar4.Value = 5;
            labelContDist.Text = trackBar4.Value.ToString();
            tBContDist.Text = Tcontdist;  // Texto placeholder
            tBContDist.ForeColor = Color.Gray;
            SetUpTextBoxPlaceholder(tBContDist, Tcontdist);
        }
        #endregion

        //Metodos
        #region Metodos Form2
        private void SetUpTextBoxPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                TextBox tb = sender as TextBox;
                if (tb != null && tb.Text == placeholder)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                TextBox tb = sender as TextBox;
                if (tb != null && string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        private void UpdateParameter(TextBox textBox, TrackBar trackBar, Label label, int min, int max, string placeholder, Action<int> updateAction, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text == placeholder)
            {
                // Actualizamos usando el valor del TrackBar
                updateAction(trackBar.Value);
                textBox.Text = "";  // Limpiar el TextBox
                label.Text = trackBar.Value.ToString();  // Actualizar la etiqueta
                MessageBox.Show($"{parameterName} updated: " + trackBar.Value);
            }
            else
            {
                // Intentar convertir el texto del TextBox a número
                if (int.TryParse(textBox.Text, out int newValue))
                {
                    if (newValue >= min && newValue <= max) // Verificar rango
                    {
                        // Actualizamos y sincronizamos el TrackBar
                        updateAction(newValue);
                        trackBar.Value = newValue;  // Asegurar que el TrackBar muestre el valor actualizado
                        textBox.Text = "";  // Limpiar el TextBox
                        label.Text = trackBar.Value.ToString();  // Actualizar la etiqueta
                        MessageBox.Show($"{parameterName} updated: " + newValue);
                    }
                    else
                    {
                        MessageBox.Show($"Please enter a number between {min} - {max}");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.");
                }
            }
        }
        #endregion

        //Eventos
        #region Eventos Form2
        private void AceptarConfig_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.SetPanelConfigVisibility(false);
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (cBNumInd.Checked)
            {
                UpdateParameter(tBnumeroBolas, trackBar1, labelNum, 1000, 10000, "1k - 10k", newValue => VariablesEpModel.numeroBolas = newValue, "Number of Balls");
            }
            if (cBTamCell.Checked)
            {
                UpdateParameter(tBTamCell, trackBar2, labelCell, 10, 50, "10 - 50", newValue => VariablesEpModel.TamañoCelda = newValue, "Cell Size");
            }
            if (cBRadio.Checked)
            {
                UpdateParameter(tBRadio, trackBar3, labelRadio, 1, 10, "1 - 10", newValue => VariablesEpModel.Radio = newValue, "Ball Radius");
            }
            if (cBContDist.Checked)
            {
                UpdateParameter(tBContDist, trackBar4, labelContDist, 1, 50, "1 - 50", newValue => VariablesEpModel.ContagioDistancia = newValue, " Infection Distance");
            }
            if (CBTerrain.Checked)
            {
                MessageBox.Show($"Simulation WITH Terrain");
                VariablesEpModel.GenerateTerrainField = true;
                VariablesEpModel.GenerateTerrainMove = true;
            }
            if (cBNoTerrain.Checked)
            {
                MessageBox.Show($"Simulation WITHOUT Terrain");
                VariablesEpModel.GenerateTerrainField = false;
                VariablesEpModel.GenerateTerrainMove = false;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelNum.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            labelCell.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            labelRadio.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            labelContDist.Text = trackBar4.Value.ToString();
        }
        
        private void CBTerrain_CheckedChanged(object sender, EventArgs e)
        {
            // Desactivar temporalmente el evento del otro CheckBox
            cBNoTerrain.CheckedChanged -= cBNoTerrain_CheckedChanged;
            cBNoTerrain.Checked = false;
            cBNoTerrain.CheckedChanged += cBNoTerrain_CheckedChanged; ;
        }

        private void cBNoTerrain_CheckedChanged(object sender, EventArgs e)
        {
            CBTerrain.CheckedChanged -= CBTerrain_CheckedChanged;
            CBTerrain.Checked = false;
            CBTerrain.CheckedChanged += CBTerrain_CheckedChanged;
        }
        #endregion
    }
}
