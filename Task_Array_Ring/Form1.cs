using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classRing;


namespace Task_Array_Ring
{
    public partial class Form1 : Form
    {
        RandomArrayRing arryRing;

        bool isDraw; //состояние есть/нет картинка на форме
        int step = 5; // расстояние межд окружностями на форме
        bool horizontal;
        bool vertical;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (isDraw && horizontal)
            {
                Graphics GRFX = e.Graphics;
                int y;
                int x = 0;
                Rectangle rect;
                int radius;
                Color color;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // сглаживает углы кругов

                foreach (Ring item in arryRing)
                {
                    radius = item.Radius;
                    color = item.Color;
                    y = ClientSize.Height / 2 - radius; // расположение кружков по оси Y
                    rect = new Rectangle(x+step*3, y, radius * 2, radius * 2);
                    GRFX.FillEllipse(new SolidBrush(color), rect);
                    x += radius * 2 + step; // интервал между кружками
                }
                GRFX.Dispose();
            }
            else if (isDraw && vertical)
            {
                Graphics GRFX = e.Graphics;
                int y = this.menuFile.Bottom + step;
                int x;
                Rectangle rect;
                int radius;
                Color color;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
              
                foreach (Ring item in arryRing)
                {
                    radius = item.Radius;
                    color = item.Color;
                    x = ClientSize.Width / 2 - radius;
                    rect = new Rectangle(x, y, radius * 2, radius * 2);
                    GRFX.FillEllipse(new SolidBrush(color), rect);
                    y += radius * 2 + step;
                }
                GRFX.Dispose();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forwardToolStripMenuItem.Enabled = false;
            clearToolStripMenuItem.Enabled = false;
            sortToolStripMenuItem.Enabled = false;
            reverseToolStripMenuItem1.Enabled = false;
            horizontalToolStripMenuItem.Checked = false;
            verticalToolStripMenuItem.Checked = false;
            reverseToolStripMenuItem1.Checked = false;
            forwardToolStripMenuItem.Checked = false;
            this.isDraw = false;
            this.BackColor = Color.White;
            Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forwardToolStripMenuItem.Enabled = false;
            reverseToolStripMenuItem1.Enabled = true;
            forwardToolStripMenuItem.CheckOnClick = true;
            reverseToolStripMenuItem1.Checked = false;
            arryRing.Sort();
            Invalidate();
        }

        private void reverseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            forwardToolStripMenuItem.Enabled = true;
            reverseToolStripMenuItem1.Enabled = false;
            reverseToolStripMenuItem1.CheckOnClick = true;
            forwardToolStripMenuItem.Checked = false;
            arryRing.Reverse();
            Invalidate();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            horizontal = true;
            vertical = false;
            isDraw = true;
            arryRing = new RandomArrayRing(5);
            
            sortToolStripMenuItem.Enabled = true;
            forwardToolStripMenuItem.Enabled = true;
            clearToolStripMenuItem.Enabled = true;
            reverseToolStripMenuItem1.Enabled = false;
            horizontalToolStripMenuItem.CheckOnClick = true;
            verticalToolStripMenuItem.Checked = false;
            forwardToolStripMenuItem.Checked = false;
            reverseToolStripMenuItem1.Checked = false;


            arryRing.Initialize();
            int y = this.menuFile.Bottom + step;

            foreach (Ring item in arryRing)
            {
                y += item.Radius * 2 + step;
            }

            this.ClientSize = new Size(y, y);

            Invalidate();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDraw = true;
            vertical = true;
            horizontal = false;
            arryRing = new RandomArrayRing(5);

            sortToolStripMenuItem.Enabled = true;
            forwardToolStripMenuItem.Enabled = true;
            clearToolStripMenuItem.Enabled = true;
            reverseToolStripMenuItem1.Enabled = false;
            horizontalToolStripMenuItem.Checked = false;
            verticalToolStripMenuItem.CheckOnClick = true;
            forwardToolStripMenuItem.Checked = false;
            reverseToolStripMenuItem1.Checked = false;

            arryRing.Initialize();

            int y = this.menuFile.Bottom + step;

            foreach (Ring item in arryRing)
            {
                y += item.Radius * 2 + step;
            }

            this.ClientSize = new Size(y, y);

            Invalidate();
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = this.BackColor;
            dlg.AllowFullOpen = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = dlg.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 dlg = new AboutBox1();
            dlg.ShowDialog();
        }
    }
}
