using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppDem
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.BackColor = Color.DarkGray;
            btn.Location = new Point(130, 10);
            btn.Height = 40;
            btn.Width = 80;
            btn.Click += Btn_Click;
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Dadova";
            lbl.Size = new Size(45, 15);
            lbl.Location = new Point(148, 60);
            tn.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text=="Silt-Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(230, 10);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(230, 40);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "Vasakule";
                r1.Location = new Point(130, 90);
                r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
                r2 = new RadioButton();
                r2.Text = "Paremale";
                r2.Location = new Point(250, 90);
                r2.CheckedChanged += new EventHandler(RadioButtons_Changed);
                this.Controls.Add(r1);
                this.Controls.Add(r2);
            }
            else if(e.Node.Text == "Tekstkast-TextBox")
            {
                string text;
                try
                {
                    text = File.ReadAllText(path: "text.txt");
                }
                catch (FileNotFoundException exception)
                {
                    text = "tekst puudub";
                }
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text;
                txt_box.Location = new Point(130, 120);
                txt_box.Height = 200;
                txt_box.Width = 200;
                this.Controls.Add(txt_box);
            }
        }

        private void RadioButtons_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(130, 10);
                lbl.Location = new Point(148, 60);
            }
            else
            {
                btn.Location = new Point(495, 10);
                lbl.Location = new Point(518, 60);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor==Color.Green)
            {
                btn.BackColor = Color.Orange;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.Orange;
            }
            else
            {
                btn.BackColor = Color.Green;
                lbl.BackColor = Color.Orange;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}
