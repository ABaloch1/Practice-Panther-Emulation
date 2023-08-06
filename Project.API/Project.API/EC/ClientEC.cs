using Project.API.Database;
using Project_library.DTO;
using Project_library.Models;


namespace Project.API.EC
{
    public class ClientEC
    {
        public ClientDTO AddorUpdate(ClientDTO dto)
        {
            if (dto.Id > 0)
            {
                var clientToUpdate
                    = FakeDatabase.getclientList.FirstOrDefault(c => c.Id == dto.Id);
                if (clientToUpdate != null)
                {
                    FakeDatabase.getclientList.Remove(clientToUpdate);
                }
                FakeDatabase.getclientList.Add(new Client(dto));
            }
            else
            {
                dto.Id = FakeDatabase.LastClientId + 1;
                FakeDatabase.getclientList.Add(new Client(dto));
            }
            return dto;
        }

        public ClientDTO? Get(int id)
        {
            var returnVal = FakeDatabase.getclientList
                 .FirstOrDefault(c => c.Id == id)
                 ?? new Client();

            return new ClientDTO(returnVal);
        }


        public ClientDTO? Delete(int id)
        {
            var clientToDelete = FakeDatabase.getclientList.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                FakeDatabase.getclientList.Remove(clientToDelete);
            }
            return clientToDelete != null ?
                new ClientDTO(clientToDelete)
                : null;
        }

        public IEnumerable<ClientDTO> Search(string query = "")
        {
            return FakeDatabase.getclientList.Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new ClientDTO(c));
        }


    }
}
