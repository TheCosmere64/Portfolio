#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AIMS.Core.Models;
using SQLite;

#endregion

namespace AIMS.Core.Database
{
    public class Database
    {
        static SQLiteConnection database;

        public Database()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "AIMSDatabase41018.db3");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<ActivityModel>();
            database.CreateTable<UserModel>();
            database.CreateTable<NewsModel>();
            database.CreateTable<EventModel>();
            database.CreateTable<MembershipModel>();
            database.CreateTable<ServiceModel>();
            database.CreateTable<JournalModel>();
            database.CreateTable<AboutUsModel>();
            database.CreateTable<CareerModel>();
        }

        #region ActivityModel

        public int InsertActivity(ActivityModel activity)
        {
            int output = database.Insert(activity);
            return output;
        }

        public void InsertOrUpdateActivity(ActivityModel activity)
        {
            if (database.Table<ActivityModel>().Any(x => x.Id == activity.Id))
            {
                database.Update(activity);
            }
        }

        public void DeleteActivity(int Id)
        {
            database.Delete<ActivityModel>(Id);
        }

        public List<ActivityModel> GetAllActivities()
        {
            var returnValue = database.Table<ActivityModel>().Where(x => x.UserId == currentUserId).ToList();
            returnValue.Reverse();
            return returnValue;
        }

        public ActivityModel GetActivity(int key)
        {
            return database.Table<ActivityModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region UserModel

        private static int? currentUserId = null;

        public int? GetCurrentUserId()
        {
            return currentUserId;
        }

        public int InsertUser(UserModel user)
        {
            int output = database.Insert(user);
            return output;
        }

        public int InsertOrUpdateUser(UserModel user)
        {
            int output;
            if (database.Table<UserModel>().Any(x => x.Id == user.Id))
            {
                output = database.Update(user);
            }
            else
            {
                output = database.Insert(user);
            }

            return output;
        }

        public int DeleteAllUsers()
        {
            int output = database.DeleteAll<UserModel>();
            database.Commit();
            return output;
        }

        public bool CheckUserExists(string email, string password)
        {
            var checker = database.Table<UserModel>()
                .Where(x => x.Email.ToUpper() == email.ToUpper() && x.Password == password).ToList();
            if (checker.Count() <= 0)
            {
                return false;
            }

            currentUserId = checker[0].Id;
            return true;
        }

        public UserModel GetUserByKey(int key)
        {
            return database.Table<UserModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region NewsModel

        public int InsertNews(NewsModel news)
        {
            int output = database.Insert(news);
            return output;
        }

        public void InsertOrUpdateNews(NewsModel news)
        {
            if (database.Table<NewsModel>().Any(x => x.Id == news.Id))
            {
                database.Update(news);
            }
        }

        public void DeleteNews(int Id)
        {
            database.Delete<NewsModel>(Id);
        }

        public int DeleteAllNews()
        {
            int output = database.DeleteAll<NewsModel>();
            database.Commit();
            return output;
        }

        public List<NewsModel> GetAllNews()
        {
            var returnValue = database.Table<NewsModel>().ToList();
            return returnValue;
        }

        public NewsModel GetNews(int key)
        {
            return database.Table<NewsModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region EventModel

        public int InsertEvent(EventModel news)
        {
            int output = database.Insert(news);
            return output;
        }

        public void InsertOrUpdateEvent(EventModel eventItem)
        {
            if (database.Table<EventModel>().Any(x => x.Id == eventItem.Id))
            {
                database.Update(eventItem);
            }
        }

        public void DeleteEvent(int Id)
        {
            database.Delete<EventModel>(Id);
        }

        public int DeleteAllEvents()
        {
            int output = database.DeleteAll<EventModel>();
            database.Commit();
            return output;
        }

        public List<EventModel> GetAllEvents()
        {
            var returnValue = database.Table<EventModel>().Reverse().ToList();
            return returnValue;
        }

        public EventModel GetEvent(int key)
        {
            return database.Table<EventModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region MembershipModel

        public int InsertMembership(MembershipModel membership)
        {
            int output = database.Insert(membership);
            return output;
        }

        public void InsertOrUpdateMembership(MembershipModel membership)
        {
            if (database.Table<MembershipModel>().Any(x => x.Id == membership.Id))
            {
                database.Update(membership);
            }
            else
            {
                database.Insert(membership);
            }
        }

        public void DeleteMembership(int Id)
        {
            database.Delete<MembershipModel>(Id);
        }

        public int DeleteAllMemberships()
        {
            int output = database.DeleteAll<MembershipModel>();
            database.Commit();
            return output;
        }

        public List<MembershipModel> GetAllMemberships()
        {
            var returnValue = database.Table<MembershipModel>().ToList();
            return returnValue;
        }

        public MembershipModel GetMembership(int key)
        {
            return database.Table<MembershipModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region ServiceModel

        public int InsertService(ServiceModel service)
        {
            int output = database.Insert(service);
            return output;
        }

        public void InsertOrUpdateService(ServiceModel service)
        {
            if (database.Table<ServiceModel>().Any(x => x.Id == service.Id))
            {
                database.Update(service);
            }
            else
            {
                database.Insert(service);
            }
        }

        public void DeleteService(int Id)
        {
            database.Delete<ServiceModel>(Id);
        }

        public int DeleteAllServices()
        {
            int output = database.DeleteAll<ServiceModel>();
            database.Commit();
            return output;
        }

        public List<ServiceModel> GetAllServices()
        {
            var returnValue = database.Table<ServiceModel>().ToList();
            return returnValue;
        }

        public ServiceModel GetService(int key)
        {
            return database.Table<ServiceModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region JournalModel

        public int InsertJournal(JournalModel journal)
        {
            int output = database.Insert(journal);
            return output;
        }

        public void InsertOrUpdateJournal(JournalModel journal)
        {
            if (database.Table<JournalModel>().Any(x => x.Id == journal.Id))
            {
                database.Update(journal);
            }
            else
            {
                database.Insert(journal);
            }
        }

        public void DeleteJournal(int Id)
        {
            database.Delete<JournalModel>(Id);
        }

        public int DeleteAllJournals()
        {
            int output = database.DeleteAll<JournalModel>();
            database.Commit();
            return output;
        }

        public List<JournalModel> GetAllJournals()
        {
            var returnValue = database.Table<JournalModel>().ToList();
            return returnValue;
        }

        public JournalModel GetJournal(int key)
        {
            return database.Table<JournalModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region AboutUsModel

        public int InsertAboutUs(AboutUsModel aboutUs)
        {
            int output = database.Insert(aboutUs);
            return output;
        }

        public void InsertOrUpdateAboutUs(AboutUsModel aboutUs)
        {
            if (database.Table<AboutUsModel>().Any(x => x.Id == aboutUs.Id))
            {
                database.Update(aboutUs);
            }
            else
            {
                database.Insert(aboutUs);
            }
        }

        public void DeleteAboutUs(int Id)
        {
            database.Delete<AboutUsModel>(Id);
        }

        public int DeleteAllAboutUs()
        {
            int output = database.DeleteAll<AboutUsModel>();
            database.Commit();
            return output;
        }

        public List<AboutUsModel> GetAllAboutUs()
        {
            var returnValue = database.Table<AboutUsModel>().ToList();
            return returnValue;
        }

        public AboutUsModel GetAboutUs(int key)
        {
            return database.Table<AboutUsModel>().Where(x => x.Id == key).FirstOrDefault();
        }

        #endregion

        #region CareerModel
        public int InsertCareer(AboutUsModel aboutUs)
        {
            int output = database.Insert(aboutUs);
            return output;
        }

        public void InsertOrUpdateCareer(CareerModel career)
        {
            if (database.Table<CareerModel>().Any(x => x.Id == career.Id))
            {
                database.Update(career);
            }
            else
            {
                database.Insert(career);
            }
        }

        public void DeleteCareer(int Id)
        {
            database.Delete<CareerModel>(Id);
        }

        public int DeleteAllCareer()
        {
            int output = database.DeleteAll<CareerModel>();
            database.Commit();
            return output;
        }

        public List<CareerModel> GetAllCareer()
        {
            var returnValue = database.Table<CareerModel>().ToList();
            return returnValue;
        }

        public CareerModel GetCareer(int key)
        {
            return database.Table<CareerModel>().Where(x => x.Id == key).FirstOrDefault();
        }
        #endregion
    }
}