using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_quiz
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    

}
class Clock {
    private int milliseconds;
    private int seconds;
    private int minutes;
    private int hours;
    private int days;
    private string elasped_time;

    public Clock()
    {
        milliseconds = 0;
        seconds = 0;
        minutes = 0;
        hours = 0;
        days = 0;
        elasped_time = "";
    }



    public void Start()
    {
        
    }
    public void Stop()
    {
        
    }

    class Task
    {
        public int start_time;
        public int duration;
        public string description;
           
    }
    public void Execute()
    {
    
    }
    class Worker: Task
    {
        public string first_name;
        public string last_name;
        public int id_num;
        public int date_of_birth;
        public char gender;
    }
   
    class Workflow: Clock
    {

    }









}
        
