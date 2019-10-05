using System;
using System.Collections.Generic;
using System.Text;

namespace RPNRadio.Core
{
    public class AppSettings
    {
        public static readonly string AppName = "RPN News & Radio";
        public static readonly string AppIdentifier = "xyz.reddvid.rpnradio";

        public static readonly string AndroidAppcenterSecret = "APP_SECRET_ANDROID";
        public static readonly string IosAppcenterSecret = "APP_SECRET_IOS";
        public static readonly string UwpAppcenterSecret = "APP_SECRET_UWP";

        public static readonly string[] AppLanguages = { "en" /*, "nl"*/ };
        public static readonly string DefaultAppLanguage = "en";

        // Cache specific settings
        public static readonly TimeSpan DefaultCacheExpiryTimeSpan = TimeSpan.FromDays(7);
        public static readonly TimeSpan DefaultShortCacheExpiryTimeSpan = TimeSpan.FromMinutes(15);
        public static readonly TimeSpan DefaultDayCacheExpiryTimeSpan = TimeSpan.FromDays(1);
        public static readonly TimeSpan DefaultLongCacheExpiryTimeSpan = TimeSpan.FromDays(30);
        public static readonly TimeSpan DefaultInfiniteCacheExpiryTimeSpan = TimeSpan.FromDays(365);

        // Text Provider settings
        public static readonly string TextProviderNamespace = "RPNRadio.Core";
        public static readonly string TextProviderSharedTypeKey = "Shared";
    }
}
