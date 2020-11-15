using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gyak8.Entities;
using gyak8.Abstractions;

namespace gyak8
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();

        private Toy _nextToy;
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set 
            {
                _factory = value;
                DisplayNext();
            }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _toys.Add(ball);
            ball.Left = -ball.Width;
            mainpanel.Controls.Add(ball);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in _toys)
            {
                ball.MoveToy();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }

            if(maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                mainpanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }

        private void btn_Car_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btn_Ball_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = button1.BackColor
            };


        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPick = new ColorDialog();
            colorPick.Color = button1.BackColor;
            if (colorPick.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPick.Color;
        }

        private void btn_Present_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory
            {
                RibbonColor = btn_Ribbonclr.BackColor,
                BoxColor = btn_Boxclr.BackColor
            };
        }
    }
}
