using System.Collections.Generic;

namespace DafWarden.Domain;

public class Password
{
    public IList<PasswordFragment> PasswordFragments { get; private set; } = Enumerable<PasswordFragment>.Empty();
}
