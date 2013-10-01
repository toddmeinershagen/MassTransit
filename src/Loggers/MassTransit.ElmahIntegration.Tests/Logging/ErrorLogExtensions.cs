// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.ElmahIntegration.Tests.Logging
{
    using System;
    using System.Collections.Generic;
    using Elmah;

    public static class ErrorLogExtensions
    {
        const string BlankError = "_blank";

        public static Error GetFirstError(this ErrorLog errorLog)
        {
            var page = new List<ErrorLogEntry>();

            try
            {
                errorLog.GetErrors(0, 1, page);
                var error = page[0].Error;
                return error.Message == BlankError ? null : error;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Clear(this ErrorLog errorLog)
        {
            var error = new Error { Message = BlankError };
            errorLog.Log(error);
        }
    }
}
