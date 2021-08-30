using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird_Windows_Form
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int gravityIncrement = 15;
        int score = 0;
        bool gameOver = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            // bring pipes backs
            // dimensions of from: 815, 692
            if (pipeBottom.Left < -150) //150 pixels
            {
                pipeBottom.Left = 900; //900 pixels
                score++;
            }
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 1050;
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25)
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -gravityIncrement;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = gravityIncrement;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!! ";
            gameOver = true;
        }

        private void restartGame(object sender, EventArgs e)
        {

        }

        private void restartGameVisible(object sender, EventArgs e)
        {

        }

        private void startGame(object sender, EventArgs e)
        {
            gameTimer.Start();
        }
    }
}
