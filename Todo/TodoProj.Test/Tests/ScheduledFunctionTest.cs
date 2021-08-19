using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TodoProj.Functions.Functions;
using TodoProj.Test.Helpers;
using Xunit;

namespace TodoProj.Test.Tests
{

    public class ScheduledFunctionTest
    {
        [Fact]
        public void ScheduledFunction_Should_Log_Message()
        {
            //arrange
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);

            //act
            ScheduleFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];

            //asert
            Assert.Contains("Deleting completed", message);
        }
    }
}
