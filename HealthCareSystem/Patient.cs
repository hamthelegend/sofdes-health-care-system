using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem
{
    public class Patient
    {
        public int id;
        public string name;
        public string phone;

        public Patient(int id, string name, string phone)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
        }

        public override string ToString()
        {
            return $"{name} ({phone})";
        }
    }
}
