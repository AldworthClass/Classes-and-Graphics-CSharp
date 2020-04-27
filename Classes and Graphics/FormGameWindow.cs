using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classes_and_Graphics
{
    public partial class FormGameWindow : Form
    {
        Random random = new Random();
        Point turret, shot;
        Brush brush = new SolidBrush(Color.Black);
        Pen lazer = new Pen(Color.Red, 2);
        Graphics canvas;
        List<Target> targets = new List<Target>();
        int score;
        int shotTime;
        bool shooting;

        public FormGameWindow()
        {
            InitializeComponent();
        }

        private void FormGameWindow_Paint(object sender, PaintEventArgs e)
        {
            canvas = e.Graphics;

            //Draws Target
            foreach (Target target in targets)
                target.Draw(canvas);
            
            //Draws Turret
            canvas.FillEllipse(brush, this.ClientSize.Width / 2 - 5, this.ClientSize.Height - 5, 10, 10);
            //Draws shot Lazer
            canvas.DrawLine(lazer, shot, turret);
        }

        private void FormGameWindow_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.crosshair.GetHicon());
            shooting = false;
            shotTime = 0;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            targets.Add(new CircleTarget(new Point(100, 100), 40, this.ClientSize));
            targets.Add(new CircleTarget(new Point(50, 50), this.ClientSize));
            for (int i = 0; i < 15; i++)
            {
                targets.Add(new CircleTarget(this.ClientSize));
                if (i %2 == 0)
                    targets.Add(new SquareTarget(this.ClientSize));
            }    
            turret = new Point(this.ClientSize.Width / 2, this.ClientSize.Height);
            shot = turret;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (shooting)
            {
                shotTime += 1;
                if (shotTime == 10)
                {
                    shooting = false;
                    shot = turret;
                    shotTime = 0;
                }                   
            }

            foreach (Target target in targets)
                target.Move();
            this.Invalidate();  // Calls Paint() which calls Target Draw()
        }

        private void FormGameWindow_MouseUp(object sender, MouseEventArgs e)
        {
            shot = turret;
            shooting = false;
        }

        private void FormGameWindow_MouseDown(object sender, MouseEventArgs e)
        {
            shooting = true;
            for (int i = 0; i < targets.Count; i++)
                if (targets[i].Hit(e.Location))
                {
                    score += 1;
                    lblScore.Text = "Score: " + score;
                    targets.RemoveAt(i);
                    i--;
                }
            shot = e.Location;

        }
    }
}
