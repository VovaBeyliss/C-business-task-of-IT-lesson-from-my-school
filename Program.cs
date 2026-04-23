using System;
using System.Linq;
using System.Collections.Generic;

public record Product(string Name, int Price, int Quantity);

public class Program {
    public static void Main(string[] args) {
        var products = new List<Product>() {
            new Product("Guitar", 5000, 10),
            new Product("Pianino", 25000, 2),
            new Product("Drums", 12000, 5),
            new Product("Bass Guitar", 13000, 0)
        };

        string input = "";
        bool run = true;

        while (run) {
            Console.WriteLine("1 - Показати товар");
            Console.WriteLine("2 - Додати товар");
            Console.WriteLine("3 - Подивитись всі товари, що є");
            Console.WriteLine("4 - Вийти з програми");

            Console.Write("Введіть номер операції: ");

            input = Console.ReadLine();

            switch (input) {
                case "1":
                    Console.Write("Введіть ім'я товару: ");
                    string name = Console.ReadLine()?.Trim();

                    var product = products.FirstOrDefault(p => p.Name == name);

                    if (product != null) {
                        Console.WriteLine($"Ім'я: {product.Name}; Ціна: {product.Price}; Кількість: {product.Quantity};");
                    } else {
                        Console.WriteLine("Ім'я в базі даних такого товару не існує!");
                    }

                    Console.WriteLine();

                    break;
                case "2":
                    Console.Write("Введіть назву нового товару: ");
                    string newName = Console.ReadLine();

                    Console.Write("Введіть ціну нового товару: ");
                    int newPrice = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введіть кількість нового товару: ");
                    int newQuantity = Convert.ToInt32(Console.ReadLine());

                    var newProduct = new Product(newName, newPrice, newQuantity);

                    products.Add(newProduct);

                    Console.WriteLine($"Новий товар: Ім'я: {newProduct.Name}; Ціна: {newProduct.Price}; Кількість: {newProduct.Quantity};");

                    Console.WriteLine();

                    break;
                case "3":
                    for (int i = 0; i < products.Count; i++) {
                        if (products[i].Quantity > 0) {
                            Console.WriteLine($"Ім'я: {products[i].Name}; Ціна: {products[i].Price}; Кількість: {products[i].Quantity};");
                        }
                    }

                    Console.WriteLine();

                    break;
                case "4":
                    Console.WriteLine("Дякую за використання програми, удачі!)");
                    run = false;
                    break;
                default:
                    Console.WriteLine("Або 1, або 2, або 3!");

                    Console.WriteLine();

                    break;
            }
        }
    }
}