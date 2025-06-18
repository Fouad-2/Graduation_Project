using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Models.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(int Id, T entity);
        void Delete(int Id, T entity);
        List<T> View(); 
        T Find(int Id);
        List<Service> GetServicesByFreelancer(int Id);
        List<Order> GetOrdersForFreelancer(int Id);
        Freelancer FindByCustomerId(int Id);

    }
}
