using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniMercado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
		MySqlConnection con = new MySqlConnection("datasource=localhost;port3306;username=root;password=");
		private string strMySql;

		private byte[] ConverteParaBitArray()
		{
			MemoryStream stream = new MemoryStream();
			byte[] barray;
			if (pictureBox1.Image == null)
			{
				stream = null;
				barray = new byte[stream.Length];
			}
			else
			{
				pictureBox1.Image.Save(stream, ImageFormat.Png);
				stream.Seek(0, SeekOrigin.Begin);
			}

			barray = new byte[stream.Length];
			stream.Read(barray, 0, Convert.ToInt32(stream.Length));
			return barray;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OpenFileDialog abrir = new OpenFileDialog();
			abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			abrir.Filter = " Image Files (*.bmp, *.jpg, *.png, *.jpeg)|*.bmp; *.jpg; *.png; *.jpeg";
			abrir.Multiselect = false;

			if(abrir.ShowDialog()== DialogResult.OK)
			{
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox1.Image = new Bitmap(abrir.FileName);
			}
		}
	}
}
