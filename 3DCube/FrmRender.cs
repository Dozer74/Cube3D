using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cube3D
{
    public partial class FrmRender : Form
    {
        public FrmRender()
        {
            InitializeComponent();
        }

        Cube cube;
        Point drawOrigin;
        private float tX, tY, tZ;

        private void FrmRender_Load(object sender, EventArgs e)
        {
            cube = new Cube(150);
            drawOrigin = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
        }

        private void Render()
        {
            cube.RotateX = tX;
            cube.RotateY = tY;
            cube.RotateZ = tZ;

            pictureBox1.Image = cube.DrawCube(drawOrigin);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tX = 0;
            tY = 0;
            tZ = 0;

            cbX.Checked = cbY.Checked = cbZ.Checked = false;
            rbShowFaces.Checked = true;
            tbSpeed.Value = 3;

            cube = new Cube(150);
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }
        
        private void rbShowMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShowLines.Checked)
            {
                cube.ShowMode = ShowMode.Bones;
            }
            else if (rbShowColorFaces.Checked)
            {
                cube.ShowMode = ShowMode.ColorFaces;
            }
            else
            {
                cube.ShowMode = ShowMode.Faces;
            }

            this.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var delta = tbSpeed.Value;

            if (cbX.Checked)
                tX = (tX + delta) % 360;

            if (cbY.Checked)
                tY = (tY + delta) % 360;

            if (cbZ.Checked)
                tZ = (tZ + delta) % 360;

            this.Refresh();
        }
    }
}