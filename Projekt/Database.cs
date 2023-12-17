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
        static readonly string dbpathOffer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"dbOffers.json");
        static readonly string dbpathCompany = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbCompanies.json");
        static readonly string dbpathUser = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbUsers.json");
        static readonly string dbpathCategory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbCategories.json");

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
    }
}
