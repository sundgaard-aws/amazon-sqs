namespace Amazon.SQS.Demo
{
    using System;
    using Amazon;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Started!");
            RunSQSDemo().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine("Ended!");
        }

        private static async Task RunSQSDemo()
        {
            var queueService=new QueueService();
            var queueURL=await queueService.GetQueueURL("amazon-sqs-demo");
            await queueService.GetNextMessage(queueURL);
        }
    }
}