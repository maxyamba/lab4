using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;

namespace lab4
{
   
    public partial class Form1 : Form
    {
        
        public class City
        {
            [Key]
            [Required(ErrorMessage = "Введіть код")]
            public int id_city { get; set; }
            [Required(ErrorMessage = "Введіть місто")]
            public string city { get; set; }
            [Required(ErrorMessage = "Введіть код")]
            public int id_country { get; set; }
            [Required(ErrorMessage = "Введіть код")]
            public int id_cinema { get; set; }
            public List<City> Cities { get; set; }
        }


        public class Cinema
        {
            [Key]
            [Required(ErrorMessage = "Введіть код")]
            public int id_cinema { get; set; }
            [Required(ErrorMessage = "Введіть кінотеатр")]
            public string cinema { get; set; }
            [Required(ErrorMessage = "Введіть код")]
            public int id_city { get; set; }
            public List<Cinema> Cinemas { get; set; }
        }
        public class Country
        {
            [Key]
            [Required(ErrorMessage = "Введіть код")]
            public int id_country { get; set; }
            [Required(ErrorMessage = "Введіть країну")]
            public string country { get; set; }
            [Required(ErrorMessage ="Введіть код")]
           // public int id_city { get; set; }
            public List<Country> Countries { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            button4.Enabled = false;
        }

        public class UserContext : DbContext
        {
            public UserContext() :
                base("cinemaConnection")
            { }

            public DbSet<City> Cities { get; set; }
            public DbSet<Cinema> Cinemas { get; set; }
            public DbSet<Country> Countries { get; set; }
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            UserContext db = new UserContext();
           
            db.Cities.Load();
            dataGridView1.DataSource = db.Cities.Local.ToBindingList();
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            
            button4.Enabled = true;
            UserContext db = new UserContext();

            db.Cinemas.Load();
            dataGridView1.DataSource = db.Cinemas.Local.ToBindingList();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UserContext db = new UserContext();

            db.Countries.Load();
            dataGridView1.DataSource = db.Countries.Local.ToBindingList();
        }

        public static void Validation()
        {
            using (var context = new UserContext())
            {
                var cinema = new Cinema() { cinema = string.Empty };
                context.Cinemas.Add(cinema);

                var validationErrors = context.GetValidationErrors()
                    .Where(vr => !vr.IsValid)
                    .SelectMany(vr => vr.ValidationErrors);

                foreach (var error in validationErrors)
                {
                    MessageBox.Show(error.ErrorMessage);

                    //Console.WriteLine(error.ErrorMessage);
                }

                //Console.ReadKey();
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
            UserContext db = new UserContext();
            try
            {
                Cinema st = db.Cinemas.First(s => s.cinema.Equals(textBox1.Text));
                st.cinema = textBox4.Text;

                db.SaveChanges();
                MessageBox.Show("inserted");
            }
            catch
            {
                Validation();
            }
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            /*using (var context = new UserContext())
            {
                var cinema = context.Cinemas.Find((textBox1.Text));

                // Change value directly in the DB
                using (var contextDB = new UserContext())
                {
                    contextDB.Database.ExecuteSqlCommand(
                        "UPDATE Cinemas SET cinema = cinema + '_DB' WHERE cinema = '" + textBox1.Text + "'");
                }

                // Change the current value in memory
                cinema.cinema = cinema.cinema + "_Memory";

                string value = context.Entry(cinema).Property(m => m.cinema).OriginalValue;
                textBox5.Text = value;
                //Console.WriteLine(string.Format("Original Value : {0}", value));

                value = context.Entry(cinema).Property(m => m.cinema).CurrentValue;
                textBox6.Text = value;
                //Console.WriteLine(string.Format("Current Value : {0}", value));

                value = context.Entry(cinema).GetDatabaseValues().GetValue<string>("cinema");
                textBox7.Text = value;
                //Console.WriteLine(string.Format("DB Value : {0}", value));

                //Console.ReadKey();
            }*/

            

            //UserContext db = new UserContext();
            using (var db = new UserContext())
            {

                /*var modified = db.Cinemas.Find("ery");
                if (modified != null)
                {
                    modified.cinema = textBox4.Text;
                }*/
                //textBox5.Text = textBox4.Text;
                String s = dataGridView1[1, 0].Value.ToString();
                string start = s;
                string  t;
                //const start;
                textBox5.Text = s;
                //const string r = dataGridView1[1, 0].Value.ToString();
                if (!textBox6.Text.StartsWith(s))
                {
                    t = string.Concat(s, textBox6.Text);

                    textBox6.Select(textBox6.Text.Length, 0);

                    if (t.Length == textBox5.Text.Length)
                    {
                        textBox6.Text = string.Concat(s, textBox6.Text);

                        textBox6.Select(textBox6.Text.Length, 0);
                       
                    }
                                        
                }

                textBox7.Text = textBox4.Text;
                //textBox6.Text = start;
                //string value = db.Entry(cin).Property(m => m.Name).OriginalValue;
            }

        
        }
    }
}
    
    

