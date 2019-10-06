using MediaManager.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPNRadio.Core.Services
{
    public interface IBrowseService
    {
        Task<IList<IMediaItem>> GetMedia();
    }
}
