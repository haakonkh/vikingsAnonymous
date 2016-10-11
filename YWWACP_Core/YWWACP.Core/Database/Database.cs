using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.Database
{
    /// <summary>
    /// Validation in all CheckIfExists must be fixed to check else than Pkeys
    /// ALL get-methodes returns a list with the the all myTable contents
    /// </summary>
    public class DatabaseTables : IDatabase
    {
        private SQLiteConnection database;
        
        public DatabaseTables()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<MyTable>();
            /* database.CreateTable<User>();
             database.CreateTable<Threads>();
             database.CreateTable<Comments>();
             database.CreateTable<Comment>();
             database.CreateTable<Diary>();
             database.CreateTable<Day>();
             database.CreateTable<HealthPlan>();
             database.CreateTable<Meal>();
             database.CreateTable<Exercise>();*/
        }

        public async Task<IEnumerable<MyTable>> GetTable()
        {
            return database.Table<MyTable>().ToList();
        }

        public async Task<int> DeleteTableRow(object id)
        {
            return database.Delete<MyTable>(id);

        }

        public async Task<int> InsertTableRow(MyTable tablerow)
        {
            var num = database.Insert(tablerow);
            database.Commit();
            return num;
        }

        public async Task<bool> CheckIfExists(MyTable myTable)
        {
            var exists = database.Table<MyTable>()
                .Any(x => x.Id == myTable.Id);
            return exists;
        }

        /*
public IEnumerable<User> GetUsers()
{
   return database.MyTable<User>().ToList();
}

/// <summary>
/// Deletes the user with id 
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteUser (int id)
{
   return database.Delete<User>(id);
}

/// <summary>
/// Inserts a new user
/// </summary>
/// <param name="user"></param>
/// <returns></returns>
public int InsertUser(User user)
{
   var num = database.Insert(user);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if user exists
/// </summary>
/// <param name="user"></param>
/// <returns></returns>
public bool CheckIfUserExists(User user)
{
   var exists = database.MyTable<User>()
   .Any(x => x.Id == user.Id); 
   return exists;
}


public IEnumerable<Threads> GetThreads()
{
   return database.MyTable<Threads>().ToList();
}

/// <summary>
/// Delete entiere thread with that id
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteThread(int id)
{
   return database.Delete<Threads>(id);
}

/// <summary>
/// Inserts a new thread
/// </summary>
/// <param name="thread"></param>
/// <returns></returns>
public int InsertThread(Threads thread)
{
   var num = database.Insert(thread);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if thread allready exists
/// </summary>
/// <param name="thread"></param>
/// <returns></returns>
public bool CheckIfThreadExists(Threads thread)
{
   var exists = database.MyTable<Threads>()
   .Any(x => x.Id == thread.Id);  
   return exists;
}



public IEnumerable<Comments> GetComments()
{
   return database.MyTable<Comments>().ToList();
}
/// <summary>
/// This will delete all comments on a thread
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteComments(int id)  
{
   return database.Delete<Comments>(id);
}

/// <summary>
/// This will instert a comments area on a thread, not produce any comments
/// </summary>
/// <param name="comments"></param>
/// <returns></returns>
public int InsertComments(Comments comments)
{
   var num = database.Insert(comments);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if there exist any comments to a thread
/// </summary>
/// <param name="comments"></param>
/// <returns></returns>
public bool CheckIfCommentsExists(Comments comments)
{
   var exists = database.MyTable<Comments>()
   .Any(x => x.Id == comments.Id);  
   return exists;
}


public IEnumerable<Comment> GetComment()
{
   return database.MyTable<Comment>().ToList();
}

/// <summary>
/// This will delete one comment on a thread
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteComment(int id)
{
   return database.Delete<Comments>(id);
}

/// <summary>
/// This will instert one comment on a thread/comments areas
/// </summary>
/// <param name="comment"></param>
/// <returns></returns>
public int InsertComment(Comment comment)
{
   var num = database.Insert(comment);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if this specific comment exist
/// </summary>
/// <param name="comment"></param>
/// <returns></returns>
public bool CheckIfCommentExists(Comment comment)
{
   var exists = database.MyTable<Comment>()
   .Any(x => x.Id == comment.Id);
   return exists;
}

public IEnumerable<Diary> GetDiary()
{
   return database.MyTable<Diary>().ToList();
}

/// <summary>
/// This will delete entire diary with that id
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteDiary(int id)
{
   return database.Delete<Diary>(id);
}

/// <summary>
/// This will instert a new diary
/// </summary>
/// <param name="diary"></param>
/// <returns></returns>
public int InsertDiary(Diary diary)
{
   var num = database.Insert(diary);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if the diary exsists
/// </summary>
/// <param name="diary"></param>
/// <returns></returns>
public bool CheckIfDiaryExists(Diary diary)
{
   var exists = database.MyTable<Diary>()
   .Any(x => x.Id == diary.Id);
   return exists;
}


public IEnumerable<Day> GetDay()
{
   return database.MyTable<Day>().ToList();
}

/// <summary>
/// This will delete one entire day from the diary
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteDay(int id)
{
   return database.Delete<Day>(id);
}

/// <summary>
/// This will instert a new day to the diary
/// </summary>
/// <param name="day"></param>
/// <returns></returns>
public int InsertDay(Day day)
{
   var num = database.Insert(day);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if the day exists
/// </summary>
/// <param name="day"></param>
/// <returns></returns>
public bool CheckIfDayExists(Day day)
{
   var exists = database.MyTable<Day>()
   .Any(x => x.Id == day.Id);
   return exists;
}


public IEnumerable<HealthPlan> GetHealthPlan()
{
   return database.MyTable<HealthPlan>().ToList();
}

/// <summary>
/// This will delete entiere Health Plan
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteHealthPlan(int id)
{
   return database.Delete<HealthPlan>(id);
}

/// <summary>
/// This will instert a new health plan
/// </summary>
/// <param name="healthPlan"></param>
/// <returns></returns>
public int InsertHealthPlan(HealthPlan healthPlan)
{
   var num = database.Insert(healthPlan);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if there exist any comments to a thread
/// </summary>
/// <param name="healthPlan"></param>
/// <returns></returns>
public bool CheckIfHealthPlanExists(HealthPlan healthPlan)
{
   var exists = database.MyTable<HealthPlan>()
   .Any(x => x.Id == healthPlan.Id);
   return exists;
}

public IEnumerable<Meal> GetMeal()
{
   return database.MyTable<Meal>().ToList();
}

/// <summary>
/// This will delete one meal
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeleteMeal(int id)
{
   return database.Delete<Meal>(id);
}

/// <summary>
/// This will instert a meal
/// </summary>
/// <param name="meal"></param>
/// <returns></returns>
public int InsertMeal(Meal meal)
{
   var num = database.Insert(meal);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if the meal exists 
/// </summary>
/// <param name="meal"></param>
/// <returns></returns>
public bool CheckIMealExists(Meal meal)
{
   var exists = database.MyTable<Meal>()
   .Any(x => x.Id == meal.Id);
   return exists;
}

public IEnumerable<Exercise> GetExercise()
{
   return database.MyTable<Exercise>().ToList();
}
/// <summary>
/// This will delete all comments on a thread
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public int DeletExercise(int id)
{
   return database.Delete<Exercise>(id);
}

/// <summary>
/// This will instert a new exercise
/// </summary>
/// <param name="exercise"></param>
/// <returns></returns>
public int InsertExercise(Exercise exercise)
{
   var num = database.Insert(exercise);
   database.Commit();
   return num;
}

/// <summary>
/// Checks if the exercise exists
/// </summary>
/// <param name="exercise"></param>
/// <returns></returns>
public bool CheckIfExerciseExists(Exercise exercise)
{
   var exists = database.MyTable<Exercise>()
   .Any(x => x.Id == exercise.Id);
   return exists;
}
*/
    }
}
