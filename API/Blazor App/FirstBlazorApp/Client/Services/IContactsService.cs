using FirstBlazorApp.Shared;

namespace FirstBlazorApp.Client.Services
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
        Task Save(Contact contact);
        Task Delete(int id);
    }
}
