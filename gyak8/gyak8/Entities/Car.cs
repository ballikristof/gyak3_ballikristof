using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gyak8.Abstractions;
using System.Drawing;
using System.Windows.Forms;

namespace gyak8.Entities
{
    class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            Image ImageFile = Image.FromFile("Images/car.png");
            g.DrawImage(ImageFile, new Rectangle(0, 0, Width, Height));
        }
    }
}
