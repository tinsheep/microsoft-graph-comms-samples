// <copyright file="CommonUtilities.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Sample.Common
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Graph.Communications.Common.Telemetry;

    /// <summary>
    /// The utility class.
    /// </summary>
    public static class CommonUtilities
    {
        /// <summary>
        /// Extension for Task to execute the task in background and log any exception.
        /// </summary>
        /// <param name="task">Task to execute and capture any exceptions.</param>
        /// <param name="logger">Graph logger.</param>
        /// <param name="description">Friendly description of the task for debugging purposes.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ForgetAndLogExceptionAsync(this Task task, IGraphLogger logger, string description = null)
        {
            try
            {
                await task.ConfigureAwait(false);
                logger?.Verbose($"Completed running task successfully: {description ?? string.Empty}");
            }
            catch (Exception e)
            {
                // Log and absorb all exceptions here.
                logger?.Error(e, $"Caught an Exception running the task: {description ?? string.Empty} {e.Message}\n StackTrace: {e.StackTrace}");
            }
        }
    }
}
