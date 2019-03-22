using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProiectAuto.Repository
{
    public class ClientRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Client> GetAll() => db.Clients.ToList();

        public Client Add(Client client)
        {
            if (GetById(client.ClientId) != null)
            {
                return null;
            }

            db.Clients.Add(client);

            db.Clients.Add(client);
            db.SaveChanges();

            return client;
        }

        public Client GetById(int id)
        {
            Client auto = db.Clients.Find(id);
            return auto;
        }

        public Client Update(Client client)
        {

            if (GetById(client.ClientId) == null)
            {
                return null;
            }

            Client client1 = GetById(client.ClientId);

            client1.Nume = client.Nume;
            client1.Prenume = client.Prenume;
            client1.Adresa = client.Adresa;
            client1.Localitate = client.Localitate;
            client1.Judet = client.Judet;
            client1.Telefon = client.Telefon;
            client1.Email = client.Email;
            client1.Autoes = client.Autoes;

            db.SaveChanges();

            return client;
        }

        public Boolean Delete(int id)
        {
            Client client = GetById(id);
            if (client == null)
            {
                return false;
            }

            db.Clients.Remove(client);
            db.SaveChanges();
            return true;
        }

    }
}
