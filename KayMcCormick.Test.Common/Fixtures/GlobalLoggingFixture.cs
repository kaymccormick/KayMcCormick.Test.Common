﻿#region header
// Kay McCormick (mccor)
// 
// WpfApp
// Tests
// GlobalLoggingFixture.cs
// 
// 2020-02-06-3:12 AM
// 
// ---
#endregion
using System.Threading.Tasks ;
using JetBrains.Annotations ;
using KayMcCormick.Logging.Common ;
using KayMcCormick.Test.Common.Logging ;
using NLog ;
using Xunit ;
using Xunit.Abstractions ;
using Xunit.Sdk ;

namespace KayMcCormick.Test.Common.Fixtures
{
    /// <summary>Test fixture to supply logging through the IMessageSink available to infrastructure types in Xunit.</summary>
    /// <autogeneratedoc />
    [ UsedImplicitly ]
    public class GlobalLoggingFixture : IAsyncLifetime
    {
        private readonly XunitSinkTarget _xunitSinkTarget ;
        private static readonly Logger          Logger = LogManager.GetCurrentClassLogger ( ) ;

        /// <summary>
        ///     Initializes a new instance of the <see cref="System.Object" />
        ///     class.
        /// </summary>
        public GlobalLoggingFixture ( IMessageSink sink )
        {
            AppLoggingConfigHelper.EnsureLoggingConfigured (
                                                            message => sink.OnMessage (
                                                                                       new DiagnosticMessage (
                                                                                                              message
                                                                                                             )
                                                                                      )
                                                           ) ;

            var l = AppLoggingConfigHelper.SetupJsonLayout ( ) ;

            sink.OnMessage (
                            new DiagnosticMessage ( "Constructing GlobalLoggingFixture." )
                           ) ;
            _xunitSinkTarget = new XunitSinkTarget ( "Xunitsink", sink )
                               {
                                   Layout = l
                               } ;
            AppLoggingConfigHelper.AddTarget ( _xunitSinkTarget, null ) ;
            Logger.Warn ( $"{nameof ( GlobalLoggingFixture)} logger added." ) ;
        }

        // ReSharper disable once IdentifierTypo

        /// <summary>
        /// Called immediately after the class has been created, before it is used.
        /// </summary>
        public Task InitializeAsync ( ) { return Task.CompletedTask ; }

        /// <summary>
        /// Called when an object is no longer needed. Called just before <see cref="System.IDisposable.Dispose"/>
        /// if the class also implements that.
        /// </summary>
        public Task DisposeAsync ( )
        {
            AppLoggingConfigHelper.RemoveTarget ( _xunitSinkTarget.Name ) ;
            return Task.CompletedTask ;
        }
    }
}