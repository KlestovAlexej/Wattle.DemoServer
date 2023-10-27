using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public static class DomainObjectRegisterExtensions
{
    /// <summary>
    /// Регистрация критической секции доменного объекта при его получении из реестра.
    /// <example>К примеру <seealso cref="IDomainObjectRegister.Find(long)" />.</example>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDomainObjectRegister LockRegister(this IDomainObjectRegister register, long identity)
    {
        if (register == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(register));
        }

        var lockService =
            ((ICustomEntryPoint)((UnitOfWork)register!.UnitOfWorkProvider.Instance).EntryPoint)
            .UnitOfWorkLocks.GetLock(register.TypeId);

        lockService.Register(identity);

        return register;
    }
}
