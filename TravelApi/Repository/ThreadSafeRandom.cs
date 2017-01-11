﻿using System;
using System.Threading;

namespace TravelApi.Repository
{
   internal static class ThreadSafeRandom
   {
      [ThreadStatic]
      private static Random _local;

      public static Random ThisThreadsRandom => _local ?? (_local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
   }
}