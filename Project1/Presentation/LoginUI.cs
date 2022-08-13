﻿using System;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class LoginUI
    {
        public void LoginMenu()
        {
            while (true)
            {
                PersonDAL dal = new PersonDAL();
                Console.WriteLine("------------------------------");
                Console.WriteLine("|            Login           |");
                Console.WriteLine("------------------------------");
                Console.Write("Name: ");
                string name = Validation.InputString();
                Console.Write("Password: ");
                string password = Validation.InputString();
                int login = dal.Login(name, password);
                if (login > 0)
                {
                    if (login == 1)
                    {
                        Console.Clear();
                        new PersonUI().PersonMenu();
                    }
                    else
                    {
                        Console.Clear();
                        new ManagerUI().ManagerMenu();
                    }
                }
                else
                {
                    Console.Write("Name or password incorrect!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}