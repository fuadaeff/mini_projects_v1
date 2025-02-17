using System;

class Employee
{
    public string Name;
    public string Surname;
    public string FatherName;
    public int Age;
    public string FIN;
    public string PhoneNumber;
    public string Position;
    public double Salary;

    public Employee(string name, string surname, string fatherName, int age, string fin, string phoneNumber, string position, double salary)
    {
        Name = name;
        Surname = surname;
        FatherName = fatherName;
        Age = age;
        FIN = fin;
        PhoneNumber = phoneNumber;
        Position = position;
        Salary = salary;
    }
}

class Program
{
    static bool ValidateName(string name)
    {
        if (name.Length < 2 || name.Length > 20)
        {
            Console.WriteLine("Adın uzunluğu 2 və 20 arasında olmalıdır.");
            return false;
        }
        if (!char.IsUpper(name[0]))
        {
            Console.WriteLine("Adın ilk hərfi böyük olmalıdır.");
            return false;
        }
        for (int i = 0; i < name.Length; i++)
        {
            if (!char.IsLetter(name[i]))
            {
                Console.WriteLine("Ad yalnız hərflərdən ibarət olmalıdır.");
                return false;
            }
        }
        return true;
    }

    static bool ValidateSurname(string surname)
    {
        if (surname.Length < 2 || surname.Length > 35)
        {
            Console.WriteLine("Soyadın uzunluğu 2 və 35 arasında olmalıdır.");
            return false;
        }
        if (!char.IsUpper(surname[0]))
        {
            Console.WriteLine("Soyadın ilk hərfi böyük olmalıdır.");
            return false;
        }
        for (int i = 0; i < surname.Length; i++)
        {
            if (!char.IsLetter(surname[i]))
            {
                Console.WriteLine("Soyad yalnız hərflərdən ibarət olmalıdır.");
                return false;
            }
        }
        return true;
    }

    static bool ValidateFatherName(string fatherName)
    {
        return ValidateName(fatherName);
    }

    static bool ValidateAge(int age)
    {
        if (age < 18 || age > 65)
        {
            Console.WriteLine("Yaş 18-65 arasında olmalıdır.");
            return false;
        }
        return true;
    }

    static bool ValidateFIN(string fin)
    {
        if (fin.Length != 7)
        {
            Console.WriteLine("FIN uzunluğu 7 olmalıdır.");
            return false;
        }
        for (int i = 0; i < fin.Length; i++)
        {
            if (!char.IsUpper(fin[i]) && !char.IsDigit(fin[i]))
            {
                Console.WriteLine("FIN yalnız böyük hərflər və rəqəmlərdən ibarət olmalıdır.");
                return false;
            }
        }
        return true;
    }

    static bool ValidatePhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 13 || !phoneNumber.StartsWith("+994"))
        {
            Console.WriteLine("Telefon nömrəsi +994 ilə başlamalı və uzunluğu 13 olmalıdır.");
            return false;
        }
        return true;
    }

    static bool ValidatePosition(string position)
    {
        if (position != "HR" && position != "Audit" && position != "Engineer")
        {
            Console.WriteLine("Pozisiya yalnız HR, Audit və ya Engineer ola bilər.");
            return false;
        }
        return true;
    }

    static bool ValidateSalary(double salary)
    {
        if (salary < 1500 || salary > 5000)
        {
            Console.WriteLine("Maaş 1500-5000 aralığında olmalıdır.");
            return false;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Ad: ");
        string name = Console.ReadLine();
        Console.Write("Soyad: ");
        string surname = Console.ReadLine();
        Console.Write("Ata adı: ");
        string fatherName = Console.ReadLine();
        Console.Write("Yaş: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("FIN: ");
        string fin = Console.ReadLine();
        Console.Write("Telefon nömrəsi: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Pozisiya (HR, Audit, Engineer): ");
        string position = Console.ReadLine();
        Console.Write("Maaş: ");
        double salary = double.Parse(Console.ReadLine());

        if (ValidateName(name) &&
            ValidateSurname(surname) &&
            ValidateFatherName(fatherName) &&
            ValidateAge(age) &&
            ValidateFIN(fin) &&
            ValidatePhoneNumber(phoneNumber) &&
            ValidatePosition(position) &&
            ValidateSalary(salary))
        {
            Employee employee = new Employee(name, surname, fatherName, age, fin, phoneNumber, position, salary);
            Console.WriteLine($"Məlumat ({employee.Name}, {employee.Surname}) sistemə əlavə olundu.");
        }
        else
        {
            Console.WriteLine("Məlumatlar düzgün daxil edilməyib!");
        }
    }
}
