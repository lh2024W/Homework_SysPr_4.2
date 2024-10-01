using System.Reflection.PortableExecutable;

namespace Homework_SysPr_4._2
{
    public class Program
    {
        static void Main()
        {
            //У вас есть консольное приложение, которое имитирует работу печати с несколькими принтерами.
            //Каждый принтер может обрабатывать одно задание за раз, но заданий может быть больше, чем доступных принтеров. 
            //Чтобы предотвратить наложение заданий друг на друга и ограничить количество одновременно обрабатываемых заданий, 
            //вы можете использовать класс Semaphore для синхронизации доступа к принтерам.

            for (int i = 1; i < 9; i++)
            {
                Printer printer = new Printer(i);
            }

            Console.ReadLine();


        }
    }

    class Printer
    {
        // создаем семафор
        Semaphore sem = new Semaphore(1, 1);
        Thread myThread;
        int count = 1;// счетчик чтения

        public Printer(int i)
        {
            myThread = new Thread(PrinterPrint);
            myThread.Name = $"Printer {i.ToString()}";
            myThread.Start();
        }

        public void PrinterPrint()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} Printer work");
                Thread.Sleep(1000);

                sem.Release();

                count--;
                Thread.Sleep(1000);
            }
            
        }
    }
}
