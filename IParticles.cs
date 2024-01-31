using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace CollisionsSimulation
{
    public interface IParticles
    {
        int Diameter { get; set; }

        Point point { get; set; } //property signature

        Point Velocity { get; set; } //prop+tab+tab shortcut to create a property
        
        Point border { get; set; }

        int Mass { get; set; }

        void GenerateParticle(int x, int y, int height, int width, int velX, int velY); //method signature

 //     void Collision(ParticleA pa);

        void ImplementVelocity();

        void DrawParticle(Graphics g);
    }
}
