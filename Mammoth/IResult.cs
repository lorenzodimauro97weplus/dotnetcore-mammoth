using System.Collections.Generic;

namespace Mammoth {
    public interface IResult<out T> {
        T Value { get; }
        ISet<string> Warnings { get; }
    }
}
