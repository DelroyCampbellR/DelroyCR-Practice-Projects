﻿using FirstMVCSQL.Models;

namespace FirstMVCSQL.Data
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
        Task Insert(Contact contact);
        Task Update(Contact contact);
        Task Delete(int id);
    }
}
