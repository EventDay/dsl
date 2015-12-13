using System;

namespace Demo
{
    public static class SystemClock
    {
        private static Func<DateTime> _now = () => DateTime.UtcNow;

        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime UtcNow => _now();

        public static IDisposable Freeze()
        {
            var date = DateTime.UtcNow;
            _now = () => date;
            return new DisposableAction(Resume);
        }

        internal static void Resume()
        {
            _now = () => DateTime.UtcNow;
        }

        public static IDisposable Set(DateTime date)
        {
            _now = () => date;
            return new DisposableAction(Resume);
        }
    }
}