namespace VitalSignsMonitoring
{
    public class Vitals
    {
        public string ? PatientName { get; set; }
        public double BodyTemp { get; set; }
        public int OxygenLevel { get; set; }
        public int PulseRate { get; set; }
    }
    public class VitalManager
    {
        public static Vitals GetVitals()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("      Vital signs monitor");
            Console.WriteLine("------------------------------------");
            Vitals curr = new Vitals();
            Console.Write("Enter Patient Name : ");
            curr.PatientName=Console.ReadLine();
            //temperature

            while(true)
            {
                try
                {
                    Console.Write("Enter Temperature : ");
                    double num = Convert.ToDouble(Console.ReadLine());
                    if(num>5 &&num<80)
                    {
                        curr.BodyTemp = num;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Error Enter a valid range");

                    }
                   
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error Enter a valid Temperatire");

                }
                

            }
            //oxygen

            while (true)
            {
                try
                {
                    Console.Write("Enter Oxygen level : ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0 && num <= 100)
                    {
                        curr.OxygenLevel = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error Enter a valid range");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error Enter a valid Temperatire");

                }


            }

            //pulse rate

            while (true)
            {
                try
                {
                    Console.Write("Enter Pulse Rate : ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0 && num <= 200)
                    {
                        curr.PulseRate = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error Enter a valid range");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error Enter a valid Temperatire");

                }


            }
            return curr;
        }
        public static string CheckStatus(Vitals currvitals)
        {
            if(currvitals.BodyTemp>39.0 ||currvitals.OxygenLevel<90 || currvitals.PulseRate<50 || currvitals.PulseRate>120)
            {
                return "Critical/Emergency";
            }
            if (currvitals.BodyTemp > 37.5 || currvitals.OxygenLevel < 95 || currvitals.PulseRate > 100)
            {
                return "Observation Needed";
            }
            return "Normal";


        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
           Vitals curr= VitalManager.GetVitals();
            string status=VitalManager.CheckStatus(curr);
            Console.WriteLine("Status"+status);
        }
    }
}
