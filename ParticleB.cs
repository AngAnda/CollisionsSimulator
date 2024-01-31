using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionsSimulation
{
    class ParticleB : IParticles
    {
        public Point point { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point Velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point border { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Diameter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Mass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /*       public void Collision(ParticleA pa)
               {
                   throw new NotImplementedException();
               }
       */
        public void DrawParticle(Graphics g)
        {
            throw new NotImplementedException();
        }

        public void GenerateParticle(int x, int y, int height, int width, int velX, int velY)
        {
            throw new NotImplementedException();
        }

        void IParticles.ImplementVelocity()
        {
            throw new NotImplementedException();
        }
    }
}
