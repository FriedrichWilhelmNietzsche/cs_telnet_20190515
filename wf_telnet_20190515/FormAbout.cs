using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wf_telnet_20190515
{
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
            string name = Environment.CurrentDirectory + "\\help\\";
            PaintTreeView(tree, name);
        }

        private void Form_About_Load(object sender, EventArgs e)
        {
                       tree.ExpandAll();
                     
        }

        //private void directoryTree_AfterExpand(object sender, TreeViewEventArgs e) {
        //    e.Node.Expand();
        //}

        //private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    string name = tree.SelectedNode.Name;
        //    string path = Environment.CurrentDirectory + "\\help\\" + name + ".html";
        //    if (File.Exists(path))
        //    {
        //        web.Navigate(path);
        //    }
        //}

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = tree.SelectedNode.Name;
            string path = Environment.CurrentDirectory + "\\help\\" + name + ".html";
            if (File.Exists(path))
            {
                web.Navigate(path);
                //  web.Refresh();
            }
        }


        private void PaintTreeView(TreeView treeView, string fullPath)
        {
            try
            {
                treeView.Nodes.Clear(); //清空TreeView

                DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
                int dircount = dir.Count();//获得文件夹对象数量
                int filecount = file.Count();//获得文件对象数量

                //循环文件夹
                for (int i = 0; i < dircount; i++)
                {
                    treeView.Nodes.Add(dir[i].Name);
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    GetMultiNode(treeView.Nodes[i], pathNode);
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {
                    treeView.Nodes.Add(file[j].Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n出错的位置为：Form1.PaintTreeView()");
            }
        }

        private bool GetMultiNode(TreeNode treeNode, string path)
        {
            if (Directory.Exists(path) == false)
            { return false; }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
            int dircount = dir.Count();//获得文件夹对象数量
            int filecount = file.Count();//获得文件对象数量
            int sumcount = dircount + filecount;

            if (sumcount == 0)
            { return false; }

            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                treeNode.Nodes.Add(dir[j].Name);
                string pathNodeB = path + "\\" + dir[j].Name;
                GetMultiNode(treeNode.Nodes[j], pathNodeB);
            }

            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                treeNode.Nodes.Add(file[j].Name);
            }
            return true;
        }
    }
}
