namespace Amazon.SQS.Demo
{
    using System;
    using Amazon;
    using Amazon.SQS.Model;

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
            await queueService.PutMessage(queueURL, new Trade{TradeAmount=600000*new Random().Next(), TradeDate=DateTime.Now, TradeGUID=Guid.NewGuid().ToString()});
            var messages=await queueService.GetNextMessages(queueURL, 4);
            foreach(var message in messages) {
                // Process message
                // Delete on success
                queueService.DeleteMessage(queueURL, message.ReceiptHandle);
            }
        }
    }
}