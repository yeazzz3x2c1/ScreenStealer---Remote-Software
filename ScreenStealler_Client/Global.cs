using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenStealler_Client
{
    internal class Global
    {
        public delegate void On_ID_Set_Handler(long ID);
        public static event On_ID_Set_Handler On_ID_Set;

        private static long ID = 0;
        private static TaskScheduler? Scheduler;
        public static void Set_Task_Scheduler(TaskScheduler Scheduler) => Global.Scheduler = Scheduler;


        public static long Get_ID() => ID;
        public static void Set_ID(long ID)
        {
            Global.ID = ID;
            if(Scheduler != null)
                new Task(() =>
                {
                    On_ID_Set?.Invoke(ID);
                }).Start(Scheduler);
        }
    }
}
