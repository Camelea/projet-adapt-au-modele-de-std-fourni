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

namespace ConsoleApp4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			StreamWriter file = new StreamWriter(@"C:\Users\CameleaOUARKOUB\Desktop\Test\test.txt");
			MessageBox.Show("Le fichier a bien été créé dans l'emplacement spécifié!", "ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
			file.Write("Bonjour, ceci est un test, votre fichier a bien été créé.");
			file.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
