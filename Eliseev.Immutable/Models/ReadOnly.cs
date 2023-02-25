using System.Linq.Expressions;

namespace Eliseev.Immutable.Models
{
    public class ReadOnly<T>
    {
        private readonly T value;

        internal ReadOnly(T value)
        {
            this.value = value;
        }

        public static ReadOnly<TValue> Create<TValue>(TValue source)
            where TValue : class
        {
            return source == null ? null : new ReadOnly<TValue>(source);
        }

        public string GetValue(Func<T, string> selector)
        {
            return InternalGetValue(selector);
        }

        public TValue GetValue<TValue>(Func<T, TValue> selector)
            where TValue : struct
        {
            return InternalGetValue(selector);
        }

        public ReadOnly<TValue> GetRefValue<TValue>(Func<T, TValue> selector)
            where TValue : class
        {
            var result = InternalGetValue(selector);
            return Create(result);
        }

        private TValue InternalGetValue<TValue>(Func<T, TValue> selector)
        {
            return selector.Invoke(value);
        }

        #region override base
        public override string ToString()
        {
            return value.ToString();
        }

        public override bool Equals(object? obj)
        {
            return value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        #endregion
    }
}
