using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsHardestGame;

namespace gyak10
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        GameArea ga;

        int populationSize = 100;
        int nbrofSteps = 10;
        int nbrofStepsIncrement = 10;
        int generation = 1;
        Brain winnerBrain = null;
        public Form1()
        {
            InitializeComponent();

            ga = gc.ActivateDisplay();
            this.Controls.Add(ga);

            gc.GameOver += Gc_GameOver;

            for (int i = 0; i < populationSize; i++)
            {
                gc.AddPlayer(nbrofSteps);
            }
            gc.Start();
        }

        private void Gc_GameOver(object sender)
        {
            button1.Hide();
            generation++;
            label1.Text = string.Format(
                "{0}. generáció", generation);

            var playerList = from p in gc.GetCurrentPlayers()
                             orderby p.GetFitness() descending
                             select p;
            var topPerformers = playerList.Take(populationSize / 2).ToList();

            gc.ResetCurrentLevel();
            foreach (var p in topPerformers)
            {
                var b = p.Brain.Clone();
                if (generation % 3 == 0)
                    gc.AddPlayer(b.ExpandBrain(nbrofStepsIncrement));
                else
                    gc.AddPlayer(b);

                if (generation % 3 == 0)
                    gc.AddPlayer(b.Mutate().ExpandBrain(nbrofStepsIncrement));
                else
                    gc.AddPlayer(b.Mutate());
            }
            gc.Start();

            var winner = from p in topPerformers
                         where p.IsWinner
                         select p;
            if (winner.Count() > 0)
            {
                button1.Show();
                winnerBrain = winner.FirstOrDefault().Brain.Clone();
                gc.GameOver -= Gc_GameOver;
                return;
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gc.ResetCurrentLevel();
            gc.AddPlayer(winnerBrain.Clone());
            gc.AddPlayer();
            ga.Focus();
            gc.Start(true);
        }
    }
}
