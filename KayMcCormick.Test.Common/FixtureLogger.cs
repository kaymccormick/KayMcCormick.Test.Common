﻿using System ;
using KayMcCormick.Logging.Common ;
using NLog ;
using NLog.Fluent ;

namespace KayMcCormick.Test.Common
{
    /// <summary></summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for FixtureLogger
    public static class FixtureLogger
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger ( ) ;
        /// <summary></summary>
        /// <param name="fixtureType"></param>
        /// <param name="lifecycle"></param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for LogFixtureLifecycleEvent
        public static void LogFixtureLifecycleEvent ( Type fixtureType , Lifecycle lifecycle )
        {
            AppLoggingConfigHelper.EnsureLoggingConfigured();
            new LogBuilder ( Logger ).Level(LogLevel.Trace).Message("Fixture lifecycle event for {fixtureType}: {lifecycle}", fixtureType, lifecycle).Write();
        }

        /// <summary>Logs the fixture finalized lifecycle event.</summary>
        /// <param name="fixtureType">Type of the fixture.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for LogFixtureFinalizedLifecycleEvent
        public static void LogFixtureFinalizedLifecycleEvent ( Type fixtureType )
        {
            LogFixtureLifecycleEvent(fixtureType, Lifecycle.Finalized);
        }


        /// <summary>Logs the fixture created lifecycle event.</summary>
        /// <param name="fixtureType">Type of the fixture.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for LogFixtureCreatedLifecycleEvent
        public static void LogFixtureCreatedLifecycleEvent(Type fixtureType)
        {
            LogFixtureLifecycleEvent(fixtureType, Lifecycle.Created);
        }
    }
}