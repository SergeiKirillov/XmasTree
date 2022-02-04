using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


class Task
{
    //CREATE TABLE "Task" ("id"	INTEGER NOT NULL UNIQUE, "dtTask" TEXT NOT NULL, "strTask" TEXT NOT NULL, "blStatus" BLOB, "Categoria" INTEGER NOT NULL,"Repeat" INTEGER, PRIMARY KEY("id" AUTOINCREMENT))
    //TODO https://metanit.com/sharp/adonetcore/4.2.php
    private string datetimetTask;
    private string stringTask;
    private bool boolStatus;
    private string strCategoria;
    

    public int Id{ get; set; }

    public string dtTask
    {
        get { return datetimetTask; }

        set { datetimetTask = value; }
    }

    public string strTask
    {
        get { return stringTask; }
        set { stringTask = value; }
    }

    public bool blStatus
    {
        get { return boolStatus; }
        set { boolStatus = value; }
    }

    public string Categoria
    {
        get { return strCategoria; }
        set { strCategoria = value; }
    }

   

    public bool SaveNewTask()
    {
        try
        {
            using (var connection = new SQLiteConnection("Data Source = TaskDB.db"))
            {
                connection.Open();

                //datetimetTask="11";
                //stringTask="test";
                //boolStatus=false;
                //intCategoria=1;
                //intRepeat=1;

                string sqlExpression = $"INSERT INTO Tasks (dtTask,strTask,blStatus,Categoria) VALUES ('{datetimetTask}', '{stringTask}', {boolStatus}, '{strCategoria}')";


                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                //Console.WriteLine($"Добавлено объектов: {number}");

                if (number>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            

            


        }
        catch (Exception)
        {

            return false;
        }
    }

}
