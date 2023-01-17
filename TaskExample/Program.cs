namespace TaskExample
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var task = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Tarea interna de Task");

            });
            task.Start();

            var task2 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Tarea interna de Task 2");

            });

            Console.WriteLine("Hago algo más...");

            task2.Start();

            await task2;
            await task; //No se ejecuta otra instrucción hasta que termine su ejecuciónel task

            int resultadoRandom = await numerosRandomAsync();
            int resultado = await MulNumAsync(resultadoRandom);

            Console.WriteLine($"Número aleatorio = {resultadoRandom}");
            Console.WriteLine($"{resultadoRandom} * {resultadoRandom} = {resultado}");

            Console.WriteLine("He terminado la tarea");

            Console.ReadLine();
        }


        public static async Task<int> numerosRandomAsync()
        {

            var task = new Task<int>(() => new Random().Next(100));
            task.Start();
            int resultado = await task;

            return resultado;
        }

        public static async Task<int> MulNumAsync(int num)
        {

            var task = new Task<int>(() => num * num);
            task.Start();
            int resultado = await task;

            return resultado;
        }

    }
}