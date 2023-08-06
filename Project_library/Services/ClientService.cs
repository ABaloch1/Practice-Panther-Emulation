using Project_library.Utilities;
using Project_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Project_library.DTO;

namespace Project_library.Services
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

        private List<ClientDTO> clients;
        public List<ClientDTO> getclientList
        {
            get
            {

                return clients ?? new List<ClientDTO>();
            }
        }

        private ClientService()
        {
            var response = new WebRequestHandler()
                .Get("/Client")
                .Result;

            clients = JsonConvert
               .DeserializeObject<List<ClientDTO>>(response)
               ?? new List<ClientDTO>();
        }


        public ClientDTO? Get(int id)
        {
            return getclientList.FirstOrDefault(s => s.Id == id);
        }

        public void AddorUpdate(ClientDTO c)
        {
            var response
                = new WebRequestHandler().Post("/Client",  c).Result;

            var myUpdatedClient = JsonConvert.DeserializeObject<ClientDTO>(response);
            if (myUpdatedClient != null)
            {
                var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                if (existingClient == null)
                {
                    clients.Add(myUpdatedClient);
                }
                else
                {
                    var index = clients.IndexOf(existingClient);
                    clients.RemoveAt(index);
                    clients.Insert(index, myUpdatedClient);
                }
            }
        }

        //private int LastId
        //{
        //    get
        //    {
        //        return getclientList.Any() ? getclientList.Select(c => c.Id).Max() : 0;
        //    }
        //}

        public IEnumerable<ClientDTO> Search(string query)
        {
            return getclientList.Where
                (c => c.Name.ToUpper()
                .Contains(query.ToUpper()));
        }

        public void Delete(int id)
        {
            var clientToDelete = getclientList.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                getclientList.Remove(clientToDelete);
            }
        }
    }

    //public void Delete(Client client) 
    //{
    //    Delete(client.Id);
    //}

    /*
    public void Update(Client? client)
    {
        if(client != null)
        {

        }
    }
    */

    //public void Read()
    //{
    //    //ClientList.ForEach(Console.WriteLine);
    //}

}
