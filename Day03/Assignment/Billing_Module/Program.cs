namespace Billing_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int Consultation = 500;
            const int BloodTest = 200;
            const int XRay = 1000;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("      Hospital Billing Calculator");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Add Services");
            Console.Write("Patient Name : ");
            string patientName=Console.ReadLine();
            Console.WriteLine();
            Console.Write("Patient Age : ");
            int age=Convert.ToInt32(Console.ReadLine());


            string[] options = ["Consultation", "Blood Test", "X-Ray"];
           
            Console.WriteLine("1. Consultation (500)");
            Console.WriteLine("2. Blood Test (200)");
            Console.WriteLine("3. X-Ray (1000)");
            Console.WriteLine("4. Done");
            List<int>list=new List<int>();
            while (true)
            {
                Console.Write("Choise : "); 
                int ch=Convert.ToInt32(Console.ReadLine());
                if (ch == 4) break;
                if (list.Contains(ch))
                {
                    Console.WriteLine("Already added");
                }
                else if (ch > 0 && ch < 4)
                {
                    list.Add(ch);
                    Console.WriteLine("[ Added " + options[ch-1] + " ]");
                }
                else
                {
                    Console.WriteLine("Please Enter a valid option");
                }

            }
            string category = "";
            if (age > 60)
            {
                category = "(Senior Citizen)";
            }
            if (age < 10)
            {
                category = "(Children)";
            }
            int total = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == 1)
                {
                    total += 500;
                }
                else if (list[i] == 2)
                {
                    total += 200;
                }
                else
                {
                    total += 1000;
                }
            }
            int totalAfterDiscount = total;
            int discount = 0;

            if (age > 60)
            {
                discount = total / 5;
                totalAfterDiscount = totalAfterDiscount - discount;


            }
            if (age < 10)
            {
                if (list.Contains(1))
                {
                    discount = 250;
                    totalAfterDiscount -= discount;
                }
            }
            int tax = totalAfterDiscount / 20;
            int totalPayable = totalAfterDiscount + tax;

            Console.WriteLine("Calculating Bill ...");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Final Bill Invoice");
            Console.WriteLine("-------------------------------------------");
            
           
            Console.Write("Patient Name : " + patientName +" "+category);

            Console.WriteLine("Patient Age  : " + age);

            Console.WriteLine("Base amount " + total);
            if (age > 60)
            {
                Console.WriteLine("Discount (20%) :    -" + discount);
                
            }
            else if(age<10)
            {
                 if(discount!=0)
                {
                    Console.WriteLine("Consultation Discount (50%) :   -" + discount);

                }
            }
            Console.WriteLine("Tax (5%)    :    +" + tax);

            Console.WriteLine("TOTAL PAYABLE : "+totalPayable);




        }
    }
}
