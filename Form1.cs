using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollisionsSimulation
{
    public partial class Form1 : Form
    {

        #region TO DO
        // Introduce the collision's equation
        // Add mass to the particles
        // Make a clear screen button 
        // ~ Add gravity
        #endregion

        List<ParticleA> particlesA = new List<ParticleA>();
        public Graphics g;
        Random RandomV = new Random();
        int MaximVelocity = 2;

        int originalValue = 0, secondValue;

        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("hello there");
            g = pictureBox1.CreateGraphics();
            panel2.Hide();

            timer1.Interval = 5;
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            particlesA.Add(new ParticleA(100, 150, pictureBox1.Width, pictureBox1.Height, RandomV.Next(-MaximVelocity, MaximVelocity), RandomV.Next(-MaximVelocity, MaximVelocity), Color.Red, 1, g));
            pictureBox1.Invalidate();
            //par = new ParticleA(pictureBox1.Width, pictureBox1.Height, 1, 1, g);
        }

        #region Particle array methods

        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < particlesA.Count(); i++)
                for (int j = i+1; j < particlesA.Count(); j++)
                    if (i != j)
                    { DetectCollision( particlesA[i], particlesA[j]);}
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (ParticleA pa in particlesA)
            {
                pa.DrawParticle(e.Graphics);
                pa.ImplementVelocity();
            }
        }

        #endregion

        #region references
        //https://stackoverflow.com/questions/1747654/error-cannot-modify-the-return-value-c-sharp  -- point as property
        //https://www.youtube.com/watch?v=A7qwuFnyIpM&ab_channel=IAmTimCorey  -- tutorial on interfaces
        //https://stackoverflow.com/questions/4362111/how-do-i-show-a-console-output-window-in-a-forms-application  -- adds console to winform app
        //https://stackoverflow.com/questions/18040945/read-picture-box-mouse-coordinates-on-click -- for mouse event 
        //https://jonskeet.uk/csharp/parameters.html  -- de citit pentru variabile transmise prin referinta

        #endregion

        #region Generate particles on screen

        private void PAButton_Click(object sender, EventArgs e)
        {
            particlesA.Add(new ParticleA(100, 150, pictureBox1.Width, pictureBox1.Height, RandomV.Next(-MaximVelocity, MaximVelocity), RandomV.Next(-MaximVelocity, MaximVelocity), Color.Red, RandomV.Next(1, 10) ,g));
            label2.Text = "Particles: " + particlesA.Count();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //MouseEventArgs mouse = (MouseEventArgs)e;
            //Point p = mouse.Location;
            //particlesA.Add(new ParticleA(p.X, p.Y, pictureBox1.Width, pictureBox1.Height, 1, 1, g));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            particlesA.Add(new ParticleA(e.X, e.Y, pictureBox1.Width, pictureBox1.Height, RandomV.Next(-MaximVelocity, MaximVelocity), RandomV.Next(-MaximVelocity, MaximVelocity), Color.Blue, RandomV.Next(1, 10), g));
            label2.Text = "Particles: " + particlesA.Count();
        }

        #endregion

        #region Particles movement

        public static void DetectCollision(ParticleA i, ParticleA j)
        {
            if (Math.Abs(i.point.X - j.point.X) <= i.Diameter && Math.Abs(i.point.Y - j.point.Y) <= j.Diameter)
            {
                Console.WriteLine("Collision detected");
                Console.WriteLine(i.WriteParticlePosition());
                Console.WriteLine(j.WriteParticlePosition());
                Point p = j.Velocity, s = i.Velocity;
                
                 p.X = p.X * (-1);
                 p.Y = p.Y * (-1);
                 j.Velocity = p;

                 p = i.Velocity;
                 p.X = p.X * (-1);
                 p.Y = p.Y * (-1);
                 i.Velocity = p;

                 i.ImplementVelocity();
                 j.ImplementVelocity();
                 
                
                /*
                p.X = 2*(i.Mass * i.Velocity.X + j.Mass * j.Velocity.X) / (i.Mass + j.Mass) - i.Velocity.X;
                p.Y = 2 * (i.Mass * i.Velocity.Y + j.Mass * j.Velocity.Y) / (i.Mass + j.Mass) - i.Velocity.Y;
                s.X = 2 * (i.Mass * i.Velocity.X + j.Mass * j.Velocity.X) / (i.Mass + j.Mass) - j.Velocity.X;
                s.Y = 2 * (i.Mass * i.Velocity.Y + j.Mass * j.Velocity.Y) / (i.Mass + j.Mass) - j.Velocity.Y;
              */


            }
        }
        #endregion

        private void GravityButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("You are about to delete this particle simulation.\n Are you sure you want to procede?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            particlesA.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            secondValue = hScrollBar1.Value - originalValue;

            foreach(ParticleA pa in particlesA)
            {
                Point aux = new Point();
                aux.X = secondValue + pa.Velocity.X;
                aux.Y = secondValue + pa.Velocity.Y;
                pa.Velocity = aux;
            }

            originalValue = hScrollBar1.Value;

            label3.Text = "Add speed: " + originalValue;

        }
    }
}
