using System;

namespace PeriodLibrary
{
    /// <summary>
    /// Represents a period in time.
    /// </summary>
    public struct Period : IEquatable<Period>
    {
        /// <summary>
        /// Instantiates a new period based on the given start and end dates.!
        // </summary>
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }
        public DateTime End { get; }

        public override string ToString() {
            return $"{Start: dd-MM-yyyy} to {End: dd-MM-yyyy}";
        }

        public override int GetHashCode(){
            return Start.GetHashCode() * 32 ^ End.GetHashCode() * 332;
        }

        public override bool Equals(object obj) {
            if (obj == null) { return false; }
            if (typeof(Period) != obj.GetType()) { return false; }
            return Equals((Period)obj);
        }

        public bool Equals(Period other)
        {
            return Start == other.Start && End == other.End;
        }
    }
}
