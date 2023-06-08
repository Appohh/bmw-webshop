﻿using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        bool RegisterEmployee(RegisterEmployee employee);
        (string hash, string salt, int id)? GetHashSalt(string email);
        Employee? GetEmployeeById(int id);
        bool DeleteEmployee(int id);

    }
}
