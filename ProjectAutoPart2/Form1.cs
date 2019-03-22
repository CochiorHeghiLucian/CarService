using ProiectAuto.Models;
using ProiectAuto.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAutoPart2
{
    public partial class CarService : Form
    {
        private ClientRepository clientRepository;
        private List<Client> clients;

        public CarService()
        {
            InitializeComponent();
            clientRepository = new ClientRepository();
            clients = clientRepository.GetAll();

            foreach(Client client in clients)
            {
                string listboxStr = client.Nume + " " + client.Prenume + " | " + client.Telefon + " | " + client.Email + " | " + client.Judet + " | " + client.Localitate;
                listBox1.Items.Add(listboxStr);
            }

            textBox1.Text = "Test";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            NewUserForm newUserForm = new NewUserForm();
            newUserForm.ShowDialog();
        }

        private void DisplayAllClients_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            clients = clientRepository.GetAll();
            foreach (Client client in clients)
            {
                string listboxStr = client.Nume + " " + client.Prenume + " | " + client.Telefon + " | " + client.Email + " | " + client.Judet + " | " + client.Localitate;
                listBox1.Items.Add(listboxStr);
            }

        }

        private void CarService_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoDataSet.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter1.Fill(this.autoDataSet.Clients);
            // TODO: This line of code loads data into the 'dataSet1.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.dataSet1.Clients);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_input_txt(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            listBox1.Items.Clear();
            foreach(Client client in clients)
            {
                if (client.Telefon.Equals(inputText))
                {
                    string listboxStr = client.Nume + " " + client.Prenume + " | " + client.Telefon + " | " + client.Email + " | " + client.Judet + " | " + client.Localitate;
                    listBox1.Items.Add(listboxStr);
                }
            }
            
        }
    }
}
