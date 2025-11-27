namespace MyLMS.Entities;

public class Employee : Members
        {
            public double Salary { get; set; }
            public  float Years { get; init; }
            public double Bonus { get; set; }

            public Employee(double salary, int id, string name, string email, float years)
                : base(id, name, email)
            {
                Salary = salary;
                Years = years;
            }
            public double BonusCalc()
            {
                if(Years>0){
                    Bonus= Salary * Years * .1;
                }
                else{
                    Bonus=0;
                }
                
                return Bonus;
            }

        }
