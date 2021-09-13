using ONECommerce.Data;
using ONECommerce.Models;
using ONECommerce.Repositories.Interface;
using System.Threading.Tasks;

namespace ONECommerce.Repositories.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly OneCommerceContext _dbContext;

        public ContactRepository(OneCommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> SendMessage(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> Subscribe(string address)
        {
            // implement your business logic
            var newContact = new Contact();
            newContact.Email = address;
            newContact.Message = address;
            newContact.Name = address;

            _dbContext.Contacts.Add(newContact);
            await _dbContext.SaveChangesAsync();

            return newContact;
        }

    }
}
