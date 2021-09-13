using ONECommerce.Models;
using System.Threading.Tasks;

namespace ONECommerce.Repositories.Interface
{
    public interface IContactRepository
    {
        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address);
    }
}
