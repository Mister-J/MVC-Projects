using SkiWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiWebApplication.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> employees { get; set; }
        public string UserName { get; set; }
    }
}