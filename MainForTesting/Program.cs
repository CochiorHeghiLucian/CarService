using ProiectAuto.Models;
using ProiectAuto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            SasiuRepository sasiuRepository = new SasiuRepository();
            AutoRepository autoRepository = new AutoRepository();
            ClientRepository clientRepository = new ClientRepository();

            Sasiu sasiu = new Sasiu();
            sasiu.SasiuId = 1;
            sasiu.CodSasiu = "12";
            sasiu.Denumire = "dsfsdfsdf";
            //sasiuRepository.Add(sasiu);

            //sasiuRepository.Update(sasiu);

            Client client = new Client();

            client.Nume = "TestName";
            client.Prenume = "TestPrenume";
            client.Adresa = "TestAdresa";
            client.Localitate = "TestLocali";
            client.Judet = "TestJudet";
            client.Telefon = "0746653884";
            client.Email = "TestEmail";




            ////List<Sasiu> sasiuri = sasiuApi.GetSasiuri();
            ////foreach (Sasiu sas in sasiuri)
            ////{
            ////    Console.WriteLine(sas.Denumire);

            ////Console.Read();

            ////sasiuRepository.UpdateSasiu(2, sasiu);
            ////sasiuRepository.Delete(2);

            Auto auto = new Auto();
            auto.NumarAuto = "TestNrAuto";

            auto.SerieSasiu = "TestSerie";

            auto.Sasiu = sasiu;

            Comanda comanda = new Comanda();
            comanda.StareComanda = "TestStareComanda";
            comanda.DataSystem = DateTime.Now;
            comanda.DataProgramare = DateTime.Now;
            comanda.DataFinalizare = DateTime.Now;
            comanda.KmBord = 100;
            comanda.Descriere = "Test Descriere";
            comanda.ValoarePiese = 100;


            Imagine imagine = new Imagine();
            imagine.Titlu = "TitluTest";
            imagine.Descriere = "TestDescriere";
            imagine.Data = DateTime.Now;


            DetaliuComanda detaliuComanda = new DetaliuComanda();
            detaliuComanda.Imagines.Add(imagine);
            comanda.DetaliuComanda = detaliuComanda;

           
            


            auto.Comandas.Add(comanda);



            //client.Autoes.Add(auto);
            client.Autoes.Add(auto);


            clientRepository.Add(client);

            //// clientRepository.Delete(1);
        }
    }
}
