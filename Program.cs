using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
/*
            //bất đồng bộ bắt đầu từ đây
            //var taskStringRet = Task.Run(taskString);
            var taskStringRet = taskString();
            var taskIntRet = taskInt();
            var taskIntRet2 = taskInt2();
            Console.WriteLine("Hello World!");

            //trở lại đồng bộ từ đây  
            var resultString = taskStringRet.Result;

            //check có đúng là chỗ này chờ có kết quả resultString
            //rồi mới thực hiện Console.WriteLine("Waiting 1....") hay là chạy lun.
            if(resultString!=null)
            {
                Console.WriteLine("Waiting 1...."); 
            }
            
            var resultInt2 =  taskIntRet2.Result;
            var resultInt =  taskIntRet.Result;

            Console.WriteLine(resultInt2);
            Console.WriteLine(resultString);
            Console.WriteLine(resultInt);
 */
            for (int i = 0; i < 11; i++)
            {
                var task = new Task(async()=>{
                    var j = i;
                    Console.WriteLine("time {0}",DateTime.Now.Millisecond);
                    await Task.Delay(1000);
                    Console.WriteLine(DateTime.Now.Second);
                });
                task.Start();
            }
            Console.ReadLine();
        }

        private static async Task<string> taskString()
        {
            await Task.Delay(1500);
            return "Finished taskString";
        }

        private static async Task<int> taskInt()
        {
            await Task.Delay(1000);
            return 1;
        }

        private static int returnInt()
        {
            Task.Delay(2000);
            return 2;
        }

        private static async Task<int> taskInt2()
        {
            var returnIntRet = Task.Factory.StartNew(()=>returnInt());
            Console.WriteLine("taskInt2");
            return await returnIntRet;
        }
    }
}
