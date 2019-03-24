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
    public partial class CreateComandaForm : Form
    {
        Auto auto;
        ComandaRepository comandaRepository;
        AutoRepository autoRepository;
        DetaliuComandaRepository detaliuComandaRepository;

        public CreateComandaForm()
        {
            InitializeComponent();
        }

        public CreateComandaForm(Auto auto)
        {
            InitializeComponent();
            this.auto = auto;
            comandaRepository = new ComandaRepository();
            autoRepository = new AutoRepository();
            detaliuComandaRepository = new DetaliuComandaRepository();
            numarAutoLabel.Text = auto.NumarAuto;
        }

        private void createComandaButton_Click(object sender, EventArgs e)
        {
            if (stareComandaTexbox.Text == "" || dataProgramareTextbox.Text == "")
            {
                MessageBox.Show("Nu s-au completat fieldurile pentru stare comanda si data programare");
                return;
            }
            Comanda comanda = new Comanda();
            DetaliuComanda detaliuComanda = new DetaliuComanda();
            detaliuComanda.esteStearsa = "false";
            comanda.StareComanda = stareComandaTexbox.Text;
            comanda.DataSystem = DateTime.Now;
            comanda.DataProgramare = DateTime.ParseExact(dataProgramareTextbox.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            comanda.DataFinalizare = DateTime.ParseExact(dataFinalizareTextbox.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            comanda.KmBord = Int32.Parse(kmBordTextbox.Text);
            comanda.Descriere = descriereTextbox.Text;
            comanda.DetaliuComanda = detaliuComanda;

            auto = autoRepository.GetById(auto.AutoId);
            auto.Comandas.Add(comanda);

            autoRepository.Update(auto);



            MessageBox.Show("Comanda a fost creata cu succes!");
        }

        private void deleteComandaButton_Click(object sender, EventArgs e)
        {
            Comanda comanda = comandaRepository.GetById(Int32.Parse(idTextbox.Text));
            if (comanda == null)
            {
                MessageBox.Show("Comanda nu exista in baza de date");
            }
            else
            {
                //detaliuComandaRepository.Delete(comanda.DetaliuComanda.DetaliuComandaId);
                comanda.DetaliuComanda.esteStearsa = "true";
                detaliuComandaRepository.Update(comanda.DetaliuComanda);
                MessageBox.Show("Comanda cu ID: " + comanda.ComandaId + " a fost stearsa");
            }
        }

        private void displayComenziButton_Click(object sender, EventArgs e)
        {
            comenziListBox.Items.Clear();
            foreach (Comanda comanda in auto.Comandas)
            {
                if (comanda.DetaliuComanda.esteStearsa.Equals("false"))
                {
                    string txt = "" + comanda.ComandaId + " | " + comanda.StareComanda + " | " + comanda.DataSystem.ToString("dd/mm/yyyy") + " | " + comanda.DataProgramare.ToString("dd/mm/yyyy") + " | " +
                        comanda.DataFinalizare.ToString("dd/mm/yyyy") + " | " + comanda.KmBord + " | " + comanda.ValoarePiese;
                    comenziListBox.Items.Add(txt);
                }
            }
        }

        private void updateComadaButton_Click(object sender, EventArgs e)
        {
            Comanda comanda = findComandaById(Int32.Parse(idTextbox.Text));
            comanda.StareComanda = stareComandaTexbox.Text;
            comanda.DataSystem = DateTime.Now;
            comanda.DataProgramare = DateTime.ParseExact(dataProgramareTextbox.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            comanda.DataFinalizare = DateTime.ParseExact(dataFinalizareTextbox.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            comanda.KmBord = Int32.Parse(kmBordTextbox.Text);
            comanda.Descriere = descriereTextbox.Text;

            comandaRepository.Update(comanda);
        }

        private Comanda findComandaById(int id)
        {
            foreach(Comanda comanda in auto.Comandas)
            {
                if (comanda.ComandaId.Equals(id))
                {
                    return comanda;
                }
            }
            return null;
        }
    }
}
