﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace gyak8.Abstractions
{
    public abstract class Toy : Label
    {
        public Toy()
        {
            AutoSize = false;
            Height = 50;
            Width = Height;
            Top = 170;
            Paint += Toy_Paint;
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected abstract void DrawImage(Graphics g);

        public virtual void MoveToy()

        {
            Left += 1;
        }
    }
}
