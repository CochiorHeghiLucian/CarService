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

            foreach (Client client in clients)
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
            foreach (Client client in clients)
            {
                if (client.Telefon.Equals(inputText))
                {
                    string listboxStr = client.Nume + " " + client.Prenume + " | " + client.Telefon + " | " + client.Email + " | " + client.Judet + " | " + client.Localitate;
                    listBox1.Items.Add(listboxStr);
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddNewCar addNewCarForm = new AddNewCar();
            addNewCarForm.ShowDialog();
        }

        private void populateCars(object sender, EventArgs e)
        {
            string txt = listBox1.SelectedItem.ToString();
            Client client = findClientByTelefon(getPhoneNumber(txt));
            carListbox.Items.Clear();
            foreach (Auto auto in client.Autoes)
            {
                string listboxStr = auto.NumarAuto + " | " + auto.SerieSasiu + " | " + auto.Sasiu.CodSasiu + " | " + auto.Sasiu.Denumire;
                carListbox.Items.Add(listboxStr);
            }
            // MessageBox.Show(getPhoneNumber(txt));
        }

        private string getPhoneNumber(string listBoxItemText)
        {
            var phoneNumber = new StringBuilder("");
            int i = 0;

            while (listBoxItemText[i] != '|')
            {
                //phoneNumber.Append(listBoxItemText[i]);
                i++;
            }
            i = i + 2;
            while (listBoxItemText[i] != ' ')
            {
                phoneNumber.Append(listBoxItemText[i]);
                i++;
            }

            return phoneNumber.ToString();
        }

        private Client findClientByTelefon(string phoneNumber)
        {

            foreach (Client client in clientRepository.GetAll())
            {
                if (client.Telefon.Equals(phoneNumber))
                {
                    return client;
                }
            }
            return null;
        }

        private void selectedACertainCar(object sender, MouseEventArgs e)
        {
            string carNumber = getCarNumber(carListbox.SelectedItem.ToString());
            string userPhoneNumber = getPhoneNumber(listBox1.SelectedItem.ToString());
            //MessageBox.Show(carNumber);
            //MessageBox.Show(userPhoneNumber);

            Client client = findClientByTelefon(userPhoneNumber);
            Auto auto = findAutoByAutoNumber(carNumber, client.Autoes);

            CreateComandaForm createComandaForm = new CreateComandaForm(auto);
            createComandaForm.ShowDialog();

        }

        private string getCarNumber(string txt)
        {
            var result = new StringBuilder("");
            int i = 0;
            while (txt[i] != ' ' || txt[i + 1] != '|')
            {
                result.Append(txt[i]);
                i++;
            }

            return result.ToString();
        }

        private Auto findAutoByAutoNumber(string autoNumber, ICollection<Auto> autos)
        {
            foreach (Auto auto in autos)
            {
                if (auto.NumarAuto.Equals(autoNumber))
                {
                    return auto;
                }
            }
            return null;
        }
    }
}
