using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoffeeShopManagment
{
	class MainClass
	{
		static int cashRegister = 0;
		static int customerBill = 0;

		public static void RandomWait()
		{
			System.Threading.Thread.Sleep(1000);
		}

		public static void Menu()
		{
			char done = 'n';
			Console.WriteLine ("Please choose a single or multple item");
			do {
				Console.WriteLine ("a. Simple Coffee: 50 PKR");
				Console.WriteLine ("b. Sandwich: 100 PKR");
				Console.WriteLine ("c. Tea: 50 PKR");
				Console.WriteLine ("d. Hot Coco: 80 PKR");
				Console.WriteLine ("e. Donut: 90 PKR");
				char order = char.Parse(Console.ReadLine());
				switch (order) {
				case 'a':
					customerBill += 50;
					using (StreamWriter w = File.AppendText("bill.txt"))
					{
						w.WriteLine("Simple Coffee: 50 PKR");
					}
					break;
				case 'b':
					customerBill += 100;
					using (StreamWriter w = File.AppendText("bill.txt"))
					{
						w.WriteLine("Sandwich: 100 PKR");
					}
					break;
				case 'c':
					customerBill += 50;
					using (StreamWriter w = File.AppendText("bill.txt"))
					{
						w.WriteLine("Tea: 50 PKR");
					}
					break;
				case 'd':
					customerBill += 80;
					using (StreamWriter w = File.AppendText("bill.txt"))
					{
						w.WriteLine("Hot Coco: 80 PKR");
					}
					break;
				case 'e':
					customerBill += 90;
					using (StreamWriter w = File.AppendText("bill.txt"))
					{
						w.WriteLine("Donut: 90 PKR");
					}
					break;
				default:
					Console.WriteLine("Not on the menu!");
					break;
				}

				Console.Write ("Order Complete?(y/n)");
				done = Char.Parse (Console.ReadLine ());
				Console.Clear();
				cashRegister += customerBill;
			} while(done == 'n' || done == 'N');
			Console.WriteLine ("Please take your bill");

			using (StreamWriter w = File.AppendText("bill.txt"))
			{
				w.WriteLine("Total Bill: {0}", customerBill);
			}
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("\t\t\t\tWelcome to TuCoffee ME");
			char run = 'n';
			do {
				Console.Write("Password: ");
				string login = Console.ReadLine();
				Console.Clear();
				if (login == "admin") {
					Console.WriteLine ("Welcome!");
					RandomWait();
					Console.Clear();
					Console.WriteLine("What action would you like to perform?");
					Console.WriteLine("a. Check current balance in register");
					Console.WriteLine("b. Place an order");
					Console.WriteLine("c. Close register");
					char choice = Char.Parse(Console.ReadLine());
					Console.Clear();
					switch(choice) {
					case 'a':
						Console.WriteLine("The cash register currently has {0} rupees", cashRegister);
						break;

					case 'b':
						customerBill = 0;
						Menu();
						break;

					case 'c':
						run = 'y';
						break;

					default:
						Console.WriteLine("Invalid option!");
						break;
					}

				} else {
					Console.WriteLine ("Access Denied");
				}
				Console.Write("Close register? (y/n)");
				run = Convert.ToChar(Console.ReadLine());
				Console.Clear();
			}
			while (run == 'n' || run == 'N');
		}
	}
}
