using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpSyntax
{
    class syn_auto_implemented_property
    {
    }
    // This class is immutable. After an object is created,
    // it cannot be modified from outside the class. It uses a
    // constructor to initialize its properties.
    class Contact
    {
        // Read-only property.
        public string Name { get; }

        // Read-write property with a private set accessor.
        public string Address { get; private set; }

        // Public constructor.
        public Contact(string contactName, string contactAddress)
        {
            Name = contactName;
            Address = contactAddress;
        }
    }

    // This class is immutable. After an object is created,
    // it cannot be modified from outside the class. It uses a
    // static method and private constructor to initialize its properties.
    public class Contact2
    {
        // Read-write property with a private set accessor.
        public string Name { get; private set; }

        // Read-only property.
        public string Address { get; }

        // Private constructor.
        private Contact2(string contactName, string contactAddress)
        {
            Name = contactName;
            Address = contactAddress;
        }

        // Public factory method.
        public static Contact2 CreateContact(string name, string address)
        {
            return new Contact2(name, address);
        }
    }
    public class FingerPrint
    {
        public DateTime TimeStamp { get; } = DateTime.UtcNow;

        //public string User { get; } =
        //  System.Security.Principal.WindowsPrincipal.Current.Identity.Name;

        public string Process { get; } =
          System.Diagnostics.Process.GetCurrentProcess().ProcessName;
    }

    public class Program
    {
        static void Main()
        {
            FingerPrint fi = new FingerPrint();
            string whattt = fi.Process;
            Console.WriteLine(whattt + fi.TimeStamp);
            
            
            
            
            // Some simple data sources.
            string[] names = {"Terry Adams","Fadi Fakhouri", "Hanying Feng",
                            "Cesar Garcia", "Debra Garcia"};
            string[] addresses = {"123 Main St.", "345 Cypress Ave.", "678 1st Ave",
                                "12 108th St.", "89 E. 42nd St."};

            // Simple query to demonstrate object creation in select clause.
            // Create Contact objects by using a constructor.
            var query1 = from i in Enumerable.Range(0, 5)
                         select new Contact(names[i], addresses[i]);

            // List elements cannot be modified by client code.
            var list = query1.ToList();
            foreach (var contact in list)
            {
                Console.WriteLine("{0}, {1}", contact.Name, contact.Address);
            }

            // Create Contact2 objects by using a static factory method.
            var query2 = from i in Enumerable.Range(0, 5) select Contact2.CreateContact(names[i], addresses[i]);

            // Console output is identical to query1.
            var list2 = query2.ToList();
            foreach (var contact in list2)
            {
                Console.WriteLine("{0}, {1}", contact.Name, contact.Address);
            }

          





        // List elements cannot be modified by client code.
        // CS0272:
        // list2[0].Name = "Eugene Zabokritski";

        // Keep the console open in debug mode.
        Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    /* Output:
        Terry Adams, 123 Main St.
        Fadi Fakhouri, 345 Cypress Ave.
        Hanying Feng, 678 1st Ave
        Cesar Garcia, 12 108th St.
        Debra Garcia, 89 E. 42nd St.
    */
}
