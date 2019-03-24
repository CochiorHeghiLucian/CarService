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
    public partial class AddNewCar : Form
    {
        AutoRepository autoRepository;
        ClientRepository clientRepository;
        SasiuRepository sasiuRepository;

        public AddNewCar()
        {
            InitializeComponent();
            autoRepository = new AutoRepository();
            clientRepository = new ClientRepository();
            sasiuRepository = new SasiuRepository();
        }

        private void createCarButton_Click(object sender, EventArgs e)
        {
            Client client = findClientByTelefon(telefonTextbox.Text);
            if (client != null && !checkIfAutoDoesntExistsInClientAutoes(client, numarAutoTextbox.Text))
            {
                Auto auto = new Auto();
                auto.NumarAuto = numarAutoTextbox.Text;
                auto.SerieSasiu = serieSasiuTextbox.Text;

                var codSasiu = new StringBuilder("");
                codSasiu.Append(auto.SerieSasiu[6]);
                codSasiu.Append(auto.SerieSasiu[7]);
                Sasiu sasiu = findSasiuByCodSasiu(codSasiu.ToString());
                auto.Sasiu = sasiu;
                client.Autoes.Add(auto);
                clientRepository.Update(client);
                MessageBox.Show("Masina " + auto.NumarAuto + " s-a adaugat la clientul " + client.Nume + " " + client.Prenume);
            }
            else
            {
                MessageBox.Show("Masina CU NUMARUL AUTO:" + numarAutoTextbox.Text + " exista deja sau numarul de telefon " + telefonTextbox.Text + " nu exista in baza de date");
            }

        }

        private bool checkIfAutoDoesntExistsInClientAutoes(Client client, string numarAuto)
        {
            foreach (Auto auto in client.Autoes)
            {
                if (auto.NumarAuto.Equals(numarAuto))
                {
                    return true;
                }
            }
            return false;
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

        private void createSasiuButton_Click(object sender, EventArgs e)
        {
            if (findSasiuByCodSasiu(codSasiuTextbox.Text) == null)
            {
                Sasiu sasiu = new Sasiu();
                sasiu.CodSasiu = codSasiuTextbox.Text;
                sasiu.Denumire = denumireTextbox.Text;
                sasiuRepository.Add(sasiu);
                MessageBox.Show("Sasiul " + denumireTextbox.Text + " s-a inserat cu succes");
            }
            else
            {
                MessageBox.Show("Sasiul " + denumireTextbox.Text + " exista deja in baza de date");
            }
        }

        private Sasiu findSasiuByCodSasiu(string codSasiu)
        {
            foreach (Sasiu sasiu in sasiuRepository.GetSasiuri())
            {
                if (sasiu.CodSasiu.Equals(codSasiu))
                {
                    return sasiu;
                }
            }
            return null;
        }

        private void UpdateSasiuButton_Click(object sender, EventArgs e)
        {
            Sasiu sasiu = findSasiuByCodSasiu(codSasiuTextbox.Text);
            if (sasiu != null)
            {
                sasiu.Denumire = denumireTextbox.Text;
                sasiuRepository.Update(sasiu);
                MessageBox.Show("Update sasasiu cu succes");
            }
            else
            {
                MessageBox.Show("Sasiul cu codSasiu = " + codSasiuTextbox.Text + " nu exista in baza de date");
            }
        }

        private void updateCarButton_Click(object sender, EventArgs e)
        {
            Auto auto = findCarByNrAuto(numarAutoTextbox.Text);
            if (auto != null)
            {
                auto.SerieSasiu = serieSasiuTextbox.Text;

                var codSasiu = new StringBuilder("");
                codSasiu.Append(auto.SerieSasiu[6]);
                codSasiu.Append(auto.SerieSasiu[7]);
                Sasiu sasiu = findSasiuByCodSasiu(codSasiu.ToString());
                auto.Sasiu = sasiu;
                autoRepository.Update(auto);
                MessageBox.Show("Masina " + auto.NumarAuto + " a fost updatata ");
            }
            else
            {
                MessageBox.Show("Masina " + auto.NumarAuto + " nu exista in baza de date");
            }
        }

        private Auto findCarByNrAuto(string numarAuto)
        {
            foreach (Auto auto in autoRepository.GetAll())
            {
                if (auto.NumarAuto.Equals(numarAuto))
                {
                    return auto;
                }
            }
            return null;
        }

        private void deleteCarButton_Click(object sender, EventArgs e)
        {
            Auto auto = findCarByNrAuto(deleteCarTextbox.Text);
            if(auto != null)
            {
                autoRepository.Delete(auto.AutoId);
                MessageBox.Show("Masina cu numarul " + deleteCarTextbox.Text + " a fost stearsa");
            }
            else
            {
                MessageBox.Show("Masina cu numarul " + deleteCarTextbox.Text + " nu exista in baza de date");
            }
        }

        private void deleteSasiuButton_Click(object sender, EventArgs e)
        {
            Sasiu sasiu = findSasiuByCodSasiu(deleteCodSasiuTextbox.Text);
            if (sasiu != null)
            {
                if (checkSasiuExistsInOtherCar(deleteCodSasiuTextbox.Text))
                {
                    MessageBox.Show("Sasiul cu codsasiu " + deleteCarTextbox.Text + " nu poate fi sters pentru ca apare in alta masina");
                }
                else
                {
                    sasiuRepository.Delete(sasiu.SasiuId);
                    MessageBox.Show("Sasiul cu codsasiu " + deleteCarTextbox.Text + " a fost stearsa");
                }
                
            }
            else
            {
                MessageBox.Show("Sasiul cu codsasiu " + deleteCodSasiuTextbox.Text + " nu exista in baza de date");
            }
        }

        private bool checkSasiuExistsInOtherCar(string codSasiu)
        {
            foreach (Auto auto in autoRepository.GetAll())
            {
                if(auto.SerieSasiu[6] == codSasiu[0] && auto.SerieSasiu[7] == codSasiu[1])
                {
                    return true;
                }
            }

                return false;
        }

        private void updateNrAutoButton_Click(object sender, EventArgs e)
        {
            Auto auto = findCarByNrAuto(updateNrAutoExiTextbox.Text);
            if(auto != null)
            {
                if(findCarByNrAuto(updateNrAutoNewTextbox.Text) == null)
                {
                    auto.NumarAuto = updateNrAutoNewTextbox.Text;
                    autoRepository.Update(auto);
                    MessageBox.Show("Numarul auto: " + updateNrAutoExiTextbox.Text + " a fost updatat cu " + updateNrAutoNewTextbox.Text);
                }
                else
                {
                    MessageBox.Show("Numarul auto: " + updateNrAutoNewTextbox.Text + " exista deja in baza de date");
                }
            }
            else
            {
                MessageBox.Show("Numarul auto: " + updateNrAutoExiTextbox.Text + " exista deja in baza de date");
            }
        }
    }
}
