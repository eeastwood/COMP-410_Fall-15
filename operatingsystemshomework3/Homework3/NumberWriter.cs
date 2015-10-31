using System;
using System.Collections.Generic;
using System.IO;

namespace Homework3 {
    internal class NumberWriter : IDisposable {
        private readonly TextWriter _writer;
        private RwLock _wlock = new RwLock();

        public NumberWriter(FileInfo file) {
            if (File.Exists(file.FullName)) {
                File.Delete(file.FullName);
            }
            _writer = new StreamWriter(new BufferedStream(new FileStream(
                file.FullName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, FileOptions.SequentialScan)));
        }

        public void WriteIntegers(IEnumerable<long> values) {
            _wlock.WriteLock();
            foreach (var value in values) {                             //critical section
                _writer.WriteLine(value);
            }
            _wlock.WriteUnLock();
        }

        public void Dispose() {
            _writer.Dispose();
        }
    }
}