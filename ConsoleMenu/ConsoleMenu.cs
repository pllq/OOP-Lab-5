using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using BLL;
using Services;
using System.Runtime.CompilerServices;

namespace ConsoleMenu
{
    public static class Menu
    {
        private static IEntityService<BLL.Human> entity_service = null;
        private static IReadWriteService<List<BLL.Human>> read_write_service = null;
        private static bool first_execution = true;

        private static void Return()
        {
            Console.WriteLine();
            Console.WriteLine("Press \"Esc\" key, to return to main menu.");
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape)
            {
                key = Console.ReadKey().Key;
            }
            Menu.ConsoleMenu();
        }
        private static string Sfromb(bool a)
        {
            if (a)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        private static string StringFromEntity(BLL.Human obj)
        {
            Type type = obj.GetType();
            if (type == typeof(BLL.Student))
            {
                return "Student";
            }
            else if (type == typeof(BLL.Painter))
            {
                return "Painter";
            }
            else
            {
                return "Farmer";
            }
        }
        private static void Add()
        {
            Console.Clear();
            Console.WriteLine("Press \"S\" key, to add Student to the file.");
            Console.WriteLine("Press \"P\" key, to add Painter to the file.");
            Console.WriteLine("Press \"F\" key, to add Farmer to the file.");
            Console.WriteLine("Press \"Esc\" key, to return to the menu.");
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape && key != ConsoleKey.S && key != ConsoleKey.P && key != ConsoleKey.F)
            {
                Console.Clear();
                Console.WriteLine("Press \"S\" key, to add Student to the file.");
                Console.WriteLine("Press \"P\" key, to add Painter to the file.");
                Console.WriteLine("Press \"F\" key, to add Farmer to the file.");
                Console.WriteLine("Press \"Esc\" key, to return to the menu.");
                Console.WriteLine();
                Console.WriteLine("Press other button.");
                key = Console.ReadKey().Key;
            }
            if (key == ConsoleKey.Escape)
            {
                Menu.ConsoleMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Input First name:");
                string f_name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Input Last name:");
                string l_name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Inpute DAY of birthday:");
                string date_day = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Inpute MONTH of birthday:");
                string date_month = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Inpute YEAR of birthday:");
                string date_year = Console.ReadLine();
                string grade = "", stud_id = "", experience = "";
                if (key == ConsoleKey.S)
                {
                    Console.Clear();
                    Console.WriteLine("Input student's grade (1-6):");
                    grade = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Input student's ID card (example: 'UA12345678'):");
                    stud_id = Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input person work experience:");
                    experience = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine("Does the person have a driver's license?");
                Console.WriteLine("Press \"Y\" key, if has driver's license.");
                Console.WriteLine("Press \"N\" key, if person doesnt have driver's license.");
                ConsoleKey key_drive = Console.ReadKey().Key;
                bool driving_license = false;
                if (key_drive == ConsoleKey.Y)
                {
                    driving_license = true;
                }
                else
                {
                    driving_license = false;
                }
                Console.Clear();
                Console.WriteLine("Can person swim?");
                Console.WriteLine("Press \"Y\" key, if person swim.");
                Console.WriteLine("Press \"N\" key, if person cannot swim.");
                ConsoleKey key_swim = Console.ReadKey().Key;
                BLL.ISwim swim = null;
                if (key_swim == ConsoleKey.Y)
                {
                    swim = new YesSwim();
                }
                else
                {
                    swim = new NoSwim();
                }
                Console.Clear();
                Console.WriteLine("Press \"Y\" key, to save data to file.");
                Console.WriteLine("Press \"Esc\" key, to stop process and return to menu.");
                ConsoleKey key_write_data = Console.ReadKey().Key;
                while (key_write_data != ConsoleKey.Escape && key_write_data != ConsoleKey.Y)
                {
                    Console.Clear();
                    Console.WriteLine("Press \"Y\" key, to save data to file.");
                    Console.WriteLine("Press \"Esc\" key, to stop process and return to menu.");
                    Console.WriteLine();
                    Console.WriteLine("Press \"Y\" or \"Esc\".");
                    key_write_data = Console.ReadKey().Key;
                }
                if (key_write_data == ConsoleKey.Escape)
                {
                    Menu.ConsoleMenu();
                }
                else
                {
                    try
                    {
                        int int_date_day, int_date_month, int_date_year;
                        int_date_day = Convert.ToInt32(date_day);
                        int_date_month = Convert.ToInt32(date_month);
                        int_date_year = Convert.ToInt32(date_year);
                        BLL.Human item = null;
                        switch (key)
                        {
                            case ConsoleKey.S:
                                int int_grade = Convert.ToInt32(grade);
                                item = new BLL.Student(f_name, l_name, int_date_year, int_date_day, int_date_month, stud_id, int_grade, driving_license, swim);
                                break;
                            case ConsoleKey.P:
                                int int_experience_1 = Convert.ToInt32(experience);
                                item = new BLL.Painter(f_name, l_name, int_date_year, int_date_day, int_date_month, int_experience_1, driving_license, swim);
                                break;
                            case ConsoleKey.F:
                                int int_experience_2 = Convert.ToInt32(experience);
                                item = new BLL.Farmer(f_name, l_name, int_date_year, int_date_day, int_date_month, int_experience_2, driving_license, swim);
                                break;
                            default:
                                break;
                        }
                        entity_service.Add(item);
                        read_write_service.WriteData((List<BLL.Human>)entity_service.DataCollection);
                    }
                    catch (Exception exception)
                    {
                        Console.Clear();
                        Console.WriteLine($"Error: {exception.Message}");
                        Console.WriteLine("Add data to work in the file or change the interaction file.");
                        Console.WriteLine("Press any key to go to the main menu.");
                        Console.ReadKey();
                    }
                    Menu.ConsoleMenu();
                }
            }
        }
        private static void EntityOut(int i)
        {
            if (i != -2147483648)
            {
                BLL.Human obj = entity_service[i];
                Console.Clear();
                if (obj.GetType() == typeof(BLL.Student))
                {
                    BLL.Student item = (BLL.Student)obj;
                    Console.WriteLine(Menu.StringFromEntity(item));
                    Console.WriteLine("First name: {0}.", item.FirstName);
                    Console.WriteLine("Last name: {0}.", item.LastName);
                    Console.WriteLine("Birthday: {0} {1} {2}.", item.Date.Year, item.Date.Day, item.Date.Month);
                    Console.WriteLine("Age: {0}.", item.Age);
                    Console.WriteLine("Student's ID card: {0}.", item.StudentID);
                    Console.WriteLine("Grade: {0}.", item.Grade);
                    Console.WriteLine("Skills:");
                    Console.WriteLine("1. Swimming: {0}.", Menu.Sfromb(item.Swim()));
                    Console.WriteLine("2. Driver's license: {0}.", Menu.Sfromb(item.DrivingLicense));
                }
                else if (obj.GetType() == typeof(BLL.Painter))
                {
                    BLL.Painter item = (BLL.Painter)obj;
                    Console.WriteLine(Menu.StringFromEntity(item));
                    Console.WriteLine("First name: {0}.", item.FirstName);
                    Console.WriteLine("Last name: {0}.", item.LastName);
                    Console.WriteLine("Birthday: {0} {1} {2}.", item.Date.Year, item.Date.Day, item.Date.Month);
                    Console.WriteLine("Age: {0}.", item.Age);
                    Console.WriteLine("Work experience: {0}.", item.Experience);
                    Console.WriteLine("Skills:");
                    Console.WriteLine("1. Swimming: {0}.", Menu.Sfromb(item.Swim()));
                    Console.WriteLine("2. Driver's license: {0}.", Menu.Sfromb(item.DrivingLicense));
                }
                else if (obj.GetType() == typeof(BLL.Farmer))
                {
                    BLL.Farmer item = (BLL.Farmer)obj;
                    Console.WriteLine(Menu.StringFromEntity(item));
                    Console.WriteLine("First name: {0}.", item.FirstName);
                    Console.WriteLine("Last name: {0}.", item.LastName);
                    Console.WriteLine("Birthday: {0} {1} {2}.", item.Date.Year, item.Date.Day, item.Date.Month);
                    Console.WriteLine("Age: {0}.", item.Age);
                    Console.WriteLine("Work experience: {0}.", item.Experience);
                    Console.WriteLine("Skills:");
                    Console.WriteLine("1. Swimming: {0}.", Menu.Sfromb(item.Swim()));
                    Console.WriteLine("2. Driver's license: {0}.", Menu.Sfromb(item.DrivingLicense));
                }
            }
        }
        private static void Out(int i)
        {
            if (i != -2147483648)
            {
                try
                {
                    EntityOut(i);
                    Menu.Return();
                }
                catch (Exception exception)
                {
                    Menu.GeneralException(exception);
                }
            }
        }
        private static void GeneralException(Exception exception)
        {
            Console.Clear();
            Console.WriteLine($"Error, {exception.Message}");
            Console.WriteLine("Press any button to return to menu");
            Console.ReadKey();
            Menu.ConsoleMenu();
        }
        private static void ConsoleMenu()
        {
            Console.Clear();
            Console.WriteLine("Main menu:\n");

            Console.WriteLine("Press \"A\" key, add person to the file.");
            Console.WriteLine("Press \"O\" key, to see information about a person by index.");
            Console.WriteLine("Press \"R\" key, to delete person by index.");
            Console.WriteLine("Press \"L\" key, show all persons from the list.");
            Console.WriteLine("Press \"F\" key, to delete person by index.");
            Console.WriteLine("Press \"Esc\" key, exit the program.");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.A:
                    Menu.Add();
                    break;
                case ConsoleKey.O:
                    Menu.Out(Menu.Index());
                    break;
                case ConsoleKey.R:
                    Menu.Remove(Menu.Index());
                    break;
                case ConsoleKey.L:
                    Menu.List();
                    break;
                case ConsoleKey.F:
                    Menu.EntityOperation();
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    Menu.ConsoleMenu();
                    break;
            }
        }
        public static void SetFile()
        {
            Console.Clear();
            Console.WriteLine("Input file name:");
            string path = Console.ReadLine();
            while (path.Any(System.IO.Path.GetInvalidFileNameChars().Contains))
            {
                Console.Clear();
                Console.WriteLine("Wrong input, please write file name again.");
                Console.WriteLine("Input file name:");
                path = Console.ReadLine();
            }
            Console.Clear();
            Console.Write("Choose type of the file:");
            Console.WriteLine("Press \"B\" key, to choose \".bin\" (Binary Serialization).");
            Console.WriteLine("Press \"X\" key, to choose \".xml\" (XML Serialization).");
            Console.WriteLine("Press \"J\" key, to choose \".json\"  (JSON Serialization).");
            Console.WriteLine("Press \"C\" key, to choose \".custom\" (Custom Serialization).");
            if (first_execution)
            {
                Console.WriteLine("Press \"Esc\" key, to leave program.");
            }
            else
            {
                Console.WriteLine("Press \"Esc\" key, to return to main menu.");
            }
            EProviders provider;
            ConsoleKey key = Console.ReadKey().Key;
            bool check = false, close = false;
            switch (key)
            {
                case ConsoleKey.B:
                    provider = EProviders.Bin;
                    break;
                case ConsoleKey.X:
                    provider = EProviders.Xml;
                    break;
                case ConsoleKey.J:
                    provider = EProviders.Json;
                    break;
                case ConsoleKey.C:
                    provider = EProviders.Custom;
                    break;
                case ConsoleKey.Escape:
                    close = true;
                    provider = 0;
                        break;
                default:
                    check = true;
                    provider = 0;
                    break;
            }
            while (check)
            {
                check = false;
                Console.Clear();
                Console.Write("Choose type of the file:");
                Console.WriteLine("Press \"B\" key, to choose \".bin\" (Binary Serialization).");
                Console.WriteLine("Press \"X\" key, to choose \".xml\" (XML Serialization).");
                Console.WriteLine("Press \"J\" key, to choose \".json\"  (JSON Serialization).");
                Console.WriteLine("Press \"C\" key, to choose \".custom\" (Custom Serialization).");
                if (first_execution)
                {
                    Console.WriteLine("Press \"Esc\" key, to leave program.");
                }
                else
                {
                    Console.WriteLine("Press \"Esc\" key, to return to main menu.");
                }
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.B:
                        provider = EProviders.Bin;
                        break;
                    case ConsoleKey.X:
                        provider = EProviders.Xml;
                        break;
                    case ConsoleKey.J:
                        provider = EProviders.Json;
                        break;
                    case ConsoleKey.C:
                        provider = EProviders.Custom;
                        break;
                    case ConsoleKey.Escape:
                        close = true;
                        break;
                    default:
                        check = true;
                        break;
                }
            }
            if (close)
            {
                if (!first_execution)
                {
                    Menu.ConsoleMenu();
                }
            }
            else
            {
                entity_service = new EntityService();
                read_write_service = new ReadWriteService(path, provider);
                Console.Clear();
                Console.WriteLine("Do yo want to read file?");

                Console.WriteLine("Press \"Y\" key, to read data from the file and go to the main menu.");
                Console.WriteLine("Press \"N\" key, to go to the main menu without reading data from the file.");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    try
                    {
                        entity_service.DataCollection = read_write_service.ReadData();
                    }
                    catch (Exception exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Error: The file with this name does not yet exist or has no data.");
                        Console.WriteLine("Error text: {0}", exception.Message);
                        Console.WriteLine("Add data to work in the file or change the interaction file.");
                        Console.WriteLine("Press any key to go to the main menu.");
                        Console.ReadKey();
                    }
                }
                first_execution = false;
                Menu.ConsoleMenu();
            }
        }
        private static bool TryRead()
        {
            try
            {
                entity_service.DataCollection = read_write_service.ReadData();
                return true;
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine("Error: The file with this name does not yet exist or has no data.");
                Console.WriteLine("Error text: {0}", exception.Message);
                Console.WriteLine("Add data to work in the file or change the interaction file.");
                Console.WriteLine("Press any key to go to the main menu.");
                Console.ReadKey();
                Menu.ConsoleMenu();
                return false;
            }
        }
        private static void List()
        {
            bool read = true;
            Console.Clear();
            if (entity_service.DataCollection.Count == 0)
            {
                read = Menu.TryRead();
            }
            if (read)
            {
                for (int i = 0; i < entity_service.DataCollection.Count; i++)
                {
                    BLL.Human item = entity_service[i];
                    Console.WriteLine("{0}: {1} {2} {3}", i, Menu.StringFromEntity(item), item.LastName, item.FirstName);
                }
                Menu.Return();
            }
        }
        private static void EntityOperation()
        {
            bool read = true;
            Console.Clear();
            if (entity_service.DataCollection.Count == 0)
            {
                read = Menu.TryRead();
            }
            if (read)
            {
                Console.WriteLine($"Number of 2-nd grade, who were born in winter: {entity_service.Operation()}.");
                Menu.Return();
            }
        }
        private static void Out_Look(int i)
        {
            if (i != -2147483648)
            {
                EntityOut(i);
                Console.WriteLine();
                Console.WriteLine("Press \"D\" key, to see the previous person on the list.");
                Console.WriteLine("Press \"A\" key, to see the next person on the list.");
                Console.WriteLine("Press \"Esc\" key, to return to main menu.");
            }
        }
        private static void Remove(int i)
        {
            if (i != -2147483648)
            {
                try
                {
                    entity_service.Remove(i);
                    if (entity_service.DataCollection.Count == 0)
                    {
                        read_write_service.WriteData(null);
                        File.Delete(read_write_service.File);
                    }
                    else
                    {
                        File.Delete(read_write_service.File);
                        read_write_service.WriteData((List<BLL.Human>)entity_service.DataCollection);
                    }
                    Menu.ConsoleMenu();
                }
                catch (Exception exception)
                {
                    Menu.GeneralException(exception);
                }
            }
        }
        private static int Index()
        {
            bool read = true;
            if (entity_service.DataCollection.Count == 0)
            {
                read = Menu.TryRead();
            }
            if (read)
            {
                Console.Clear();
                Console.WriteLine("*Index starts from 0*");
                Console.WriteLine("Press \"Esc\" key, to return to main menu.");

                Console.WriteLine("Input index: ");
                string index;
                bool check = true;
                int int_index = -1;
                while (check)
                {
                    index = Console.ReadLine();
                    try
                    {
                        if (index.CompareTo("Esc") == 0)
                        {
                            Menu.ConsoleMenu();
                        }
                        else
                        {
                            int_index = Convert.ToInt32(index);
                            check = false;
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Error: input number or \"Esc\".");
                        Console.WriteLine();
                        Console.WriteLine("*Index starts from 0*");

                        Console.WriteLine("Input index: ");
                    }
                }
                return int_index;
            }
            else
            {
                return -2147483648;
            }
        }
    }
}
