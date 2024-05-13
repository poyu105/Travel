/*using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

public class CustomUserManager<TUser>(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger) : UserManager<TUser>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) where TUser : class
{
    private readonly ILookupProtectorKeyRing _keyRing;
    private readonly ILookupProtector _protector;

    /*
    public CustomUserManager(IUserStore<TUser> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<TUser> passwordHasher,
        IEnumerable<IUserValidator<TUser>> userValidators,
        IEnumerable<IPasswordValidator<TUser>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager<TUser>> logger,
        ILookupProtectorKeyRing keyRing,
        ILookupProtector protector)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _keyRing = keyRing;
        _protector = protector;
    }
    
    public override async Task<TUser?> FindByNameAsync(string userName)
    {
        ThrowIfDisposed();
        if (userName == null)
        {
            throw new ArgumentNullException(nameof(userName));
        }
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!EWUE(AIWFHDAOLSFBAIOWLFGHBIWAOPLFGHBWAIOLFGHBAWIOL\n\n\n\n\n");
        // Avoid normalization of userName
        var user = await Store.FindByNameAsync(userName, CancellationToken).ConfigureAwait(false);

        // Need to potentially check all keys
        if (user == null && Options.Stores.ProtectPersonalData)
        {
            if (_keyRing != null && _protector != null)
            {
                foreach (var key in _keyRing.GetAllKeyIds())
                {
                    var oldKey = _protector.Protect(key, userName);
                    user = await Store.FindByNameAsync(oldKey, CancellationToken).ConfigureAwait(false);
                    if (user != null)
                    {
                        return user;
                    }
                }
            }
        }
        return user;
    }
}
*/