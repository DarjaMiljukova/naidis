using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace naidis
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        TextBox txt_box;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb;
        ListBox lb;
        Button btn2;
        Button btn3;

        private TriangleForm triangleForm;

        bool isBtnVisible = false;
        bool isLblVisible = false;
        bool isTxtVisible = false;
        bool isRVisible = false;
        bool isCBVisible = false;
        bool isPBVisible = false;
        bool isLBVisible = false;

        public TreeForm()
        {

            this.Height = 1280;
            this.Width = 1200;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode = new TreeNode("Elemendid");
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));


            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(150, 150);
            btn.Click += Btn_Click;
            btn.MouseHover += Btn_MouseHover;
            btn.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            
            //label

            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(this.Width, btn.Location.Y);
            lbl.BackColor = Color.White;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            
            //tekstkast

            treeNode.Nodes.Add(new TreeNode("Tekstkast-Texbox"));
            txt_box = new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "...";
            txt_box.Location = new Point(tree.Width, btn.Top + btn.Height);
            txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);

            //radiobutton

            treeNode.Nodes.Add(new TreeNode("RadioNupp-RadioButton"));
            r1 = new RadioButton();
            r1.Text = "Valgus teema";
            r1.Location = new Point(tree.Width, txt_box.Location.Y + txt_box.Height);

            r2 = new RadioButton();
            r2.Text = "Tume teema";
            r2.Location = new Point(r1.Location.X + r1.Width, txt_box.Location.Y + txt_box.Height);


            r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
            r2.CheckedChanged += new EventHandler(Radiobuttons_Changed);

            //checkbox

            treeNode.Nodes.Add(new TreeNode("Kontrollkast-CheckBox"));
            c1 = new CheckBox();
            c1.Text = "Valik 1";
            c1.Location = new Point(tree.Width, r1.Location.Y + r1.Height);

            c2 = new CheckBox();
            c2.Text = "Valik 2";
            c2.Location = new Point(tree.Width, c1.Location.Y + c1.Height);

            c1.CheckedChanged += new EventHandler(CheckBox_Changed);


            //picturebox

            treeNode.Nodes.Add(new TreeNode("Piltkast-PictureBox"));
            pb = new PictureBox();
            pb.Location = new Point(tree.Width, c2.Location.Y + c2.Height);
            pb.Image = new Bitmap("../../../images.jpg");
            pb.Size = new Size(200, 200);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;

            //listbox

            treeNode.Nodes.Add(new TreeNode("ListBox"));
            lb = new ListBox();
            lb.Items.Add("Kollane");
            lb.Items.Add("Punane");
            lb.Items.Add("Sinine");
            lb.Items.Add("Lille");
            lb.Location = new Point(tree.Width, pb.Location.Y + pb.Height);



            btn2 = new Button();
            btn2.Height = 50;
            btn2.Width = 100;
            btn2.Text = "Loo";
            btn2.Location = new Point(lb.Left, lb.Bottom);
            btn2.Click += Btn2_Click;


            btn3 = new Button();
            btn3.Height = 50;
            btn3.Width = 100;
            btn3.Text = "Kustuta";
            btn3.Location = new Point(lb.Left, btn2.Bottom);
            btn3.Click += Btn3_Click;


            //data

            treeNode.Nodes.Add(new TreeNode("DataGridView"));
            DataSet ds = new DataSet("XML fail. Menüü");
            ds.ReadXml(@"..\..\..\books.xml");
            DataGridView dataGrid = new DataGridView();
            dataGrid.Location = new Point(tree.Width + pb.Width, pb.Location.Y);
            dataGrid.DataSource = ds;
            dataGrid.AutoGenerateColumns = true;
            dataGrid.AutoSize = true;
            dataGrid.DataMember = "book";
            dataGrid.ReadOnly = true;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            //triangle
            treeNode.Nodes.Add(new TreeNode("Kolmnurk"));
            btn2= new Button();
            btn2.Height = 50;
            btn2.Click += Btn2_Click;



            this.Controls.Add(dataGrid);
            tree.Nodes.Add(treeNode);
            this.Controls.Add(txt_box);
            this.Controls.Add(r1);
            this.Controls.Add(r2);
            this.Controls.Add(tree);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            this.Controls.Add(c1);
            this.Controls.Add(c2);
            this.Controls.Add(pb);
            this.Controls.Add(lb);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            txt_box.Visible = false;
            lbl.Visible = false;
            btn.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            c1.Visible = false;
            c2.Visible = false;
            pb.Visible = false;
            lb.Visible = false;


        }


        private void Btn2_Click(object? sender, EventArgs e)
        {
            string tekst = Interaction.InputBox("Lisa uus väli", "Pealkiri muutmine", "Väli");
            if (tekst.Length > 0 && !lb.Items.Contains(tekst))
            {
                lb.Items.Add(tekst);
                lb.Height += 20;
                btn2.Location = new Point(lb.Left, lb.Bottom);
            }
        }

        private void Btn3_Click(object? sender, EventArgs e)
        {
            if (lb.SelectedItem != null)
            {
                lb.Items.Remove(lb.SelectedItem);
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode selectedNode = tree.GetNodeAt(e.X, e.Y);
                MessageBox.Show("Te klõpsasite sõlme: " + selectedNode.Text);
                Console.WriteLine("Klõpsake");
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Te klõpsasite sõlme: " + e.Node.Text, "Lahendus 2");
            }
        }


        private void Txt_box_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txt_box.Enabled = false;
                    this.Text = txt_box.Text;
                }
                else
                {
                    string tekst = Interaction.InputBox("Sisesta pealkiri", "Pealkiri muutmine", "Uus pealkiri");
                    if (tekst.Length > 0)
                    {
                        this.Text = tekst;

                    }


                }
            }
            else if (e.KeyCode == Keys.Back)
            {

                txt_box.Clear();
            }
        }

        private void CheckBox_Changed(object? sender, EventArgs e)
        {

            if (c1.Checked == true && c2.Checked == false)
            {

                tree.SelectedNode = null;
                isPBVisible = !isPBVisible;
                pb.Visible = !isPBVisible;

            }
        }

        private void Radiobuttons_Changed(object? sender, EventArgs e)
        {
            if (r1.Checked)
            {
                this.BackColor = Color.White;
                r1.ForeColor = Color.Black;
                r2.ForeColor = Color.Black;

            }
            if (r2.Checked)
            {
                this.BackColor = Color.Black;
                r1.ForeColor = Color.White;
                r2.ForeColor = Color.White;
            }


        }


        private void Btn_MouseHover(object? sender, EventArgs e)
        {
            btn.BackColor = Color.Red;
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btn.Visible = isBtnVisible;
            lbl.Visible = isLblVisible;
            txt_box.Visible = isTxtVisible;
            r1.Visible = isRVisible;
            r2.Visible = isRVisible;
            c1.Visible = isCBVisible;
            c2.Visible = isCBVisible;
            pb.Visible = isPBVisible;
            lb.Visible = isLBVisible;

            if (e.Node.Text == "Nupp-Button")
            {
                isBtnVisible = true;
            }
            else if (e.Node.Text == "Silt-Label")
            {
                isLblVisible = true;
            }
            else if (e.Node.Text == "Tekstkast-Texbox")
            {
                isTxtVisible = true;
            }
            else if (e.Node.Text == "RadioNupp-RadioButton")
            {
                isRVisible = true;
            }
            else if (e.Node.Text == "Kontrollkast-CheckBox")
            {
                isCBVisible = true;
            }
            else if (e.Node.Text == "Piltkast-PictureBox")
            {
                isPBVisible = true;
            }
            else if (e.Node.Text == "ListBox")
            {
                isLBVisible = true;
            }
            else if (e.Node.Text == "Kolmnurk")
            {
                isLBVisible = true;
                triangleForm = new TriangleForm();
                triangleForm.Show(); 
            }

        }



        private void Btn_Click(object? sender, EventArgs e)
        {
            if (btn.BackColor == Color.Plum)
            {
                btn.BackColor = Color.Pink;
            }
            else
            {
                btn.BackColor = Color.Plum;
            }
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:
                    MessageBox.Show("Vasaku nupu klõpsamine");
                    btn.BackColor = Color.Red;
                    break;
                case MouseButtons.Right:
                    MessageBox.Show("Parema nupu klõpsamine");
                    btn.BackColor = Color.Green;
                    break;
                case MouseButtons.Middle:
                    MessageBox.Show("Keskmise nupu klõpsamine");
                    btn.BackColor = Color.Yellow;
                    break;

                default:
                    break;
            }
        }
    }
}