using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace File_Binder
{
    public class SplashScreen : Form
    {
        private Timer fadeTimer;
        private Timer displayTimer;
        private double opacity = 0.0;
        private bool fadingIn = true;
        private Label titleLabel;
        private Label subtitleLabel;
        private Panel gradientPanel;

        public SplashScreen()
        {
            InitializeComponent();
            this.Opacity = 0;

            			fadeTimer = new Timer();
            			fadeTimer.Interval = 30;
            			fadeTimer.Tick += FadeTimer_Tick;

            			displayTimer = new Timer();
            			displayTimer.Interval = 150000;
            			displayTimer.Tick += DisplayTimer_Tick;

            fadeTimer.Start();
            displayTimer.Start();
        }

        private void InitializeComponent()
        {
            this.gradientPanel = new Panel();
            this.titleLabel = new Label();
            this.subtitleLabel = new Label();
            this.SuspendLayout();

            // gradientPanel
            this.gradientPanel.Dock = DockStyle.Fill;
            this.gradientPanel.Location = new Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.Size = new Size(600, 350);
            this.gradientPanel.TabIndex = 0;
            this.gradientPanel.Paint += new PaintEventHandler(this.GradientPanel_Paint);

            // titleLabel
            this.titleLabel.AutoSize = false;
            this.titleLabel.BackColor = Color.Transparent;
            this.titleLabel.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            this.titleLabel.ForeColor = Color.White;
            this.titleLabel.Location = new Point(50, 100);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new Size(500, 90);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "FILE BINDER";
            this.titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // subtitleLabel
            this.subtitleLabel.AutoSize = false;
            this.subtitleLabel.BackColor = Color.Transparent;
            this.subtitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Italic);
            this.subtitleLabel.ForeColor = Color.FromArgb(255, 100, 100);
            this.subtitleLabel.Location = new Point(50, 220);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new Size(500, 40);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Cracked by unknown hart";
            this.subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // SplashScreen
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(600, 350);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.gradientPanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.ResumeLayout(false);
        }

        private void GradientPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = gradientPanel.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(20, 20, 30),
                Color.FromArgb(50, 10, 20),
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillRectangle(brush, rect);
            }

            using (Pen pen = new Pen(Color.FromArgb(150, 255, 50, 50), 3))
            {
                g.DrawRectangle(pen, 10, 10, rect.Width - 20, rect.Height - 20);
            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            			if (fadingIn)
            			{
            				opacity += 0.03;
            				if (opacity >= 1.0)
            				{
            					opacity = 1.0;
            					fadingIn = false;
            				}
            			}
            			else
            			{
            				opacity -= 0.03;
            				if (opacity <= 0.0)
            				{
            					opacity = 0.0;
            					fadeTimer.Stop();
            					this.Close();
            				}
            			}
            this.Opacity = opacity;
        }

        private void DisplayTimer_Tick(object sender, EventArgs e)
        {
            displayTimer.Stop();
            fadingIn = false;
        }
    }
}
