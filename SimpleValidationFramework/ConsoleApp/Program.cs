using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Model.User jkp = new Model.User() { firstname = "jkpr5", lastname = "kingjp", age =22, password = "123456", email="kingkrys@gmail.com" };

            Console.WriteLine("Validate Result {0}", jkp.IsValid); // cause by address;

            jkp = new Model.User() { firstname = "jkpr5", lastname = "kingjp", age = -1, password = "123456", email = "kingkrys" };
            Console.WriteLine("Validate Result {0}", jkp.IsValid); // false cause by age, email;

            jkp = new Model.User() { firstname = "jkpr5", lastname = "kingjp", age = 22, password = "KLPERTS", email = "kingkrys@gmail.com" };
            jkp.Address.address = "172 Tran Nhan Ton, Q5";
            jkp.Address.province = "Binh Thuan";
            jkp.Address.city = "Unknow";
            Console.WriteLine("Validate Result {0}", jkp.IsValid); // everything is ok
        }
    }
}
