using Project_library.Models;

namespace Project.API.Database
{
    public class FakeDatabase
    {
        public static List<Client> getclientList = new List<Client>
        {
                new Client{Id = 1, Name = "Samad", IsActive = true},
                new Client{Id = 2, Name = "Chris", IsActive = true},
                new Client{Id = 3, Name = "Amir", IsActive = true, Notes="Roomate"}

        };

        public static int LastClientId
        {
            get
            {
                if (getclientList.Any())
                {
                    return getclientList.Select(x => x.Id).Max();
                }
                else
                {
                    return 0;
                }                
            }
        }    
    }
}
