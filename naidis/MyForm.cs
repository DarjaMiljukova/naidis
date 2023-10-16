using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naidis
{
    public partial class MyForm : Form
    {
        private TrianglePictureBoxControl trianglePictureBox;
        private Label heightLabel;
        private Label medianLabel;
        private TextBox sideATextBox;
        private TextBox sideBTextBox;
        private TextBox sideCTextBox;

        private void CalculateTriangle(object sender, EventArgs e)
        {
            double sideA, sideB, sideC;
            if (double.TryParse(sideATextBox.Text, out sideA) &&
                double.TryParse(sideBTextBox.Text, out sideB) &&
                double.TryParse(sideCTextBox.Text, out sideC))
            {
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                double height = triangle.Height();
                double median = triangle.Median();

                heightLabel.Text = $"Kõrgus: {height}";
                medianLabel.Text = $"Laius: {median}";

                trianglePictureBox.Invalidate();
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public MyForm()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            trianglePictureBox = new TrianglePictureBoxControl();
            heightLabel = new Label();
            medianLabel = new Label();
            sideATextBox = new TextBox();
            sideBTextBox = new TextBox();
            sideCTextBox = new TextBox();

            trianglePictureBox.Location = new Point(10, 10);
            trianglePictureBox.Size = new Size(200, 200);
            heightLabel.Location = new Point(10, 220);
            medianLabel.Location = new Point(10, 240);
            sideATextBox.Location = new Point(10, 260);
            sideBTextBox.Location = new Point(10, 280);
            sideCTextBox.Location = new Point(10, 300);

            this.Controls.Add(trianglePictureBox);
            this.Controls.Add(heightLabel);
            this.Controls.Add(medianLabel);
            this.Controls.Add(sideATextBox);
            this.Controls.Add(sideBTextBox);
            this.Controls.Add(sideCTextBox);

            sideATextBox.TextChanged += CalculateTriangle;
            sideBTextBox.TextChanged += CalculateTriangle;
            sideCTextBox.TextChanged += CalculateTriangle;
        }       
                
    }
}