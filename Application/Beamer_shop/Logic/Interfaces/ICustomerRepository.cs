﻿using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers();
        public bool RegisterCustomer(Register customer);
        public Customer ValidateCredentials(Login customer);


    }
}