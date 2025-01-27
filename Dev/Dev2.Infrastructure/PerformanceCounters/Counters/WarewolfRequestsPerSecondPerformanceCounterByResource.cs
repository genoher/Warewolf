#pragma warning disable
﻿using System;
using System.Collections.Generic;
using Dev2.Common;
using Dev2.Common.Interfaces.Monitoring;

namespace Dev2.PerformanceCounters.Counters
{
    public class WarewolfRequestsPerSecondPerformanceCounterByResource : MyPerfCounter, IResourcePerformanceCounter
    {
        System.Diagnostics.Stopwatch _stopwatch;


        const WarewolfPerfCounterType _perfCounterType = WarewolfPerfCounterType.RequestsPerSecond;
        public WarewolfRequestsPerSecondPerformanceCounterByResource(Guid resourceId, string categoryInstanceName, IRealPerformanceCounterFactory performanceCounterFactory)
            :base(performanceCounterFactory)
        {
            ResourceId = resourceId;
            CategoryInstanceName = categoryInstanceName;
            IsActive = true;
        }

        public void Setup()
        {


            if (_counter == null)
            {
                _stopwatch = new System.Diagnostics.Stopwatch();
                _stopwatch.Start();
                _counter = _counterFactory.New(GlobalConstants.WarewolfServices, Name, CategoryInstanceName);
            }
        }
        public void Reset()
        {
            if (_counter != null)
            {
                _counter.RawValue = 0;
            }
        }
        #region Implementation of IPerformanceCounter

        public void Increment()
        {
            if (IsActive)
            {
                _counter.Increment();
            }
        }

        public void IncrementBy(long ticks)
        {
            if (IsActive)
            {
                _counter.IncrementBy(ticks);
            }
        }

        public void Decrement()
        {
            if (IsActive)
            {

                _counter.Decrement();
            }
        }

        public string Category => GlobalConstants.WarewolfServices;

        public string Name => "Request Per Second";

        public WarewolfPerfCounterType PerfCounterType => _perfCounterType;

        public IEnumerable<(string CounterName, string CounterHelp, PerformanceCounterType CounterType)> CreationData()
        {
            yield return 
            (
                Name,
                Name,
                PerformanceCounterType.RateOfCountsPerSecond32
            );
        }

        #endregion

        #region Implementation of IResourcePerformanceCounter

        public Guid ResourceId { get; private set; }
        public string CategoryInstanceName { get; private set; }

        #endregion
    }
}