using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sim03
{
    public partial class Form3 : Form
    {
        private Form1 form1; // Referencia al Form1   
        private string previousState { get; set; }
        private bool isUpdatingCheckBoxes { get; set; } = false;
        private Dictionary<string, Color> colorMap { get; set; } = new Dictionary<string, Color>

        {
            // Verdes y azules claros
            { "LightGreen", System.Drawing.Color.FromArgb(144, 238, 144) },
            { "LightBlue", System.Drawing.Color.FromArgb(173, 216, 230) },
    
            // Grises y neutros
            { "Gray", System.Drawing.Color.FromArgb(128, 128, 128) },
            { "White", System.Drawing.Color.FromArgb(255, 255, 255) },
            { "Black", System.Drawing.Color.FromArgb(11, 7, 17) },
    
            // Rojos, amarillos y naranjas
            { "Red", System.Drawing.Color.FromArgb(255, 0, 0) },
            { "Orange", System.Drawing.Color.FromArgb(255, 165, 0) },
            { "Yellow", System.Drawing.Color.FromArgb(255, 255, 0) },
            { "Gold", System.Drawing.Color.FromArgb(255, 215, 0) },       // Dorado
    
            // Verdes
            { "Green", System.Drawing.Color.FromArgb(0, 128, 0) },
            { "ForestGreen", System.Drawing.Color.FromArgb(34, 139, 34) }, // Verde bosque
    
            // Morados y lavandas
            { "Lavender", System.Drawing.Color.FromArgb(230, 230, 250) },
            { "Purple", System.Drawing.Color.FromArgb(128, 0, 128) },
            { "MediumPurple", System.Drawing.Color.FromArgb(147, 112, 219) },
            { "DarkPurple", System.Drawing.Color.FromArgb(75, 0, 130) },  // Púrpura oscuro
            { "Orchid", System.Drawing.Color.FromArgb(218, 112, 214) },   // Orquídea
    
            // Azules y cian
            { "SkyBlue", System.Drawing.Color.FromArgb(135, 206, 235) },
            { "DodgerBlue", System.Drawing.Color.FromArgb(30, 144, 255) },
            { "DeepSkyBlue", System.Drawing.Color.FromArgb(0, 191, 255) },
    
            // Rosas
            { "Pink", System.Drawing.Color.FromArgb(255, 192, 203) },
            { "DeepPink", System.Drawing.Color.FromArgb(255, 20, 147) },
    
            // Marrones
            { "Brown", System.Drawing.Color.FromArgb(139, 69, 19) },
            { "Chocolate", System.Drawing.Color.FromArgb(210, 105, 30) },
    
            // Tonos adicionales de naranjas y rojos
            { "Coral", System.Drawing.Color.FromArgb(255, 127, 80) },
            { "Tomato", System.Drawing.Color.FromArgb(255, 99, 71) },
        };
        private string[] Names { get; set; } = { "S", "V", "E", "Is", "Ia", "I", "A", "Q", "R", "M", "-" };
        private string[] remove_states => Names.Where(name => name != "-").ToArray();

        public Form3(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1; // Asignar la referencia local
            this.Load += Form3_Load;
        }

        #region Eventos
        private void AcceptModel_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.SetPanelConfigVisibility(false);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            #region Colores datagridview           
            // Obtener la columna ComboBox
            var colorColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Color"];

            // Limpiar cualquier elemento previo en la columna ComboBox
            colorColumn.Items.Clear();

            // Agregar los nombres de los colores al ComboBox
            foreach (var colorName in colorMap.Keys)
            {
                colorColumn.Items.Add(colorName);
            }
            #endregion

            #region Estados datagridview
            // Obtener la columna ComboBox de estados
            var statesColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["States"];

            // Limpiar cualquier elemento previo en la columna ComboBox de estados
            statesColumn.Items.Clear();

            // Agregar los nombres de los estados al ComboBox de la columna de estados
            foreach (var state in Names)
            {
                statesColumn.Items.Add(state);
            }
            #endregion

            #region Interaction datagridview
            // Configuración de la columna Action como ComboBox con opciones
            var actionColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Action"];
            actionColumn.Items.Clear();
            actionColumn.Items.Add("->");
            actionColumn.Items.Add("o");
            actionColumn.Items.Add("");
            #endregion

            #region Eventos requeridos
            // Suscribir eventos
            cBvseiqr.Checked = true;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            cBsis.CheckedChanged += cBsis_CheckedChanged;
            cBsir.CheckedChanged += cBsir_CheckedChanged;
            cBempty.CheckedChanged += cBempty_CheckedChanged;
            cBvseiqr.CheckedChanged += cBvseiqr_CheckedChanged;
            #endregion
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Color"].Index && e.RowIndex >= 0)
            {
                if (e.Value is string colorName && colorMap.TryGetValue(colorName, out Color color))
                {
                    // Dibujar el fondo con el color deseado
                    e.Graphics.FillRectangle(new SolidBrush(color), e.CellBounds);

                    // Crear un borde personalizado
                    using (Pen customPen = new Pen(System.Drawing.Color.FromArgb(180, 180, 180)))
                    {
                        e.Graphics.DrawRectangle(customPen, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
                    }

                    // Indicar que la celda está pintada y cancelar el evento de pintura estándar
                    e.Handled = true;
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["States"].Index)
            {
                if (e.Control is ComboBox comboBox)
                {
                    // Guardar el estado actual antes de que sea cambiado
                    previousState = dataGridView1.CurrentCell.Value?.ToString();

                    // Desuscribir cualquier evento previo para evitar múltiples suscripciones
                    comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
                    // Suscribir el evento para verificar duplicados
                    comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                }
            }
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                // Obtener el valor seleccionado
                string selectedValue = comboBox.SelectedItem.ToString();
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                // Si el valor es "-", limpiar la fila y la columna del estado anterior
                if (selectedValue == "-")
                {
                    // Limpiar todas las celdas de la fila excepto la de estado
                    foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
                    {
                        if (cell.ColumnIndex != columnIndex) // Excluir la columna de estado
                        {
                            cell.Value = null; // Limpiar el contenido de la celda
                        }
                    }

                    // Limpiar las celdas de la columna correspondiente al estado anterior y eliminar la columna
                    if (!string.IsNullOrEmpty(previousState) && dataGridView1.Columns.Contains(previousState))
                    {
                        int previousColumnIndex = dataGridView1.Columns[previousState].Index;

                        // Limpiar la columna y eliminarla
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells[previousColumnIndex].Value = null;
                        }
                        dataGridView1.Columns.Remove(previousState); // Eliminar la columna del estado anterior
                    }

                    // Eliminar la fila actual
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    return;
                }

                // Verificar duplicados solo si el valor no es "-"
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index != rowIndex) // Ignorar la fila actual
                    {
                        if (row.Cells[columnIndex].Value != null && row.Cells[columnIndex].Value.ToString() == selectedValue)
                        {
                            MessageBox.Show("Este valor ya está seleccionado en otra fila. Por favor, elige un valor diferente.", "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            comboBox.SelectedIndex = -1; // Quitar la selección
                            return;
                        }
                    }
                }

                // Agregar columnas solo en la columna de "States" y si cBempty está marcado
                if (cBempty.Checked && dataGridView1.Columns[columnIndex].Name == "States")
                {
                    // Verificar si la columna para el estado seleccionado ya existe
                    if (!dataGridView1.Columns.Contains(selectedValue))
                    {
                        // Crear una nueva columna para el estado seleccionado
                        DataGridViewTextBoxColumn newStateColumn = new DataGridViewTextBoxColumn
                        {
                            Name = selectedValue,
                            HeaderText = selectedValue,
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        };

                        // Agregar la columna al DataGridView
                        dataGridView1.Columns.Add(newStateColumn);
                    }
                }

                // Confirmar el valor si no hay duplicados
                dataGridView1.CurrentCell.Value = selectedValue;
                dataGridView1.EndEdit(); // Terminar la edición para aplicar el valor
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns.Contains("Color") && e.ColumnIndex == dataGridView1.Columns["Color"].Index && e.RowIndex >= 0)
            {
                // Invalidar la celda para redibujarla
                dataGridView1.InvalidateCell(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cBsis_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBoxes) return;
            // Verificar si el CheckBox está seleccionado
            if (cBsis.Checked)
            {
                DeselectAllExcept(cBsis);
                pBmodel.Image = Image.FromFile(@"..\..\img\sis.png");
                pBmodel.SizeMode = PictureBoxSizeMode.Zoom;
                pBmodel.BackColor = System.Drawing.Color.White;
                // Limpiar todos los valores en el DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = null; // Limpiar cada celda
                    }
                }

                // Eliminar columnas correspondientes a los estados
                foreach (string state in remove_states)
                {
                    if (dataGridView1.Columns.Contains(state))
                    {
                        dataGridView1.Columns.Remove(state); // Eliminar la columna si existe
                    }
                }

                //Modelo que agrega el check box
                string[] states = { "S", "I"}; // Los nombres de las columnas de estados
                string[] colores = { "LightGreen", "Red"};
                int[,] D =
                {
                    {0, 1},
                    {8, 10},
                };

                double[,] T =
                {
                    {1.0, 0.0},
                    {0.79, 0.21}
                };

                int[] Qty = { 8500, 1500};

                add_Matrix(states, colores, D, T, Qty);

                for (int i = 0; i < states.Length; i++)
                {
                    // Asignar valores específicos a la columna Action para "S" y "I"
                    if (states[i] == "S")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "->";
                    }
                    else if (states[i] == "I")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "o";
                    }
                }
            }
        }

        private void cBempty_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBoxes) return;
            // Verificar si el CheckBox está seleccionado
            if (cBempty.Checked)
            {
                DeselectAllExcept(cBempty);
                pBmodel.Image = null;
                pBmodel.BackColor = System.Drawing.Color.FromArgb(21, 23, 32);
                // Limpiar todos los valores en el DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = null; // Limpiar cada celda
                    }
                }

                // Eliminar columnas correspondientes a los estados
                string[] remove_states = { "S", "V", "E", "Is", "Ia", "I", "Q", "R", "M" };
                foreach (string state in remove_states)
                {
                    if (dataGridView1.Columns.Contains(state))
                    {
                        dataGridView1.Columns.Remove(state); // Eliminar la columna si existe
                    }
                }
            }
        }

        private void cBvseiqr_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBoxes) return;
            // Verificar si el CheckBox está seleccionado
            if (cBvseiqr.Checked)
            {
                DeselectAllExcept(cBvseiqr);
                pBmodel.Image = Image.FromFile(@"..\..\img\vseiqr.png");
                pBmodel.SizeMode = PictureBoxSizeMode.Zoom;
                pBmodel.BackColor = System.Drawing.Color.White;
                // Limpiar todos los valores en el DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = null; // Limpiar cada celda
                    }
                }

                // Eliminar columnas correspondientes a los estados
                foreach (string state in remove_states)
                {
                    if (dataGridView1.Columns.Contains(state))
                    {
                        dataGridView1.Columns.Remove(state); // Eliminar la columna si existe
                    }
                }

                //Modelo que agrega el check box
                string[] states = { "S", "V", "E", "Is", "Ia", "Q", "R", "M" }; // Los nombres de las columnas de estados
                string[] colores = { "LightGreen", "LightBlue", "Gray", "Red", "Orange", "Yellow", "Green", "Black" };
                int[,] D =
                {
                    {7, 8},  //S
                    {8, 10}, //V
                    {7, 8},  //E
                    {7, 8},  //Is
                    {7, 8},  //Ia
                    {7, 8},  //Q
                    {7, 8},  //R
                    {0, 1},  //M
                };

                double[,] T =
                {
                  //  S    V    E    Is   Ia   Q    R    M
                    {0.85, 0.15, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},         //S -> S, V
                    {0.1, 0.9, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},           //V -> V, S
                    {0.0, 0.0, 0.78, 0.05, 0.16, 0.01, 0.0, 0.0},       //E -> E, Is, Ia, Q
                    {0.0, 0.0, 0.0, 0.936, 0.0, 0.05, 0.01, 0.004},     //Is -> Is, Q, M, R
                    {0.0, 0.0, 0.0, 0.0, 0.92, 0.0, 0.08, 0.0},         //Ia -> Ia, R 
                    {0.0, 0.0, 0.0, 0.0, 0.0, 0.972, 0.02, 0.008},      //Q -> Q, M, R
                    {0.2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.8, 0.0},           //R -> R, S
                    {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0}            //M
                };

                /*
                int[,] D =
                {
                    {50, 100},  //S
                    {50, 100},  //V
                    {0, 1},     //E
                    {25, 50},   //Is
                    {25, 50},   //Ia
                    {25, 50},   //Q
                    {0, 1},     //R
                    {0, 1},     //M
                };

                double[,] T =
                {
                  //  S    V    E    Is   Ia   Q    R    M
                    {0.5, 0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},           //S -> V
                    {0.5, 0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},           //V -> S
                    {0.0, 0.0, 0.25, 0.25, 0.25, 0.25, 0.0, 0.0},       //E -> Is, Ia, Q
                    {0.0, 0.0, 0.0, 0.25, 0.0, 0.25, 0.25, 0.25},       //Is -> Q, M, R
                    {0.0, 0.0, 0.0, 0.0, 0.5, 0.0, 0.5, 0.0},           //Ia -> R 
                    {0.0, 0.0, 0.0, 0.0, 0.0, 0.3333, 0.3333, 0.3334},  //Q -> M, R
                    {0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.5, 0.0},           //R -> S
                    {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0}            //M
                };*/

                int[] Qty = { 8500, 0, 1500, 0, 0, 0, 0, 0};

                add_Matrix(states, colores,D,T, Qty);

                for (int i = 0; i < states.Length; i++)
                {
                    // Asignar valores específicos a la columna Action para "S" y "I"
                    if (states[i] == "S")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "->";
                    }
                    else if (states[i] == "E")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "o";
                    }
                }
            }
        }

        private void cBseair_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBoxes) return;
            // Verificar si el CheckBox está seleccionado
            if (cBseair.Checked)
            {
                DeselectAllExcept(cBseair);
                pBmodel.Image = Image.FromFile(@"..\..\img\seair.png");
                pBmodel.SizeMode = PictureBoxSizeMode.Zoom;
                pBmodel.BackColor = System.Drawing.Color.White;
                // Limpiar todos los valores en el DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = null; // Limpiar cada celda
                    }
                }

                // Eliminar columnas correspondientes a los estados
                foreach (string state in remove_states)
                {
                    if (dataGridView1.Columns.Contains(state))
                    {
                        dataGridView1.Columns.Remove(state); // Eliminar la columna si existe
                    }
                }

                //Modelo que agrega el check box
                string[] states = { "S", "E", "A","I", "R"}; // Los nombres de las columnas de estados
                string[] colores = { "Gray", "Orange", "Yellow", "Red", "Green" };

                /*
                int[,] D =
                {
                    { 0, 1},            //S
                    { 7, 8},            //E
                    { 7, 8},            //A
                    { 7, 8},            //I
                    { 6, 8},            //R
                };

                double[,] T =
                {
                  //  S    E    A    I    R
                    {1.0, 0.0, 0.0, 0.0, 0.0},          //S
                    {0.0, 0.8, 0.082, 0.118, 0.0},      //E -> E,A,I
                    {0.0, 0.0, 0.6, 0.0, 0.4},          //A -> A,R
                    {0.0, 0.0, 0.0, 0.8, 0.2},          //I -> I,R
                    {0.45, 0.0, 0.0, 0.0, 0.55}         //R -> R,S
                }; */

                
                int[,] D =
                {
                    { 0, 1},            //S
                    { 10, 11},            //E
                    { 0, 2},            //A
                    { 0, 1},            //I
                    { 2, 4},            //R
                };

                double[,] T =
                {
                  //  S    E    A    I    R
                    {1.0, 0.0, 0.0, 0.0, 0.0},          //S
                    {0.0, 0.72, 0.105, 0.175, 0.0},      //E -> E,A,I
                    {0.0, 0.0, 0.93, 0.0, 0.07},      //A -> A,R
                    {0.0, 0.0, 0.0, 0.97, 0.03},      //I -> I,R
                    {0.25, 0.0, 0.0, 0.0, 0.75}     //R -> R,S
                };

                int[] Qty = { 8500, 1000, 100, 400, 0 };

                add_Matrix(states, colores, D, T, Qty);

                for (int i = 0; i < states.Length; i++)
                {
                    // Asignar valores específicos a la columna Action para "S" y "I"
                    if (states[i] == "S")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "->";
                    }
                    else if (states[i] == "E")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "o";
                    }
                }
            }

        }

        private void cBsir_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBoxes) return;
            // Verificar si el CheckBox está seleccionado
            if (cBsir.Checked)
            {
                DeselectAllExcept(cBsir);
                pBmodel.Image = Image.FromFile(@"..\..\img\sir.png");
                pBmodel.SizeMode = PictureBoxSizeMode.Zoom;
                pBmodel.BackColor = System.Drawing.Color.White;
                // Limpiar todos los valores en el DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = null; // Limpiar cada celda
                    }
                }

                // Eliminar columnas correspondientes a los estados
                foreach (string state in remove_states)
                {
                    if (dataGridView1.Columns.Contains(state))
                    {
                        dataGridView1.Columns.Remove(state); // Eliminar la columna si existe
                    }
                }

                //Modelo que agrega el check box
                string[] states = { "S", "I", "R"}; // Los nombres de las columnas de estados
                string[] colores = { "LightGreen", "Red" , "LightBlue" };
                int[,] D =
                {
                    {0, 1}, //S
                    {7, 8}, //I
                    {6, 8}  //R
                };

                double[,] T =
                {
                  //  S    I    R
                    {1.0, 0.0, 0.0},    //S
                    {0.0, 0.6, 0.4},    //I -> I,R
                    {0.39, 0.0, 0.61}   //R -> R,S
                };

                int[] Qty = { 8500, 1500, 0 };

                add_Matrix(states, colores, D, T, Qty);

                for (int i = 0; i < states.Length; i++)
                {
                    // Asignar valores específicos a la columna Action para "S" y "I"
                    if (states[i] == "S")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "->";
                    }
                    else if (states[i] == "I")
                    {
                        dataGridView1.Rows[i].Cells["Action"].Value = "o";
                    }
                }
            }
        }

        private void ApplyModel_Click(object sender, EventArgs e)
        {
            Color[] newColors = GetSelectedColors();
            string[] newStates = GetSelectedStates();
            int[] newQty = GetSelectedQty();
            int[,] newD = GetMinMaxTimes();
            double[,] newT = GetStateTransitionMatrix();

            // Validación: aceptar si la suma es 0 o si coincide con el total de bolas
            if (newQty != null && newQty.Sum() != 0 && newQty.Sum() != VariablesEpModel.numeroBolas)
            {
                MessageBox.Show($"Error: The sum of balls per state ({newQty.Sum()}) does not match the total number of balls ({VariablesEpModel.numeroBolas}).",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            UpdateParameter(() => VariablesEpModel.colores, value => VariablesEpModel.colores = value, newColors);
            UpdateParameter(() => VariablesEpModel.nombre, value => VariablesEpModel.nombre = value, newStates);
            UpdateParameter(() => VariablesEpModel.bolasPorEstado, value => VariablesEpModel.bolasPorEstado = value, newQty);
            UpdateParameter(() => VariablesEpModel.D, value => VariablesEpModel.D = value, newD);
            UpdateParameter(() => VariablesEpModel.T, value => VariablesEpModel.T = value, newT);

            if (CB3Terrain.Checked)
            {
                MessageBox.Show($"Simulation WITH Terrain");
                VariablesEpModel.GenerateTerrainField = true;
                VariablesEpModel.GenerateTerrainMove = true;
            }
            if (CB3NoTerrain.Checked)
            {
                MessageBox.Show($"Simulation WITHOUT Terrain");
                VariablesEpModel.GenerateTerrainField = false;
                VariablesEpModel.GenerateTerrainMove = false;
            }

            // Obtener y asignar los estados de contagio y exposición
            GetEstadoAccion(newStates);

            MessageBox.Show("Updated Model");
        }
        #endregion

        #region Metodos
        private void add_Matrix(string[] states, string[] colores, int[,] D, double[,] T, int[]qty)
        {
            // Limpiar todas las filas existentes en el DataGridView antes de agregar nuevas
            dataGridView1.Rows.Clear();

            // Crear y agregar columnas de estados si no existen
            foreach (var state in states)
            {
                if (state != "-" && !dataGridView1.Columns.Contains(state))
                {
                    var newColumn = new DataGridViewTextBoxColumn
                    {
                        Name = state,
                        HeaderText = state,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    dataGridView1.Columns.Add(newColumn);
                }
            }

            // Agregar filas solo según el número de colores, para evitar filas en blanco
            for (int i = 0; i < colores.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Color"].Value = colores[i];
                dataGridView1.Rows[i].Cells["MinTime"].Value = D[i, 0];
                dataGridView1.Rows[i].Cells["MaxTime"].Value = D[i, 1];
                dataGridView1.Rows[i].Cells["States"].Value = states[i];
                dataGridView1.Rows[i].Cells["Qty"].Value = qty[i];
            }

            // Agregar las probabilidades de transición de estados en las celdas correspondientes
            for (int i = 0; i < states.Length; i++)
            {
                for (int j = 0; j < states.Length; j++)
                {
                    if (j < dataGridView1.Rows.Count) // Asegurar que no se exceda el límite de filas
                    {
                        dataGridView1.Rows[j].Cells[states[i]].Value = T[j, i];
                    }
                }
            }

            // Agregar una fila en blanco al final si no existe
            if (!dataGridView1.AllowUserToAddRows || dataGridView1.Rows[dataGridView1.Rows.Count - 1].IsNewRow == false)
            {
                dataGridView1.AllowUserToAddRows = true;
            }
        }

        private void DeselectAllExcept(CheckBox selectedCheckBox)
        {
            isUpdatingCheckBoxes = true; // Activar la bandera para evitar recursión

            // Método recursivo para buscar y deseleccionar los CheckBox
            void DeselectCheckBoxes(Control parent)
            {
                foreach (Control control in parent.Controls)
                {
                    if (control is CheckBox checkBox && checkBox != selectedCheckBox)
                    {
                        checkBox.Checked = false; // Deseleccionar todos los otros CheckBox
                    }
                    else if (control.HasChildren)
                    {
                        DeselectCheckBoxes(control); // Llamada recursiva para recorrer controles anidados
                    }
                }
            }

            // Llamamos a la función de deselección en el formulario principal
            DeselectCheckBoxes(this);

            isUpdatingCheckBoxes = false; // Desactivar la bandera
        }

        private Color[] GetSelectedColors()
        {
            var selectedColors = new List<Color>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                // Obtener el nombre del color desde la primera columna
                string colorName = row.Cells["Color"].Value?.ToString();

                if (colorName != null && colorMap.ContainsKey(colorName))
                {
                    // Obtener el color correspondiente y agregarlo a la lista
                    selectedColors.Add(colorMap[colorName]);
                }
            }

            // Convertir la lista a un arreglo y devolverlo
            return selectedColors.ToArray();
        }

        private string[] GetSelectedStates()
        {
            var selectedStates = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                // Obtener el nombre del estado desde la columna "States"
                string stateName = row.Cells["States"].Value?.ToString();

                if (!string.IsNullOrEmpty(stateName))
                {
                    // Agregar el nombre del estado a la lista
                    selectedStates.Add(stateName);
                }
            }

            // Convertir la lista a un arreglo y devolverlo
            return selectedStates.ToArray();
        }

        private int[] GetSelectedQty()
        {
            var selectedQty = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Qty"].Value != null) // Verificar si la celda no es nula
                {
                    // Intentar convertir el valor de la celda a int
                    if (int.TryParse(row.Cells["Qty"].Value.ToString(), out int qty))
                    {
                        // Si la conversión es exitosa, agregar el valor a la lista
                        selectedQty.Add(qty);
                    }
                }
            }

            // Convertir la lista a un arreglo y devolverlo
            return selectedQty.ToArray();
        }

        private int[,] GetMinMaxTimes()
        {
            // Número de filas en el DataGridView, excluyendo la fila nueva
            int rowCount = dataGridView1.Rows.Count - 1;
            int[,] minMaxTimes = new int[rowCount, 2]; // Crear matriz con 2 columnas para MinTime y MaxTime

            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                // Obtener los valores de MinTime y MaxTime, y convertirlos a enteros
                int minTime = Convert.ToInt32(row.Cells["MinTime"].Value ?? 0); // Usa 0 si el valor es nulo
                int maxTime = Convert.ToInt32(row.Cells["MaxTime"].Value ?? 0); // Usa 0 si el valor es nulo

                // Almacenar los valores en la matriz
                minMaxTimes[i, 0] = minTime;
                minMaxTimes[i, 1] = maxTime;
            }

            return minMaxTimes;
        }

        private double[,] GetStateTransitionMatrix()
        {
            // Contar las columnas de estado (después de las columnas "MinTime" y "MaxTime")
            int stateColumnStartIndex = dataGridView1.Columns["MaxTime"].Index + 1;
            int stateColumnCount = dataGridView1.Columns.Count - stateColumnStartIndex;
            int rowCount = dataGridView1.Rows.Count - 1; // Excluir la fila nueva

            // Crear la matriz para los valores de transición de estados
            double[,] transitionMatrix = new double[rowCount, stateColumnCount];

            // Llenar la matriz con los valores de las columnas de estado
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < stateColumnCount; j++)
                {
                    // Obtener el valor de la celda y convertirlo a double
                    DataGridViewCell cell = dataGridView1.Rows[i].Cells[stateColumnStartIndex + j];
                    transitionMatrix[i, j] = Convert.ToDouble(cell.Value ?? 0); // Usa 0 si el valor es nulo
                }
            }

            return transitionMatrix;
        }

        private void GetEstadoAccion(string[] newStates)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["States"].Value != null && row.Cells["Action"].Value != null)
                {
                    string stateName = row.Cells["States"].Value.ToString();
                    string action = row.Cells["Action"].Value.ToString();

                    // Buscar el índice del estado en newStates en lugar de Names
                    int stateIndex = Array.IndexOf(newStates, stateName);

                    // Validar que el estado existe en newStates
                    if (stateIndex >= 0)
                    {
                        if (action == "->")
                        {
                            VariablesEpModel.estadoInicialContagio = stateIndex; // Estado inicial de contagio
                        }
                        else if (action == "o")
                        {
                            VariablesEpModel.estadoExpuesto = stateIndex; // Estado expuesto
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Warning: The state {stateName} was not found in the new states.");
                    }
                }
            }
        }
        
        // Método genérico para actualizar una variable de cualquier tipo
        private void UpdateParameter<T>(Func<T> getVariable, Action<T> setVariable, T newValue)
        {
            // Se actualiza la variable mediante la acción especificada
            setVariable(newValue);
        }
        #endregion
    }
}
