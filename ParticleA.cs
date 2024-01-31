using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace CollisionsSimulation
{
    public class ParticleA : IParticles
    {

        Random r = new Random();

        #region Properties

        public Point point { get; set; }

        public Point Velocity { get; set; }

        public Point border { get; set; }

        public int Diameter { get; set; }

        public Color color { get; set; }

        public int Mass { get; set; }

        #endregion

        #region Create and display particles

        public void GenerateParticle(int x, int y, int height, int width, int velX, int velY)
        {
            Diameter = 20;
            Point b = new Point(height, width); //Sets the borders
            border = b;
            point = new Point(x, y);       //Sets the X and Y of the particle
            Velocity = new Point(velX, velY);  //Sets the velocity of the particle
        }

        public ParticleA(int x, int y, int height, int width, int velX, int velY, Color c,int m,  Graphics g)
        {
            this.Mass = m;
            this.GenerateParticle(x, y, height, width, velX, velY);
            this.color = c;
            this.DrawParticle(g);
            Console.WriteLine("A particle A has been generated");
        }

        public void DrawParticle(Graphics g)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillEllipse(brush, point.X, point.Y, Diameter, Diameter);
        }

        #endregion

        #region Particle Movement

        public void ImplementVelocity()
        {
            Point r = new Point(point.X + Velocity.X, point.Y + Velocity.Y);
            this.point = r;
            this.CollisionToWall(border);
        }

        public void CollisionToWall(Point second)
        {
            Point v = new Point();
            v = Velocity;
            if (point.X <= 0 || point.X+Diameter/2 >= second.X)
                v.X = Velocity.X * (-1);
            if (point.Y <= 0 || point.Y+Diameter/2 >= second.Y)
                v.Y = Velocity.Y * (-1);
            Velocity = v;
        }

        #endregion

        public void Collision(ParticleA pa)
        {
            Point ch = Velocity;
            Point ch2 = pa.Velocity;
            if ((this.point.X - pa.point.X) * (this.point.X - pa.point.X) <= this.Diameter*this.Diameter)
            {
                ch.X = -ch.X;
                ch2.X = -ch2.X;
            }

            if ((this.point.Y - pa.point.Y) * (this.point.Y - pa.point.Y) <= this.Diameter * this.Diameter)
            {
                ch.Y = -ch.Y;
                ch2.Y = -ch2.Y;
            }

            Velocity = ch;
            pa.Velocity = ch2;
        }

        #region Debug Particles

        public string WriteParticlePosition()
        {
            return "Particle position: " + this.Velocity.X + " " +this.Velocity.Y;
        }

        #endregion

    }
}
