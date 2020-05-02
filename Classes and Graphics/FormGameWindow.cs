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
        int seconds;
        int timerCount;

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
                if (i % 3 == 1)
                    targets.Add(new CircleTarget(this.ClientSize));
                else if (i % 3 == 0)
                    targets.Add(new SquareTarget(this.ClientSize));
                else if (i % 3 == 2)
                    targets.Add(new RandomTarget(this.ClientSize));
            }    
            turret = new Point(this.ClientSize.Width / 2, this.ClientSize.Height);
            shot = turret;
            seconds = 0;
            timerCount = 0;
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


            //Keeps track of time
            timerCount += 1;
            if (timerCount == 100)
            {
                timerCount = 0;
                seconds += 1;
            }
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
                    if (targets.Count == 0)
                    {
                        GameOver();
                        Invalidate();
                        return;
                    }      
                }
            shot = e.Location;

        }
        private void GameOver()
        {
            GameTimer.Enabled = false;
            shot = turret;
            lblGameOver.Visible = true;
            lblGameOver.Text = "Great job, it took you " + seconds + " seconds.";
        }
    }
}
