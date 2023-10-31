using System;
interface IWagon //інтерфейс
{
    string Info(); //інформація про поля об'єкта
    void Income(); //обчислення доходу
}
class Common : IWagon //загальний вагон
{
    private double price; //ціна квитка
    private int seats; //кількість місць
    private double income; //дохід з вагона
    public Common(double price, int seats) //конструктор
    {
        this.price = price;this.seats = seats;
    }
    public string Info() //виведення
    {
        return $"Загальний вагон: Ціна квитка: {price:C2}," +
            $" Кількість квитків: {seats}, Дохід: {income:C2}";
    }
    public void Income() //дохід
    {
        income = price * seats;
    }
}
class Reserved : IWagon //плацкарт
{
    private double price; //ціна
    private int seats; //кількість місць
    private double income; //дохід
    private double services; //вартість додаткових послуг
    public Reserved(double price, int seats, double services) //конструктор
    {
        this.price = price; this.seats = seats; this.services = services;
    }
    public string Info() //виведення
    {
        return $"Плацкартний вагон: Ціна квитка: {price:C2}, Кількість квитків:" +
            $" {seats}, Додаткові послуги: {services:C2}, Дохід: {income:C2}";
    }
    public void Income() //дохід
    {
        income = price * seats + seats * services * 0.5;
    }
}
class Compartment : IWagon //купе
{
    private double price; //ціна
    private int seats; //місця
    private double income; //дохід
    private double services; //послуги
    public Compartment(double price, int seats, double services) //конструктор
    {
        this.price = price; this.seats = seats; this.services = services;
    }
    public string Info() //виведення
    {
        return $"Купейний вагон: Ціна квитка: {price:C2}, Кількість квитків: " +
            $"{seats}, Вартість послуг: {services:C2}, Дохід: {income:C2}";
    }
    public void Income() //дохід
    {
        income = seats * (price + services);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            int wagonType = rand.Next(1, 4);
            IWagon wagon = null;
            switch (wagonType)
            {
                case 1: //загальний
                    double commonPrice = rand.Next(50, 100);
                    int commonSeats = rand.Next(30, 70);
                    wagon = new Common(commonPrice, commonSeats);
                    break;
                case 2: //плацкарт
                    double reservedPrice = rand.Next(100, 150);
                    int reservedSeats = rand.Next(30, 54);
                    double reservedServices = rand.Next(5, 20);
                    wagon = new Reserved(reservedPrice, reservedSeats, reservedServices);
                    break;
                case 3: //купе
                    double compartmentPrice = rand.Next(150, 200);
                    int compartmentSeats = rand.Next(20, 40);
                    double compartmentServices = rand.Next(10, 30);
                    wagon = new Compartment(compartmentPrice, 
                        compartmentSeats, compartmentServices);
                    break;
            }
            wagon.Income();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(wagon.Info());
            Console.WriteLine();
        }
    }
}
