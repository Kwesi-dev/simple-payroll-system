using System;
using System.Collections.Generic;

namespace C_tuts
{
    class Program
    {
        static void Main(string[] args)
        {   
            List<Staff> staffList = new List<Staff>();
            int month = 0; int year = 0;

             while (year == 0)
            {
                Console.WriteLine("                Payroll System For QFace Group               ");
                Console.WriteLine("------------------------------------------------------------------------");
                Console.Write("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Please try again.");
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Month must be from 1 to 12. Please try again.");
                        month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Please try again.");
                }
            }
            
            PaySlip p = new PaySlip(month, year);
            p.GeneratePaySlip(staffList); 
        }
    }

    class Staff{
        private string rank;
        public double basic_salary { get; set; }
        public double total_allowances { get; set; }
        public double actual_salary { get; set; }
        public string staffName { get; set; }
        public string staffId { get; set; }

        public Staff(string id, string staffRank, string name){
            rank = staffRank;
            staffName = name;
            staffId = id;
            
            //initialising the ranks according to their salaries
            //imediately the rank is set, the salary will be assigned to it 
            if(rank == "R1"){
                basic_salary = 2100;
            }else if(rank == "R2"){
                basic_salary = 790;
            }else if(rank == "R3"){
                basic_salary = 1680;
            }else if(rank == "R4"){
                basic_salary = 810;
            }else{
                Console.WriteLine("invalid rank");
            }

            double entertainment_allowance = 120;
            double book_allowance = 118;
            double car_allowance = 800;
            
            //initialising the total allowances imediately an object is created based on the fact the rank is valid
            if(rank == "R1" || rank == "R2" || rank == "R3" || rank == "R4"){
                total_allowances = entertainment_allowance + book_allowance + car_allowance;
            }else{
                Console.WriteLine("you dont have any allowance");
            }
        }   

        //setting the rank
        public string Rank{
            get{
                return rank;
            }
            set{
                if(value == "R1"){
                    rank = value;
                }else if(value == "R2"){
                    rank = value;
                }else if(value == "R3"){
                    rank = value;
                }else if(value == "R4"){
                    rank = value;
                }else{
                    Console.WriteLine("You need enter a rank  from R1 to R4");
                }
            }
        }
        public double calc_actual_salary(){
            //making ded uctions
            double snnit_deduction = (3/100 * basic_salary);
            double nhis_deduction = (4.3/100 * basic_salary);
            double vat_deduction = 0;
            if(basic_salary > 300){
                vat_deduction = (3/100 * basic_salary);
            }else if(basic_salary > 100){
                vat_deduction = (3/100 * basic_salary);
            }
            double total_deductions = snnit_deduction + nhis_deduction + vat_deduction;
            //subtracting the deductions from the basic salary
            double salary_left = basic_salary - total_deductions;
            actual_salary = salary_left + total_allowances;
            return actual_salary;
        }
        
        //print all the information about a staff
        public override string ToString()
        {
            return "\nId = " + staffId + "\nName of Staff = " + staffName + "\nRank = "+ rank + "\nBasic salary = " + basic_salary + "\ntotal allowances = " + total_allowances + "\nActual Salary = " + calc_actual_salary();
        }      
    }

    class PaySlip{
        private int month;
        private int year;

        enum MonthsOfYear { JAN = 1, FEB = 2, MAR = 3, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> staffList){
            staffList.Add(new Staff("10001", "R1", "Kwame Atta 01"));
            staffList.Add(new Staff("10002", "R1", "Kwame Atta 02"));
            staffList.Add(new Staff("10003", "R1", "Kwame Atta 03"));
            staffList.Add(new Staff("10004", "R1", "Kwame Atta 04"));
            staffList.Add(new Staff("10005", "R1", "Kwame Atta 05"));
            staffList.Add(new Staff("10006", "R2", "Kwame Atta 06"));
            staffList.Add(new Staff("10007", "R3", "Kwame Atta 07"));
            staffList.Add(new Staff("10008", "R4", "Kwame Atta 08"));

            foreach(Staff f in staffList){
                Console.WriteLine("----------------- PAYSLIP FOR {0} {1}-----------------", (MonthsOfYear)month, year);
                Console.WriteLine(f);
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }   

    }

}
