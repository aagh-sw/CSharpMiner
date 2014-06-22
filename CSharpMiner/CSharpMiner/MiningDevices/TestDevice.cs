﻿using CSharpMiner.Helpers;
using CSharpMiner.Stratum;
using DeviceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MiningDevice
{
    [DataContract]
    public class TestDevice : IMiningDevice
    {
        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "cores")]
        public int Cores { get; set; }

        [IgnoreDataMember]
        public int Id { get; set; }

        [IgnoreDataMember]
        public int HashRate
        {
            get { return 1; }
        }

        [IgnoreDataMember]
        public int HardwareErrors
        {
            get { return 0; }
        }

        public Timer WorkRequestTimer
        {
            get { return new Timer(); }
        }

        public TestDevice(string path, int cores)
        {
            Path = path;
            Cores = cores;
        }

        public void Load(Action<PoolWork, string, int> submitWork, Action<int> requestWork)
        {
            LogHelper.ConsoleLogAsync(string.Format("Loading Miner {0}", Path), LogVerbosity.Verbose);
        }

        public void Unload()
        {
            LogHelper.ConsoleLogAsync(string.Format("Unloading Miner {0}", Path), LogVerbosity.Verbose);
        }

        public void StartWork(PoolWork work)
        {
            LogHelper.ConsoleLogAsync(string.Format("Miner {0} starting work {1} with:", Path, work.JobId), LogVerbosity.Verbose);
            LogHelper.ConsoleLogAsync(string.Format("\tExtranonce2: {0}", work.Extranonce2), LogVerbosity.Verbose);
            LogHelper.ConsoleLogAsync(string.Format("\tStartNonce:  {0}", work.StartingNonce), LogVerbosity.Verbose);
        }

        public void Dispose()
        {
            this.Unload();
        }
    }
}
