using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace ApiGit
{
    public partial class Form1 : Form
    {
        private GitHubClient _client;
        Graph graph;
        private int currentDepth;
        protected readonly string token = "105afb31155d270aa63f6a283c143b136bb0557a";
        public Form1()
        {
            InitializeComponent();
            InitClient();
        }

        private void InitClient()
        {
            _client = new GitHubClient(new ProductHeaderValue("GitApi"));
            var tokenAuth = new Credentials(token);
            _client.Credentials = tokenAuth;
        }

        public async Task GetRepositories(string username)
        {
            var repos = await _client.Repository.GetAllForUser(username);
            int i = 0;
            foreach (var item in repos)
            {
                
                listBox1.Items.Add(repos[i].Name);
                i++;
                
            }
        }

        public async Task GetFollowers(string username,int depth)
        {

            var user = await _client.User.Get(username);
           // label1.Text = user.Login;
            var followersClient = await _client.User.Followers.GetAll(username);
           
            currentDepth ++;
            foreach (var item in followersClient)
            {
                graph.AddEdge(username, item.Login);
                //listBox1.Items.Add(item.Login);
                if (currentDepth < depth) await GetFollowers(item.Login, depth);
            }
            currentDepth--;
            
        }

        public async Task DrawGraph(string username)
        {
            Form form = new Form();
            GViewer viewer = new GViewer();
            graph = new Graph("graph");
            currentDepth = 0;
            listBox1.Items.Clear();
            await GetRepositories(username);
            await GetFollowers(username, (int)numericUpDown1.Value);
            viewer.Graph = graph;
            form.SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            DrawGraph(username);
        }
    }
}
