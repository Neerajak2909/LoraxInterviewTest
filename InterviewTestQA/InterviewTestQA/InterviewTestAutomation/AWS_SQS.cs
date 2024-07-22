using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace InterviewTestQA.InterviewTestAutomation
{
    internal class AWS_SQS
    {
        private static readonly string ServiceURL = "http://localhost:4566"; // LocalStack SQS endpoint
        private static readonly string QueueName = "MyTestQueue";
        private static string QueueUrl = "";

        public static async Task Main(string[] args)
        {
            try
            {
                var credentials = new BasicAWSCredentials("fake-access-key", "fake-secret-key");
                var sqsClient = new AmazonSQSClient(credentials, new AmazonSQSConfig
                {
                    ServiceURL = ServiceURL
                });

                Console.WriteLine("Creating queue...");
                await CreateQueueAsync(sqsClient);

                Console.WriteLine("Getting queue URL...");
                QueueUrl = await GetQueueUrlAsync(sqsClient, QueueName);
                Console.WriteLine($"Queue URL: {QueueUrl}");

                // Send a message to the SQS queue
                string messageBody = "Hi, this is a test message!";
                await SendMessageAsync(sqsClient, QueueUrl, messageBody);

                // Receive the message from the SQS queue
                var receivedMessage = await ReceiveMessageAsync(sqsClient, QueueUrl);

                if (receivedMessage.HasMessage)
                {
                    Console.WriteLine($"Message received with ID: {receivedMessage.MessageId}");
                    Console.WriteLine($"Message body: {receivedMessage.Body}");

                    // Verify that the received message matches the sent message
                    if (receivedMessage.Body == messageBody)
                    {
                        Console.WriteLine("Test Passed: The received message matches the sent message.");
                    }
                    else
                    {
                        Console.WriteLine("Test Failed: The received message does not match the sent message.");
                    }

                    // Delete the message from the queue
                    await DeleteMessageAsync(sqsClient, QueueUrl, receivedMessage.ReceiptHandle);
                    Console.WriteLine("Message deleted from the queue.");
                }
                else
                {
                    Console.WriteLine("No messages received from the queue.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static async Task CreateQueueAsync(IAmazonSQS sqsClient)
        {
            await sqsClient.CreateQueueAsync(new CreateQueueRequest
            {
                QueueName = QueueName
            });
        }

        private static async Task<string> GetQueueUrlAsync(IAmazonSQS sqsClient, string queueName)
        {
            var response = await sqsClient.GetQueueUrlAsync(new GetQueueUrlRequest
            {
                QueueName = queueName
            });
            return response.QueueUrl;
        }

        private static async Task SendMessageAsync(IAmazonSQS sqsClient, string queueUrl, string messageBody)
        {
            await sqsClient.SendMessageAsync(new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = messageBody
            });
        }

        private static async Task<MessageResult> ReceiveMessageAsync(IAmazonSQS sqsClient, string queueUrl)
        {
            var response = await sqsClient.ReceiveMessageAsync(new ReceiveMessageRequest
            {
                QueueUrl = queueUrl,
                MaxNumberOfMessages = 1,
                WaitTimeSeconds = 5
            });

            if (response.Messages.Count == 0)
            {
                return new MessageResult { HasMessage = false };
            }

            var message = response.Messages[0];
            return new MessageResult
            {
                HasMessage = true,
                MessageId = message.MessageId,
                Body = message.Body,
                ReceiptHandle = message.ReceiptHandle
            };
        }

        private static async Task DeleteMessageAsync(IAmazonSQS sqsClient, string queueUrl, string receiptHandle)
        {
            await sqsClient.DeleteMessageAsync(new DeleteMessageRequest
            {
                QueueUrl = queueUrl,
                ReceiptHandle = receiptHandle
            });
        }

        public class MessageResult
        {
            public bool HasMessage { get; set; }
            public string MessageId { get; set; }
            public string Body { get; set; }
            public string ReceiptHandle { get; set; }
        }
    }
}
