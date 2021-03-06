﻿#region header
// Kay McCormick (mccor)
// 
// WpfApp
// Tests
// XunitSinkTarget.cs
// 
// 2020-02-06-2:12 AM
// 
// ---
#endregion
using NLog ;
using NLog.Targets ;
using Xunit.Abstractions ;

namespace KayMcCormick.Test.Common.Logging
{
    /// <summary></summary>
    /// <seealso cref="NLog.Targets.TargetWithLayout" />
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for XunitSinkTarget
    [Target ( "Xunit" ) ]
    public class XunitSinkTarget : TargetWithLayout
    {
        private readonly IMessageSink _sink ;

        /// <summary>Initializes a new instance of the <see cref="XunitSinkTarget"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="sink"></param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public XunitSinkTarget ( string name , IMessageSink sink )
        {
            _sink = sink ;
            OptimizeBufferReuse = false ;
            if ( name != null )
            {
                Name = name ;
            }
        }

        /// <summary>
        ///     Writes logging event to the log target. Must be overridden in inheriting
        ///     classes.
        /// </summary>
        /// <param name="logEvent">Logging event to be written out.</param>
        protected override void Write ( LogEventInfo logEvent )
        {
            var logMessage = RenderLogEvent ( Layout , logEvent ) ;


            _sink.OnMessage ( new Xunit.Sdk.DiagnosticMessage ( logMessage ) ) ;
        }

    }
}