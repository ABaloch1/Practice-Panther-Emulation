using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        //private static object _lock = new object();
        public static ClientService Current {
            get
            {
                if (instance == null) 
                {
                    instance = new ClientService();
                }
                
                return instance;
            }
        }

        private List<Client> ClientList;
        public List<Client> getclientList
        {
            get { return ClientList; }

        }

        private ClientService()
        {
            //going to force some mfs into this and see if shit works lol
            //ClientList = new List<ClientService>();

            ClientList = new List<Client>
            {
                new Client{Id = 1, Name = "Booby"},
                new Client{Id = 2, Name = "Smelly"},
                new Client{Id = 3, Name = "Dumpy"}
            };
        }

        
        //finding client by name
        /*
        public List<Client> Search(string query)
        {
            return getclientList.Where(s => s.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
        */

        public Client? Get(int id)
        {
            return ClientList.FirstOrDefault(s => s.Id == id);
        }

        public void AddorUpdate(Client c) 
        {
            if(c.Id == 0)
            {
                //add
                c.Id = LastId + 1;
                ClientList.Add(c);
            }
        }

        private int LastId
        {
            get
            {
                return ClientList.Any() ? ClientList.Select(c => c.Id).Max() : 0;
            }
        }

        public IEnumerable<Client> Search(string query)
        {
            return ClientList.Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void Delete(int id) 
        {
            var remove = Get(id);
            if (remove != null)
            {
                ClientList.Remove(remove);
            }
        }

        public void Delete(Client client) 
        {
            Delete(client.Id);
        }

        /*
        public void Update(Client? client)
        {
            if(client != null)
            {

            }
        }
        */

        public void Read()
        {
            ClientList.ForEach(Console.WriteLine);
        }


    }
}
