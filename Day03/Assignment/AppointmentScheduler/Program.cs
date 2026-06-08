namespace AppointmentScheduler
{
    public class Appointment
    {
        public string? Patient { get; set; }
        public string? Department { get; set; }
        public string? Doctor { get; set; }
        public string? Time { get; set; }
        public string? Status { get; set; }
    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string[] Departments = ["General", "Dental", "Orthopedics"];
            string[][] Doctors = [
                ["Dr.A.Kumar", "Dr.B.Singh"],
                ["Dr. C. Roy", "Dr. D. Gupta"],
                ["Dr. D.Rao", "Dr.E.patel"]

                ];
            //string[] GeneralDoctors = ["Dr.A.Kumar", "Dr.B.Singh"];
            //string[] DentalDoctors = ["Dr. C. Roy", "Dr. D. Gupta"];
            //string[] OrthopedicDoctors = ["Dr. D.Rao", "Dr.E.patel"];
            string[] timeSlots = ["10:00 Am", "11:00 Am", "2:00 Pm"];
            Appointment curr=new Appointment();
                Console.Write("Enter patientName : ");
                curr.Patient=Console.ReadLine();
                Console.WriteLine("Select department");
                for(int i=0;i<Departments.Length;i++)
                {
                    Console.WriteLine((i+1)+". "+Departments[i]);

                }
            int index;
             while(true)
            {
                try
                {
                    Console.Write("Enter choise");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0 && num <= Departments.Length)
                    {
                        index = num - 1;
                        curr.Department = Departments[num - 1];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error : please enter a valid choise");
                    }

                }
                catch(FormatException)
                {
                    Console.WriteLine("Error : Inavlid Format");
                }
               


            }
            Console.WriteLine("Select Doctor");
            for (int j = 0; j < Doctors[index].Length; j++)
            {
                Console.WriteLine((j+1)+" . " + Doctors[index][j]);

            }
            while (true)
            {
                try
                {
                    Console.Write("Enter choise");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0 && num <= Doctors[index].Length)
                    {
                        
                        curr.Doctor = Doctors[index][num - 1];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error : please enter a valid choise");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Error : Inavlid Format");
                }



            }

            Console.WriteLine("Select Time Slot");


            for (int j = 0; j <timeSlots.Length; j++)
            {
                Console.WriteLine((j + 1) + " . " + timeSlots[j]);

            }

            while (true)
            {
                try
                {
                    Console.Write("Enter choise");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0 && num <= timeSlots.Length)
                    {
                        index = num - 1;
                        curr.Time= timeSlots[num - 1];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error : please enter a valid choise");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Error : Inavlid Format");
                }



            }
            curr.Status = "Confirmed";

            Console.WriteLine("Booking Confirmed");


            Console.WriteLine("----------------------------");
            Console.WriteLine("Appointment Ticket");
            Console.WriteLine("----------------------------");
            Console.Write("Patient     : "+curr.Patient);
            Console.Write("Deapartment : "+curr.Department);
            Console.Write("Doctor      : "+curr.Doctor);
            Console.Write("Time        : "+curr.Time);
            Console.Write("Status      : "+curr.Status);
            Console.Write("Please arrive 15 mins before your slot.\r\n");





        }
    }
}
