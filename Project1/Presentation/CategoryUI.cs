﻿using System;
using System.Collections.Generic;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    // giao dien chuc nang
    public class CategoryUI
    {
        private CategoryDAL _dal = new CategoryDAL();

        public void Add() //chức năng thêm
        {
            Category Category = new Category();
            Category.Input();
            _dal.Add(Category);
            Console.WriteLine("Successfully");
            Console.ReadKey();
            Console.Clear();
        }

        public void Display() //hiện thị danh sach thông tin
        {
            List<Category> Categorys = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}", "ID", "Name");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            foreach (var Category in Categorys)
            {
                Category.Display();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void Update() //cap nhat thogn tin
        {
            List<Category> Categorys = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}", "Index", "ID", "Name");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            foreach (var Category in Categorys)
            {
                Console.Write("{0,-20}", Categorys.IndexOf(Category));
                Category.Display();
            }

//chon doi tuong can sua
            int choose = Validation.InputNumber();
            // neu lon hon so luong thi loi
            if (choose >= Categorys.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                //cap nhat thogn tin theo doi tuong vua chon
                Category Category = Categorys[choose];
                Category.Input();
                _dal.Update(choose,Category);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //xóa thông tin 
        public void Delete()
        {
            //get toàn bộ danh sách
            List<Category> Categorys = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}", "Index", "ID", "Name");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            foreach (var Category in Categorys)
            {
                Console.Write("{0,-20}", Categorys.IndexOf(Category));
                Category.Display();
            }
            //chọn đối tượng cần xóa

            int choose = Validation.InputNumber();
            //neu index lớn hơn độ dài của list báo lỗi
            if (choose >= Categorys.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                //xóa đối tượng
                _dal.Delete(choose);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void CategoryMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("             Category Manager           ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Add new category");
                Console.WriteLine("     2. Update category");
                Console.WriteLine("     3. Delete category");
                Console.WriteLine("     4. Category list");
                Console.WriteLine("     0. Back");
                Console.WriteLine("--------------------------------------");
                int choose = Validation.InputNumber();
                switch (choose)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Display();
                        break;
                    default: break;
                }

                if (choose == 0) break;
            }
        }
    }
}