using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sim03
{
    public static class InterfaceManager
    {
        //Variables
        #region VInterfaz

        // Importar la función SendMessage de user32.dll para manejo de la ventana
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        // Constantes para el mensaje de clic en la barra de título (non-client area)
        private const uint WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private static Form activeForm = null;
        #endregion

        //Barra de titulo
        #region Barra

        // Dibuja barra y botones dentro de ella
        public static void SetupCustomTitleBar(Form form, Panel Main)
        {
            Panel titleBar = new Panel
            {
                BackColor = Color.FromArgb(255, 11, 7, 17),
                Height = 25,
                Dock = DockStyle.Top
            };
            // Manejador del evento MouseDown para permitir mover la ventana
            titleBar.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Envía el mensaje para simular el clic en la barra de título
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
                }
            };

            // Crear botones de minimizar, maximizar/restaurar y cerrar
            Button minimizeButton = CreateTitleBarButton("_", Color.FromArgb(255, 11, 7, 17), (sender, e) => MinimizeForm(form));
            Button maximizeButton = CreateTitleBarButton("□", Color.FromArgb(255, 11, 7, 17), (sender, e) => MaximizeRestoreForm(form, Main));
            Button closeButton = CreateTitleBarButton("X", Color.Red, (sender, e) => CloseForm(form));

            // Agregar botones a la barra de título
            titleBar.Controls.Add(minimizeButton);
            titleBar.Controls.Add(maximizeButton);
            titleBar.Controls.Add(closeButton);
            form.Controls.Add(titleBar);
        }

        // Especificacion de los botones
        private static Button CreateTitleBarButton(string text, Color backColor, EventHandler clickEvent)
        {
            Button button = new Button
            {
                Text = text,
                ForeColor = Color.White,
                BackColor = backColor,
                FlatStyle = FlatStyle.Popup,
                FlatAppearance = { BorderSize = 0 },
                Height = 25,
                Width = 40,
                Dock = DockStyle.Right
            };
            button.Click += clickEvent;
            return button;
        }
        #endregion

        // Manejadores de eventos para las acciones de los botones
        #region MEvent

        public static void MinimizeForm(Form form)
        {
            form.WindowState = FormWindowState.Minimized;
        }

        public static void MaximizeRestoreForm(Form form, Panel Main)
        {
            form.WindowState = (form.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
            pMain(form, Main);
        }

        public static void CloseForm(Form form)
        {
            form.Close();
        }

        public static void HideSubMenu(Panel subMenu)
        {
            if (subMenu.Visible)
            {
                subMenu.Visible = false;
            }
        }

        public static void StopSimulation(Timer timer1, Button Run_1, Button Start_1, Action<bool> setSimulationState)
        {
            if (timer1.Enabled == false)
            {
                timer1.Stop(); // Detener el timer
                Run_1.Text = "Run"; // Cambiar el texto del botón
                Run_1.ForeColor = Color.White;
                Run_1.BackColor = Color.FromArgb(255, 11, 7, 17); // Cambiar el color del botón a verde

                Start_1.Text = "Start";
                Start_1.ForeColor = Color.White;
                Start_1.BackColor = Color.FromArgb(255, 11, 7, 17);
                setSimulationState(false); // Actualizar el estado de la simulación
            }
        }

        public static void ClearSimulation(Form form, Bola[] bolas, MallaEspacial mallaEspacial, int TamañoCelda)
        {
            // Limpiar el arreglo de bolas
            if (bolas != null)
            {
                for (int i = 0; i < bolas.Length; i++)
                {
                    bolas[i] = null;  // Esto ayuda a que el recolector de basura recoja estas instancias más adelante
                }
                bolas = null;  // Opcionalmente, anula el arreglo completo
            }

            // Reinicializar la malla espacial si es necesario
            int ancho = form.ClientSize.Width;
            int alto = form.ClientSize.Height;
            mallaEspacial = new MallaEspacial(ancho, alto, TamañoCelda);

            // Opcional: Actualizar la interfaz de usuario si es necesario, como redibujar el área de dibujo
            form.Invalidate(); // Esto hará que se llame a OnPaint y se redibuje el formulario
        }

        public static void ShowSubMenu(Panel currentSubMenu, params Panel[] otherSubMenus)
        {
            // Ocultar otros submenús
            foreach (var menu in otherSubMenus)
            {
                if (menu.Visible)
                {
                    menu.Visible = false;
                }
            }

            // Alternar visibilidad del submenú actual
            currentSubMenu.Visible = !currentSubMenu.Visible;
        }

        public static void customizeDesign(Form form, Panel subMenu1, Panel Main)
        {
            //Ocultar submenú
            subMenu1.Visible = false;

            //Agrego mi panelMain
            form.Controls.Add(Main);
            //Posiciono el panel a la mitad
            pMain(form,Main);
            // Oculto el panel al inicio 
            Main.Visible = false;
        }

        public static void pMain(Form form, Panel Main)
        {
            // Calcular la nueva posición para centrar el panel dentro del formulario
            int x = (form.ClientSize.Width - Main.Width) / 2;
            int y = 25;

            // Establecer la nueva posición del panel
            Main.Location = new Point(x, y);
        }


        public static void OpenChildForm(Form1 parentForm, Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            parentForm.PanelConfig.Controls.Add(childForm);
            parentForm.PanelConfig.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion
    }
}


