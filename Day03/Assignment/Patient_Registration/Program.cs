namespace Patient_Registration
{
    public class Patient
    {

        public  string?   PatientId { get; set; }
        public string? Name { get; set; }

        public int Age { get;set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }


    }

    public class RegistrationManager
    {
        public static Patient PatientRegistration()
        {
            Patient curr =new Patient();

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("   HOSPITAL PATIENT REGISTRATION SYSTEM");
            Console.WriteLine("--------------------------------------------------\n");

            //Name
            while (true)
            {
                Console.Write("Enter patient Name : ");
                string name=Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    curr.Name = name;
                    break;
                }
                else
                {
                    Console.WriteLine(" Error : Name can not be Empty");
                }
            }

            //Age

            while (true)
            {

                try
                {
                    Console.Write("Enter Age : ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    if (age < 0 || age > 119)
                    {
                        Console.WriteLine("Error : Age must be between 1 and 119");
                    }
                    else
                    {
                        curr.Age = age;
                        break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Error : Please enter a valid numeric age");

                }

            }

            //Gender
            while (true)
            {
                Console.Write("Enter Gender (Male/Female/Other):");
                string gender=Console.ReadLine();
                string[] validGenders = { "Male", "Female", "Other" };
                if (Array.IndexOf(validGenders,gender) != -1)
                {
                    curr.Gender = gender;
                    break;

                }
                else
                {
                    Console.WriteLine("Error : Please enter a valid gender");
                }
            }

            //Phone Number
            while(true)
            {
                Console.Write("Enter Phone Number : ");
                string phno=Console.ReadLine();
                if(phno.Length==10 && long.TryParse(phno,out _))
                {
                    curr.PhoneNumber= phno;
                    break;
                }
                else { 
                    Console.WriteLine("Error : Enter a valid phone number");

                }
            }

            Console.Write("Enter city : ");
            string city=Console.ReadLine();
            curr.City = city;
            curr.PatientId = GeneratePatientID();
            Console.WriteLine("[Registration Complete]");
            return curr;

        }

        private static string GeneratePatientID()
        {
            return $"PAT-{DateTime.Now.Year}-001";
        }

        public static void PrintSlip(Patient patient)
        {

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("          PATIENT REGISTRATION SLIP");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine($"Date: {DateTime.Now.ToShortDateString()}\n");

            Console.WriteLine($"Patient ID: {patient.PatientId}");
            Console.WriteLine($"Name:       {patient.Name}");
            Console.WriteLine($"Age:        {patient.Age} years");
            Console.WriteLine($"Gender:     {patient.Gender}");
            Console.WriteLine($"Contact:    {patient.PhoneNumber}");
            Console.WriteLine($"Location:   {patient.City}");

            Console.WriteLine("\nInstructions:");
            Console.WriteLine("Please proceed to the waiting area.");
            Console.WriteLine("--------------------------------------------------");

        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Patient patinet = RegistrationManager.PatientRegistration();
            RegistrationManager.PrintSlip( patinet );
        }
    }
}
