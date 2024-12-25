using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace malzemekayıt
{
    public partial class müşteriler : Form
    {
        public müşteriler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CN4K9TK;Initial Catalog=Stok3;Integrated Security=True");

        private void müşteriler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'stok3DataSet2.Musteriler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.musterilerTableAdapter.Fill(this.stok3DataSet2.Musteriler);
            listele(); // Refresh the customer list when the form loads
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Placeholder for any event handling related to label5 (if needed).
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // EKLE: Insert customer data into the database
            String ad = textBox1.Text;   // Customer Name
            String soyad = textBox2.Text; // Customer Surname
            String telefon = textBox3.Text; // Customer Phone
            String email = textBox4.Text; // Customer Email
            String adres = textBox5.Text; // Customer Address
            String borc = textBox6.Text;  // Customer Debt

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Musteriler (Ad, Soyad, Telefon, Email, Adres, Borc) VALUES (@ad, @soyad, @telefon, @email, @adres, @borc)", baglanti);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@email", email);
                komut.Parameters.AddWithValue("@adres", adres);
                komut.Parameters.AddWithValue("@borc", borc);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele(); // Refresh the list after insertion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // SIL: Delete customer from the database
            string ad = textBox1.Text;  // Get the customer name to delete (ideally, use a unique identifier like ID)

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM Musteriler WHERE Ad = @ad", baglanti);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele(); // Refresh the list after deletion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Method to refresh the customer list (populate the DataGridView or similar UI component)
        private void listele()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Musteriler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Assuming there's a DataGridView to display the customer data
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
