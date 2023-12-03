using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Projekt
{
    public class Database
    {
        static readonly string dbpathOffer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"DBOffers.json");
        static readonly string dbpathCompany = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"DBCompanies.json");
        static readonly string dbpathUser = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"DBUsers.json");
        static readonly string dbpathCategory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"DBCategories.json");

        public List<Offer> GetOffers()
        {
            List<Offer> ret = new List<Offer>();

            try
            {
                string read = File.ReadAllText(dbpathOffer);
                ret = JsonSerializer.Deserialize<List<Offer>>(read);
            }
            catch
            {
                ret = new List<Offer>();
                string read = JsonSerializer.Serialize(ret);
                File.WriteAllText(dbpathOffer, read);
            }

            return ret;
        }
        public void AddOffer(Offer offer)
        {
            List<Offer> ret = GetOffers();

            if(ret.Count > 0) { offer.Offer_id = ret[ret.Count - 1].Offer_id+1;}
            else { offer.Offer_id = 0; }

            ret.Add(offer);

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathOffer, read);

        }
        public void UpdateOffer(Offer offer)
        {
            List<Offer> ret = GetOffers();

            for(int i = 0;i < ret.Count; i++)
            {
                if (ret[i].Offer_id == offer.Offer_id)
                {
                    ret[i] = offer;
                }
            }

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathOffer, read);

        }
        public void DeleteOffer(Offer offer)
        {
            List<Offer> ret = GetOffers();

            for (int i = 0; i < ret.Count; i++)
            {
                if (ret[i].Offer_id == offer.Offer_id)
                {
                    ret.RemoveAt(i);
                }
            }

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathOffer, read);

        }
        public List<Category> GetCategory()
        {
            List<Category> ret = new List<Category>();

            try
            {
                string read = File.ReadAllText(dbpathCategory);
                ret = JsonSerializer.Deserialize<List<Category>>(read);
            }
            catch
            {
                ret = new List<Category>();
                string read = JsonSerializer.Serialize(ret);
                File.WriteAllText(dbpathCategory, read);
            }

            return ret;
        }
        public void AddCategory(Category offer)
        {
            List<Category> ret = GetCategory();

            if (ret.Count > 0) { offer.Category_id = ret[ret.Count - 1].Category_id + 1; }
            else { offer.Category_id = 0; }

            ret.Add(offer);

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathCategory, read);

        }
        public List<Company> GetCompanies()
        {
            List<Company> ret = new List<Company>();

            try
            {
                string read = File.ReadAllText(dbpathCompany);
                ret = JsonSerializer.Deserialize<List<Company>>(read);
            }
            catch
            {
                ret = new List<Company>();
                string read = JsonSerializer.Serialize(ret);
                File.WriteAllText(dbpathCompany, read);
            }

            return ret;
        }
        public void AddCompany(Company company)
        {
            List<Company> ret = GetCompanies();

            if (ret.Count > 0) { company.Company_id = ret[ret.Count - 1].Company_id + 1; }
            else { company.Company_id = 0; }

            ret.Add(company);

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathCompany, read);

        }
        public void EditCompany(Company company)
        {
            List<Company> ret = GetCompanies();

            for(int i = 0;i<ret.Count;i++)
            {
                if (ret[i].Company_id == company.Company_id)
                {
                    ret[i] = company;
                }
            }

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathCompany, read);

        }
        public List<User> GetUsers()
        {
            List<User> ret = new List<User>();

            try
            {
                string read = File.ReadAllText(dbpathUser);
                ret = JsonSerializer.Deserialize<List<User>>(read);
            }
            catch
            {
                ret = new List<User>();
                string read = JsonSerializer.Serialize(ret);
                File.WriteAllText(dbpathUser, read);
            }

            return ret;
        }
        public void AddUser(User user)
        {
            List<User> ret = GetUsers();

            if (ret.Count > 0) { user.User_id = ret[ret.Count - 1].User_id + 1; }
            else { user.User_id = 0; }

            ret.Add(user);

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathUser, read);

        }
        public void EditUser(User user)
        {
            List<User> ret = GetUsers();

            for(int i = 0;i<ret.Count;i++)
            {
                if (ret[i].User_id == user.User_id)
                {
                    ret[i] = user;
                }
            }

            string read = JsonSerializer.Serialize(ret);
            File.WriteAllText(dbpathUser, read);

        }
        /*
        public async static void InitializeDatabase()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                         "ProjectBase.db");
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                string tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Offers (Offer_id INTEGER PRIMARY KEY, " +
                    "Company_id INTEGER, Title NVARCHAR(2048), Description NVARCHAR(2048)," +
                    "Position_name NVARCHAR(2048) , Position_level NVARCHAR(2048) , Type_of_contract NVARCHAR(2048), " +
                    "Employment NVARCHAR(2048) , Type_of_Job NVARCHAR(2048) , Salary NVARCHAR(2048)," +
                    "Days NVARCHAR(2048) , Hours NVARCHAR(2048) , Expired NVARCHAR(2048)," +
                    "Duties NVARCHAR(2048) , Requirements NVARCHAR(2048) , Benefits NVARCHAR(2048)," +
                    "Application_Count INTEGER NULL)";

                var createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Companies (Company_id INTEGER PRIMARY KEY, " +
                    "Name NVARCHAR(2048), Localization NVARCHAR(2048), Logo NVARCHAR(2048), Description NVARCHAR(2048) NULL)";

                createTable = new SqliteCommand(tableCommand, db);


                createTable.ExecuteReader();
            }
        }
        public static void AddOffer(Offer offer)
        {
            InitializeDatabase();

            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                         "ProjectBase.db");
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Offers VALUES (NULL, @Company_Id, @Title, @Description, @Position_name, @Position_level, @Type_of_contract, @Employment, @Type_of_Job, @Salary" +
                    ",                                                  @Days, @Hours, @Expired, @Duties, @Requirements, @Benefits, @Application_Count);";
                insertCommand.Parameters.AddWithValue("@Company_Id", offer.Company_Id);
                insertCommand.Parameters.AddWithValue("@Title", offer.Title);
                insertCommand.Parameters.AddWithValue("@Description", offer.Description);
                insertCommand.Parameters.AddWithValue("@Position_name", offer.Position_name);
                insertCommand.Parameters.AddWithValue("@Position_level", offer.Position_level);
                insertCommand.Parameters.AddWithValue("@Type_of_contract", offer.Type_of_contract);
                insertCommand.Parameters.AddWithValue("@Employment", offer.Employment);
                insertCommand.Parameters.AddWithValue("@Type_of_Job", offer.Type_of_Job);
                insertCommand.Parameters.AddWithValue("@Salary", offer.Salary);
                insertCommand.Parameters.AddWithValue("@Days", offer.Days);
                insertCommand.Parameters.AddWithValue("@Hours", offer.Hours);
                insertCommand.Parameters.AddWithValue("@Expired", offer.Expired);
                insertCommand.Parameters.AddWithValue("@Duties", offer.Duties);
                insertCommand.Parameters.AddWithValue("@Requirements", offer.Requirements);
                insertCommand.Parameters.AddWithValue("@Benefits", offer.Benefits);
                insertCommand.Parameters.AddWithValue("@Application_Count", offer.Application_Count);

                insertCommand.ExecuteReader();
            }

        }
        public static List<Offer> GetOffers()
        {
            List<Offer> entries = new List<Offer>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                         "ProjectBase.db");
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                var selectCommand = new SqliteCommand
                    ("SELECT * from Offers", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    Offer offer = new Offer();
                    offer.Offer_id = query.GetInt32(0);
                    offer.Company_Id = query.GetInt32(1);
                    offer.Title = query.GetString(2);
                    offer.Description = query.GetString(3);
                    offer.Position_name = query.GetString(4);
                    offer.Position_level = query.GetString(5);
                    offer.Type_of_contract = query.GetString(6);
                    offer.Employment = query.GetString(7);
                    offer.Type_of_Job = query.GetString(8);
                    offer.Salary = query.GetString(9);
                    offer.Days = query.GetString(10);
                    offer.Hours = query.GetString(11);
                    offer.Expired = query.GetString(12);
                    offer.Duties = query.GetString(13);
                    offer.Requirements = query.GetString(14);
                    offer.Benefits = query.GetString(15);
                    offer.Application_Count = query.GetInt32(16);

                    entries.Add(offer);
                }
            }

            return entries;
        }
        public static void AddCompanies(Company company)
        {
            InitializeDatabase();

            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                         "ProjectBase.db");
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Companies VALUES (NULL, @Name, @Localization, @Logo, @Description);";
                insertCommand.Parameters.AddWithValue("@Name", company.Name);
                insertCommand.Parameters.AddWithValue("@Localization", company.Localization);
                insertCommand.Parameters.AddWithValue("@Logo", company.Logo);
                insertCommand.Parameters.AddWithValue("@Description", company.Description);

                insertCommand.ExecuteReader();
            }

        }
        public static List<Company> GetCompanies()
        {
            List<Company> entries = new List<Company>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                         "ProjectBase.db");
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                var selectCommand = new SqliteCommand
                    ("SELECT * from Companies", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    Company company = new Company();
                    company.Company_id = query.GetInt32(0);
                    company.Name = query.GetString(1);
                    company.Localization = query.GetString(1);
                    company.Logo = query.GetString(2);
                    company.Description = query.GetString(3);

                    entries.Add(company);
                }
            }

            return entries;
        }
        */
    }
}
