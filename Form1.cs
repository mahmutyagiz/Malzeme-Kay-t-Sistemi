using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //Veritbanı baglantısı için dahil edilen kutuphane
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace malzemekayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void listele() //veri tabanı kayıtlarını görüntülemesi için koydum 
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Malzemeler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CN4K9TK;Initial Catalog=Stok3;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        { //EKLE
            String t1 = textBox1.Text; //Malzeme kodu
            String t2 = textBox2.Text; //malzeme adı
            String t3 = textBox3.Text; //yıllık satıs
            String t4 = textBox4.Text; // birim fiyat
            String t5 = textBox5.Text; // min stok
            String t6 = textBox6.Text; // t süresi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler (MalzemeKodu, MalzemeAdi ,YillikSatis ,BirimFiyat ,MinStok ,TSuresi ) VALUES ('" + t1 + "' , '+" + t2 + "' , '+" + t3 + "' , '+" + t4 + "' , '+" + t5 + "' , '+" + t6 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }
        private void dataGrideView1CellContentClik(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();    // Seçili Veriyi üst kısma atama
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {//Silme kısmı
            string t1 = textBox1.Text; //seçilen satırın malzeme kodun alma
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('" + t1 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
        private void button3_Click(object sender, EventArgs e)
        {// güncelleme
            String t1 = textBox1.Text; //Malzeme kodu
            String t2 = textBox2.Text; //malzeme adı
            String t3 = textBox3.Text; //yıllık satıs
            String t4 = textBox4.Text; // birim fiyat
            String t5 = textBox5.Text; // min stok
            String t6 = textBox6.Text; // t süresi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='" + t1 + "', MalzemeAdı='" + t2 + "', Yilliksatiş= '" + t3 + "', BirimFiyat='" + t4 + "' , MinStok= '+" + t5 + "' , TSuresi= '+" + t6 + "' WHERE MalzemeKodu='" + t1 + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void aBCAnalizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Müşteriler formunu başlatma
            müşteriler müşterilerForm = new müşteriler();
            müşterilerForm.Show();  
        }

    }
}