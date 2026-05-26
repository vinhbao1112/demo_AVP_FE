using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DeviceNetApp.Lib
{
    public delegate void Action();

    public delegate void Action<TArg1,TArg2>(TArg1 arg1, TArg2 arg2);

    public delegate void Action<TArg1,TArg2,TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3);

    public delegate void Action<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);

    [SuppressMessage("Microsoft.Naming", "CA1704")]
    public delegate T Func<T>();

    [SuppressMessage("Microsoft.Naming", "CA1704")]
    public delegate TReturn Func<TArg1,TReturn>(TArg1 arg1);

    [SuppressMessage("Microsoft.Design", "CA1005")]
    [SuppressMessage("Microsoft.Naming", "CA1704")]
    public delegate TReturn Func<TArg1,TArg2,TReturn>(TArg1 arg1, TArg2 arg2);

    [SuppressMessage("Microsoft.Design", "CA1005")]
    [SuppressMessage("Microsoft.Naming", "CA1704")]
    public delegate TReturn Func<TArg1,TArg2,TArg3,TReturn>(TArg1 arg1, TArg2 arg2, TArg3 arg3);
}
