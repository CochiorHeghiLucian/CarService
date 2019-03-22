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
    public partial class NewUserForm : Form
    {
        ClientRepository clientRepository;
        public NewUserForm()
        {
            InitializeComponent();
            clientRepository = new ClientRepository();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (checkIsFilled(numeTextbox.Text, prenumeTextbox.Text, adresaTextbox.Text, localitateTextbox.Text, judetTextbox.Text, telefonTextbox.Text, emailTextbox.Text) && !phoneNumberIsAlreadyExists(telefonTextbox.Text))
            {
                Client client = new Client();
                client.Nume = numeTextbox.Text;
                client.Prenume = prenumeTextbox.Text;
                client.Adresa = adresaTextbox.Text;
                client.Localitate = localitateTextbox.Text;
                client.Judet = judetTextbox.Text;
                client.Telefon = telefonTextbox.Text;
                client.Email = emailTextbox.Text;
                clientRepository.Add(client);
                MessageBox.Show("Userul a fost inserat");
            }
            else
            {
                MessageBox.Show("Nu sunt completate toate fieldurile sau numarul de telefon exista deja in baza de date");
            }

        }

        private bool checkIsFilled(string nume, string prenume, string adresa, string localitate, string judet, string telefon, string email)
        {
            if (nume == "" || prenume == "" || adresa == "" || localitate == "" || judet == "" || telefon == "" || email == "")
            {
                return false;
            }
            if (nume == " " || prenume == " " || adresa == " " || localitate == " " || judet == " " || telefon == " " || email == " ")
            {
                return false;
            }
            return true;
        }

        private bool phoneNumberIsAlreadyExists(string phoneNumber)
        {
            List<Client> clients = clientRepository.GetAll();
            foreach (Client client in clients)
            {
                if (client.Telefon.Equals(phoneNumber))
                {
                    return true;
                }
            }
            return false;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (checkIsFilled(numeTextbox.Text, prenumeTextbox.Text, adresaTextbox.Text, localitateTextbox.Text, judetTextbox.Text, telefonTextbox.Text, emailTextbox.Text) && !phoneNumberIsAlreadyExists(telefonTextbox.Text))
            {
                List<Client> clients = clientRepository.GetAll();
                Boolean ok = false;
                foreach (Client client in clients)
                {
                    if (client.Telefon.Equals(telefonTextbox.Text))
                    {
                        client.Nume = numeTextbox.Text;
                        client.Prenume = prenumeTextbox.Text;
                        client.Adresa = adresaTextbox.Text;
                        client.Localitate = localitateTextbox.Text;
                        client.Judet = judetTextbox.Text;
                        client.Telefon = telefonTextbox.Text;
                        client.Email = emailTextbox.Text;
                        clientRepository.Add(client);
                        clientRepository.Update(client);
                        MessageBox.Show("Userul a fost updatat");
                        ok = true;
                        break;
                    }
                }
                if (!ok)
                {
                    MessageBox.Show("Numarul de telefon nu exista in baza de date");
                }

            }
            else
            {
                MessageBox.Show("Nu sunt completate toate fieldurile sau numarul de telefon exista deja in baza de date");
            }

        }

        private void deteteButton_Click(object sender, EventArgs e)
        {
            if (phoneNumberIsAlreadyExists(deleteUserTextbox.Text))
            {
                List<Client> clients = clientRepository.GetAll();
                foreach (Client client in clients)
                {
                    if (client.Telefon.Equals(deleteUserTextbox.Text))
                    {
                        clientRepository.Delete(client.ClientId);
                        MessageBox.Show("Userul " + client.Nume + " " + client.Prenume + " a fost sters.");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Numarul de telefon nu exista in baza de date");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (phoneNumberIsAlreadyExists(updateNumberExiTextbox.Text) && !phoneNumberIsAlreadyExists(updateNumberNewTextbox.Text))
            {
                List<Client> clients = clientRepository.GetAll();
                foreach (Client client in clients)
                {
                    if (client.Telefon.Equals(updateNumberExiTextbox.Text))
                    {
                        client.Telefon = updateNumberNewTextbox.Text;
                        clientRepository.Update(client);
                        MessageBox.Show("Numarul " + updateNumberExiTextbox.Text + " a fost schimbat cu " + updateNumberNewTextbox.Text);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Numarul de telefon nu exista in baza de date");
            }
        }
    }
}
